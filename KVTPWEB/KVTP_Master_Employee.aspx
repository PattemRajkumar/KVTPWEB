<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KVTP_Master_Employee.aspx.cs" Inherits="KVTP_Master_Employee" %>

<%@ Register Src="~/Navigations/KVTPHeader.ascx" TagPrefix="uc1" TagName="KVTPHeader" %>
<%@ Register Src="~/Navigations/KVTPFooter.ascx" TagPrefix="uc1" TagName="KVTPFooter" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Register</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <%-- <link href="https://code.jquery.com/ui/1.10.4/themes/ui-lightness/jquery-ui.css"
    rel="stylesheet" />

<script src="https://code.jquery.com/jquery-1.10.2.js"></script>
<script src="https://code.jquery.com/ui/1.10.4/jquery-ui.js"></script>--%>
    <style>
        /*.kvt {
            padding: 15px !important;
        }*/

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
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>

    <link href="Sweetalert/sweetalert.min.css" rel="stylesheet" />
    <script src="Sweetalert/sweetalert.min.js"></script>
    <script>
        function Confirm(ctl, event) {
            event.preventDefault();
            swal({
                title: "Are You Sure?",
                text: "Do you  want to Deactive Record?",
                type: "warning",
                showCancelButton: true,
                closeOnConfirm: true,
                closeOnCancel: true
            },
                function (isConfirm) {
                    if (isConfirm) {
                        _doPostBack('btnemployee', 'OnClick');
                    }
                });

            return false;

        }
        function successalert() {
            swal({
                title: 'Data Save /  Update Successfully ',
                type: 'success'
            });
        }
    </script>
</head>

<body class="hold-transition sidebar-mini layout-fixed">
    <uc1:KVTPHeader runat="server" ID="KVTPHeader" />
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server" ID="ddlpanel" UpdateMode="Conditional">
            <Triggers>
                <asp:PostBackTrigger ControlID="btnemployee" />
                <asp:PostBackTrigger ControlID="btnsavenext" />
                <asp:PostBackTrigger ControlID="btncancel" />
                <asp:PostBackTrigger ControlID="HRME_ExpectedRetirementDate" />
                <%--                  <asp:PostBackTrigger ControlID="HRME_Photo" />--%>
            </Triggers>
            <ContentTemplate>
                <div class="content-wrapper">
                    <section class="content-header">
                        <div class="container-fluid">
                            <div class="col-md-12">
                                <div class="card direct-chat direct-chat-warning">
                                    <div class="card-header" style="border-bottom: 1px solid #ff9800; border-top: 3px solid #3a5999">
                                        <h4 class="card-title kvttext1"><b>Master Employee</b></h4>

                                        <div class="card-tools">
                                            <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                                <i class="fas fa-minus"></i>
                                            </button>

                                        </div>

                                    </div>

                                    <div class="card-body">


                                        <div class="col-md-12" style="margin-top: 10px !important">

                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="row">
                                                        <label class="control-label col-md-4">Employee Name:<strong style="color: red; display: inline; font-weight: bolder; margin-left: 7px;">*</strong></label>
                                                        <div class="col-md-8">
                                                            <asp:TextBox runat="server" ID="HRME_EmployeeFirstName" CssClass="form-control val-word" placeholder="First Name" TabIndex="1" ValidationGroup="g1" autocomplete="off"></asp:TextBox>
                                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="HRME_EmployeeFirstName" ErrorMessage="First Name" ValidationGroup="g1" ForeColor="Red"></asp:RequiredFieldValidator>

                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <label class="control-label col-md-4"></label>
                                                        <div class="col-md-4">
                                                            <asp:TextBox runat="server" ID="HRME_EmployeeMiddleName" CssClass="form-control val-word" placeholder="Middel Name" TabIndex="2" autocomplete="off"></asp:TextBox>

                                                        </div>
                                                        <div class="col-md-4">
                                                            <asp:TextBox runat="server" ID="HRME_EmployeeLastName" CssClass="form-control val-word" placeholder="Last Name" TabIndex="3" autocomplete="off"></asp:TextBox>
                                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="HRME_EmployeeLastName" ErrorMessage="Last Name" ValidationGroup="g1" ForeColor="Red"></asp:RequiredFieldValidator>

                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <label class="control-label col-md-4">Employee Code:<strong style="color: red; display: inline; font-weight: bolder;">*</strong></label>
                                                        <div class="col-md-8">
                                                            <asp:TextBox runat="server" ID="HRME_EmployeeCode" CssClass="form-control val-whole" placeholder="Employee Code" TabIndex="4" autocomplete="off"></asp:TextBox>
                                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="HRME_EmployeeCode" ErrorMessage="Employee code" ValidationGroup="g1" ForeColor="Red"></asp:RequiredFieldValidator>

                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <label class="control-label col-md-4">Date Of Join:<strong style="color: red; display: inline; font-weight: bolder;">*</strong></label>
                                                        <div class="col-md-5">
                                                            <asp:TextBox runat="server" ID="HRME_DOJ" CssClass="form-control" TextMode="Date" placeholder="Date Of Join" Style="background-color: #fff"></asp:TextBox>
                                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="HRME_DOJ" ErrorMessage="Date Of Join" ValidationGroup="g1" ForeColor="Red"></asp:RequiredFieldValidator>

                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <label class="control-label col-md-4">Father Name:<!--<strong style="color:red;display:inline; font-weight: bolder; margin-left: 7px;">*</strong>--></label>
                                                        <div class="col-md-8">
                                                            <asp:TextBox runat="server" ID="HRME_FatherName" CssClass="form-control val-word" placeholder="Father Name" autocomplete="off" TabIndex="5"></asp:TextBox>
                                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="HRME_FatherName" ErrorMessage="Father Name" ValidationGroup="g1" ForeColor="Red"></asp:RequiredFieldValidator>

                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <label class="control-label col-md-4">Mother Name:<!--<strong style="color:red;display:inline; font-weight: bolder; margin-left: 7px;">*</strong>--></label>
                                                        <div class="col-md-8">
                                                            <asp:TextBox runat="server" ID="HRME_MotherName" placeholder="Mother Name" CssClass="form-control val-word" autocomplete="off" TabIndex="6"></asp:TextBox>
                                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="HRME_MotherName" ErrorMessage="Mother Name" ValidationGroup="g1" ForeColor="Red"></asp:RequiredFieldValidator>

                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <label class="control-label col-md-4">Employee Type :<strong style="color: red; display: inline; font-weight: bolder;">*</strong></label>
                                                        <div class="col-md-8">
                                                            <asp:DropDownList runat="server" ID="HRME_Type" CssClass="form-control" TabIndex="7">
                                                                <asp:ListItem Value="">--Select Employee Type</asp:ListItem>
                                                                <asp:ListItem Value="PERMENENT">PERMENENT </asp:ListItem>
                                                                <asp:ListItem Value="OTHER">OTHER </asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="HRME_Type" ErrorMessage="Employee Type" ValidationGroup="g1" ForeColor="Red"></asp:RequiredFieldValidator>

                                                        </div>
                                                    </div>

                                                    <div class="row">
                                                        <label class="control-label col-md-4">Employee Group :<strong style="color: red; display: inline; font-weight: bolder;">*</strong></label>
                                                        <div class="col-md-8">
                                                            <asp:DropDownList runat="server" ID="HRM_Gropup" CssClass="form-control" TabIndex="8">
                                                                <asp:ListItem Value="">--Select Group Type</asp:ListItem>
                                                                <asp:ListItem Value="group">Group</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="HRM_Gropup" ErrorMessage="Employee Group" ForeColor="Red"></asp:RequiredFieldValidator>

                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <label class="control-label col-md-4">RoleFlag:</label>
                                                        <div class="col-md-8">
                                                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddlroleFlag" TabIndex="9">
                                                                <asp:ListItem Value="">--Select--</asp:ListItem>
                                                                <asp:ListItem Value="PRINCIPAL">PRINCIPAL</asp:ListItem>
                                                                <asp:ListItem Value="HOD">HOD</asp:ListItem>
                                                                <asp:ListItem Value="STAFF">STAFF</asp:ListItem>
                                                                <asp:ListItem Value="OTHER">OTHER</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlroleFlag" ErrorMessage="Role Flag" ValidationGroup="g1" ForeColor="Red"></asp:RequiredFieldValidator>

                                                        </div>
                                                    </div>
                                                    <div class="row padding">
                                                        <label class="control-label col-md-4">Department :<strong style="color: red;">*</strong></label>
                                                        <div class="col-md-8">
                                                            <asp:DropDownList runat="server" ID="ddlHRMD_Id" CssClass="form-control" OnSelectedIndexChanged="ddlHRMD_Id_SelectedIndexChanged" AutoPostBack="true" RepeatDirection="Horizontal" TabIndex="10">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ErrorMessage="Department" InitialValue="0" Display="Dynamic" SetFocusOnError="true" ForeColor="Red" ValidationGroup="g1" ControlToValidate="ddlHRMD_Id" runat="server" />

                                                            <%-- <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlHRMD_Id" ErrorMessage="Department" ValidationGroup="g1" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                        </div>
                                                    </div>

                                                    <div class="row padding">
                                                        <label class="control-label col-md-4">Designation :<strong style="color: red; display: inline; font-weight: bolder;">*</strong></label>
                                                        <div class="col-md-8">
                                                            <asp:DropDownList runat="server" ID="ddlHRMDES_Id" CssClass="form-control" TabIndex="11">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ErrorMessage="Designation" InitialValue="0" Display="Dynamic" SetFocusOnError="true" ForeColor="Red" ValidationGroup="g1" ControlToValidate="ddlHRMDES_Id" runat="server" />

                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <label class="control-label col-md-4">Subject Taught :</label>
                                                        <div class="col-md-8">
                                                            <asp:TextBox runat="server" ID="HRME_SubjectsTaught" CssClass="form-control val-whole" placeholder="Subject Taught" TabIndex="12" AutoComplete="off"></asp:TextBox>
                                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="HRME_SubjectsTaught" ErrorMessage="Subject Taught" ForeColor="Red"></asp:RequiredFieldValidator>

                                                        </div>
                                                    </div>




                                                </div>

                                                <div class="col-md-6">
                                                    <div class="row">
                                                        <div class="col-md-8">
                                                            <div class="row padding">
                                                                <label class="control-label col-md-6">Religion:<strong style="color: red; display: inline; font-weight: bolder; margin-left: 7px;">*</strong></label>
                                                                <div class="col-md-6">

                                                                    <asp:DropDownList runat="server" ID="ddlIVRMMR_Id" CssClass="form-control" TabIndex="15"></asp:DropDownList>
                                                                    <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="ddlIVRMMR_Id" ErrorMessage="Religion" ValidationGroup="g1" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                                    <asp:RequiredFieldValidator ErrorMessage="Religion" InitialValue="0" Display="Dynamic" SetFocusOnError="true" ForeColor="Red" ValidationGroup="g1" ControlToValidate="ddlIVRMMR_Id" runat="server" />
                                                                </div>
                                                            </div>

                                                            <div class="row padding">
                                                                <label class="control-label col-md-6">Caste Category:<strong style="color: red; display: inline; font-weight: bolder; margin-left: 7px;">*</strong></label>
                                                                <div class="col-md-6">
                                                                    <asp:DropDownList runat="server" ID="ddlIMCC_Id" CssClass="form-control" OnSelectedIndexChanged="ddlIMCC_Id_SelectedIndexChanged" AutoPostBack="true" TabIndex="14"></asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ErrorMessage="Caste Category" InitialValue="0" Display="Dynamic" SetFocusOnError="true" ForeColor="Red" ValidationGroup="g1" ControlToValidate="ddlIMCC_Id" runat="server" />

                                                                </div>
                                                            </div>

                                                            <div class="row padding">
                                                                <label class="control-label col-md-6">Caste:<strong style="color: red; display: inline; font-weight: bolder; margin-left: 7px;">*</strong></label>
                                                                <div class="col-md-6">

                                                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlIMC_Id" TabIndex="15">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ErrorMessage="Caste" InitialValue="0" Display="Dynamic" SetFocusOnError="true" ForeColor="Red" ValidationGroup="g1" ControlToValidate="ddlIMC_Id" runat="server" />

                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <label class="control-label col-md-6">Date Of Birth:<strong style="color: red; display: inline; font-weight: bolder; margin-left: 7px;">*</strong></label>
                                                                <div class="col-md-6">
                                                                    <asp:TextBox runat="server" ID="HRME_DOB" CssClass="form-control" placeholder="Date Of Birth" TabIndex="16" TextMode="Date"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="HRME_DOB" ErrorMessage="Date Of Birth" ValidationGroup="g1" ForeColor="Red"></asp:RequiredFieldValidator>

                                                                </div>

                                                            </div>
                                                            <div class="row padding">
                                                                <label class="control-label col-md-6">
                                                                    Retirement Date:
                                                                </label>
                                                                <div class="col-md-6">
                                                                    <asp:TextBox runat="server" ID="HRME_ExpectedRetirementDate" CssClass="form-control" placeholder="Retirement Date" TabIndex="17" TextMode="Date"></asp:TextBox>

                                                                </div>

                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="row padding text-center">
                                                                <div style="width: 70%; height: 120px; border: 1px solid #ccc; margin: auto;">
                                                                    <img id="Image1" style="width: 100%; height: 120px; cursor: none;" />
                                                                    <%--<asp:Image ID="Image1" runat="server" Style="width: 100%; height: 120px; cursor: none;" />--%>
                                                                    <label>
                                                                        <asp:FileUpload runat="server" ID="HRME_Photo" TabIndex="18" />
                                                                        <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="HRME_Photo" ErrorMessage="*****" ValidationGroup="g1" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                        <asp:RegularExpressionValidator ID="regexValidator" runat="server" ControlToValidate="HRME_Photo" ErrorMessage="Only JPEG images are allowed" ValidationExpression="(.*\.([Jj][Pp][Gg])|.*\.([Jj][Pp][Ee][Gg])$)" ValidationGroup="G1" ForeColor="Red">  </asp:RegularExpressionValidator>

                                                                        <asp:CustomValidator ControlToValidate="HRME_Photo" ClientValidationFunction="HRME_Photo" runat="server" ErrorMessage="file must be below 1000 kb!" ForeColor="Red" ValidationGroup="g1"></asp:CustomValidator>--%>
                                                                    </label>
<%--                                                                    <div class="col-sm-1">
                                                <asp:Button ID="btnUpload" CssClass="btn btn-primary" Text="Upload" runat="server" OnClick="UploadFile" />
                                            </div>--%>
                                                                </div>

                                                            </div>

                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <label class="control-label col-md-4">Gender:<strong style="color: red; display: inline; font-weight: bolder; margin-left: 7px;">*</strong></label>
                                                        <div class="col-md-8">
                                                            <asp:DropDownList runat="server" CssClass="form-control" ID="HRME_Gender" TabIndex="19">
                                                                <asp:ListItem Value="">-Select Gender --</asp:ListItem>
                                                                <asp:ListItem Value="Male">Male</asp:ListItem>
                                                                <asp:ListItem Value="Female">Female</asp:ListItem>
                                                                <asp:ListItem Value="Other">Other</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="HRME_Gender" ErrorMessage="Gender" ValidationGroup="g1" ForeColor="Red"></asp:RequiredFieldValidator>

                                                        </div>
                                                    </div>
                                                    <div class="row padding">
                                                        <label class="control-label col-md-4">Marital Status :<strong style="color: red; display: inline; font-weight: bolder;">*</strong></label>
                                                        <div class="col-md-8">
                                                            <asp:DropDownList ID="HRME_Material" CssClass="form-control" runat="server" TabIndex="20">
                                                                <asp:ListItem Value="">-Marital Status --</asp:ListItem>
                                                                <asp:ListItem Value="Married">Married</asp:ListItem>
                                                                <asp:ListItem Value="Unmarried">Unmarried</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <label class="control-label col-md-4">
                                                            Mobile No: <span style="color: red">*</span>
                                                        </label>
                                                        <div class="col-md-8">
                                                            <asp:TextBox runat="server" ID="HRME_MobileNo" CssClass="form-control val-whole" placeholder="Mobile Number" TabIndex="21" autocomplete="off"></asp:TextBox>
                                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="HRME_MobileNo" ErrorMessage="Mobile Number" ValidationGroup="insert" ForeColor="Red"></asp:RequiredFieldValidator>

                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="HRME_MobileNo" Display="Dynamic" ErrorMessage=" Phone Number" ForeColor="Red" ToolTip="Please Enter Proper Email" ValidationExpression="^([7-9]{1})([0-9]{9})$" ValidationGroup="g1"></asp:RegularExpressionValidator>

                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <label class="control-label col-md-4">
                                                            Email Id:<span style="color: red">*</span>
                                                        </label>
                                                        <div class="col-md-8">
                                                            <asp:TextBox runat="server" ID="HRME_EmailId" CssClass="form-control" placeholder="Email Id" TabIndex="22" autocomplete="off"></asp:TextBox>
                                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="HRME_EmailId" ErrorMessage="EmailId" ValidationGroup="g1" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="HRME_EmailId" Display="Dynamic" ErrorMessage="Enter Proper Email" ForeColor="Red" ToolTip="Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="g1"></asp:RegularExpressionValidator>

                                                        </div>

                                                    </div>
                                                    <div class="row padding">
                                                        <label class="control-label col-md-4">Aadhar No:</label>
                                                        <div class="col-md-8">
                                                            <asp:TextBox runat="server" ID="HRME_AadharCardNo" CssClass="form-control val-whole" placeholder="Aadhar Number" MaxLength="12" TabIndex="23" autocomplete="off"></asp:TextBox>

                                                        </div>
                                                    </div>

                                                    <div class="row padding">
                                                        <label class="control-label col-md-4">PAN Card No.:</label>
                                                        <div class="col-md-8">
                                                            <asp:TextBox runat="server" ID="HRME_PANCardNo" CssClass="form-control word-num" placeholder="PAN Card Number" MaxLength="9" TabIndex="24" autocomplete="off"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                    <div class="row padding">
                                                        <label class="control-label col-md-4">Identification Mark :</label>
                                                        <div class="col-md-8">
                                                            <asp:TextBox runat="server" ID="HRME_IdentificationMark" CssClass="form-control" placeholder="Identification Mark" TabIndex="25" autocomplete="off"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="row padding">
                                                        <label class="control-label col-md-4">Qulification  :</label>
                                                        <div class="col-md-8">
                                                            <asp:TextBox runat="server" ID="HRME_Qulification" CssClass="form-control val-word" placeholder="Qulification" TabIndex="26" autocomplete="off"></asp:TextBox>
                                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="HRME_Qulification" ErrorMessage="Qulification" ValidationGroup="g1" ForeColor="Red"></asp:RequiredFieldValidator>


                                                        </div>
                                                    </div>
                                                    <div class="row padding">
                                                        <label class="control-label col-md-4">Blood Group:</label>
                                                        <div class="col-md-8">
                                                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddlHRME_BloodGroup" TabIndex="14">
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
                                                            <%-- <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlHRME_BloodGroup" ErrorMessage="Blood Group" ValidationGroup="g1" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>

                                            <div class="padding" style="text-align: center">
                                                <asp:HiddenField runat="server" ID="HRME_Id" />
                                                <asp:Button runat="server" ID="btnemployee" CssClass="btn btn-primary" OnClick="btnemployee_Click" Text="SAVE/NEXT" ValidationGroup="g1" TabIndex="15" />
                                                <asp:Button runat="server" ID="btnsavenext" CssClass="btn btn-warning" OnClick="btnsavenext_Click" Text="CANCEL" ValidationGroup="g3" TabIndex="16" />

                                                <asp:Button runat="server" ID="btncancel" CssClass="btn btn-danger" OnClick="btncancel_Click" Text="Clear" ValidationGroup="g2" TabIndex="17" />


                                            </div>

                                        </div>


                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="card direct-chat direct-chat-warning">
                                    <div class="card-header" style="border-bottom: 1px solid #ff9800; border-top: 3px solid #3a5999">
                                        <h4 class="card-title kvttext1"><b>Master Employee Details</b></h4>

                                        <div class="card-tools">
                                            <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                                <i class="fas fa-minus"></i>
                                            </button>

                                        </div>

                                    </div>

                                    <div class="card-body">
                                        <div class="row">
                                            <div class="col-md-12 padding">
                                                <div class="col-md-4">
                                                </div>
                                                <div class="col-md-4">
                                                </div>
                                                <div class="col-md-4" style="text-align: right !important">
                                                    <input type="text" id="txtsearch" class="form-control" placeholder="search here...." />
                                                </div>
                                            </div>
                                            <div class="col-md-12 padding">
                                                <br />
                                                <table class="table  table-bordered table-condensed" id="tabaledemo">
                                                    <asp:Repeater runat="server" ID="rptstaffregistation" OnItemCommand="rptstaffregistation_ItemCommand">
                                                        <HeaderTemplate>
                                                            <thead style="background-color: #3a5999 !important; color: #fff !important">
                                                                <tr>
                                                                    <th>Sl No</th>
                                                                    <th>NAME</th>
                                                                    <th>Employee Code
                                                                    </th>
                                                                    <th>Department Name</th>
                                                                    <th>Designation Name
                                                                    </th>

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
                                                                        <asp:HiddenField runat="server" Value='<%#Eval("HRME_Id") %>' ID="HRMEId" />
                                                                        <asp:HiddenField runat="server" Value='<%#Eval("HRME_EmployeeMiddleName") %>' ID="HRMEEmployeeMiddleName" />
                                                                        <asp:HiddenField runat="server" Value='<%#Eval("HRME_EmployeeLastName") %>' ID="HRMEEmployeeLastName" />
                                                                        <asp:HiddenField runat="server" Value='<%#Eval("HRME_FatherName") %>' ID="HRMEFatherName" />
                                                                        <asp:HiddenField runat="server" Value='<%#Eval("HRME_MotherName") %>' ID="HRMEMotherName" />
                                                                        <asp:Label runat="server" Text='<%#Eval("HRME_Type") %>' Visible="false" ID="HRMEType"></asp:Label>
                                                                        <asp:Label runat="server" Text='<%#Eval("HRM_Gropup") %>' Visible="false" ID="HRMGropup"></asp:Label>
                                                                        <asp:HiddenField runat="server" Value='<%#Eval("HRMD_Id") %>' ID="HRMDId" />
                                                                        <asp:HiddenField runat="server" Value='<%#Eval("HRMDES_Id") %>' ID="HRMDESId" />
                                                                        <asp:Label runat="server" Text='<%#Eval("HRME_SubjectsTaught") %>' Visible="false" ID="HRMESubjectsTaught"></asp:Label>
                                                                        <asp:Label runat="server" Text='<%#Eval("HRME_BloodGroup") %>' Visible="false" ID="HRMEBloodGroup"></asp:Label>
                                                                        <asp:HiddenField runat="server" Value='<%#Eval("ReligionId") %>' ID="ReligionIdee" />
                                                                        <asp:HiddenField runat="server" Value='<%#Eval("CasteCategoryId") %>' ID="CasteCategoryId" />
                                                                        <asp:HiddenField runat="server" Value='<%#Eval("CasteId") %>' ID="CasteId" />
                                                                        <asp:Label runat="server" Text='<%#Eval("HRME_Gender") %>' Visible="false" ID="HRMEGender"></asp:Label>
                                                                        <asp:Label runat="server" Text='<%#Eval("HRME_Material") %>' Visible="false" ID="HRMEMaterial"></asp:Label>
                                                                        <asp:Label runat="server" Text='<%#Eval("HRME_PANCardNo") %>' Visible="false" ID="HRMEPANCardNo"></asp:Label>
                                                                        <asp:Label runat="server" Text='<%#Eval("HRME_Qulification") %>' Visible="false" ID="HRMEQulification"></asp:Label>
                                                                        <asp:Label runat="server" Text='<%#Eval("HRME_AadharCardNo") %>' Visible="false" ID="HRMEAadharCardNo"></asp:Label>
                                                                        <asp:Label runat="server" Text='<%#Eval("HRME_IdentificationMark") %>' Visible="false" ID="HRMEIdentificationMark"></asp:Label>
                                                                        <asp:Label runat="server" Text='<%#Eval("KVTP_RoleFlag") %>' Visible="false" ID="KVTPRoleFlag"></asp:Label>
                                                                        <asp:Label runat="server" Text='<%#Eval("HRME_DOJ") %>' Visible="false" ID="HRMEDOJ"></asp:Label>

                                                                        <asp:Label runat="server" Text='<%#Eval("HRME_DOB") %>' Visible="false" ID="HRMEDOB"></asp:Label>
                                                                        <asp:Label runat="server" Text='<%#Eval("HRME_ExpectedRetirementDate") %>' Visible="false" ID="HRMEExpectedRetirementDate"></asp:Label>


                                                                    </td>

                                                                    <td>
                                                                        <asp:Label runat="server" Text='<%#Eval("HRME_EmployeeFirstName") %>' ID="HRMEEmployeeFirstName"></asp:Label>


                                                                    </td>
                                                                    <td>
                                                                        <asp:Label runat="server" Text='<%#Eval("HRME_EmployeeCode") %>' ID="HRMEEmployeeCode"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label runat="server" Text='<%#Eval("KVTB_DeptName") %>'></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label runat="server" Text='<%#Eval("HRMDES_DesignationName") %>'></asp:Label>
                                                                    </td>

                                                                    <td>
                                                                        <asp:Label runat="server" Text='<%#Eval("HRME_MobileNo") %>' ID="HRMEMobileNo"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label runat="server" Text='<%#Eval("HRME_EmailId") %>' ID="HRMEEmailId"></asp:Label>
                                                                    </td>

                                                                    <td>
                                                                        <span>
                                                                            <asp:LinkButton runat="server" ID="btnLogout" CssClass="text-green" Text="Activate" CommandName="deletetwo" CommandArgument='<%#Eval("HRME_Id") %>' OnClientClick="return Confirm();" ValidationGroup="g3" Visible='<%# Convert.ToInt32(Eval("HRME_ActiveFlag")).Equals(0)? true:false %>' UseSubmitBehavior="False"></asp:LinkButton>

                                                                        </span>
                                                                        <span>
                                                                            <asp:LinkButton runat="server" CssClass="text-danger" Text="Deactivate" CommandName="delete" CommandArgument='<%#Eval("HRME_Id") %>' OnClientClick="return Confirm();" ValidationGroup="g3" Visible='<%# Convert.ToInt32(Eval("HRME_ActiveFlag")).Equals(1)? true:false %>' UseSubmitBehavior="False"></asp:LinkButton>

                                                                        </span>

                                                                        <span>
                                                                            <asp:LinkButton runat="server" CssClass="fas fa-edit" Text="edit" CommandName="edit" CommandArgument='<%#Eval("HRME_Id") %>' ValidationGroup="g4" Visible='<%# Convert.ToInt32(Eval("HRME_ActiveFlag")).Equals(1)? true:false %>' UseSubmitBehavior="False"></asp:LinkButton>

                                                                        </span>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </table>
                                                <div class="pagination-page"></div>
                                            </div>
                                        </div>

                                    </div>


                                </div>

                            </div>
                        </div>
                    </section>

                </div>



            </ContentTemplate>

            <%--<Triggers>
                <asp:PostBackTrigger ControlID="HRME_DOJ" />
                <asp:PostBackTrigger ControlID="HRME_ExpectedRetirementDate" />
                <asp:PostBackTrigger ControlID="HRME_DOB" />
            </Triggers>--%>
        </asp:UpdatePanel>


    </form>
    <uc1:KVTPFooter runat="server" ID="KVTPFooter" />
</body>
</html>
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
<script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.11.2/jquery-ui.min.js"></script>

<script src="pagination.js"></script>
<script src="pagination_min.js"></script>
<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.4/jquery.min.js"></script>
<script src="https://code.jquery.com/jquery-1.8.0.min.js"></script>
<script type="text/javascript">
    validate();

    $(document).ready(function () {
    
        $('#tabaledemo').paging({
            limit: 7
        });
        //$('.pagination-page').pagination({
        //    items: 100,
        //    itemsOnPage: 5,
        //    cssStyle: 'light-theme'
        //});
        $("#txtsearch").change(function () {
            quicksearch('table tbody tr');

        });

        $("#HRME_Photo").change(function () {
            var allowedFiles = [".jpg", ".jpeg", ".png ", ".JPG", ".JPEG", ".PNG"];
            // var allowedFiles = [".pdf"];
            var fileUpload = document.getElementById("HRME_Photo");
            var regex = new RegExp("([a-zA-Z0-9\s_\\.\-:])+(" + allowedFiles.join('|') + ")$");
            if (!regex.test(fileUpload.value.toLowerCase())) {
                alert(" File Upload Must be allowed jpg/jpeg/png !");
                $('#HRME_Photo').val(null);
                return false;
            }
            else {
                var image = document.getElementById('Image1');
                image.src = URL.createObjectURL(event.target.files[0]);
                $('#HRME_Photo').val(null);
                // return true;
            }

            //------valiadtioninsie-----
            var file_size = $('#HRME_Photo')[0].files[0].size;
            if (file_size > 1000000) {
                alert('File size is below 1 Kb');
                $('#HRME_Photo').val(null);
                return false;
            }
            else {
                return true;
            }
        });
    });

    function validate() {
        // $("#HRME_ExpectedRetirementDate").datepicker({
        //    changeMonth: true,
        //    forceParse: false,
        //    keyboardNavigation: false,
        //    changeYear: true,
        //    dateFormat: 'dd-mm-yy',
        //    autoclose: true
        //});

        //$("#HRME_DOB").datepicker({
        //    changeMonth: true,
        //    forceParse: false,
        //    keyboardNavigation: false,
        //    changeYear: true,
        //    dateFormat: 'dd-mm-yy',
        //    autoclose: true
        //});
        //$("#HRME_DOJ").datepicker({
        //    changeMonth: true,
        //    forceParse: false,
        //    keyboardNavigation: false,
        //    changeYear: true,
        //    dateFormat: 'dd-mm-yy',
        //    autoclose: true
        //});
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


</script>
