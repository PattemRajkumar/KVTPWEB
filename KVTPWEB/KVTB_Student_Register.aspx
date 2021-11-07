<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KVTB_Student_Register.aspx.cs" Inherits="KVTB_Student_Register" %>



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
</head>

<body class="hold-transition sidebar-mini layout-fixed">
    <uc1:KVTPHeader runat="server" ID="KVTPHeader" />
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <div class="content-wrapper">
            <section class="content-header">
                <div class="container-fluid">
                    <div class="col-md-12">
                        <div class="card direct-chat direct-chat-warning">
                            <div class="card-header" style="border-bottom: 1px solid #ff9800;border-top: 3px solid #3a5999">
                                <h4 class="card-title kvttext1"> <b>STDUENT REGISTER</b></h4>

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
                                                      <div class="row kvt">
                                        <div class="col-md-6">
                                            <div class="row padding">
                                                <label class="control-label col-md-4">Student Name:<strong style="color: red; display: inline; font-weight: bolder; margin-left: 7px;">*</strong></label>
                                                <div class="col-md-8">
                                                    <asp:TextBox runat="server" ID="amsT_FirstName" CssClass="form-control" placeholder="First Name" TabIndex="1"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="row padding">
                                                <label class="control-label col-md-4"></label>
                                                <div class="col-md-4">
                                                    <asp:TextBox runat="server" ID="TextBox1" CssClass="form-control" placeholder="Middel Name" TabIndex="2"></asp:TextBox>

                                                </div>
                                                <div class="col-md-4 padding">
                                                    <asp:TextBox runat="server" ID="amsT_MiddleName" CssClass="form-control" placeholder="Last Name" TabIndex="3"></asp:TextBox>

                                                </div>
                                            </div>

                                            <div class="row padding">
                                                <label class="control-label col-md-4">Academic Year :<strong style="color: red; display: inline; font-weight: bolder; margin-left: 7px;">*</strong></label>
                                                <div class="col-md-8">
                                                    <asp:TextBox runat="server" ID="allAcademicYear" CssClass="form-control" placeholder="Academic Year"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="row padding">
                                                <label class="control-label col-md-4">RegNo :<strong style="color: red; display: inline; font-weight: bolder; margin-left: 7px;">*</strong></label>
                                                <div class="col-md-8">
                                                    <asp:TextBox runat="server" ID="amsT_RegistrationNo" CssClass="form-control" placeholder="RegNo"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="row padding">
                                                <label class="control-label col-md-4">Admission No:<strong style="color: red; display: inline; font-weight: bolder; margin-left: 7px;">*</strong></label>
                                                <div class="col-md-8">
                                                    <asp:TextBox runat="server" ID="amsT_AdmNo" CssClass="form-control" placeholder="Admission No:"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="row padding">
                                                <label class="control-label col-md-4">Date of Admission :</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox runat="server" ID="amsT_Date" CssClass="form-control" placeholder="Date of Admission "></asp:TextBox>

                                                </div>
                                            </div>
                                            <div class="row padding">
                                                <label class="control-label col-md-4">Date Of Birth:</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox runat="server" ID="DOB" placeholder="Select date" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="row padding">
                                                <label class="control-label col-md-6">Caste Category:<strong style="color: red; display: inline; font-weight: bolder; margin-left: 7px;">*</strong></label>
                                                <div class="col-md-6">
                                                    <asp:DropDownList runat="server" ID="ddlIMCC_Id" CssClass="form-control"  AutoPostBack="true"></asp:DropDownList>

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
                                                <label class="control-label col-md-4">Student Birth Place :</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox runat="server" ID="amsT_BirthPlace" placeholder="Student Birth Place" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="row padding">
                                                <label class="control-label col-md-4">Caste Certificate No:</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox runat="server" ID="amsT_StuCasteCertiNo" placeholder="Caste Certificate No" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="row padding">
                                                <label class="control-label col-md-4">Govt.Admno :</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox runat="server" ID="amsT_GovtAdmno" placeholder="Govt.Admno " CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="row padding">
                                                <label class="control-label col-md-4">Student PAN Card No :</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox runat="server" ID="amsT_StudentPANNo" placeholder="Student PAN Card No " CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>


                                            <div class="row padding">
                                                <label class="control-label col-md-4">Age :</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox runat="server" ID="pasR_Age" placeholder="enter Age" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="row padding">
                                                <label class="control-label col-md-4">Gender:<strong style="color: red; display: inline; font-weight: bolder; margin-left: 7px;">*</strong></label>
                                                <div class="col-md-8">
                                                    <asp:DropDownList runat="server" CssClass="form-control" ID="HRME_Gender">
                                                        <asp:ListItem Value="">-select Gender --</asp:ListItem>
                                                        <asp:ListItem Value="Male">Male</asp:ListItem>
                                                        <asp:ListItem Value="Female">Female</asp:ListItem>
                                                        <asp:ListItem Value="Other">Other</asp:ListItem>
                                                    </asp:DropDownList>

                                                </div>
                                            </div>

                                            <div class="row padding">
                                                <label class="control-label col-md-6">Religion:<strong style="color: red; display: inline; font-weight: bolder; margin-left: 7px;">*</strong></label>
                                                <div class="col-md-6">

                                                    <asp:DropDownList runat="server" ID="ddlIVRMMR_Id" CssClass="form-control"></asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="row padding">
                                                <label class="control-label col-md-6">Nationality:<strong style="color: red; display: inline; font-weight: bolder; margin-left: 7px;">*</strong></label>
                                                <div class="col-md-6">

                                                    <asp:DropDownList runat="server" ID="ddlIVRMMC_Id" CssClass="form-control"></asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="row padding">
                                                <label class="control-label col-md-6">State:<strong style="color: red; display: inline; font-weight: bolder; margin-left: 7px;">*</strong></label>
                                                <div class="col-md-6">

                                                    <asp:DropDownList runat="server" ID="ddlAMST_State" CssClass="form-control"></asp:DropDownList>
                                                </div>
                                            </div>

   

                                        </div>
                                        <div class="col-md-6">
                                            <div class="row">
                                                <div class="col-md-8">
                                               

                                              
                                                    <div class="row padding">
                                                        <label class="control-label col-md-6">Date Of Birth:<strong style="color: red; display: inline; font-weight: bolder; margin-left: 7px;">*</strong></label>
                                                        <div class="col-md-6">
                                                            <asp:TextBox runat="server" ID="HRME_DOB" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                                        </div>

                                                    </div>
                                                    <div class="row padding">
                                                        <label class="control-label col-md-6">
                                                            Retirement Date:
                                                        </label>
                                                        <div class="col-md-6">
                                                            <asp:TextBox runat="server" ID="HRME_ExpectedRetirementDate" CssClass="form-control" TextMode="Date"></asp:TextBox>

                                                        </div>

                                                    </div>
                                                </div>
                                                <div class="col-md-4" style="padding-bottom: 5px;">
                                                    <div class="row padding text-center">
                                                        <div style="width: 70%; height: 120px; border: 1px solid #ccc; margin: auto;">
                                                            <img src="https://dcampusstrg.blob.core.windows.net/files/17/EmployeeProfilePics/ba54c96f-f099-4f00-b8a1-8aa262ba298e.jpg" style="width: 100%; height: 120px; cursor: none;" id="blah" />
                                                        </div>
                                                        <label style="width: 70%; margin: auto;">
                                                            <asp:FileUpload runat="server" ID="HRME_Photo" ForeColor="Green" />
                                                        </label>

                                                    </div>

                                                </div>
                                            </div>
                                       
                                            <div class="row padding">
                                                <label class="control-label col-md-4">Marital Status :<strong style="color: red; display: inline; font-weight: bolder; margin-left: 7px;">*</strong></label>
                                                <div class="col-md-8">
                                                    <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server">
                                                        <asp:ListItem Value="">-Marital Status --</asp:ListItem>
                                                        <asp:ListItem Value="Married">Married</asp:ListItem>
                                                        <asp:ListItem Value="Unmarried">Unmarried</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="row padding">
                                                <label class="control-label col-md-4">
                                                    Mobile No.:
                                                </label>
                                                <div class="col-md-8">
                                                    <asp:TextBox runat="server" ID="TextBox2" CssClass="form-control" placeholder="Mobile Number"></asp:TextBox>

                                                </div>
                                            </div>
                                            <div class="row padding ">
                                                <label class="control-label col-md-4">
                                                    Email Id:
                                                </label>
                                                <div class="col-md-8">
                                                    <asp:TextBox runat="server" ID="TextBox3" CssClass="form-control" placeholder=" Email Id"></asp:TextBox>
                                                </div>

                                            </div>
                                            <div class="row padding">
                                                <label class="control-label col-md-4">Aadhar No:</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox runat="server" ID="TextBox4" CssClass="form-control" placeholder="Aadhar Number"></asp:TextBox>

                                                </div>
                                            </div>

                                            <div class="row padding">
                                                <label class="control-label col-md-4">PAN Card No.:</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox runat="server" ID="TextBox5" CssClass="form-control" placeholder="PAN Card Number"></asp:TextBox>

                                                </div>
                                            </div>
                                            <div class="row padding">
                                                <label class="control-label col-md-4">Identification Mark :</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox runat="server" ID="HRME_IdentificationMark" CssClass="form-control" placeholder="Identification Mark"></asp:TextBox>
                                                </div>
                                            </div>
                                                                                     <div class="row padding">
                                                <label class="control-label col-md-4">Blood Group:</label>
                                                <div class="col-md-8">
                                                    <asp:DropDownList runat="server" CssClass="form-control">
                                                        <asp:ListItem Value="">--Select--</asp:ListItem>
                                                        <asp:ListItem value="">--Select--</asp:ListItem>
                                                        <asp:ListItem value="A+">A+</asp:ListItem>
                                                        <asp:ListItem value="A-">A-</asp:ListItem>
                                                        <asp:ListItem value="B+">B+</asp:ListItem>
                                                        <asp:ListItem value="B-">B-</asp:ListItem>
                                                        <asp:ListItem value="AB+">AB+</asp:ListItem>
                                                        <asp:ListItem value="AB-">AB-</asp:ListItem>
                                                        <asp:ListItem value="O+">O+</asp:ListItem>
                                                        <asp:ListItem value="O-">O-</asp:ListItem>
                                                    </asp:DropDownList>

                                                </div>
                                            </div>

                                            <div class="row padding">
                                                <label class="control-label col-md-4">Father's Name: :<strong style="color: red; display: inline; font-weight: bolder; margin-left: 7px;">*</strong></label>
                                                <div class="col-md-8">
                                                    <asp:TextBox runat="server" ID="amsT_FatherAliveFlag" CssClass="form-control" placeholder="Father's Name"></asp:TextBox>
                                                </div>
                                            </div>
                                    

                                            <div class="row padding">
                                                <label class="control-label col-md-4">Marital Status :<strong style="color: red; display: inline; font-weight: bolder; margin-left: 7px;">*</strong></label>
                                                <div class="col-md-8">
                                                    <asp:DropDownList ID="HRME_Material" CssClass="form-control" runat="server">
                                                        <asp:ListItem Value="">-Marital Status --</asp:ListItem>
                                                        <asp:ListItem Value="Married">Married</asp:ListItem>
                                                        <asp:ListItem Value="Unmarried">Unmarried</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="row padding">
                                                <label class="control-label col-md-4">
                                                    Mobile No.:
                                                </label>
                                                <div class="col-md-8">
                                                    <asp:TextBox runat="server" ID="HRME_MobileNo" CssClass="form-control" placeholder="Mobile Number"></asp:TextBox>

                                                </div>
                                            </div>
                                            <div class="row padding ">
                                                <label class="control-label col-md-4">
                                                    Email Id:
                                                </label>
                                                <div class="col-md-8">
                                                    <asp:TextBox runat="server" ID="HRME_EmailId" CssClass="form-control" placeholder=" Email Id"></asp:TextBox>
                                                </div>

                                            </div>
                                            <div class="row padding">
                                                <label class="control-label col-md-4">Aadhar No:</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox runat="server" ID="HRME_AadharCardNo" CssClass="form-control" placeholder="Aadhar Number"></asp:TextBox>

                                                </div>
                                            </div>

                                            <div class="row padding">
                                                <label class="control-label col-md-4">PAN Card No.:</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox runat="server" ID="HRME_PANCardNo" CssClass="form-control" placeholder="PAN Card Number"></asp:TextBox>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>


                        </div>

                    </div>
                    <div class="col-md-12">
                        <div class="card direct-chat direct-chat-warning">
                            <div class="card-header" style="border-bottom: 1px solid #ff9800;border-top: 3px solid #3a5999">
                                <h4 class="card-title kvttext1"> <b>STUDENT DETAILS</b></h4>

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
    </form>
    <uc1:KVTPFooter runat="server" ID="KVTPFooter" />
</body>
</html>
