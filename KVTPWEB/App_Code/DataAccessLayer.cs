using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using System.Configuration;

public class DataAccessLayer
{
    //public DataAccessLayer(){}
    public GraphDataList GetGraphData(string graphName, int type, int inst_id, string from, string to, int cat, string group)//, int sess
    {
        GraphData graphData = null;
        GraphDataList GraphDataList = new GraphDataList();
        GraphDataList.ListOfGraphData = new List<GraphData>();
        string st = "";
        try
        {
            using (var con = new SqlConnection(ConfigurationManager.AppSettings["con"]))
            {
                con.Open();
                if (graphName == "donut")
                {
                    SqlCommand cmd = new SqlCommand(@"SELECT ISNULL(SUM(tbl_bill.round_off), 0) AS net_amt, tbl_registration.com_name
                                                        FROM  tbl_bill INNER JOIN  tbl_registration ON tbl_bill.inst_id = tbl_registration.inst_id
                                                        WHERE (CAST(tbl_bill.bill_date AS date) >= CAST(DATEADD(day, -30, getdate()) AS date))
                                                        GROUP BY tbl_registration.com_name", con);
                    SqlDataAdapter SqlDadp = new SqlDataAdapter(cmd);

                    cmd.CommandType = CommandType.Text;

                    using (IDataReader dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            graphData = new GraphData();
                            graphData.label = Convert.ToString(dataReader["com_name"].ToString());
                            graphData.value = Convert.ToString(dataReader["net_amt"].ToString());
                            GraphDataList.ListOfGraphData.Add(graphData);
                        }
                        dataReader.Close();
                    }
                }
                if (graphName == "bar")
                {
                    SqlCommand cmd = new SqlCommand(@"", con);
                    SqlDataAdapter SqlDadp = new SqlDataAdapter(cmd);
                    using (IDataReader dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            graphData = new GraphData();
                            graphData.label = Convert.ToString(dataReader["refer_by"].ToString());
                            graphData.value = Convert.ToString(dataReader["total"].ToString());
                            GraphDataList.ListOfGraphData.Add(graphData);
                        }
                        dataReader.Close();
                    }
                }
                if (graphName == "line")
                {
                    SqlCommand cmd = new SqlCommand(@"", con);
                    SqlDataAdapter SqlDadp = new SqlDataAdapter(cmd);
                    cmd.CommandType = CommandType.Text;
                    using (IDataReader dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            graphData = new GraphData();
                            graphData.label = Convert.ToString(dataReader["date"].ToString());
                            graphData.value = Convert.ToString(dataReader["total"].ToString());
                            graphData.fee = Convert.ToString(dataReader["fee"].ToString());
                            GraphDataList.ListOfGraphData.Add(graphData);
                        }
                        dataReader.Close();
                    }
                }

                if (graphName == "area")
                {
                    if (type == 1)
                    {
                        st = "";
                        if (inst_id == 0)
                        {
                            st = @"SELECT bill_date, CONVERT(numeric, SUM(CASE inst_id WHEN 1 THEN net_amt ELSE 0 END)) AS 'Peoples pub', CONVERT(numeric, SUM(CASE inst_id WHEN 2 THEN net_amt ELSE 0 END)) AS 'Bubbles bite', 
                                   CONVERT(numeric, SUM(CASE inst_id WHEN 3 THEN net_amt ELSE 0 END)) AS 'Mayuri Dhammanagi', CONVERT(numeric, SUM(CASE inst_id WHEN 4 THEN net_amt ELSE 0 END)) AS 'Hubli Dhammanagi'
                                    FROM (SELECT DISTINCT dbo.tbl_bill.bill_id, dbo.tbl_bill.round_off AS net_amt, CONVERT(varchar, dbo.tbl_bill.bill_date, 103) AS bill_date, dbo.tbl_bill.bill_date AS date, dbo.tbl_bill.inst_id
                                    FROM dbo.tbl_bill INNER JOIN dbo.tbl_registration ON dbo.tbl_bill.inst_id = dbo.tbl_registration.inst_id INNER JOIN
                                    dbo.tbl_salesdetails ON dbo.tbl_bill.bill_id = dbo.tbl_salesdetails.bill_id AND dbo.tbl_bill.inst_id = dbo.tbl_salesdetails.inst_id";
                            if (from != "" && to != "")
                            {
                                st += "  WHERE (CAST(dbo.tbl_bill.bill_date AS date) >= CONVERT(date,'" + from + "',103)) and(CAST(dbo.tbl_bill.bill_date AS date) <= CONVERT(date,'" + to + "',103)) ) AS dd";
                            }
                            else
                            {
                                st += " WHERE (CAST(dbo.tbl_bill.bill_date AS date) >= CAST(DATEADD(day, - 30, GETDATE()) AS date)) ) AS dd";
                            }
                            st += " GROUP BY bill_date, CAST(date AS date)  ORDER BY CAST(date AS date)";
                        }
                        else
                        {
                            st = "";
                            if (cat > 0)
                            {
                                if (group != "")
                                {
                                    st = @"SELECT bill_date,SUM(net_amt) as net_amt,inst_id,cat,item_group from
                                            (SELECT DISTINCT dbo.tbl_bill.bill_id, dbo.tbl_bill.round_off AS net_amt, CONVERT(varchar, dbo.tbl_bill.bill_date, 103) AS bill_date, dbo.tbl_bill.bill_date AS date, dbo.tbl_bill.inst_id,dbo.item_master.cat,item_master.item_group
                                            FROM dbo.item_master INNER JOIN dbo.tbl_bill INNER JOIN dbo.tbl_registration ON dbo.tbl_bill.inst_id = dbo.tbl_registration.inst_id INNER JOIN
                                            dbo.tbl_salesdetails ON dbo.tbl_bill.bill_id = dbo.tbl_salesdetails.bill_id AND dbo.tbl_bill.inst_id = dbo.tbl_salesdetails.inst_id ON 
                                            dbo.item_master.inst_id = dbo.tbl_salesdetails.inst_id AND dbo.item_master.item_no = dbo.tbl_salesdetails.item_no";
                                    if (from != "" && to != "")
                                    {
                                        st += " WHERE (CAST(dbo.tbl_bill.bill_date AS date) >= CONVERT(date,'" + from + "',103)) and  (CAST(dbo.tbl_bill.bill_date AS date) <= convert(date,'" + to + "',103))) as dd";
                                    }
                                    else
                                    {
                                        st += "  WHERE (CAST(dbo.tbl_bill.bill_date AS date) >= CAST(DATEADD(day, - 30, GETDATE()) AS date)))as dd ";
                                    }
                                    st += " where inst_id=" + inst_id + " and cat=" + cat + " and item_group='" + group + "'";
                                    st += " GROUP BY bill_date, CAST(date AS date),inst_id,cat,item_group  ORDER BY CAST(date AS date)";
                                }
                                else
                                {
                                    st = @"SELECT bill_date,SUM(net_amt) as net_amt,inst_id,cat from
                                        (SELECT DISTINCT dbo.tbl_bill.bill_id, dbo.tbl_bill.round_off AS net_amt, CONVERT(varchar, dbo.tbl_bill.bill_date, 103) AS bill_date, dbo.tbl_bill.bill_date AS date, dbo.tbl_bill.inst_id,dbo.item_master.cat
                                        FROM dbo.item_master INNER JOIN
                                             dbo.tbl_bill INNER JOIN
                                             dbo.tbl_registration ON 
                                             dbo.tbl_bill.inst_id = dbo.tbl_registration.inst_id INNER JOIN
                                             dbo.tbl_salesdetails ON 
                                             dbo.tbl_bill.bill_id = dbo.tbl_salesdetails.bill_id AND dbo.tbl_bill.inst_id = dbo.tbl_salesdetails.inst_id ON 
                                             dbo.item_master.inst_id = dbo.tbl_salesdetails.inst_id AND dbo.item_master.item_no = dbo.tbl_salesdetails.item_no";
                                    if (from != "" && to != "")
                                    {
                                        st += " WHERE (CAST(dbo.tbl_bill.bill_date AS date) >= CONVERT(date,'" + from + "',103)) and  (CAST(dbo.tbl_bill.bill_date AS date) <= convert(date,'" + to + "',103))) as dd";
                                    }
                                    else
                                    {
                                        st += "  WHERE (CAST(dbo.tbl_bill.bill_date AS date) >= CAST(DATEADD(day, - 30, GETDATE()) AS date)))as dd ";
                                    }
                                    st += " where inst_id=" + inst_id + " and cat=" + cat + " ";
                                    st += "  GROUP BY bill_date, CAST(date AS date),inst_id,cat ORDER BY CAST(date AS date)";
                                }
                            }
                            else
                            {
                                st = "";
                                st = @"SELECT bill_date,SUM(net_amt) as net_amt,inst_id from
                                            (SELECT DISTINCT dbo.tbl_bill.bill_id, dbo.tbl_bill.round_off AS net_amt, CONVERT(varchar, dbo.tbl_bill.bill_date, 103) AS bill_date, dbo.tbl_bill.bill_date AS date, dbo.tbl_bill.inst_id
                                            FROM  dbo.item_master INNER JOIN
                                                  dbo.tbl_bill INNER JOIN
                                                  dbo.tbl_registration ON dbo.tbl_bill.inst_id = dbo.tbl_registration.inst_id INNER JOIN
                                                  dbo.tbl_salesdetails ON dbo.tbl_bill.bill_id = dbo.tbl_salesdetails.bill_id AND dbo.tbl_bill.inst_id = dbo.tbl_salesdetails.inst_id ON 
                                                  dbo.item_master.inst_id = dbo.tbl_salesdetails.inst_id AND dbo.item_master.item_no = dbo.tbl_salesdetails.item_no";
                                if (from != "" && to != "")
                                {
                                    st += " WHERE (CAST(dbo.tbl_bill.bill_date AS date) >= CONVERT(date,'" + from + "',103)) and  (CAST(dbo.tbl_bill.bill_date AS date) <= convert(date,'" + to + "',103))) as dd";
                                }
                                else
                                {
                                    st += "  WHERE (CAST(dbo.tbl_bill.bill_date AS date) >= CAST(DATEADD(day, - 30, GETDATE()) AS date)))as dd ";
                                }
                                st += " where inst_id=" + inst_id + " ";
                                st += "  GROUP BY bill_date, CAST(date AS date),inst_id ORDER BY CAST(date AS date)";

                            }

                        }
                    }
                    else if (type == 2)
                    {
                        st = "";
                        if (inst_id == 0)
                        {
                            st = @"SELECT CONVERT(varchar, tbl_purchase.bill_date, 103) AS bill_date, CONVERT(numeric, SUM(CASE tbl_purchase.inst_id WHEN 1 THEN tbl_purchase.gd_ttl ELSE 0 END)) AS 'Peoples pub', CONVERT(numeric, 
                                             SUM(CASE tbl_purchase.inst_id WHEN 2 THEN tbl_purchase.gd_ttl ELSE 0 END)) AS 'Bubbles bite', CONVERT(numeric, SUM(CASE tbl_purchase.inst_id WHEN 3 THEN tbl_purchase.gd_ttl ELSE 0 END)) 
                                             AS 'Mayuri Dhammanagi', CONVERT(numeric, SUM(CASE tbl_purchase.inst_id WHEN 4 THEN tbl_purchase.gd_ttl ELSE 0 END)) AS 'Hubli Dhammanagi'
                                             FROM tbl_purchase INNER JOIN tbl_registration ON tbl_purchase.inst_id = tbl_registration.inst_id";



                            if (from != "" && to != "")
                            {
                                st += "  WHERE (CAST(tbl_purchase.bill_date AS date) BETWEEN Convert(date,'" + from + "',103) AND Convert(date,'" + to + "',103)) ";
                            }
                            else
                            {
                                st += "  WHERE (CAST(dbo.tbl_purchase.bill_date AS date) >= CAST(DATEADD(day, - 30, GETDATE()) AS date))";
                            }
                            st += " GROUP BY CONVERT(varchar, tbl_purchase.bill_date, 103), CAST(tbl_purchase.bill_date AS date) ORDER BY CAST(tbl_purchase.bill_date AS date)";

                        }
                        else
                        {
                            st = "";
                            if (cat > 0)
                            {
                                if (group != "")
                                {
                                    st = @"Select bill_date,SUM(net_amt) as net_amt,inst_id,cat,item_group from
                                            (SELECT dbo.tbl_purchase.gd_ttl AS net_amt, CONVERT(varchar, dbo.tbl_purchase.bill_date, 103) AS bill_date, dbo.item_master.cat, dbo.item_master.inst_id, 
                                             dbo.item_master.item_group FROM   dbo.tbl_purchase INNER JOIN
                                             dbo.tbl_registration ON dbo.tbl_purchase.inst_id = dbo.tbl_registration.inst_id INNER JOIN
                                             dbo.tbl_purchasedetails ON dbo.tbl_purchase.in_id = dbo.tbl_purchasedetails.in_id INNER JOIN
                                             dbo.item_master ON dbo.tbl_purchasedetails.item_no = dbo.item_master.item_no";


                                    if (from != "" && to != "")
                                    {
                                        st += " WHERE (CAST(dbo.tbl_purchase.bill_date AS date) >= CONVERT(date,'" + from + "',103)) and  (CAST(dbo.tbl_purchase.bill_date AS date) <= convert(date,'" + to + "',103))) as dd";
                                    }
                                    else
                                    {
                                        st += "   WHERE (CAST(dbo.tbl_purchase.bill_date AS date) >= CAST(DATEADD(day, - 30, GETDATE()) AS date))) as dd";
                                    }
                                    st += " where inst_id=" + inst_id + " and cat=" + cat + " and item_group='" + group + "'";
                                    st += " GROUP BY bill_date,inst_id,cat,item_group  ORDER BY CAST(bill_date AS date)";
                                }
                                else
                                {
                                    st = @"Select   bill_date,SUM(net_amt) as net_amt,inst_id,cat from
                                            (SELECT dbo.tbl_purchase.gd_ttl AS net_amt, CONVERT(varchar, dbo.tbl_purchase.bill_date, 103) AS bill_date, dbo.item_master.cat, dbo.item_master.inst_id, 
                                             dbo.item_master.item_group
                                            FROM  dbo.tbl_purchase INNER JOIN
                                            dbo.tbl_registration ON dbo.tbl_purchase.inst_id = dbo.tbl_registration.inst_id INNER JOIN
                                            dbo.tbl_purchasedetails ON dbo.tbl_purchase.in_id = dbo.tbl_purchasedetails.in_id INNER JOIN
                                            dbo.item_master ON dbo.tbl_purchasedetails.item_no = dbo.item_master.item_no";
                                    if (from != "" && to != "")
                                    {
                                        st += " WHERE (CAST(dbo.tbl_bill.bill_date AS date) >= CONVERT(date,'" + from + "',103)) and  (CAST(dbo.tbl_bill.bill_date AS date) <= convert(date,'" + to + "',103))) as dd";
                                    }
                                    else
                                    {
                                        st += "  WHERE (CAST(dbo.tbl_bill.bill_date AS date) >= CAST(DATEADD(day, - 30, GETDATE()) AS date)))as dd ";
                                    }
                                    st += " where inst_id=" + inst_id + " and cat=" + cat + " ";
                                    st += "   GROUP BY bill_date,inst_id,cat,item_group  ORDER BY CAST(bill_date AS date)";
                                }
                            }
                            else
                            {
                                st = "";
                                st = @"SELECT SUM(tbl_purchase.gd_ttl) AS net_amt, CONVERT(varchar, tbl_purchase.bill_date, 103) AS bill_date
                                       FROM tbl_purchase INNER JOIN tbl_registration ON tbl_purchase.inst_id = tbl_registration.inst_id";
                                if (from != "" && to != "")
                                {
                                    st += " WHERE (CAST(tbl_purchase.bill_date AS date) >= CONVERT(date,'" + from + "',103)) and  (CAST(tbl_purchase.bill_date AS date) <= convert(date,'" + to + "',103))  AND (tbl_purchase.inst_id = " + inst_id + ")";
                                }
                                else
                                {
                                    st += " WHERE (CAST(tbl_purchase.bill_date AS date) >= CAST(DATEADD(day, -30, getdate()) AS date)) AND (tbl_purchase.inst_id = " + inst_id + ")";
                                }
                                st += "  GROUP BY CONVERT(varchar, tbl_purchase.bill_date, 103), cast(bill_date as date) ORDER BY cast(bill_date as date)";
                            }
                        }
                    }


                    SqlCommand cmd;
                    if (type == 1)
                    {
                        cmd = new SqlCommand(st, con);
                        if (inst_id == 0)
                        {
                            SqlDataAdapter SqlDadp = new SqlDataAdapter(cmd);

                            cmd.CommandType = CommandType.Text;

                            using (IDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    graphData = new GraphData();

                                    graphData.label = Convert.ToString(dataReader["bill_date"].ToString());
                                    graphData.PP = Convert.ToDecimal(dataReader["Peoples pub"].ToString());
                                    graphData.BB = Convert.ToDecimal(dataReader["Bubbles bite"].ToString());
                                    graphData.MD = Convert.ToDecimal(dataReader["Mayuri Dhammanagi"].ToString());
                                    graphData.HD = Convert.ToDecimal(dataReader["Hubli Dhammanagi"].ToString());
                                    GraphDataList.ListOfGraphData.Add(graphData);
                                }
                                dataReader.Close();
                            }
                        }
                        else
                        {
                            SqlDataAdapter SqlDadp = new SqlDataAdapter(cmd);

                            cmd.CommandType = CommandType.Text;

                            using (IDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    graphData = new GraphData();
                                    graphData.label = Convert.ToString(dataReader["bill_date"].ToString());
                                    graphData.value = Convert.ToString(dataReader["net_amt"].ToString());
                                    //graphData.fee = Convert.ToString(dataReader["fee"].ToString());
                                    graphData.Amount = Convert.ToString(dataReader["net_amt"].ToString());
                                    GraphDataList.ListOfGraphData.Add(graphData);
                                }
                                dataReader.Close();
                            }
                        }
                    }
                    else if (type == 2)
                    {
                        cmd = new SqlCommand(st, con);

                    }
                    //last used below logic
                    //                    if (inst_id == 0 && cat >= 0)
                    //                    {
                    //                        st = @"";
                    //                        cmd = new SqlCommand(@"SELECT        bill_date, CONVERT(numeric, SUM(CASE inst_id WHEN 1 THEN net_amt ELSE 0 END)) AS 'Peoples pub', CONVERT(numeric, SUM(CASE inst_id WHEN 2 THEN net_amt ELSE 0 END)) AS 'Bubbles bite', 
                    //                                                                         CONVERT(numeric, SUM(CASE inst_id WHEN 3 THEN net_amt ELSE 0 END)) AS 'Mayuri Dhammanagi', CONVERT(numeric, SUM(CASE inst_id WHEN 4 THEN net_amt ELSE 0 END)) AS 'Hubli Dhammanagi'
                    //                                                FROM            (SELECT DISTINCT dbo.tbl_bill.bill_id, dbo.tbl_bill.round_off AS net_amt, CONVERT(varchar, dbo.tbl_bill.bill_date, 103) AS bill_date, dbo.tbl_bill.bill_date AS date, dbo.tbl_bill.inst_id
                    //                                                                          FROM            dbo.tbl_bill INNER JOIN
                    //                                                                                                    dbo.tbl_registration ON dbo.tbl_bill.inst_id = dbo.tbl_registration.inst_id INNER JOIN
                    //                                                                                                    dbo.tbl_salesdetails ON dbo.tbl_bill.bill_id = dbo.tbl_salesdetails.bill_id AND dbo.tbl_bill.inst_id = dbo.tbl_salesdetails.inst_id
                    //                                                                          WHERE        (CAST(dbo.tbl_bill.bill_date AS date) >= CAST(DATEADD(day, - 30, GETDATE()) AS date)) ) AS dd
                    //                                                GROUP BY bill_date, CAST(date AS date)
                    //                                                ORDER BY CAST(date AS date)", con);

                    //                        SqlDataAdapter SqlDadp = new SqlDataAdapter(cmd);

                    //                        cmd.CommandType = CommandType.Text;

                    //                        using (IDataReader dataReader = cmd.ExecuteReader())
                    //                        {
                    //                            while (dataReader.Read())
                    //                            {
                    //                                graphData = new GraphData();

                    //                                graphData.label = Convert.ToString(dataReader["bill_date"].ToString());
                    //                                graphData.PP = Convert.ToDecimal(dataReader["Peoples pub"].ToString());
                    //                                graphData.BB = Convert.ToDecimal(dataReader["Bubbles bite"].ToString());
                    //                                graphData.MD = Convert.ToDecimal(dataReader["Mayuri Dhammanagi"].ToString());
                    //                                graphData.HD = Convert.ToDecimal(dataReader["Hubli Dhammanagi"].ToString());
                    //                                graphDataList.ListOfGraphData.Add(graphData);
                    //                            }
                    //                            dataReader.Close();
                    //                        }
                    //                    }
                    //                    else
                    //                    {
                    //                        if (cat > 0)
                    //                        {

                    //                        }
                    //                        else
                    //                        {

                    //                        }
                    //                        cmd = new SqlCommand(@" SELECT        SUM(tbl_bill.round_off) AS net_amt, CONVERT(varchar, tbl_bill.bill_date, 103) AS bill_date
                    //                                               FROM            tbl_bill INNER JOIN
                    //                                                                     tbl_registration ON tbl_bill.inst_id = tbl_registration.inst_id
                    //                                               WHERE        (CAST(tbl_bill.bill_date AS date) >= CAST(DATEADD(day, -30, getdate()) AS date)) and tbl_bill.inst_id=" + inst_id + " GROUP BY CONVERT(varchar, tbl_bill.bill_date, 103), cast(bill_date as date)  ORDER BY cast(bill_date as date)", con);
                    //                        SqlDataAdapter SqlDadp = new SqlDataAdapter(cmd);

                    //                        cmd.CommandType = CommandType.Text;

                    //                        using (IDataReader dataReader = cmd.ExecuteReader())
                    //                        {
                    //                            while (dataReader.Read())
                    //                            {
                    //                                graphData = new GraphData();

                    //                                graphData.label = Convert.ToString(dataReader["bill_date"].ToString());
                    //                                graphData.value = Convert.ToString(dataReader["net_amt"].ToString());
                    //                                //    graphData.fee = Convert.ToString(dataReader["fee"].ToString());
                    //                                graphData.Amount = Convert.ToString(dataReader["net_amt"].ToString());
                    //                                graphDataList.ListOfGraphData.Add(graphData);
                    //                            }
                    //                            dataReader.Close();
                    //                        }
                    //                    }

                }
            }
        }
        catch (Exception)
        {
            //Logging.LogError(ex);
        }

        return GraphDataList;
    }

    public GraphDataList GetGraphData(string graphName)
    {
        GraphData graphData = null;
        GraphDataList GraphDataList = new GraphDataList();
        GraphDataList.ListOfGraphData = new List<GraphData>();
        string st = "";
        try
        {
            using (var con = new SqlConnection(ConfigurationManager.AppSettings["con"]))
            {
                con.Open();
                if (graphName == "pie")
                {
                    SqlCommand cmd = new SqlCommand(@"SELECT tbl_main_category.ct_id, tbl_main_category.name, ISNULL(SUM(dd.Sales_Qty * ISNULL(dd.Unit_qty, 1)), 0) AS sold_qty
                    FROM (SELECT DISTINCT tbl_salesdetails.invoice_no_dtl, tbl_salesdetails.item_no, tbl_salesdetails.qty AS Sales_Qty, CASE WHEN tbl_alterate.serial_no IS NULL 
                    THEN 1 ELSE tbl_alterate.qty END AS Unit_qty, tbl_salesdetails.c_id FROM tbl_bill INNER JOIN
                    tbl_salesdetails ON tbl_bill.bill_id = tbl_salesdetails.bill_id INNER JOIN item_master ON tbl_salesdetails.item_no = item_master.item_no LEFT OUTER JOIN
                    tbl_alterate ON tbl_salesdetails.item_no = tbl_alterate.item_no AND tbl_salesdetails.serial_no = tbl_alterate.serial_no
                    WHERE (tbl_bill.note = 0)) AS dd RIGHT OUTER JOIN  tbl_main_category ON dd.c_id = tbl_main_category.ct_id
                    WHERE (tbl_main_category.ct_id <> 3) GROUP BY dd.c_id, tbl_main_category.name, tbl_main_category.ct_id", con);
                    SqlDataAdapter SqlDadp = new SqlDataAdapter(cmd);

                    cmd.CommandType = CommandType.Text;

                    using (IDataReader dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            graphData = new GraphData();
                            graphData.label = Convert.ToString(dataReader["name"].ToString());
                            graphData.value = Convert.ToString(dataReader["sold_qty"].ToString());
                            GraphDataList.ListOfGraphData.Add(graphData);
                        }
                        dataReader.Close();
                    }
                }
                if(graphName=="LocalArea")
                {
//                    SqlCommand cmd = new SqlCommand(@"SELECT tbl_main_category.ct_id, tbl_main_category.name, ISNULL(SUM(dd.amt), 0) AS ttl_amt
//                    FROM (SELECT DISTINCT tbl_salesdetails.invoice_no_dtl, tbl_salesdetails.item_no, tbl_salesdetails.qty AS Sales_Qty, 
//                    CASE WHEN tbl_alterate.serial_no IS NULL THEN 1 ELSE tbl_alterate.qty END AS Unit_qty, tbl_salesdetails.c_id, tbl_salesdetails.c_ttl_amt AS amt
//                    FROM tbl_bill INNER JOIN tbl_salesdetails ON tbl_bill.bill_id = tbl_salesdetails.bill_id INNER JOIN item_master ON tbl_salesdetails.item_no = item_master.item_no LEFT OUTER JOIN
//                    tbl_alterate ON tbl_salesdetails.item_no = tbl_alterate.item_no AND tbl_salesdetails.serial_no = tbl_alterate.serial_no
//                    WHERE(tbl_bill.note = 0)) AS dd RIGHT OUTER JOIN tbl_main_category ON dd.c_id = tbl_main_category.ct_id WHERE (tbl_main_category.ct_id <> 3)
//                    GROUP BY dd.c_id, tbl_main_category.name, tbl_main_category.ct_id", con);
                    
//                    SqlCommand cmd = new SqlCommand(@"SELECT        bill_date, CONVERT(numeric, sum(isnull(net_amt,0))) AS Amount
//FROM            (SELECT DISTINCT tbl_bill.bill_id, tbl_bill.round_off AS net_amt, CONVERT(varchar, tbl_bill.bill_date, 103) AS bill_date, tbl_bill.bill_date AS date, tbl_bill.inst_id
//                          FROM            tbl_bill INNER JOIN
//                                                    tbl_salesdetails ON tbl_bill.bill_id = tbl_salesdetails.bill_id
//                          WHERE        (CAST(tbl_bill.bill_date AS date) >= CAST(DATEADD(day, - 30, GETDATE()) AS date)) AND (tbl_bill.status = 2)) AS dd
//GROUP BY bill_date, CAST(date AS date)
//ORDER BY CAST(date AS date)", con);

                    SqlCommand cmd = new SqlCommand(@"SELECT        bill_date, CONVERT(numeric, SUM(CASE c_id WHEN 1 THEN ttl_amt ELSE 0 END)) AS 'Food', CONVERT(numeric, SUM(CASE c_id WHEN 2 THEN ttl_amt ELSE 0 END)) AS 'Liquor Items', CONVERT(numeric, 
                         SUM(CASE c_id WHEN 4 THEN ttl_amt ELSE 0 END)) AS 'Tobacco', CONVERT(numeric, SUM(CASE c_id WHEN 5 THEN ttl_amt ELSE 0 END)) AS 'Beverages'
FROM            (SELECT        tbl_bill.bill_id, CONVERT(varchar, tbl_bill.bill_date, 103) AS bill_date, tbl_bill.bill_date AS date, tbl_salesdetails.c_id, SUM(tbl_salesdetails.c_ttl_amt) AS ttl_amt
                          FROM            tbl_bill INNER JOIN
                                                    tbl_salesdetails ON tbl_bill.bill_id = tbl_salesdetails.bill_id
                          WHERE        (CAST(tbl_bill.bill_date AS date) >= CAST(DATEADD(day, - 30, GETDATE()) AS date)) AND (tbl_bill.status = 2)
                          GROUP BY tbl_bill.bill_id, tbl_bill.bill_date, tbl_salesdetails.c_id) AS dd
GROUP BY bill_date, CAST(date AS date)
ORDER BY CAST(date AS date)", con);
                    SqlDataAdapter SqlDadp = new SqlDataAdapter(cmd);
                    cmd.CommandType = CommandType.Text;
                    using (IDataReader dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            graphData = new GraphData();
                            //graphData.label = Convert.ToString(dataReader["bill_date"].ToString());
                            //graphData.value = Convert.ToString(dataReader["Amount"].ToString());
                            graphData.label = Convert.ToString(dataReader["bill_date"].ToString());
                            graphData.PP = Convert.ToDecimal(dataReader["Food"].ToString());
                            graphData.BB = Convert.ToDecimal(dataReader["Liquor Items"].ToString());
                            graphData.MD = Convert.ToDecimal(dataReader["Tobacco"].ToString());
                            graphData.HD = Convert.ToDecimal(dataReader["Beverages"].ToString());
                            GraphDataList.ListOfGraphData.Add(graphData);
                        }
                        dataReader.Close();
                    }
                }
            }
        }

        catch (Exception)
        {

        }
        return GraphDataList;
    }
}
