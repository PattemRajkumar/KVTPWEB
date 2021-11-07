using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterSem : System.Web.UI.Page
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
            rptSemister.DataBind(); rptSemister.DataSource = null;
            st = @"SELECT b.HRMSEM_Id, b.KVTB_DepId, a.KVTB_DeptName, b.HRMSEM_SemisterName ,b.HRMSEM_SemCode,b.HRMSEM_ActiveFlag   FROM 
                     KVTB_Department a  INNER JOIN
   HR_Master_Semister b ON  a.KVTB_DepId=b.KVTB_DepId where a.MI_Id=1";
            db.fill_repeater(st, rptSemister);

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
                // st = "Select * from HR_Master_Semister  where HRMSEM_SemCode='" + HRMSEM_SemCode.Text + "' and KVTB_DepId=" + ddl_Department.SelectedValue + " and MI_Id=1";
                st = "Select * from HR_Master_Semister  where HRMSEM_SemCode='" + HRMSEM_SemCode.Text + "'  and MI_Id=1";

                dr = db.readall(st);
                if (dr.Read())
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "a1", "<script>alert('Semister Code already exit');</script>", false);

                    dr.Dispose(); db.db_close();
                    clear();
                }
                else
                {
                    dr.Dispose(); db.db_close();
                    st = "insert into HR_Master_Semister (MI_Id,HRMSEM_SemisterName,HRMSEM_SemCode,HRMSEM_ActiveFlag,KVTB_DepId,HRMSEM_CreatedBy,HRMSEM_UpdatedBy,CreatedDate,UpdateDate)  values ";
                    st += "(1,'" + HRMSEM_SemisterName.Text + "','" + HRMSEM_SemCode.Text + "',1," + ddl_Department.SelectedValue + "," + Session["KVTP_Admin"] + "," + Session["KVTP_Admin"] + ",convert(date,getdate(),101),convert(date,getdate(),101))";
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
        HRMSEM_SemisterName.Text = "";
        HRMSEM_SemCode.Text = "";
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

}