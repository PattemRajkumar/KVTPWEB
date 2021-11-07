using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StudentRegister : System.Web.UI.Page
{
    mydb db = new mydb();
    string st;
    string st3;
    string st4;
    string st5;
    string st6;
    int x;
    int y;
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
                    db.fill_ddl_no_select(st, ddlHRMD_Id);
                    ddlHRMD_Id.Items.Insert(0, new ListItem("Select Department Name", "0"));
                    FillAcademicYear();
                    FillReligion();
                    FillCasteCategory();
                    FillCaste();
                    EnableControl();
                    fillrpt();
                   
                }


            }


        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "err2", "alert('" + ex.Message.ToString() + "');", true);
            this.LogError(ex);

        }
    }
     public void FillAcademicYear()
    {
        st5 = @"select ASMAY_Id,ASMAY_Year from Adm_School_M_Academic_Year where ASMAY_ActiveFlag = 1 and MI_Id=1 ORDER BY ASMAY_Year";
        db.fill_ddl_no_select(st5, ddlASMAY_Id);
        ddlASMAY_Id.Items.Insert(0, new ListItem("Select Academic Year", "0"));

    }


    public void FillCasteCategory()
    {
        st4 = @" select IMCC_Id ,IMCC_CategoryName from IVRM_Master_Caste_Category";
        db.fill_ddl_no_select(st4, ddlIMCC_Id);
        ddlIMCC_Id.Items.Insert(0, new ListItem("Select Caste Category", "0"));

    }
     public void FillCaste()
    {
        st6 = @" SELECT IVRM_Master_Caste.IMC_Id, IVRM_Master_Caste.IMC_CasteName FROM IVRM_Master_Caste_Category INNER JOIN
                         IVRM_Master_Caste ON IVRM_Master_Caste_Category.IMCC_Id = IVRM_Master_Caste.IMCC_Id 
               where  IVRM_Master_Caste_Category.IMCC_Id=" + ddlIMCC_Id.SelectedValue + "";
        db.fill_ddl_no_select(st6, ddlIMC_Id);
        ddlIMC_Id.Items.Insert(0, new ListItem("Select Caste", "0"));

    }
    public void FillReligion()
    {
        st3 = @" select  IVRMMR_Id,IVRMMR_Name from  IVRM_master_Religion where Is_Active = 1 ORDER BY IVRMMR_Name";
        db.fill_ddl_no_select(st3, ddlIVRMMR_Id);
        ddlIVRMMR_Id.Items.Insert(0, new ListItem("Select Religion", "0"));

    }
    public void fillrpt()
    {
        try
        {
            
            st = @" SELECT Adm_School_M_Academic_Year.ASMAY_Id,Adm_School_M_Academic_Year.ASMAY_Year, convert(date,HRMS_DOB,101)HRMS_DOB,HRMS_FatherName,convert(date,HRMS_DOJ,101)HRMS_DOJ,HRMS_MotherName,HRMS_BloodGroup,HRMD_Id,ReligionId ReligionIdee,CasteCategoryId ,CasteId,HRMS_Gender,HRMS_AadharCardNo,Student_Master_Register.HRMS_StudentMiddleName,Student_Master_Register.HRMS_StudentLastName, Student_Master_Register.AMST_Id,(ISNULL(Student_Master_Register.HRMS_StudentFirstName ,'' )+ ' ' + ISNULL(Student_Master_Register.HRMS_StudentMiddleName,'')+' ' + ISNULL(Student_Master_Register.HRMS_StudentLastName,''))
 AS HRMS_StudentName,IVRM_Master_Caste_Category.IMCC_CategoryName,IVRM_Master_Caste.IMC_CasteName,IVRM_Master_Religion.IVRMMR_Name, Student_Master_Register.HRMS_REGNO AS HRMS_REGNO,Student_Master_Register.HRMS_EmailId AS HRMS_EmailId
,Student_Master_Register.HRMS_MobileNo, KVTB_Department.KVTB_DeptName,Student_Master_Register.HRMS_AdmNO ,
                         Student_Master_Register.HRMD_Id,Student_Master_Register.AMSE_ActiveFlag   
                              FROM  Student_Master_Register INNER JOIN
                         KVTB_Department ON Student_Master_Register.HRMD_Id = KVTB_Department.KVTB_DepId 
						  inner join IVRM_Master_Religion on IVRM_Master_Religion.IVRMMR_Id=Student_Master_Register.ReligionId
						  inner join IVRM_Master_Caste_Category on IVRM_Master_Caste_Category.IMCC_Id=Student_Master_Register.CasteCategoryId
						  inner join IVRM_Master_Caste on IVRM_Master_Caste.IMC_Id=Student_Master_Register.CasteId
						  inner join Adm_School_M_Academic_Year on Adm_School_M_Academic_Year.ASMAY_Id = Student_Master_Register.ASMAY_Id
                                               where Student_Master_Register.MI_Id=1";
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
    
    protected void ddlIMCC_Id_SelectedIndexChanged(object sender, EventArgs e)
    {       
        try
        {

            if (ddlIMCC_Id.SelectedItem.Value != null)
            {

                FillCaste();

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
    private void EnableControl()
    {
        HRMS_REGNO.Enabled = true;
     

        btnOK.Visible = true;
    }

    private void DisableControl()
    {
        HRMS_REGNO.Enabled = false;
       
    }
        public void clear()
    {
        
        HRMS_StudentFirstName.Text = ""; HRMS_StudentMiddleName.Text = ""; HRMS_StudentLastName.Text = "";
        HRMS_REGNO.Text = ""; HRMS_FatherName.Text = ""; HRMS_MotherName.Text = ""; 
        ddlHRMD_Id.ClearSelection(); HRMS_DOJ.Text = "";
        ddlASMAY_Id.ClearSelection();
        ddlHRMS_BloodGroup.ClearSelection(); ddlIVRMMR_Id.ClearSelection(); ddlIMCC_Id.ClearSelection();
        ddlIMC_Id.ClearSelection(); HRMS_DOB.Text = ""; HRMS_Gender.ClearSelection();
         HRMS_MobileNo.Text = ""; HRMS_EmailId.Text = ""; HRMS_AadharCardNo.Text = ""; 
        HRMS_REGNO.Text = ""; HRMS_AdmNO.Text = "";

        
    }
    protected void btndept_Click(object sender, EventArgs e)
    {
        if (btnOK.Text.ToUpper() == "SAVE".ToUpper())
        {
            btnOK.Enabled = false;
            string strMessage = "";
            if (AMST_Id.Value != "")
            {
                st = @"Update Student_Master_Register set HRMS_StudentFirstName='" + HRMS_StudentFirstName.Text + "',HRMS_StudentMiddleName='" + HRMS_StudentMiddleName.Text + "' ,HRMS_StudentLastName='" +    HRMS_StudentLastName.Text + "' ," +
                         "HRMS_AdmNO='" + HRMS_AdmNO.Text + "',HRMS_FatherName='" + HRMS_FatherName.Text +          "',HRMS_MotherName='" + HRMS_MotherName.Text + "' " +
                                            ",ASMAY_Id='" + ddlASMAY_Id.SelectedValue + "',HRMS_DOB='" + HRMS_DOB.Text + 
                           "',HRMD_Id='" + ddlHRMD_Id.SelectedValue + "',HRMS_BloodGroup='" + ddlHRMS_BloodGroup.SelectedValue + "'," +
                         "ReligionId='" + ddlIVRMMR_Id.SelectedValue + "',CasteCategoryId='" + ddlIMCC_Id.SelectedValue + "',CasteId='" + ddlIMC_Id.SelectedValue + "'," +
                         "HRMS_Gender='" + HRMS_Gender.SelectedItem.Value + "',HRMS_MobileNo='" + HRMS_MobileNo.Text + "',HRMS_EmailId='" + HRMS_EmailId.Text + "'," +
                         "HRMS_AadharCardNo='" + HRMS_AadharCardNo.Text + "'," +
                             "HRMS_DOJ='" + HRMS_DOJ.Text + "'                                                                      where AMST_Id=" + AMST_Id.Value + "";


                //st = @"Update Student_Master_Register set HRMS_StudentFirstName='" + HRMS_StudentFirstName.Text + "', HRMS_AdmNO=" + HRMS_AdmNO.Text + "," + "HRMS_StudentMiddleName=" + HRMS_StudentMiddleName.Text + "," +
                //    "ASMAY_Year=" + ddlASMAY_Id.SelectedValue + " ,HRMS_StudentLastName='" + HRMS_StudentLastName.Text + "',HRMS_DOB='" + HRMS_DOB.Text + "',HRMS_FatherName='" + HRMS_FatherName.Text + "',HRMS_MotherName='" + HRMS_MotherName.Text + "' " +
                //       "',HRMD_Id='" + ddlHRMD_Id.SelectedValue + 
                //       "',HRMS_BloodGroup='" + ddlHRMS_BloodGroup.SelectedValue + "',ReligionId='" + ddlIVRMMR_Id.SelectedValue + "',CasteCategoryId='" + ddlIMCC_Id.SelectedValue + "',CasteId='" + ddlIMC_Id.SelectedValue + "',HRMS_Gender='" + HRMS_Gender.SelectedItem.Value +  "',HRMS_MobileNo='" + HRMS_MobileNo.Text + "',HRMS_EmailId='" + HRMS_EmailId.Text + "',HRMS_AadharCardNo='" + HRMS_AadharCardNo.Text + "', HRMS_Photo='" + Path.GetExtension(HRMS_Photo.PostedFile.FileName) + "',HRMS_DOJ='" + HRMS_DOJ.Text + "' where AMST_Id=" + AMST_Id.Value + "";

                    x = db.ExeQuery(st);
                    // x = db.return_affectedrow(st);
                    if (x > 0)
                    {
                        dr.Dispose(); db.db_close();
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert();", true);
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "a1", "<script>alert(' Inserted Sucessfully');</script>", false);
                        clear();
                      
                        btnOK.Enabled = true;
                        fillrpt();
                    DisableControl();
                        //  fillrepetr();
                        // EnableControl();
                    return;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "a1", "<script>alert('Not Success');</script>", false);
                    btnOK.Enabled = true;
                    return;
                }

                
            }
            else
            {
                try
                {
                    TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                    DateTime indianTime = TimeZoneInfo.ConvertTime(DateTime.UtcNow, INDIAN_ZONE);

                    st = "Select * from Student_Master_Register where HRMS_REGNO='" + HRMS_REGNO.Text + "'  and MI_Id=1";
                    dr = db.readall(st);
                    if (dr.Read())
                    {

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "a1", "<script>alert('Department Duplicate');</script>", false);

                        dr.Dispose(); db.db_close();
                        btnOK.Enabled = true;
                        return;
                        //clear();
                    }
                    else
                    {
                        db.db_close();
                        st = "";
                        st = @"insert into Student_Master_Register(MI_Id,HRMS_StudentFirstName,HRMS_StudentMiddleName,HRMS_StudentLastName,
                         HRMS_REGNO,HRMS_FatherName,HRMS_DOJ,HRMS_DOB,HRMS_MotherName,HRMD_Id,HRMS_BloodGroup,
                    ReligionId,CasteCategoryId,CasteId,HRMS_Gender,HRMS_MobileNo
             ,HRMS_EmailId,HRMS_AadharCardNo,AMSE_ActiveFlag,HRMS_AdmNO,ASMAY_Id)  output inserted.AMST_Id values ";
                        st += @"(1,'" + HRMS_StudentFirstName.Text + "','" + HRMS_StudentMiddleName.Text + "','" + HRMS_StudentLastName.Text + "'," +
                            "'" + HRMS_REGNO.Text + "','" + HRMS_FatherName.Text + "','" + HRMS_DOJ.Text + "','" + HRMS_DOB.Text + "','" + HRMS_MotherName.Text + "'," +
                              "'" + ddlHRMD_Id.SelectedValue + "','" + ddlHRMS_BloodGroup.SelectedValue + "'," +
                            "'" + ddlIVRMMR_Id.SelectedValue + "','" + ddlIMCC_Id.SelectedValue + "'," +

                            "'" + ddlIMC_Id.SelectedValue + "','" + HRMS_Gender.SelectedItem.Value + "','" + HRMS_MobileNo.Text + "'," +
                            "'" + HRMS_EmailId.Text + "','" + HRMS_AadharCardNo.Text + "','" + '1' + "','" + HRMS_AdmNO.Text + "','" + ddlASMAY_Id.SelectedValue + "')";

                        x = db.return_affectedrow(st);
                        AMST_Id.Value = x.ToString();
                        if (x > 0)
                        {

                            dr.Dispose(); db.db_close();
                            st = "";
                            st = "insert into  IVRM_Staff_User_Login (MI_Id, IVRMSTAUL_UserName, IVRMSTAUL_Password, IVRMSTAUL_ActiveFlag, CreatedDate, UpdatedDate, IVRMSTAUL_CreatedBy, IVRMSTAUL_UpdatedBy, KVTP_RoleFlag, IVRMUL_ID) values";
                            st += @"(1,'" + HRMS_REGNO.Text + "','Password@123',1,getdate(),getdate()," + Session["KVTP_Admin"] + "," + Session["KVTP_Admin"] + ",'STUDENT',  " + AMST_Id.Value + ")";
                            y = db.ExeQuery(st);


                            ScriptManager.RegisterStartupScript(this, this.GetType(), "a1", "<script>alert(' Inserted Sucessfully');</script>", false);
                            clear();
                            
                            btnOK.Enabled = true;
                            fillrpt();
                            return;
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "a1", "<script>alert('Not Success');</script>", false);
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

    protected void btnCancel_Click(object sender, EventArgs e)
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

    protected void btnsavenext_Click(object sender, EventArgs e)
    {

    }

    protected void rptstaffregistation_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "edit")
            {

                //,HRMS_Photo";

                Label HRMSStudentName = (Label)e.Item.FindControl("HRMSStudentName");
                HRMS_StudentFirstName.Text = HRMSStudentName.Text;
                Label HRMSREGNO = (Label)e.Item.FindControl("HRMSREGNO");
                HRMS_REGNO.Text = HRMSREGNO.Text;
                Label HRMSAdmNO = (Label)e.Item.FindControl("HRMSAdmNO");
                HRMS_AdmNO.Text = HRMSAdmNO.Text;

                Label KVTBDeptName = (Label)e.Item.FindControl("KVTBDeptName");
                ddlHRMD_Id.SelectedIndex = ddlHRMD_Id.Items.IndexOf(ddlHRMD_Id.Items.FindByText(KVTBDeptName.Text));
                HiddenField HRMSStudentMiddleName = (HiddenField)e.Item.FindControl("HRMSStudentMiddleName");
                HRMS_StudentMiddleName.Text = HRMSStudentMiddleName.Value;
                HiddenField HRMSStudentLastName = (HiddenField)e.Item.FindControl("HRMSStudentLastName");
                HRMS_StudentLastName.Text = HRMSStudentLastName.Value;

                HiddenField HRMSFatherName = (HiddenField)e.Item.FindControl("HRMSFatherName");
                HRMS_FatherName.Text = HRMSFatherName.Value;
                HiddenField HRMSMotherName = (HiddenField)e.Item.FindControl("HRMSMotherName");
                HRMS_MotherName.Text = HRMSMotherName.Value;


                Label HRMSBloodGroup = (Label)e.Item.FindControl("HRMSBloodGroup");
                ddlHRMS_BloodGroup.SelectedIndex = ddlHRMS_BloodGroup.Items.IndexOf(ddlHRMS_BloodGroup.Items.FindByValue(HRMSBloodGroup.Text));
                FillAcademicYear();
                Label ASMAYYear = (Label)e.Item.FindControl("ASMAYYear");
                ddlASMAY_Id.SelectedIndex = ddlASMAY_Id.Items.IndexOf(ddlASMAY_Id.Items.FindByText(ASMAYYear.Text));
                FillReligion();
                Label IVRMMRName = (Label)e.Item.FindControl("IVRMMRName");
                ddlIVRMMR_Id.SelectedIndex = ddlIVRMMR_Id.Items.IndexOf(ddlIVRMMR_Id.Items.FindByText(IVRMMRName.Text));
                FillCasteCategory();
                Label IMCCCategoryName = (Label)e.Item.FindControl("IMCCCategoryName");
                ddlIMCC_Id.SelectedIndex = ddlIMCC_Id.Items.IndexOf(ddlIMCC_Id.Items.FindByText(IMCCCategoryName.Text));
                FillCaste();
                Label IMCCasteName = (Label)e.Item.FindControl("IMCCasteName");
                ddlIMC_Id.SelectedIndex = ddlIMC_Id.Items.IndexOf(ddlIMC_Id.Items.FindByText(IMCCasteName.Text));

                Label HRMSGender = (Label)e.Item.FindControl("HRMSGender");
                HRMS_Gender.SelectedIndex = HRMS_Gender.Items.IndexOf(HRMS_Gender.Items.FindByValue(HRMSGender.Text));



                Label HRMSMobileNo = (Label)e.Item.FindControl("HRMSMobileNo");
                HRMS_MobileNo.Text = HRMSMobileNo.Text;


                Label HRMSEmailId = (Label)e.Item.FindControl("HRMSEmailId");
                HRMS_EmailId.Text = HRMSEmailId.Text;

                Label HRMSAadharCardNo = (Label)e.Item.FindControl("HRMSAadharCardNo");
                HRMS_AadharCardNo.Text = HRMSAadharCardNo.Text;
                

                Label HRMSDOB = (Label)e.Item.FindControl("HRMSDOB");
                HRMS_DOB.Text = HRMSDOB.Text;
                Label HRMSDOJ = (Label)e.Item.FindControl("HRMSDOJ");
                HRMS_DOJ.Text = HRMSDOJ.Text;
                HiddenField AMSTId = (HiddenField)e.Item.FindControl("AMSTId");
                AMST_Id.Value = AMSTId.Value;
                DisableControl();

            }

            if (e.CommandName == "delete")
            {
                st = "Update Student_Master_Register set AMSE_ActiveFlag=0 where AMST_Id=" + e.CommandArgument + "";
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
                st = "Update  Student_Master_Register set AMSE_ActiveFlag=1 where AMST_Id=" + e.CommandArgument + "";
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

}