using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class KVTP_Master_Employee : System.Web.UI.Page
{
    mydb db = new mydb();
    string st;
    int x;
    int y;
    SqlDataReader dr;
    string Filename = "";
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
                    db.fill_ddl_no_select(st, ddlHRMD_Id);
                    ddlHRMD_Id.Items.Insert(0, new ListItem("Select Department Name", "0"));
                    st = @" select  IVRMMR_Id,IVRMMR_Name from  IVRM_master_Religion where Is_Active = 1 ORDER BY IVRMMR_Name";
                    db.fill_ddl_no_select(st, ddlIVRMMR_Id);
                    ddlIVRMMR_Id.Items.Insert(0, new ListItem("Select Religion", "0"));
                    st = @" select IMCC_Id ,IMCC_CategoryName from IVRM_Master_Caste_Category";
                    db.fill_ddl_no_select(st, ddlIMCC_Id);
                    ddlIMCC_Id.Items.Insert(0, new ListItem("Select Caste_Category", "0"));
                    ddlHRMDES_Id.Items.Insert(0, new ListItem("Select Designation Name", "0"));
                    //caste
                    ddlIMC_Id.Items.Insert(0, new ListItem("Select Caste ", "0"));

                    fillrpt();
                    //rptstaffregistation


                }


            }


        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "err2", "alert('" + ex.Message.ToString() + "');", true);
            this.LogError(ex);

        }
    }
    public void fillrpt()
    {
        try
        {
            rptstaffregistation.DataBind(); rptstaffregistation.DataSource = null;
            //st = @" SELECT  HR_Master_Employee.HRME_Id,(ISNULL(HR_Master_Employee.HRME_EmployeeFirstName ,'' )+ ' ' + ISNULL(HR_Master_Employee.HRME_EmployeeMiddleName,'')+' ' + ISNULL(HR_Master_Employee.HRME_EmployeeLastName,'')) AS HRME_EmployeeFirstName, HR_Master_Employee.HRME_EmployeeMiddleName AS Expr8, HR_Master_Employee.HRME_EmployeeLastName AS HRME_EmployeeLastName, 
            //             HR_Master_Employee.HRME_EmployeeCode AS HRME_EmployeeCode, HR_Master_Employee.HRME_EmailId AS HRME_EmailId, HR_Master_Employee.HRME_DOL AS HRME_DOL, HR_Master_Employee.HRME_Qulification AS HRME_Qulification, 
            //             HR_Master_Employee.HRME_MobileNo, KVTB_Department.KVTB_DeptName, HR_Master_Designation.HRMDES_DesignationName, 
            //             HR_Master_Employee.HRMD_Id,HR_Master_Employee.HRME_ActiveFlag     FROM     HR_Master_Employee INNER JOIN
            //             KVTB_Department ON HR_Master_Employee.HRMD_Id = KVTB_Department.KVTB_DepId INNER JOIN
            //             HR_Master_Designation ON HR_Master_Employee.HRMDES_Id = HR_Master_Designation.HRMDES_Id where HR_Master_Employee.MI_Id=1";

            st = @"SELECT HR_Master_Employee.HRME_Id, HR_Master_Employee.MI_Id, HR_Master_Employee.HRMG_Id, HR_Master_Employee.HRME_EmployeeFirstName, HR_Master_Employee.HRME_EmployeeMiddleName, 
                         HR_Master_Employee.HRME_EmployeeLastName, HR_Master_Employee.HRME_EmployeeCode, HR_Master_Employee.HRME_BiometricCode, HR_Master_Employee.HRME_LocPincode, HR_Master_Employee.IVRMMMS_Id, 
                         HR_Master_Employee.IVRMMG_Id, HR_Master_Employee.CasteCategoryId, HR_Master_Employee.CasteId, HR_Master_Employee.ReligionId, HR_Master_Employee.HRME_FatherName, 
                         HR_Master_Employee.HRME_MotherName, HR_Master_Employee.HRME_SpouseName, HR_Master_Employee.HRME_SpouseOccupation, HR_Master_Employee.HRME_SpouseMobileNo, 
                         HR_Master_Employee.HRME_SpouseEmailId, HR_Master_Employee.HRME_SpouseAddress, HR_Master_Employee.HRME_DOB, HR_Master_Employee.HRME_DOJ, HR_Master_Employee.HRME_ExpectedRetirementDate, 
                         HR_Master_Employee.HRME_MobileNo, HR_Master_Employee.HRME_EmailId, HR_Master_Employee.HRME_BloodGroup, HR_Master_Employee.HRME_Type, HR_Master_Employee.HRME_Photo, 
                         HR_Master_Employee.HRME_LeftFlag, HR_Master_Employee.HRME_DOL, HR_Master_Employee.HRME_IdentificationMark, HR_Master_Employee.HRME_PANCardNo, HR_Master_Employee.HRME_AadharCardNo, 
                         HR_Master_Employee.HRME_ActiveFlag, HR_Master_Employee.HRME_SubjectsTaught, HR_Master_Employee.HRME_Gender, HR_Master_Employee.HRME_Material, HR_Master_Employee.HRME_Qulification, 
                         HR_Master_Employee.KVTP_RoleFlag, HR_Master_Employee.HRMD_Id, KVTB_Department.KVTB_DeptName, HR_Master_Employee.HRMDES_Id, HR_Master_Employee.HRM_Gropup, 
                         HR_Master_Designation.HRMDES_DesignationName
FROM            HR_Master_Employee INNER JOIN
                         KVTB_Department ON HR_Master_Employee.HRMD_Id = KVTB_Department.KVTB_DepId INNER JOIN
                         HR_Master_Designation ON HR_Master_Employee.HRMDES_Id = HR_Master_Designation.HRMDES_Id";
            db.fill_repeater(st, rptstaffregistation);

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
    }   //select IMC_Id,IMC_CasteName from IVRM_Master_Caste
    protected void ddlHRMD_Id_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlHRMD_Id.SelectedItem.Value != null)
            {
                st = @" SELECT  HR_Master_Designation.HRMDES_Id, 
                          HR_Master_Designation.HRMDES_DesignationName
                FROM            KVTB_Department INNER JOIN
                         HR_Master_Designation ON KVTB_Department.KVTB_DepId = HR_Master_Designation.KVTB_DepId where KVTB_Department.MI_Id=1 and KVTB_Department.KVTB_DepId=" + ddlHRMD_Id.SelectedValue + "";
                db.fill_ddl_no_select(st, ddlHRMDES_Id);
                ddlHRMDES_Id.Items.Insert(0, new ListItem("Select Designation Name", "0"));
            }
            else
            {
                dr.Dispose(); db.db_close();
                ddlHRMDES_Id.Items.Insert(0, new ListItem("Select Designation Name", "0"));
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "err2", "alert('" + ex.Message.ToString() + "');", true);
            this.LogError(ex);

        }
    }
    protected void ddlIMCC_Id_SelectedIndexChanged(object sender, EventArgs e)
    {
        //ddlIMCC_Id
        try
        {

            if (ddlIMCC_Id.SelectedItem.Value != null)
            {
                st = @" SELECT IVRM_Master_Caste.IMC_Id, IVRM_Master_Caste.IMC_CasteName FROM IVRM_Master_Caste_Category INNER JOIN
                         IVRM_Master_Caste ON IVRM_Master_Caste_Category.IMCC_Id = IVRM_Master_Caste.IMCC_Id 
               where  IVRM_Master_Caste_Category.IMCC_Id=" + ddlIMCC_Id.SelectedValue + "";
                db.fill_ddl_no_select(st, ddlIMC_Id);
                ddlIMC_Id.Items.Insert(0, new ListItem("Select Caste ", "0"));


            }
            else
            {
                dr.Dispose(); db.db_close();
                ddlIMC_Id.Items.Insert(0, new ListItem("Select Caste", "0"));
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
        HRME_EmployeeFirstName.Text = ""; HRME_EmployeeMiddleName.Text = ""; HRME_EmployeeLastName.Text = "";
        HRME_EmployeeCode.Text = ""; HRME_FatherName.Text = ""; HRME_MotherName.Text = ""; HRME_Type.ClearSelection();
        ddlHRMD_Id.ClearSelection(); ddlHRMDES_Id.ClearSelection(); HRME_SubjectsTaught.Text = ""; HRME_DOJ.Text = "";
        ddlHRME_BloodGroup.ClearSelection(); ddlIVRMMR_Id.ClearSelection(); ddlIMCC_Id.ClearSelection();
        ddlIMC_Id.ClearSelection(); HRME_DOB.Text = ""; HRME_ExpectedRetirementDate.Text = ""; HRME_Gender.ClearSelection();
        HRME_Material.ClearSelection(); HRME_MobileNo.Text = ""; HRME_EmailId.Text = ""; HRME_AadharCardNo.Text = ""; HRME_PANCardNo.Text = "";
        HRME_IdentificationMark.Text = ""; HRME_Qulification.Text = "";

    }
    protected void btnemployee_Click(object sender, EventArgs e)
    {
        try
        {
            TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime indianTime = TimeZoneInfo.ConvertTime(DateTime.UtcNow, INDIAN_ZONE);

            if (HRME_Id.Value != "")
            {
                st = "Select * from HR_Master_Employee where MI_Id=1 and HRME_Id !=" + HRME_Id.Value + " and (HRME_EmployeeCode='" + HRME_EmployeeCode.Text + "' OR  HRME_EmailId='" + HRME_EmailId.Text + "')";
                dr = db.readall(st);
                if (dr.Read())
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "a1", "<script>alert('Email Id / Employee Code Duplicate');</script>", false);
                    dr.Dispose(); db.db_close();
                    HRME_Id.Value="";
                    clear();
                }
                else
                {
                    dr.Dispose(); db.db_close();
                    st = "";
                    st = @"Update HR_Master_Employee set HRME_EmployeeFirstName='" + HRME_EmployeeFirstName.Text + "',HRME_EmployeeMiddleName='" + HRME_EmployeeMiddleName.Text + "' ,HRME_EmployeeLastName='" + HRME_EmployeeLastName.Text + "' ," +
                        "HRME_EmployeeCode='" + HRME_EmployeeCode.Text + "',HRME_FatherName='" + HRME_FatherName.Text + "',HRME_MotherName='" + HRME_MotherName.Text + "' " +
                        ",HRME_Type='" + HRME_Type.SelectedItem.Value + "',HRM_Gropup='" + HRM_Gropup.SelectedItem.Value + "',HRMD_Id=" + ddlHRMD_Id.SelectedValue + "," +
                        "HRMDES_Id=" + ddlHRMDES_Id.SelectedValue + ",HRME_SubjectsTaught='" + HRME_SubjectsTaught.Text + "',HRME_BloodGroup='" + ddlHRME_BloodGroup.SelectedValue + "'," +
                        "ReligionId='" + ddlIVRMMR_Id.SelectedValue + "',CasteCategoryId='" + ddlIMCC_Id.SelectedValue + "',CasteId='" + ddlIMC_Id.SelectedValue + "'," +
                        "HRME_Gender='" + HRME_Gender.SelectedItem.Value + "',HRME_Material='" + HRME_Material.SelectedItem.Value + "',HRME_MobileNo='" + HRME_MobileNo.Text + "'," +
                        "HRME_PANCardNo='" + HRME_PANCardNo.Text + "',HRME_Qulification='" + HRME_Qulification.Text + "',HRME_EmailId='" + HRME_EmailId.Text + "'," +
                        "HRME_AadharCardNo='" + HRME_AadharCardNo.Text + "',HRME_IdentificationMark='" + HRME_IdentificationMark.Text + "',KVTP_RoleFlag='" + ddlroleFlag.SelectedItem.Value + "'," +
                        "HRME_Photo='" + Path.GetExtension(HRME_Photo.PostedFile.FileName) + "',HRME_DOJ='" + HRME_DOJ.Text + "',HRME_DOB='" + HRME_DOB.Text + "',HRME_ExpectedRetirementDate='" + HRME_ExpectedRetirementDate.Text + "' where HRME_Id=" + HRME_Id.Value + "";

                    x = db.ExeQuery(st);
                    if (x > 0)
                    {
                        dr.Dispose(); db.db_close();
                        clear();
                        fillrpt();
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert();", true);


                    }
                    else
                    {
                        // ScriptManager.RegisterStartupScript(this, this.GetType(), "a1", "<script>alert('Not Success');</script>", false);
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert();", true);

                    }

                }
            }
            else
            {
                st = "Select * from HR_Master_Employee where MI_Id=1 and (HRME_EmployeeCode='" + HRME_EmployeeCode.Text + "' OR  HRME_EmailId='" + HRME_EmailId.Text + "')";
                dr = db.readall(st);
                if (dr.Read())
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "a1", "<script>alert('Department Duplicate');</script>", false);

                    dr.Dispose(); db.db_close();
                    //clear();
                }
                else
                {
                    db.db_close();
                    st = "";
                    st = @"insert into HR_Master_Employee(MI_Id,HRME_EmployeeFirstName,HRME_EmployeeMiddleName,HRME_EmployeeLastName,
                         HRME_EmployeeCode,HRME_FatherName,HRME_MotherName,HRME_Type,HRM_Gropup,HRMD_Id,HRMDES_Id,HRME_SubjectsTaught,HRME_BloodGroup,
                    ReligionId,CasteCategoryId,CasteId,HRME_Gender,HRME_Material,HRME_MobileNo,HRME_PANCardNo,
             HRME_Qulification,HRME_EmailId,HRME_AadharCardNo,HRME_IdentificationMark,HRME_ActiveFlag,KVTP_RoleFlag,HRME_Photo,HRME_DOJ,HRME_DOB,HRME_ExpectedRetirementDate)  output inserted.HRME_Id values ";
                    st += @"(1,'" + HRME_EmployeeFirstName.Text + "','" + HRME_EmployeeMiddleName.Text + "','" + HRME_EmployeeLastName.Text + "'," +
                        "'" + HRME_EmployeeCode.Text + "','" + HRME_FatherName.Text + "','" + HRME_MotherName.Text + "','" + HRME_Type.SelectedItem.Value + "','" + HRM_Gropup.SelectedItem.Value + "'," +
                        "" + ddlHRMD_Id.SelectedValue + "," + ddlHRMDES_Id.SelectedValue + ",'" + HRME_SubjectsTaught.Text + "'," +
    "'" + ddlHRME_BloodGroup.SelectedValue + "','" + ddlIVRMMR_Id.SelectedValue + "'" +
                        ",'" + ddlIMCC_Id.SelectedValue + "','" + ddlIMC_Id.SelectedValue + "'," +
                        "'" + HRME_Gender.SelectedItem.Value + "','" + HRME_Material.SelectedItem.Value + "','" + HRME_MobileNo.Text + "'," +
                        "'" + HRME_PANCardNo.Text + "','" + HRME_Qulification.Text + "','" + HRME_EmailId.Text + "','" + HRME_AadharCardNo.Text + "','" + HRME_IdentificationMark.Text + "',1,'" + ddlroleFlag.SelectedItem.Value + "','" + Path.GetExtension(HRME_Photo.PostedFile.FileName) + "','" + HRME_DOJ.Text + "','" + HRME_DOB.Text + "','" + HRME_ExpectedRetirementDate.Text + "')";

                    x = db.return_affectedrow(st);
                    HRME_Id.Value = x.ToString();
                    if (x > 0)
                    {
                        imagespdf();
                        dr.Dispose(); db.db_close();
                        st = "";
                        st = "insert into IVRM_Staff_User_Login(MI_Id, IVRMSTAUL_UserName, IVRMSTAUL_Password, IVRMSTAUL_ActiveFlag, CreatedDate, UpdatedDate, IVRMSTAUL_CreatedBy, IVRMSTAUL_UpdatedBy, KVTP_RoleFlag, IVRMUL_ID) values";
                        st += @"(1,'" + HRME_EmployeeCode.Text + "','Password@123',1,getdate(),getdate()," + Session["KVTP_Admin"] + "," + Session["KVTP_Admin"] + ",'" + ddlroleFlag.SelectedItem.Value + "',  " + HRME_Id.Value + ")";
                        y = db.ExeQuery(st);

                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert();", true);
                        //   ScriptManager.RegisterStartupScript(this, this.GetType(), "a1", "<script>alert(' Inserted Sucessfully');</script>", false);
                        clear();
                        fillrpt();
                        HRME_Id.Value = "";

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
    protected void btncancel_Click(object sender, EventArgs e)
    {

    }
    protected void btnsavenext_Click(object sender, EventArgs e)
    {

    }
    protected void rptstaffregistation_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "edit")
            {            
            
             //,HRME_Photo";

                Label HRMEEmployeeFirstName = (Label)e.Item.FindControl("HRMEEmployeeFirstName");
                HRME_EmployeeFirstName.Text = HRMEEmployeeFirstName.Text;                          
                HiddenField HRMEEmployeeMiddleName = (HiddenField)e.Item.FindControl("HRMEEmployeeMiddleName");
                HRME_EmployeeMiddleName.Text = HRMEEmployeeMiddleName.Value;
                HiddenField HRMEEmployeeLastName = (HiddenField)e.Item.FindControl("HRMEEmployeeLastName");
                HRME_EmployeeLastName.Text = HRMEEmployeeLastName.Value;
                Label HRMEEmployeeCode = (Label)e.Item.FindControl("HRMEEmployeeCode");
                HRME_EmployeeCode.Text = HRMEEmployeeCode.Text;
                HiddenField HRMEFatherName = (HiddenField)e.Item.FindControl("HRMEFatherName");
                HRME_FatherName.Text = HRMEFatherName.Value;
                HiddenField HRMEMotherName = (HiddenField)e.Item.FindControl("HRMEMotherName");
                HRME_MotherName.Text = HRMEMotherName.Value;
               
                Label HRMEType = (Label)e.Item.FindControl("HRMEType");
                HRME_Type.SelectedIndex = HRME_Type.Items.IndexOf(HRME_Type.Items.FindByValue(HRMEType.Text));
               
                Label HRMGropup = (Label)e.Item.FindControl("HRMGropup");
                HRM_Gropup.SelectedIndex = HRM_Gropup.Items.IndexOf(HRM_Gropup.Items.FindByValue(HRMGropup.Text));

                HiddenField HRMDId = (HiddenField)e.Item.FindControl("HRMDId");              
                ddlHRMD_Id.SelectedIndex = ddlHRMD_Id.Items.IndexOf(ddlHRMD_Id.Items.FindByValue(HRMDId.Value));

                HiddenField HRMDESId = (HiddenField)e.Item.FindControl("HRMDESId");
                ddlHRMDES_Id.SelectedIndex = ddlHRMD_Id.Items.IndexOf(ddlHRMD_Id.Items.FindByValue(HRMDESId.Value));

                Label HRMESubjectsTaught = (Label)e.Item.FindControl("HRMESubjectsTaught");
                HRME_SubjectsTaught.Text = HRMESubjectsTaught.Text;

                Label HRMEBloodGroup = (Label)e.Item.FindControl("HRMEBloodGroup");
                ddlHRME_BloodGroup.SelectedIndex = ddlHRME_BloodGroup.Items.IndexOf(ddlHRME_BloodGroup.Items.FindByValue(HRMEBloodGroup.Text));

                HiddenField ReligionId = (HiddenField)e.Item.FindControl("ReligionIdee");
                ddlIVRMMR_Id.SelectedIndex = ddlIVRMMR_Id.Items.IndexOf(ddlIVRMMR_Id.Items.FindByValue(ReligionId.Value));

                HiddenField CasteCategoryId = (HiddenField)e.Item.FindControl("CasteCategoryId");
                ddlIMCC_Id.SelectedIndex = ddlIMCC_Id.Items.IndexOf(ddlIMCC_Id.Items.FindByValue(CasteCategoryId.Value));

                HiddenField CasteId = (HiddenField)e.Item.FindControl("CasteId");
                ddlIMC_Id.SelectedIndex = ddlIMCC_Id.Items.IndexOf(ddlIMC_Id.Items.FindByValue(CasteId.Value));

                Label HRMEGender = (Label)e.Item.FindControl("HRMEGender");
                HRME_Gender.SelectedIndex = HRME_Gender.Items.IndexOf(HRME_Gender.Items.FindByValue(HRMEGender.Text));

               
                Label HRMEMaterial = (Label)e.Item.FindControl("HRMEMaterial");
                HRME_Material.SelectedIndex = HRME_Material.Items.IndexOf(HRME_Material.Items.FindByValue(HRMEMaterial.Text));

                Label HRMEMobileNo = (Label)e.Item.FindControl("HRMEMobileNo");
                HRME_MobileNo.Text = HRMEMobileNo.Text;

                Label HRMEPANCardNo = (Label)e.Item.FindControl("HRMEMobileNo");
                HRME_PANCardNo.Text = HRMEPANCardNo.Text;

                Label HRMEQulification = (Label)e.Item.FindControl("HRMEQulification");
                HRME_Qulification.Text = HRMEQulification.Text;

                Label HRMEEmailId = (Label)e.Item.FindControl("HRMEEmailId");
                HRME_EmailId.Text = HRMEEmailId.Text;
           
                Label HRMEAadharCardNo = (Label)e.Item.FindControl("HRMEAadharCardNo");
                HRME_AadharCardNo.Text = HRMEAadharCardNo.Text;

                Label HRMEIdentificationMark = (Label)e.Item.FindControl("HRMEIdentificationMark");
                HRME_IdentificationMark.Text = HRMEIdentificationMark.Text;
                
                Label KVTPRoleFlag = (Label)e.Item.FindControl("KVTPRoleFlag");
                ddlroleFlag.SelectedIndex = ddlroleFlag.Items.IndexOf(ddlroleFlag.Items.FindByValue(KVTPRoleFlag.Text));

                
                Label HRMEDOJ = (Label)e.Item.FindControl("HRMEDOJ");
                HRME_DOJ.Text = HRMEDOJ.Text;

                Label HRMEDOB = (Label)e.Item.FindControl("HRMEDOB");
                HRME_DOB.Text = HRMEDOB.Text;
              
                Label HRMEExpectedRetirementDate = (Label)e.Item.FindControl("HRMEExpectedRetirementDate");
                HRME_ExpectedRetirementDate.Text = HRMEExpectedRetirementDate.Text;
                //HRME_Id
                HiddenField HRMEId = (HiddenField)e.Item.FindControl("HRMEId");
                HRME_Id.Value = HRMEId.Value;
                
            }

            if (e.CommandName == "delete")
            {
                st = "Update HR_Master_Employee set HRME_ActiveFlag=0 where HRME_Id=" + e.CommandArgument + "";
                x = db.ExeQuery(st);
                if (x > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "a3", "<script>alert('Record Deactive Successfully !');</script>", false);
                    fillrpt();
                    clear();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "a4", "<script>alert('Record Not Deactivate !');</script>", false);

                }

            }
            if (e.CommandName == "deletetwo")
            {
                st = "Update  HR_Master_Employee set HRME_ActiveFlag=1 where HRME_Id=" + e.CommandArgument + "";
                x = db.ExeQuery(st);
                if (x > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "a3", "<script>alert('Record Deactive Successfully !');</script>", false);
                    fillrpt();
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
    public string imagespdf()
    {
        try
        {
            if (HRME_Photo.FileName != "")
            {
                string ext = Path.GetExtension(HRME_Photo.PostedFile.FileName);
                HRME_Photo.SaveAs(Server.MapPath("~/Document/StaffProfiles") + "\\" + HRME_Id.Value + ext);
                Filename = "Doccuments/StaffProfiles/" + HRME_Id.Value + ext;
            }

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "err2", "alert('" + ex.Message.ToString() + "');", true);
            this.LogError(ex);
        }
        return Filename;
    }
    //protected void HRME_Photo_Load(object sender, EventArgs e)
    //{
    //    string folderPath = Server.MapPath("~/Document/StaffProfiles");      
    //    if (!Directory.Exists(folderPath))
    //    {            
    //        Directory.CreateDirectory(folderPath);
    //    }       
    //    HRME_Photo.SaveAs(folderPath + Path.GetFileName(HRME_Photo.FileName));       
    //    Image1.ImageUrl = "~/Document/StaffProfiles" + Path.GetFileName(HRME_Photo.FileName);

    //}
}