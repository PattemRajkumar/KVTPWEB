using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class dashboard : System.Web.UI.Page
{
    mydb db = new mydb();
    string st;
    int x;
    SqlDataReader dr;
   // DBOperation dbop = new DBOperation();
    protected void Page_Load(object sender, EventArgs e)
    {
       

    string    st1 = @"select count(AMST_Id)count1 from Student_Master_Register where AMSE_ActiveFlag=1";
     dr = db.readall(st1);
     if (dr.Read())
    {
             spnSTUD.InnerText = dr["count1"].ToString();
    }

        st = @"select count(HRME_Id)count from HR_Master_Employee where HRME_ActiveFlag=1";
        dr = db.readall(st);
        if (dr.Read())
        {
            spnEMP.InnerText = dr["count"].ToString();
        }

        //DataSet dsData = new DataSet();
        //String strdata = "uds_SelPurchaseDasboardData  ";
        //db.GetDataSet(strdata, "data", ref dsData);
        //if (dsData.Tables[0].Rows.Count > 0)
        //{
        //    spnPOApproval.InnerText = dsData.Tables[0].Rows[0]["PendingPOApproval"].ToString();
        //    spnCashGRN.InnerText = dsData.Tables[0].Rows[0]["PendingCashPurchaseGRNApproval"].ToString();
        //    spnSubConPOApprval.InnerText = dsData.Tables[0].Rows[0]["PendingSubConPOApprval"].ToString();
        //    spnPEFollowUp.InnerText = dsData.Tables[0].Rows[0]["PendingPEFollowUp"].ToString();
        //    spnPOFollowUp.InnerText = dsData.Tables[0].Rows[0]["PendingPOFollowUp"].ToString();
        //    //  spnPendingQC.InnerText = dsData.Tables[0].Rows[0]["PendingQC"].ToString();
        //}
    }
}