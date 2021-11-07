<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MasterDesignations.aspx.cs" Inherits="MasterDesignations" %>

<%@ Register Src="~/Navigations/KVTPHeader.ascx" TagPrefix="uc1" TagName="KVTPHeader" %>
<%@ Register Src="~/Navigations/KVTPFooter.ascx" TagPrefix="uc1" TagName="KVTPFooter" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Master Designations</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
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

                var KVTB_DeptName = document.getElementById("KVTB_DeptName").value;

            document.getElementById("KVTB_DeptName").style.borderColor = "";
            if (KVTB_DeptName == "") {
                alert("First  Enter Department Name.");
                document.getElementById("KVTB_DeptName").focus();
                document.getElementById("KVTB_DeptName").style.borderColor = "Red";
                return false;
            }
                 var KVTB_DeptCode = document.getElementById("KVTB_DeptCode").value;

            document.getElementById("KVTB_DeptCode").style.borderColor = "";
            if (KVTB_DeptCode == "") {
                alert("First  Enter Department Code.");
                document.getElementById("KVTB_DeptCode").focus();
                document.getElementById("KVTB_DeptCode").style.borderColor = "Red";
                return false;
               }
                 var KVTB_Order = document.getElementById("KVTB_Order").value;

            document.getElementById("KVTB_Order").style.borderColor = "";
            if (KVTB_Order == "") {
                alert("First  Enter Department Order.");
                document.getElementById("KVTB_Order").focus();
                document.getElementById("KVTB_Order").style.borderColor = "Red";
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
        <div class="content-wrapper">
            <section class="content-header">
                <div class="container-fluid">
                    <div class="col-md-12">
                        <div class="card direct-chat direct-chat-warning">
                            <div class="card-header" style="border-bottom: 1px solid #ff9800; border-top: 3px solid #3a5999">
                                <h4 class="card-title kvttext1"><b>Master Designation</b></h4>

                                <div class="card-tools">
                                    <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                        <i class="fas fa-minus"></i>
                                    </button>

                                </div>

                            </div>

                            <div class="card-body">
                                <div class="row kvt">
                                    <div class="col-md-3">
                                    </div>
                                    <div class="col-md-6 ">
                                        <div class="row padding">
                                            <label class="col-md-4 kvttext">Department Name<span style="color: red">*</span></label>
                                            <div class="col-md-8">
                                             <asp:DropDownList ID="ddl_Department" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                                                </div>

                                        </div>

                                        <div class="row padding">
                                            <label class="col-md-4 kvttext">Designation Name<span style="color: red">*</span></label>
                                            <div class="col-md-8">
                                                <asp:TextBox runat="server" CssClass="form-control" placeholder="Designation  Name" ID="HRMDES_DesignationName" autocomplete="off"></asp:TextBox>
                                            </div>

                                        </div>
                                        <div class="row padding">
                                            <label class="col-md-4 kvttext">Designation Order <span style="color: red">*</span></label>
                                            <div class="col-md-8">
                                                <asp:TextBox runat="server" CssClass="form-control" placeholder="Designation Order" ID="HRMDES_Order" autocomplete="off"></asp:TextBox>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">

                                            <div class="col-md-12" style="text-align: center">
                                                <asp:Button runat="server" ID="btndesighn" CssClass="btn btn-primary" Text="SAVE" ValidationGroup="g1" OnClick="btndesighn_Click"  OnClientClick="return InputValidate(this);"/>
                                                &nbsp;&nbsp;
                                                    <asp:Button runat="server" ID="btncansel" CssClass="btn btn-warning" Text="CANCEL" ValidationGroup="g2" OnClick="btncansel_Click"  OnClientClick="return InputValidateCancel(this);" />
                                            </div>



                                        </div>
                                        
                                    </div>


                                </div>
                                <div class="col-md-3">
                                </div>



                            </div>


                        </div>

                    </div>
               
                    <div class="col-md-12">
                        <div class="card direct-chat direct-chat-warning">
                            <div class="card-header"  style="border-bottom: 1px solid #ff9800;border-top: 3px solid #3a5999">
                                <h4 class="card-title kvttext1"> <b>Master Department Details</b></h4>
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
                          <asp:Repeater runat="server" ID="rptdessination" OnItemCommand="rptdessination_ItemCommand">
                          <HeaderTemplate>
                      <thead style="background-color:#3a5999 !important;color:#fff !important">
                          <tr>
                             <th>Sl No</th>
                                           <th>Department Name</th>
                                           <th>
                                               Designation Name
                                           </th>
                                           <th>
                                               Designation Order
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
                                    <asp:HiddenField runat="server" Value='<%#Eval("HRMDES_Id") %>' />
                                    <asp:Label runat="server" Text='<%#Eval("KVTB_DeptName") %>'></asp:Label>
                                
                               </td>
                              <td>
                                   <asp:Label runat="server" Text='<%#Eval("HRMDES_DesignationName") %>'></asp:Label>
                                
                             
                              </td>
                              <td>
                                  <asp:Label runat="server" Text='<%#Eval("HRMDES_Order") %>'></asp:Label>
                              </td>
                               
                               <td>
                                   <span>
                                          <asp:LinkButton runat="server" ID="btnLogout" CssClass="text-green" Text="Activate"  CommandName="deletetwo" CommandArgument='<%#Eval("HRMDES_Id") %>' OnClientClick="return confirm('are you sure you want to delete?')" ValidationGroup="g3" Visible='<%# Convert.ToInt32(Eval("HRMDES_ActiveFlag")).Equals(0)? true:false %>'></asp:LinkButton>
                 
                                   </span>
                                   <span>
                                        <asp:LinkButton runat="server"  CssClass="text-danger" Text="Deactivate"  CommandName="delete" CommandArgument='<%#Eval("HRMDES_Id") %>' OnClientClick="return confirm('are you sure you want to delete?')" ValidationGroup="g3" Visible='<%# Convert.ToInt32(Eval("HRMDES_ActiveFlag")).Equals(1)? true:false %>'></asp:LinkButton>
                   
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
    </form>
    <uc1:KVTPFooter runat="server" ID="KVTPFooter" />
</body>
</html>
