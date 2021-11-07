using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterDesignations : System.Web.UI.Page
{
    mydb db = new mydb();
    string st;
    int x;
    SqlDataReader dr;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["KVTP_Admin"] == null)
            {
                Response.Redirect("Index.aspx");
            }
              if (!IsPostBack)
            {
            st = @" SELECT distinct KVTB_DepId, KVTB_DeptName FROM KVTB_Department WHERE (KVTB_ActiveFlag = 1) ORDER BY KVTB_DeptName";
            db.fill_ddl_no_select(st, ddl_Department);
            ddl_Department.Items.Insert(0, new ListItem("Select Department Name", "0"));
          //  ddl_Department.Items.Insert(0, "--Select Department Name--");

         //   dr.Dispose(); db.db_close();
          
                fillrepetr();
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "err2", "alert('" + ex.Message.ToString() + "');", true);
            this.LogError(ex);
        }

    }
    public void fillrepetr()
    {
        try
        {
            //rptdessination.DataBind(); rptdessination.DataSource = null;
            st = @"SELECT b.HRMDES_Id, b.KVTB_DepId, a.KVTB_DeptName, b.HRMDES_DesignationName ,b.HRMDES_Order,b.HRMDES_ActiveFlag   FROM 
                     KVTB_Department a  INNER JOIN
   HR_Master_Designation b ON  a.KVTB_DepId=b.KVTB_DepId where a.MI_Id=1";
            db.fill_repeater(st, rptdessination);

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "err2", "alert('" + ex.Message.ToString() + "');", true);
            this.LogError(ex);
        }
    }
    protected void btndesighn_Click(object sender, EventArgs e)
    {
        try
        {
            //ddl_Department.SelectedIndex = ddl_Department.Items.IndexOf(ddl_Department.Items.FindByValue(dr["KVTB_DepId"].ToString()));
            // ddl_Department.SelectedValue = ddl_Department.Items.FindByValue(dr["KVTB_DepId"].ToString());
            //dr.Dispose(); db.db_close();
            if (ddl_Department.SelectedItem.Value != null)
            {
                st = "Select * from HR_Master_Designation where HRMDES_DesignationName='" + HRMDES_DesignationName.Text + "' and KVTB_DepId=" + ddl_Department.SelectedValue + " and MI_Id=1";
                dr = db.readall(st);
                if (dr.Read())
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "a1", "<script>alert('Department Duplicate');</script>", false);

                    dr.Dispose(); db.db_close();
                    clear();
                }
                else
                {
                    dr.Dispose(); db.db_close();
                    st = "insert into HR_Master_Designation(MI_Id,HRMDES_DesignationName,HRMDES_Order,HRMDES_ActiveFlag,KVTB_DepId,HRMDES_CreatedBy,HRMDES_UpdatedBy,CreatedDate,UpdateDate)  values ";
                    st += "(1,'" + HRMDES_DesignationName.Text + "','" + HRMDES_Order.Text + "',1," + ddl_Department.SelectedValue + "," + Session["KVTP_Admin"] + "," + Session["KVTP_Admin"] + ",convert(date,getdate(),101),convert(date,getdate(),101))";
                    x = db.ExeQuery(st);
                    // x = db.return_affectedrow(st);

                    if (x > 0)
                    {
                        dr.Dispose(); db.db_close();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "a1", "<script>alert(' Inserted Sucessfully');</script>", false);
                        clear();
                        fillrepetr();

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "a1", "<script>alert('Not Success');</script>", false);

                    }
                   
                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "err2", "alert('" + ex.Message.ToString() + "');", true);
            this.LogError(ex);
           
        }
      
    }
    public void clear()
    {
        ddl_Department.ClearSelection();
        HRMDES_DesignationName.Text = "";
    }
    protected void btncansel_Click(object sender, EventArgs e)
    {
        try
        {
            clear();
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "err2", "alert('" + ex.Message.ToString() + "');", true);
            this.LogError(ex);
        }
    }
    private void LogError(Exception ex)
    {
        string message = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
        message += Environment.NewLine;
        message += "-----------------------------------------------------------";
        message += Environment.NewLine;
        message += string.Format("Message: {0}", ex.Message);
        message += Environment.NewLine;
        message += string.Format("StackTrace: {0}", ex.StackTrace);
        message += Environment.NewLine;
        message += string.Format("Source: {0}", ex.Source);
        message += Environment.NewLine;
        message += string.Format("TargetSite: {0}", ex.TargetSite.ToString());
        message += Environment.NewLine;
        message += "-----------------------------------------------------------";
        message += Environment.NewLine;
        string path1 = Server.MapPath("~/ErrorLog/ErrorLog.txt");
        using (StreamWriter writer = new StreamWriter(path1, true))
        {
            writer.WriteLine(message);
            writer.Close();
        }

    }


    protected void rptdessination_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            st = "Update  HR_Master_Designation set HRMDES_ActiveFlag=0 where HRMDES_Id=" + e.CommandArgument + "";
            x = db.ExeQuery(st);
            if (x > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "a3", "<script>alert('Record Deactive Successfully !');</script>", false);
                fillrepetr();
                clear();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "a4", "<script>alert('Record Not Deactivate !');</script>", false);

            }

        }
        if (e.CommandName == "deletetwo")
        {
            st = "Update  HR_Master_Designation set HRMDES_ActiveFlag=0 where HRMDES_Id=" + e.CommandArgument + "";
            x = db.ExeQuery(st);
            if (x > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "a3", "<script>alert('Record Deactive Successfully !');</script>", false);
                fillrepetr();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "a4", "<script>alert('Record Not Deactivate !');</script>", false);

            }

        }

    }
}