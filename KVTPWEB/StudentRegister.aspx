<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentRegister.aspx.cs" Inherits="StudentRegister" %>

<%@ Register Src="~/Navigations/KVTPHeader.ascx" TagPrefix="uc1" TagName="KVTPHeader" %>
<%@ Register Src="~/Navigations/KVTPFooter.ascx" TagPrefix="uc1" TagName="KVTPFooter" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Register</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <style>
        .kvt {
            padding: 15px !important;
        }

        .kvttext {
            font-size: 14px !important;
        }

        .kvttext1 {
            font-size: 17px !important;
            color: #3a5999 !important;
        }

        .padding {
            padding-bottom: 10px !important;
        }
    </style>
      <script>

           function InputValidate(myButton) {

                var HRMS_StudentFirstName = document.getElementById("HRMS_StudentFirstName").value;

            document.getElementById("HRMS_StudentFirstName").style.borderColor = "";
            if (HRMS_StudentFirstName == "") {
                alert("First  Enter Student First Name.");
                document.getElementById("HRMS_StudentFirstName").focus();
                document.getElementById("HRMS_StudentFirstName").style.borderColor = "Red";
                return false;
               }
               var ddlASMAY_Id = document.getElementById("ddlASMAY_Id");

            document.getElementById("ddlASMAY_Id").style.borderColor = "";
            if (ddlASMAY_Id.options[ddlASMAY_Id.selectedIndex].text == '' || ddlASMAY_Id.options[ddlASMAY_Id.selectedIndex].text.toUpperCase() == 'SELECT' || ddlASMAY_Id.options[ddlASMAY_Id.selectedIndex].text == 'Select Academic Year') {

                alert("First Select Correct Academic Year.");
                document.getElementById("ddlASMAY_Id").focus();

                document.getElementById("ddlASMAY_Id").style.borderColor = "Red";
                return false;
               }
                 var HRMS_REGNO = document.getElementById("HRMS_REGNO").value;

            document.getElementById("HRMS_REGNO").style.borderColor = "";
            if (HRMS_REGNO == "") {
                alert("First  Enter Register Number.");
                document.getElementById("HRMS_REGNO").focus();
                document.getElementById("HRMS_REGNO").style.borderColor = "Red";
                return false;
               }
                 var HRMS_AdmNO = document.getElementById("HRMS_AdmNO").value;

            document.getElementById("HRMS_AdmNO").style.borderColor = "";
            if (HRMS_AdmNO == "") {
                alert("First  Enter Adimission Number.");
                document.getElementById("HRMS_AdmNO").focus();
                document.getElementById("HRMS_AdmNO").style.borderColor = "Red";
                return false;
               }
               
              var HRMS_FatherName = document.getElementById("HRMS_FatherName").value;
              document.getElementById("HRMS_FatherName").style.borderColor = "";
            if (HRMS_FatherName == "") {
                alert("First  Enter Father Name.");
                document.getElementById("HRMS_FatherName").focus();
                document.getElementById("HRMS_FatherName").style.borderColor = "Red";
                return false;
            }
            var HRMS_MotherName = document.getElementById("HRMS_MotherName").value;
              document.getElementById("HRMS_MotherName").style.borderColor = "";
            if (HRMS_MotherName == "") {
                alert("First  Enter Mother Name.");
                document.getElementById("HRMS_MotherName").focus();
                document.getElementById("HRMS_MotherName").style.borderColor = "Red";
                return false;
            }

             

                 var ddlHRMD_Id = document.getElementById("ddlHRMD_Id");

            document.getElementById("ddlHRMD_Id").style.borderColor = "";
            if (ddlHRMD_Id.options[ddlHRMD_Id.selectedIndex].text == '' || ddlHRMD_Id.options[ddlHRMD_Id.selectedIndex].text.toUpperCase() == 'SELECT' || ddlHRMD_Id.options[ddlHRMD_Id.selectedIndex].text == 'Select Department Name') {

                alert("First Select Correct Department Name.");
                document.getElementById("ddlHRMD_Id").focus();

                document.getElementById("ddlHRMD_Id").style.borderColor = "Red";
                return false;
               }

               var HRMS_DOJ = document.getElementById("HRMS_DOJ").value;
              document.getElementById("HRMS_DOJ").style.borderColor = "";
            if (HRMS_DOJ == "") {
                alert("First  Enter Date of Joinig.");
                document.getElementById("HRMS_DOJ").focus();
                document.getElementById("HRMS_DOJ").style.borderColor = "Red";
                return false;
            }
                var ddlIVRMMR_Id = document.getElementById("ddlIVRMMR_Id");

            document.getElementById("ddlIVRMMR_Id").style.borderColor = "";
            if (ddlIVRMMR_Id.options[ddlIVRMMR_Id.selectedIndex].text == '' || ddlIVRMMR_Id.options[ddlIVRMMR_Id.selectedIndex].text.toUpperCase() == 'SELECT' || ddlIVRMMR_Id.options[ddlIVRMMR_Id.selectedIndex].text == 'Select Religion') {

                alert("First Select Correct Religion.");
                document.getElementById("ddlIVRMMR_Id").focus();

                document.getElementById("ddlIVRMMR_Id").style.borderColor = "Red";
                return false;
               }
               
                var ddlIMC_Id = document.getElementById("ddlIMC_Id");

            document.getElementById("ddlIMC_Id").style.borderColor = "";
            if (ddlIMC_Id.options[ddlIMC_Id.selectedIndex].text == '' || ddlIMC_Id.options[ddlIMC_Id.selectedIndex].text.toUpperCase() == 'SELECT' || ddlIMC_Id.options[ddlIVRMMR_Id.selectedIndex].text == 'Select Caste Category') {

                alert("First Select Correct Caste Category.");
                document.getElementById("ddlIMC_Id").focus();

                document.getElementById("ddlIMC_Id").style.borderColor = "Red";
                return false;
               }

                var ddlIMCC_Id = document.getElementById("ddlIMCC_Id");

            document.getElementById("ddlIMCC_Id").style.borderColor = "";
            if (ddlIMCC_Id.options[ddlIMCC_Id.selectedIndex].text == '' || ddlIMCC_Id.options[ddlIMCC_Id.selectedIndex].text.toUpperCase() == 'SELECT' || ddlIMCC_Id.options[ddlIMCC_Id.selectedIndex].text == 'Select Caste') {

                alert("First Select Correct Caste.");
                document.getElementById("ddlIMCC_Id").focus();

                document.getElementById("ddlIMCC_Id").style.borderColor = "Red";
                return false;
               }
               
               var HRMS_DOB = document.getElementById("HRMS_DOB").value;
              document.getElementById("HRMS_DOB").style.borderColor = "";
            if (HRMS_DOB == "") {
                alert("First  Enter Date Of Birth.");
                document.getElementById("HRMS_DOB").focus();
                document.getElementById("HRMS_DOB").style.borderColor = "Red";
                return false;
            }
              var HRMS_Gender = document.getElementById("HRMS_Gender");

            document.getElementById("HRMS_Gender").style.borderColor = "";
            if (HRMS_Gender.options[HRMS_Gender.selectedIndex].text == '' || HRMS_Gender.options[HRMS_Gender.selectedIndex].text.toUpperCase() == 'SELECT' || HRMS_Gender.options[HRMS_Gender.selectedIndex].text == 'Select Gender') {

                alert("First Select Correct Caste.");
                document.getElementById("HRMS_Gender").focus();

                document.getElementById("HRMS_Gender").style.borderColor = "Red";
                return false;
               }

            var btnOK = document.getElementById("btnOK").value;
            if (btnOK == "Delete") {
                if (confirm('Are you sure you want to Delete the Record ?')) {
                    return true;
                } else {
                    return false;
                }
            }
                
            else  if (btnOK == "Update") {
                if (confirm('Are you sure you want to Update the Record ?')) {
                    return true;
                } else {
                    return false;
                }
            }
            {
                if (confirm('Are you sure you want to save?')) {
                    return true;
                } else {
                    return false;
                }
            }

            return true;

        }
        function InputValidateCancel(myButton) {

            if (confirm('Are you sure you want to Cancel?')) {
                return true;
            } else {
                return false;
            }

            return true;

        }
    </script>
</head>

<body class="hold-transition sidebar-mini layout-fixed">
    <uc1:KVTPHeader runat="server" ID="KVTPHeader" />
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server" ID="ddlpanel">
            <ContentTemplate>
                <div class="content-wrapper">
                    <section class="content-header">
                        <div class="container-fluid">
                            <div class="col-md-12">
                                <div class="card direct-chat direct-chat-warning">
                                    <div class="card-header" style="border-bottom: 1px solid #ff9800; border-top: 3px solid #3a5999">
                                        <h4 class="card-title kvttext1"><b>Student Register</b></h4>

                                        <div class="card-tools">
                                            <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                                <i class="fas fa-minus"></i>
                                            </button>

                                        </div>

                                    </div>

                                    <div class="card-body">


                                        <div class="col-md-12" style="margin-top: 10px !important">
                                           
                                            <div class="row kvt">
                                                <div class="col-md-6">
                                                    <div class="row padding">
                                                        <label class="control-label col-md-4">Student Name:<strong style="color: red; display: inline; font-weight: bolder; margin-left: 7px;">*</strong></label>
                                                        <div class="col-md-8">
                                                            <asp:TextBox runat="server" ID="HRMS_StudentFirstName" CssClass="form-control" placeholder="First Name" TabIndex="1"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="row padding">
                                                        <label class="control-label col-md-4"></label>
                                                        <div class="col-md-4">
                                                            <asp:TextBox runat="server" ID="HRMS_StudentMiddleName" CssClass="form-control" placeholder="Middel Name" TabIndex="2"></asp:TextBox>

                                                        </div>
                                                        <div class="col-md-4 padding">
                                                            <asp:TextBox runat="server" ID="HRMS_StudentLastName" CssClass="form-control" placeholder="Last Name" TabIndex="3"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                    <div class="row padding">
                                                        <label class="control-label col-md-4">Academic Year :<strong style="color: red; display: inline; font-weight: bolder; margin-left: 7px;">*</strong></label>
                                                        <div class="col-md-8">
                                                            <asp:DropDownList runat="server" ID="ddlASMAY_Id" CssClass="form-control"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <%-- HRMS_AdmisionRegster--%>
                                                    <div class="row padding">
                                                        <label class="control-label col-md-4">Register Number:<strong style="color: red; display: inline; font-weight: bolder; margin-left: 7px;">*</strong></label>
                                                        <div class="col-md-8">
                                                            <asp:TextBox runat="server" ID="HRMS_REGNO" CssClass="form-control" placeholder="Register Number"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="row padding">
                                                        <label class="control-label col-md-4">Admission Number:<strong style="color: red; display: inline; font-weight: bolder; margin-left: 7px;">*</strong></label>
                                                        <div class="col-md-8">
                                                            <asp:TextBox runat="server" ID="HRMS_AdmNO" CssClass="form-control" placeholder="Admission Number"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="row padding">
                                                        <label class="control-label col-md-4">Father Name:<strong style="color:red;display:inline; font-weight: bolder; margin-left: 7px;">*</strong></label>
                                                        <div class="col-md-8">
                                                            <asp:TextBox runat="server" ID="HRMS_FatherName" CssClass="form-control" placeholder="Father Name"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                    <div class="row padding">
                                                        <label class="control-label col-md-4">Mother Name:<strong style="color:red;display:inline; font-weight: bolder; margin-left: 7px;">*</strong></label>
                                                        <div class="col-md-8">
                                                            <asp:TextBox runat="server" ID="HRMS_MotherName" placeholder="Mother Name" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                  

                                                    <div class="row padding">
                                                        <label class="control-label col-md-4">Department :<strong style="color: red; display: inline; font-weight: bolder; margin-left: 7px;">*</strong></label>
                                                        <div class="col-md-8">
                                                            <asp:DropDownList runat="server" ID="ddlHRMD_Id" CssClass="form-control">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>

                                                    


                                                    <div class="row padding">
                                                        <label class="control-label col-md-4">Date Of Join:<strong style="color: red; display: inline; font-weight: bolder; margin-left: 7px;">*</strong></label>
                                                        <div class="col-md-8">
                                                            <asp:TextBox runat="server" ID="HRMS_DOJ" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="row padding">
                                                        <label class="control-label col-md-4">Blood Group:</label>
                                                        <div class="col-md-8">
                                                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddlHRMS_BloodGroup">
                                                                <asp:ListItem Value="">--Select--</asp:ListItem>
                                                                <asp:ListItem Value="">--Select--</asp:ListItem>
                                                                <asp:ListItem Value="A+">A+</asp:ListItem>
                                                                <asp:ListItem Value="A-">A-</asp:ListItem>
                                                                <asp:ListItem Value="B+">B+</asp:ListItem>
                                                                <asp:ListItem Value="B-">B-</asp:ListItem>
                                                                <asp:ListItem Value="AB+">AB+</asp:ListItem>
                                                                <asp:ListItem Value="AB-">AB-</asp:ListItem>
                                                                <asp:ListItem Value="O+">O+</asp:ListItem>
                                                                <asp:ListItem Value="O-">O-</asp:ListItem>
                                                            </asp:DropDownList>

                                                        </div>
                                                    </div>

                                                </div>

                                                <div class="col-md-6">
                                                    <div class="row">
                                                        <div class="col-md-8">
                                                            <div class="row padding">
                                                                <label class="control-label col-md-6">Religion:<strong style="color: red; display: inline; font-weight: bolder; margin-left: 7px;">*</strong></label>
                                                                <div class="col-md-6">

                                                                    <asp:DropDownList runat="server" ID="ddlIVRMMR_Id" CssClass="form-control"></asp:DropDownList>
                                                                </div>
                                                            </div>

                                                            <div class="row padding">
                                                                <label class="control-label col-md-6">Caste Category:<strong style="color: red; display: inline; font-weight: bolder; margin-left: 7px;">*</strong></label>
                                                                <div class="col-md-6">
                                                                    <asp:DropDownList runat="server" ID="ddlIMCC_Id" CssClass="form-control" OnSelectedIndexChanged="ddlIMCC_Id_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>

                                                                </div>
                                                            </div>

                                                            <div class="row padding">
                                                                <label class="control-label col-md-6">Caste:<strong style="color: red; display: inline; font-weight: bolder; margin-left: 7px;">*</strong></label>
                                                                <div class="col-md-6">

                                                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlIMC_Id">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                            <div class="row padding">
                                                                <label class="control-label col-md-6">Date Of Birth:<strong style="color: red; display: inline; font-weight: bolder; margin-left: 7px;">*</strong></label>
                                                                <div class="col-md-6">
                                                                    <asp:TextBox runat="server" ID="HRMS_DOB" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                                                </div>

                                                            </div>

                                                        </div>
                                                        <div class="col-md-4" style="padding-bottom: 5px;">
                                                            <div class="row padding text-center">
                                                                <div style="width: 70%; height: 120px; border: 1px solid #ccc; margin: auto;">
                                                                    <img src="https://dcampusstrg.blob.core.windows.net/files/17/EmployeeProfilePics/1fc89e1e-52d4-4da3-8dc4-e2663ae4dcac.jpg" style="width: 100%; height: 120px; cursor: none;" id="blah" />
                                                                </div>
                                                                <label style="width: 70%; margin: auto;">
                                                                    <asp:FileUpload runat="server" ID="HRMS_Photo" ForeColor="Green" />
                                                                </label>

                                                            </div>

                                                        </div>
                                                    </div>
                                                    <div class="row padding">
                                                        <label class="control-label col-md-4">Gender:<strong style="color: red; display: inline; font-weight: bolder; margin-left: 7px;">*</strong></label>
                                                        <div class="col-md-8">
                                                            <asp:DropDownList runat="server" CssClass="form-control" ID="HRMS_Gender">
                                                                <asp:ListItem Value="">-Select Gender --</asp:ListItem>
                                                                <asp:ListItem Value="Male">Male</asp:ListItem>
                                                                <asp:ListItem Value="Female">Female</asp:ListItem>
                                                                <asp:ListItem Value="Other">Other</asp:ListItem>
                                                            </asp:DropDownList>

                                                        </div>
                                                    </div>
                                                   
                                                    <div class="row padding">
                                                        <label class="control-label col-md-4">
                                                            Mobile No.:
                                                        </label>
                                                        <div class="col-md-8">
                                                            <asp:TextBox runat="server" ID="HRMS_MobileNo" CssClass="form-control" placeholder="Mobile Number"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                    <div class="row padding ">
                                                        <label class="control-label col-md-4">
                                                            Email Id:
                                                        </label>
                                                        <div class="col-md-8">
                                                            <asp:TextBox runat="server" ID="HRMS_EmailId" CssClass="form-control" placeholder=" Email Id"></asp:TextBox>
                                                        </div>

                                                    </div>
                                                    <div class="row padding">
                                                        <label class="control-label col-md-4">Aadhar No:</label>
                                                        <div class="col-md-8">
                                                            <asp:TextBox runat="server" ID="HRMS_AadharCardNo" CssClass="form-control" placeholder="Aadhar Number"></asp:TextBox>

                                                        </div>
                                                    </div>


                                                </div>

                                            </div>

<%--                                            <div class="kvt" style="text-align: center">
                                                <asp:HiddenField runat="server" ID="AMST_Id" />
                                                <asp:Button runat="server" ID="btnemployee" CssClass="btn btn-primary" OnClick="btnemployee_Click" Text="SAVE/NEXT" ValidationGroup="g1" />
                                                <asp:Button runat="server" ID="btnsavenext" CssClass="btn btn-warning" OnClick="btnsavenext_Click" Text="CANCEL" ValidationGroup="g3" />

                                                <asp:Button runat="server" ID="btncancel" CssClass="btn btn-danger" OnClick="btncancel_Click" Text="Clear" ValidationGroup="g2" />


                                            </div>--%>

                                              <div class="row">
                                                    <asp:HiddenField runat="server" ID="AMST_Id" />
                                                <div class="col-md-12" style="text-align:center">
                                                    <asp:Button runat="server" ID="btnOK" CssClass="btn btn-primary" Text="SAVE" OnClick="btndept_Click" OnClientClick="return InputValidate(this);" ValidationGroup="g1"   /> &nbsp;&nbsp;
                                                    <asp:Button runat="server" ID="btncansel" CssClass="btn btn-warning" Text="CANCEL" OnClick="btnCancel_Click"  OnClientClick="return InputValidateCancel(this);" ValidationGroup="g2" />                                                  </div>
                                            
                                                  

                                       </div>

                                        </div>


                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="card direct-chat direct-chat-warning">
                                    <div class="card-header" style="border-bottom: 1px solid #ff9800; border-top: 3px solid #3a5999">
                                        <h4 class="card-title kvttext1"><b>Student Register Details</b></h4>

                                        <div class="card-tools">
                                            <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                                <i class="fas fa-minus"></i>
                                            </button>

                                        </div>

                                    </div>

                                    <div class="card-body">
                                        <div class="row">
                                            <div class="row kvt">
                                                <div class="col-md-12">
                                                    <div class="row padding">

                                                        <div class="col-md-12" style="overflow-x: auto !important;">
                                                            <table class="table  table-bordered table-condensed">
                                                                <asp:Repeater runat="server" ID="rptstaffregistation" OnItemCommand="rptstaffregistation_ItemCommand">
                                                                    <HeaderTemplate>
                                                                        <thead style="background-color: #3a5999 !important; color: #fff !important">
                                                                            <tr>
                                                                                <th>Sl No</th>
                                                                                <th>NAME</th>
                                                                                 
                                                                                <th>Registation Number
                                                                                </th>

                                                                              <th>
                                                                                  Admission Number
                                                                              </th>
                                                              <th>Department Name</th>
                                                                                <th>Mobile Number
                                                                                </th>
                                                                                <th>Email ID
                                                                                </th>
                                                                                <th>Action
                                                                                </th>
                                                                            </tr>
                                                                        </thead>

                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <tbody>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label runat="server" Text='<%#Container.ItemIndex + 1 %>'></asp:Label>
                                                                                    <asp:HiddenField runat="server" Value='<%#Eval("AMST_Id") %>' ID="AMSTId" />
                                                                                                                           <asp:HiddenField runat="server" Value='<%#Eval("HRMS_StudentMiddleName") %>' ID="HRMSStudentMiddleName" />
                                                                        <asp:HiddenField runat="server" Value='<%#Eval("HRMS_StudentLastName") %>' ID="HRMSStudentLastName" />
                                                                        <asp:HiddenField runat="server" Value='<%#Eval("HRMS_FatherName") %>' ID="HRMSFatherName" />
                                                                        <asp:HiddenField runat="server" Value='<%#Eval("HRMS_MotherName") %>' ID="HRMSMotherName" />
                                                                       
                                                                        
                                                                        <asp:Label runat="server" Text='<%#Eval("HRMS_BloodGroup") %>' Visible="false" ID="HRMSBloodGroup"></asp:Label>
                                                                                     <asp:Label runat="server" Text='<%#Eval("ASMAY_Year") %>' Visible="false" ID="ASMAYYear"></asp:Label>
                                                                                    <asp:Label runat="server" Text='<%#Eval("IVRMMR_Name") %>' Visible="false" ID="IVRMMRName"></asp:Label>
                                                                       <asp:Label runat="server" Text='<%#Eval("IMCC_CategoryName") %>' Visible="false" ID="IMCCCategoryName"></asp:Label>
                                                                       <asp:Label runat="server" Text='<%#Eval("IMC_CasteName") %>' Visible="false" ID="IMCCasteName"></asp:Label>
                                                                      
                                                                        <asp:Label runat="server" Text='<%#Eval("HRMS_Gender") %>' Visible="false" ID="HRMSGender"></asp:Label>
                                                                        <asp:Label runat="server" Text='<%#Eval("HRMS_AadharCardNo") %>' Visible="false" ID="HRMSAadharCardNo"></asp:Label>
                                                                        
                                                                       

                                                                        <asp:Label runat="server" Text='<%#Eval("HRMS_DOB") %>' Visible="false" ID="HRMSDOB"  ></asp:Label>
                                                                                       <asp:Label runat="server" Text='<%#Eval("HRMS_DOJ") %>' Visible="false" ID="HRMSDOJ" TextMode="Date"></asp:Label>

                                                                                </td>

                                                                                <td>
                                                                                    <asp:Label runat="server" Text='<%#Eval("HRMS_StudentName") %>' ID="HRMSStudentName"></asp:Label>


                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label runat="server" Text='<%#Eval("HRMS_REGNO") %>' ID="HRMSREGNO"></asp:Label>
                                                                                </td>
                                                                                 <td>
                                                                                    <asp:Label runat="server" Text='<%#Eval("HRMS_AdmNO") %>' ID="HRMSAdmNO"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label runat="server" Text='<%#Eval("KVTB_DeptName") %>' ID="KVTBDeptName"></asp:Label>
                                                                                </td>
                                                                              

                                                                                <td>
                                                                                    <asp:Label runat="server" Text='<%#Eval("HRMS_MobileNo") %>' ID="HRMSMobileNo"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label runat="server" Text='<%#Eval("HRMS_EmailId") %>' ID="HRMSEmailId"></asp:Label>
                                                                                </td>

                                                                                <td>
                                                                                    <span>
                                                                                        <asp:LinkButton runat="server" ID="btnLogout" CssClass="text-green" Text="Activate" CommandName="deletetwo" CommandArgument='<%#Eval("AMST_Id") %>' OnClientClick="return confirm('are you sure you want to delete?')" ValidationGroup="g3" Visible='<%# Convert.ToInt32(Eval("AMSE_ActiveFlag")).Equals(0)? true:false %>'></asp:LinkButton>

                                                                                    </span>
                                                                                    <span>
                                                                                        <asp:LinkButton runat="server" CssClass="text-danger" Text="Deactivate" CommandName="delete" CommandArgument='<%#Eval("AMST_Id") %>' OnClientClick="return confirm('are you sure you want to delete?')" ValidationGroup="g3" Visible='<%# Convert.ToInt32(Eval("AMSE_ActiveFlag")).Equals(1)? true:false %>'></asp:LinkButton>

                                                                                    </span>

                                                                                     <span>
                                                                            <asp:LinkButton runat="server" CssClass="fas fa-edit" Text="edit" CommandName="edit" CommandArgument='<%#Eval("AMST_Id") %>' ValidationGroup="g4" Visible='<%# Convert.ToInt32(Eval("AMSE_ActiveFlag")).Equals(1)? true:false %>' UseSubmitBehavior="False"></asp:LinkButton>

                                                                        </span>


                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </ItemTemplate>
                                                                </asp:Repeater>
                                                            </table>


                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                    </div>


                                </div>

                            </div>
                        </div>
                    </section>

                </div>
            </ContentTemplate>
        </asp:UpdatePanel>


    </form>
    <uc1:KVTPFooter runat="server" ID="KVTPFooter" />
</body>
</html>
<script type="text/javascript">
    validate();


    function validate() {
        $('.val-whole').bind('keyup blur', function () {
            $(this).val($(this).val().replace(/[^0-9]/g, ''));
        });
        $('.val-deci').bind('keyup blur', function () {
            $(this).val($(this).val().replace(/[^0-9,\.]/g, ''));
        });
        $('.word-num').bind('keyup blur', function () {
            $(this).val($(this).val().replace(/[^a-z,A-Z,\s,0-9,\#\@]/g, ''));
        });
        $('.val-word').bind('keyup blur', function () {
            $(this).val($(this).val().replace(/[^a-z,A-Z,\s]/g, ''))
        });
    };
    Sys.WebForms.PageRequestManager.getInstance().add_initializeRequest(intiatefunction)
    function intiatefunction(sender, args) {
        validate();



    }
    function Confirm(ctl, event) {
        event.preventDefault();
        swal({
            title: "Confirm Logout?",
            text: "Do you really want to log this Account out?",
            type: "warning",
            showCancelButton: true,
            closeOnConfirm: true,
            closeOnCancel: true
        },
            function (isConfirm) {
                if (isConfirm) {
                    _doPostBack('btnLogout', 'OnClick');
                }
            });

        return false;

    }

</script>
