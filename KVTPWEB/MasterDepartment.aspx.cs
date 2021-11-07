using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterDepartment : System.Web.UI.Page
{
    mydb db = new mydb();
    string st;
    int x;
    SqlDataReader dr;
    protected void Page_Load(object sender, EventArgs e)
    {       
        try
        {
            //if (Session["admin_id"] == null)
            //{
            //    Response.Redirect("adminlogin.aspx");
            //}
            if (Session["KVTP_Admin"] == null)
            {
                Response.Redirect("Index.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    fillrepetr();
                    ClientScript.GetPostBackEventReference(this, string.Empty);

                }
            }

               
            
        }
          
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "err2", "alert('" + ex.Message.ToString() + "');", true);
            this.LogError(ex);
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        btnOK.ToolTip = "SAVE";
        btnOK.Text = "SAVE";
        clear();
      //  btncansel.Visible = false;
       
      

    }
    public void fillrepetr()
    {
        try
        {
            st = @"SELECT   KVTB_DepId, KVTB_DeptName, KVTB_DeptCode, KVTB_Order, KVTB_ActiveFlag, CreatedDate, UpdatedDate, HRMD_CreatedBy, HRMD_UpdatedBy
                   FROM             KVTB_Department";
           db.fill_repeater(st, rptdescdep);

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

    public void clear()
    {
        KVTB_DeptName.Text = ""; KVTB_DeptCode.Text = ""; KVTB_Order.Text = "";
    }
    protected void popupclose(object sender, EventArgs e)
    {
        string sPath = Request.Url.AbsolutePath;
        System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
        string sRet = oInfo.Name;
        Response.Redirect(sRet, false);
    }
    protected void btndept_Click(object sender, EventArgs e)
    {
        // SAVE
        if (btnOK.Text.ToUpper() == "SAVE".ToUpper())
        {
             btnOK.Enabled = false;
            string strMessage = "";

            try
            {
                st = "Select * from KVTB_Department where KVTB_DeptCode='" + KVTB_DeptCode.Text + "' or KVTB_DeptName='" + KVTB_DeptName.Text + "' and MI_Id=1";
                dr = db.readall(st);
                if (dr.Read())
                {

                  ScriptManager.RegisterStartupScript(this, this.GetType(), "a1", "<script>alert('Department Code already exist in Database');</script>", false);
                  //  strMessage = "City Code " + KVTB_DeptName.Text + " allready Exits in database.Please try with Diffrent code.";
                  //  lblPoupmsg1.InnerHtml = strMessage;
                  //  mpemsg1.Show();
                    dr.Dispose();
                    db.db_close();
                    clear();
                   
                    btnOK.Enabled = true;
                    return;
                }
                else
                {
                    dr.Dispose(); db.db_close();
                    st = "insert into KVTB_Department(KVTB_DeptName, KVTB_DeptCode, KVTB_Order, KVTB_ActiveFlag,  HRMD_CreatedBy, HRMD_UpdatedBy , MI_Id)  values ";
                    st += "('" + KVTB_DeptName.Text + "','" + KVTB_DeptCode.Text + "','" + KVTB_Order.Text + "',1,1,1,1)";
                    x = db.ExeQuery(st);
                    // x = db.return_affectedrow(st);

                    if (x > 0)
                    {
                        ClientScript.GetPostBackEventReference(this, string.Empty);
                        clear();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "a1", "<script>alert('Data Insterted Successfully');</script>", false);

                        btnOK.Enabled = true;
                        fillrepetr();
                        return;

                    }
                    else
                    {
                        ClientScript.GetPostBackEventReference(this, string.Empty);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "a1", "<script>alert('Data Not Insterted Successfully');</script>", false);
                        btnOK.Enabled = true;

                        return;
                    }

                }

            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "err2", "alert('" + ex.Message.ToString() + "');", true);
                this.LogError(ex);
                btnOK.Enabled = true;
                return;
            }
        }
    }
    protected void rptdescdep_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {

            if (e.CommandName == "delete")
            {
                st = "Update  KVTB_Department set KVTB_ActiveFlag=0 where KVTB_DepId=" + e.CommandArgument + "";
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
                st = "Update  KVTB_Department set KVTB_ActiveFlag=1 where KVTB_DepId=" + e.CommandArgument + "";
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
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "err3", "alert('" + ex.Message.ToString() + "');", true);
            this.LogError(ex);
        }
    }

    
}