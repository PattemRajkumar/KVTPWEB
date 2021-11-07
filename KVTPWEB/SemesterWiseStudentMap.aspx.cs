using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SemesterWiseStudentMap : System.Web.UI.Page
{
    mydb db = new mydb();
    string st;
    string st1;
    string st2;
    string st3;
    string st4;
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
            else
            {
                if (!IsPostBack)
                {
                    //accdemic year
                    st4 = @"select ASMAY_Id,ASMAY_Year from Adm_School_M_Academic_Year where ASMAY_ActiveFlag = 1 and MI_Id=1 ORDER BY ASMAY_Year";
                    db.fill_ddl_no_select(st4, ddlASMAY_Id);
                    ddlASMAY_Id.Items.Insert(0, new ListItem("Select Academic Year", "0"));

                    st = @" SELECT distinct KVTB_DepId, KVTB_DeptName FROM KVTB_Department WHERE (KVTB_ActiveFlag = 1) ORDER BY KVTB_DeptName";
                    db.fill_ddl_no_select(st, ddl_Department);
                    ddl_Department.Items.Insert(0, new ListItem("Select Department Name", "0"));


                    FillStudent();
                   
                    FillSemester();
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
    
    protected void ddl_Departmen_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillSemester();
            FillStudent();
        }
        catch (Exception)
        {

        }
    }
    public void FillSemester()
    {
        st3 = @" SELECT distinct HRMSEM_Id,HRMSEM_SemisterName  FROM HR_Master_Semister WHERE (HRMSEM_ActiveFlag = 1) and KVTB_DepId=" + ddl_Department.SelectedValue + "  ORDER BY HRMSEM_SemisterName";
        db.fill_ddl_no_select(st3, ddl_Semester);
        ddl_Semester.Items.Insert(0, new ListItem("Select Semester Name", "0"));

    }
    public void FillStudent()
    {
        st2 = @" SELECT distinct AMST_Id,(HRMS_StudentFirstName + ' ' + HRMS_StudentMiddleName + ' ' + HRMS_StudentLastName)HRMS_StudentName  FROM Student_Master_Register WHERE (AMSE_ActiveFlag = 1) and HRMD_Id=" + ddl_Department.SelectedValue + "   ORDER BY HRMDES_DesignationName";
        db.fill_ddl_no_select(st2, ddl_Student);
        ddl_Student.Items.Insert(0, new ListItem("Select Student Name", "0"));

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
            st = @"SELECT AY.ASMAY_Id,AY.ASMAY_Year,D.KVTB_DepId,D.KVTB_DeptName,SM.AMST_Id,(SM.HRMS_StudentFirstName + ' ' + SM.HRMS_StudentMiddleName + ' ' + SM.HRMS_StudentLastName)HRMS_StudentName,SS.HRMSEM_Id,SS.HRMSEM_SemisterName,S.SemStud_Id FROM 
  HR_Master_SemWiseStudentMap S inner join KVTB_Department D on D.KVTB_DepId = S.KVTB_DepId
 inner join HR_Master_Semister SS on SS.HRMSEM_Id = S.HRMSEM_Id
 inner join Student_Master_Register SM on SM.AMST_Id=S.AMST_Id
 inner join Adm_School_M_Academic_Year AY on AY.ASMAY_Id = S.ASMAY_Id
   where S.MI_Id=1";
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
        ddl_Department.ClearSelection();
        ddl_Student.ClearSelection();
        ddl_Semester.ClearSelection();
        ddlASMAY_Id.ClearSelection();
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
            if (SemStud_Id.Value != "")
            {
               
                
                    //dr.Dispose(); db.db_close();
                    
                    st = @"Update HR_Master_SemWiseStudentMap set ASMAY_Id='" + ddlASMAY_Id.SelectedValue + "', KVTB_DepId=" + ddl_Department.SelectedValue + "," +
                        "AMST_Id=" + ddl_Student.SelectedValue + ",HRMSEM_Id='" + ddl_Semester.SelectedValue +
                        "' where SemStud_Id=" + SemStud_Id.Value + "";

                    x = db.ExeQuery(st);
                    if (x > 0)
                    {
                     //   dr.Dispose(); db.db_close();
                  
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert();", true);
                    clear();
                    btnOK.Enabled = true;
                    fillrepetr();
                   
                    return;

                }
                    else
                    {
                        // ScriptManager.RegisterStartupScript(this, this.GetType(), "a1", "<script>alert('Not Success');</script>", false);
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert();", true);
                    btnOK.Enabled = true;
                    return;
                }
                
            }
            else {
                try
                {
                    st = "Select * from HR_Master_SemWiseStudentMap where ASMAY_Id='" + ddlASMAY_Id.SelectedValue + "' and KVTB_DepId='" + ddl_Department.SelectedValue + "' and AMST_Id='" + ddl_Student.SelectedValue + "' and HRMSEM_Id='" + ddl_Semester.SelectedValue + "'  and MI_Id=1";
                    dr = db.readall(st);
                    if (dr.Read())
                    {

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "a1", "<script>alert('Subject Code already exist in Database');</script>", false);
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
                        st = "insert into HR_Master_SemWiseStudentMap(MI_Id,ASMAY_Id,KVTB_DepId,HRMSEM_Id,AMST_Id,HRMSWS_CreatedBy,HRMSWS_UpdatedBy,CreatedDate,UpdateDate)  values ";
                        st += "(1,'" + ddlASMAY_Id.SelectedValue + "',1," + ddl_Department.SelectedValue + "," + ddl_Semester.SelectedValue + "," + ddl_Student.SelectedValue + "," + Session["KVTP_Admin"] + "," + Session["KVTP_Admin"] + ",convert(date,getdate(),101),convert(date,getdate(),101))";
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
    }
   

    
    protected void rptdescdep_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "edit")
            {
                Label ASMAYYear = (Label)e.Item.FindControl("ASMAYYear");
                ddlASMAY_Id.SelectedIndex = ddlASMAY_Id.Items.IndexOf(ddlASMAY_Id.Items.FindByText(ASMAYYear.Text));


                Label KVTBDeptName = (Label)e.Item.FindControl("KVTBDeptName");
                ddl_Department.SelectedIndex = ddl_Department.Items.IndexOf(ddl_Department.Items.FindByText(KVTBDeptName.Text));

                FillSemester();
                Label HRMSEMSemisterName = (Label)e.Item.FindControl("HRMSEMSemisterName");
                ddl_Semester.SelectedIndex = ddl_Semester.Items.IndexOf(ddl_Semester.Items.FindByText(HRMSEMSemisterName.Text));

                FillStudent();
                Label HRMSStudentName = (Label)e.Item.FindControl("HRMSStudentName");
                ddl_Student.SelectedIndex = ddl_Student.Items.IndexOf(ddl_Student.Items.FindByText(HRMSStudentName.Text));


                //HRME_Id
                HiddenField HRMSUBId = (HiddenField)e.Item.FindControl("HRMSUBId");
                SemStud_Id.Value = HRMSUBId.Value;
                
            }
            //if (e.CommandName == "delete")
            //{
            //    st = "Update  HR_Master_Subject set HRMSUB_ActiveFlag=0 where HRMSUB_Id=" + e.CommandArgument + "";
            //    x = db.ExeQuery(st);
            //    if (x > 0)
            //    {
            //        ScriptManager.RegisterStartupScript(this, this.GetType(), "a3", "<script>alert('Record Deactive Successfully !');</script>", false);
            //        fillrepetr();
            //        clear();
            //    }
            //    else
            //    {
            //        ScriptManager.RegisterStartupScript(this, this.GetType(), "a4", "<script>alert('Record Not Deactivate !');</script>", false);

            //    }

            //}
            //if (e.CommandName == "deletetwo")
            //{
            //    st = "Update  HR_Master_Subject set HRMSUB_ActiveFlag=1 where HRMSUB_Id=" + e.CommandArgument + "";
            //    x = db.ExeQuery(st);
            //    if (x > 0)
            //    {
            //        ScriptManager.RegisterStartupScript(this, this.GetType(), "a3", "<script>alert('Record Deactive Successfully !');</script>", false);
            //        fillrepetr();
            //    }
            //    else
            //    {
            //        ScriptManager.RegisterStartupScript(this, this.GetType(), "a4", "<script>alert('Record Not Deactivate !');</script>", false);

            //    }

            //}

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "err3", "alert('" + ex.Message.ToString() + "');", true);
            this.LogError(ex);
        }
    }


}