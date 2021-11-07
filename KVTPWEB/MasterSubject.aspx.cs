using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterSubject : System.Web.UI.Page
{
    mydb db = new mydb();
    string st;
    string st1;
    string st2;
    string st3;
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
                    st = @" SELECT distinct KVTB_DepId, KVTB_DeptName FROM KVTB_Department WHERE (KVTB_ActiveFlag = 1) ORDER BY KVTB_DeptName";
                    db.fill_ddl_no_select(st, ddl_Department);
                    ddl_Department.Items.Insert(0, new ListItem("Select Department Name", "0"));


                    FillDesignation();
                    FillEmployee();
                    FillSemester();
                    fillrepetr();
                    EnableControl();
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
    protected void ddl_Employee_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillSemester();
        }
        catch (Exception)
        {

        }
    }
    protected void ddl_Designation_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillEmployee();
        }
        catch (Exception)
        {

        }
    }
    protected void ddl_Departmen_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillDesignation();
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
    public void FillDesignation()
    {
        st2 = @" SELECT distinct HRMDES_Id,HRMDES_DesignationName  FROM HR_Master_Designation WHERE (HRMDES_ActiveFlag = 1) and KVTB_DepId=" + ddl_Department.SelectedValue + "   ORDER BY HRMDES_DesignationName";
        db.fill_ddl_no_select(st2, ddl_Designation);
        ddl_Designation.Items.Insert(0, new ListItem("Select Designation Name", "0"));

    }
    public void FillEmployee()
    {
        st1 = @"SELECT distinct HRME_Id, (HRME_EmployeeFirstName + ' ' +HRME_EmployeeMiddleName + ' ' + HRME_EmployeeLastName)KVTB_EmpName FROM HR_Master_Employee WHERE (HRME_ActiveFlag = 1) and HRMD_Id=" + ddl_Department.SelectedValue + " and HRMDES_Id = " + ddl_Designation.SelectedValue + "  ORDER BY KVTB_EmpName";
        db.fill_ddl_no_select(st1, ddl_Employee);
        ddl_Employee.Items.Insert(0, new ListItem("Select Employee Name", "0"));

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        btnOK.ToolTip = "SAVE";
        btnOK.Text = "SAVE";
        EnableControl();
        clear();
        //  btncansel.Visible = false;



    }
    public void fillrepetr()
    {
        try
        {
            st = @"SELECT MD.HRMDES_Id, MD.HRMDES_DesignationName,D.KVTB_DepId,D.KVTB_DeptName,E.HRME_Id,(E.HRME_EmployeeFirstName + ' ' + E.HRME_EmployeeMiddleName + ' ' + E.HRME_EmployeeLastName)KVTB_EmpName,SS.HRMSEM_Id,SS.HRMSEM_SemisterName,S.HRMSUB_Id,S.HRMSUB_SubjectCode,S.HRMSUB_SubjectName,S.HRMSUB_ActiveFlag FROM 
  HR_Master_Subject S inner join HR_Master_Employee E on E.HRME_Id = S.HRME_Id
 inner join KVTB_Department D on D.KVTB_DepId = S.KVTB_DepID
  inner join HR_Master_Designation MD ON  MD.HRMDES_Id= S.HRMDES_Id 
 inner join HR_Master_Semister SS on SS.HRMSEM_Id = S.HRMSEM_Id where S.MI_Id=1";
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
        ddl_Employee.ClearSelection();
        ddl_Semester.ClearSelection();
        ddl_Designation.ClearSelection();
        HRMSUB_SubjectName.Text = "";
        HRMSUB_SubjectCode.Text = "";
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
            if (HRMSUB_Id.Value != "")
            {
               
                
                    //dr.Dispose(); db.db_close();
                    
                    st = @"Update HR_Master_Subject set HRMSUB_SubjectName='" + HRMSUB_SubjectName.Text + "', KVTB_DepId=" + ddl_Department.SelectedValue + "," +
                        "HRMDES_Id=" + ddl_Designation.SelectedValue + ",HRMSEM_Id='" + ddl_Semester.SelectedValue + "',HRME_Id='" + ddl_Employee.SelectedValue +
                        "' where HRMSUB_Id=" + HRMSUB_Id.Value + "";

                    x = db.ExeQuery(st);
                    if (x > 0)
                    {
                     //   dr.Dispose(); db.db_close();
                  
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert();", true);
                    clear();
                    btnOK.Enabled = true;
                    fillrepetr();
                    EnableControl();
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
                    st = "Select * from HR_Master_Subject where HRMSUB_SubjectCode='" + HRMSUB_SubjectCode.Text + "'  and MI_Id=1";
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
                        st = "insert into HR_Master_Subject(MI_Id,HRMSUB_SubjectCode,HRMSUB_SubjectName,HRMSUB_ActiveFlag,KVTB_DepId,HRMSEM_Id,HRMDES_Id,HRME_Id,HRMSUB_CreatedBy,HRMSUB_UpdatedBy,CreatedDate,UpdateDate)  values ";
                        st += "(1,'" + HRMSUB_SubjectCode.Text + "','" + HRMSUB_SubjectName.Text + "',1," + ddl_Department.SelectedValue + "," + ddl_Semester.SelectedValue + "," + ddl_Designation.SelectedValue + "," + ddl_Employee.SelectedValue + "," + Session["KVTP_Admin"] + "," + Session["KVTP_Admin"] + ",convert(date,getdate(),101),convert(date,getdate(),101))";
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
    private void EnableControl()
    {
        HRMSUB_SubjectCode.Enabled = true;
        HRMSUB_SubjectName.Enabled = true;
        ddl_Employee.Enabled = true;
        ddl_Designation.Enabled = true;
        ddl_Department.Enabled = true;

        ddl_Semester.Enabled = true;

        btnOK.Visible = true;
    }

    private void DisableControl()
    {
        HRMSUB_SubjectCode.Enabled = false;
       
        //btnOK.Visible = false;
    }
    protected void rptdescdep_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "edit")
            {

                //,HRME_Photo";

                Label HRMSUBSubjectCode = (Label)e.Item.FindControl("HRMSUBSubjectCode");
                HRMSUB_SubjectCode.Text = HRMSUBSubjectCode.Text;
                
                Label HRMSUBSubjectName = (Label)e.Item.FindControl("HRMSUBSubjectName");
                HRMSUB_SubjectName.Text = HRMSUBSubjectName.Text;
                //HiddenField KVTB_DepId = (HiddenField)e.Item.FindControl("KVTB_DepId");
                //ddl_Department.SelectedIndex = ddl_Department.Items.IndexOf(ddl_Department.Items.FindByValue(KVTB_DepId.Value));

                Label KVTBDeptName = (Label)e.Item.FindControl("KVTBDeptName");
                ddl_Department.SelectedIndex = ddl_Department.Items.IndexOf(ddl_Department.Items.FindByText(KVTBDeptName.Text));

                FillDesignation();
                Label HRMDESDesignationName = (Label)e.Item.FindControl("HRMDESDesignationName");
                ddl_Designation.SelectedIndex = ddl_Designation.Items.IndexOf(ddl_Designation.Items.FindByText(HRMDESDesignationName.Text));

                FillEmployee();
                Label KVTBEmpName = (Label)e.Item.FindControl("KVTBEmpName");
                ddl_Employee.SelectedIndex = ddl_Employee.Items.IndexOf(ddl_Employee.Items.FindByText(KVTBEmpName.Text));
                FillSemester();
                Label HRMSEMSemisterName = (Label)e.Item.FindControl("HRMSEMSemisterName");
                ddl_Semester.SelectedIndex = ddl_Semester.Items.IndexOf(ddl_Semester.Items.FindByText(HRMSEMSemisterName.Text));


                //HRME_Id
                HiddenField HRMSUBId = (HiddenField)e.Item.FindControl("HRMSUBId");
                HRMSUB_Id.Value = HRMSUBId.Value;
                DisableControl();
            }
            if (e.CommandName == "delete")
            {
                st = "Update  HR_Master_Subject set HRMSUB_ActiveFlag=0 where HRMSUB_Id=" + e.CommandArgument + "";
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
                st = "Update  HR_Master_Subject set HRMSUB_ActiveFlag=1 where HRMSUB_Id=" + e.CommandArgument + "";
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