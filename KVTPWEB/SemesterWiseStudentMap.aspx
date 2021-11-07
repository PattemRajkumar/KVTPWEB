<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SemesterWiseStudentMap.aspx.cs" Inherits="SemesterWiseStudentMap" %>

<%@ Register Src="~/Navigations/KVTPHeader.ascx" TagPrefix="uc1" TagName="KVTPHeader" %>
<%@ Register Src="~/Navigations/KVTPFooter.ascx" TagPrefix="uc1" TagName="KVTPFooter" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title></title>
  <meta charset="utf-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1"/>
  <link rel="stylesheet" href="Sweetalert/sweetalert.min.css" />
<script src="Sweetalert/sweetalert.min.js"></script>

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
                var ddlASMAY_Id = document.getElementById("ddlASMAY_Id");

            document.getElementById("ddlASMAY_Id").style.borderColor = "";
            if (ddlASMAY_Id.options[ddlASMAY_Id.selectedIndex].text == '' || ddlASMAY_Id.options[ddlASMAY_Id.selectedIndex].text.toUpperCase() == 'SELECT' || ddlASMAY_Id.options[ddlASMAY_Id.selectedIndex].text == 'Select Academic Year') {

                alert("First Select Correct Academic Year.");
                document.getElementById("ddlASMAY_Id").focus();

                document.getElementById("ddlASMAY_Id").style.borderColor = "Red";
                return false;
               }
                
               
                  var ddl_Department = document.getElementById("ddl_Department");

            document.getElementById("ddl_Department").style.borderColor = "";
            if (ddl_Department.options[ddl_Department.selectedIndex].text == '' || ddl_Department.options[ddl_Department.selectedIndex].text.toUpperCase() == 'SELECT' || ddl_Department.options[ddl_Department.selectedIndex].text == 'Select Department Name') {

                alert("First Select Correct Department Name.");
                document.getElementById("ddl_Department").focus();

                document.getElementById("ddl_Department").style.borderColor = "Red";
                return false;
               }
               
                var ddl_Semester = document.getElementById("ddl_Semester");
               
            document.getElementById("ddl_Semester").style.borderColor = "";
            if (ddl_Semester.options[ddl_Semester.selectedIndex].text == '' || ddl_Semester.options[ddl_Semester.selectedIndex].text.toUpperCase() == 'SELECT' || ddl_Semester.options[ddl_Semester.selectedIndex].text == 'Select Semester Name') {

                alert("First Select Correct Semester Name.");
                document.getElementById("ddl_Semester").focus();

                document.getElementById("ddl_Semester").style.borderColor = "Red";
                return false;
            }
                var ddl_Student = document.getElementById("ddl_Student");

            document.getElementById("ddl_Student").style.borderColor = "";
            if (ddl_Student.options[ddl_Student.selectedIndex].text == '' || ddl_Student.options[ddl_Student.selectedIndex].text.toUpperCase() == 'SELECT'  || ddl_Student.options[ddl_Student.selectedIndex].text == 'Select Student Name') {

                alert("First Select Correct Student Name.");
                document.getElementById("ddl_Student").focus();

                document.getElementById("ddl_Student").style.borderColor = "Red";
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
         <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>  
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="content-wrapper">
            <section class="content-header">
                <div class="container-fluid">
                    <div class="col-md-12">
                        <div class="card direct-chat direct-chat-warning">
                            <div class="card-header"  style="border-bottom: 1px solid #ff9800;border-top: 3px solid #3a5999">
                                <h4 class="card-title kvttext1"> <b>Semester Wise Student Mapping</b></h4>
                                <div class="card-tools">
                                    <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                        <i class="fas fa-minus"></i>
                                    </button>
                                </div>
                            </div>
                            <div class="card-body" ">
                               <div class="row kvt" >
                                   <div class="col-md-3"></div>
                                   <div class="col-md-6 ">
                                      <div class="row padding">
                                                        <label class="control-label col-md-4">Academic Year :<strong style="color: red; display: inline; font-weight: bolder; margin-left: 7px;">*</strong></label>
                                                        <div class="col-md-8">
                                                            <asp:DropDownList runat="server" ID="ddlASMAY_Id" CssClass="form-control"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                        <div class="row padding">
                                            <label class="col-md-4 kvttext">Department Name<span style="color: red">*</span></label>
                                            <div class="col-md-8">
                                             <asp:DropDownList ID="ddl_Department" CssClass="form-control" runat="server"  AutoPostBack="True" OnSelectedIndexChanged="ddl_Departmen_SelectedIndexChanged">
                                </asp:DropDownList>
                                                </div>

                                        </div>
                                        
                                       
                                        <div class="row padding">
                                            <label class="col-md-4 kvttext">Semester Name<span style="color: red">*</span></label>
                                            <div class="col-md-8">
                                             <asp:DropDownList ID="ddl_Semester" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                                                </div>

                                        </div>
                                        
                                        <div class="row padding">
                                            <label class="col-md-4 kvttext">Student Name<span style="color: red">*</span></label>
                                            <div class="col-md-8">
                                             <asp:DropDownList ID="ddl_Student" CssClass="form-control" runat="server" >
                                </asp:DropDownList>
                                                </div>

                                        </div>
                                      
                                       <br />
                                         <div class="row">
                                                    <asp:HiddenField runat="server" ID="SemStud_Id" />
                                                <div class="col-md-12" style="text-align:center">
                                                    <asp:Button runat="server" ID="btnOK" CssClass="btn btn-primary" Text="SAVE" OnClick="btndept_Click" OnClientClick="return InputValidate(this);" ValidationGroup="g1"   /> &nbsp;&nbsp;
                                                    <asp:Button runat="server" ID="btncansel" CssClass="btn btn-warning" Text="CANCEL" OnClick="btnCancel_Click"  OnClientClick="return InputValidateCancel(this);" ValidationGroup="g2" />                                                  </div>
                                            
                                                  

                                       </div>
                               </div>
                                   <div class="col-md-3"> </div>     
                                    </div>
                            </div>   
                        </div>
                    </div>
                      <div class="col-md-12">
                        <div class="card direct-chat direct-chat-warning">
                            <div class="card-header"  style="border-bottom: 1px solid #ff9800;border-top: 3px solid #3a5999">
                                <h4 class="card-title kvttext1"> <b>Semester Wise Student Mapping</b></h4>
                                <div class="card-tools">
                                    <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                        <i class="fas fa-minus"></i>
                                    </button>
                                </div>
                            </div>
                            <div class="card-body" ">
                                <br />
                                <div class="col-md-12"  style="overflow-x:auto !important;">
                          <table class="table table-hover table-bordered table-condensed">
                          <asp:Repeater runat="server" ID="rptdescdep" OnItemCommand="rptdescdep_ItemCommand">
                          <HeaderTemplate>
                          <thead style="background-color:#3a5999 !important;color:#fff !important">
                              <tr>
                             <th>Sl No</th>
                                           <th>Academic Year</th>
                                           <th>
                                               Department Name
                                           </th>
                               <th>
                                               Semester Name
                                           </th>
                            
                                           <th>
                                               Student Name
                                           </th>
                                           <th>
                                               Action
                                           </th>
                              </tr>
                          </thead>

                          </HeaderTemplate>
                          <ItemTemplate>
                      <tbody>
                          <tr>
                              <td>
                                   <asp:Label runat="server" Text='<%#Container.ItemIndex + 1 %>' ></asp:Label>
                             
                              </td>
                               <td>
                                    <asp:HiddenField runat="server" Value='<%#Eval("SemStud_Id") %>' ID="HRMSUBId"/>
                                     
                                    <asp:Label runat="server" Text='<%#Eval("ASMAY_Year") %>' ID="ASMAYYear"></asp:Label>
                               </td>
                               <td>
                                    <asp:Label runat="server" Text='<%#Eval("KVTB_DeptName") %>' ID="KVTBDeptName"></asp:Label>

                                   </td>
                               <td>
                                    <asp:Label runat="server" Text='<%#Eval("HRMSEM_SemisterName") %>' ID="HRMSEMSemisterName"></asp:Label>

                               </td>
                              
                              <td>
                                    
                                    <asp:Label runat="server" Text='<%#Eval("HRMS_StudentName") %>' ID="HRMSStudentName"></asp:Label>
                                
                               </td>
                             
                             
                               <td>  <span>
                                     <asp:LinkButton runat="server" CssClass="fas fa-edit" Text="edit" CommandName="edit" CommandArgument='<%#Eval("SemStud_Id") %>' ValidationGroup="g4" UseSubmitBehavior="False"></asp:LinkButton>
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
            title: "Confirm  Do U Want Deactive ?",
            text: "Do you really want  Deactive ?",
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