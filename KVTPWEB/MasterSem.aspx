<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MasterSem.aspx.cs" Inherits="MasterSem" %>



<%@ Register Src="~/Navigations/KVTPHeader.ascx" TagPrefix="uc1" TagName="KVTPHeader" %>
<%@ Register Src="~/Navigations/KVTPFooter.ascx" TagPrefix="uc1" TagName="KVTPFooter" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>  Master Semester</title>
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
                                <h4 class="card-title kvttext1"><b>  Master Semister</b></h4>

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
                                            <label class="col-md-4 kvttext">  Semester Name<span style="color: red">*</span></label>
                                            <div class="col-md-8">
                                                <asp:TextBox runat="server" CssClass="form-control" placeholder="Semister Name" ID="HRMSEM_SemisterName" autocomplete="off"></asp:TextBox>
                                            </div>

                                        </div>
                                        <div class="row padding">
                                            <label class="col-md-4 kvttext">  Semester code <span style="color: red">*</span></label>
                                            <div class="col-md-8">
                                                <asp:TextBox runat="server" CssClass="form-control" placeholder="Semister code" ID="HRMSEM_SemCode" autocomplete="off"></asp:TextBox>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">

                                            <div class="col-md-12" style="text-align: center">
                                                <asp:Button runat="server" ID="btndesighn" CssClass="btn btn-primary" Text="SAVE" ValidationGroup="g1" OnClick="btndesighn_Click" />
                                                &nbsp;&nbsp;
                                                    <asp:Button runat="server" ID="btncansel" CssClass="btn btn-warning" Text="CANCEL" ValidationGroup="g2" OnClick="btncansel_Click" />
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
                                <h4 class="card-title kvttext1"> <b> Master Semister  Details</b></h4>
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
                          <asp:Repeater runat="server" ID="rptSemister">
                          <HeaderTemplate>
                      <thead style="background-color:#3a5999 !important;color:#fff !important">
                          <tr>
                             <th>Sl No</th>
                                           <th>Department Name</th>
                                           <th>
                                                 Semester Name
                                           </th>
                                           <th>
                                               Semester Code
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
                                    <asp:HiddenField runat="server" Value='<%#Eval("HRMSEM_Id") %>' />
                                    <asp:Label runat="server" Text='<%#Eval("KVTB_DeptName") %>'></asp:Label>
                                
                               </td>
                              <td>
                                   <asp:Label runat="server" Text='<%#Eval("HRMSEM_SemisterName") %>'></asp:Label>
                                
                             
                              </td>
                              <td>
                                  <asp:Label runat="server" Text='<%#Eval("HRMSEM_SemCode") %>'></asp:Label>
                              </td>
                               
                               <td>
                                   <span>
                                          <asp:LinkButton runat="server" ID="btnLogout" CssClass="text-green" Text="Activate"  CommandName="deletetwo" CommandArgument='<%#Eval("HRMSEM_Id") %>' OnClientClick="return confirm('are you sure you want to delete?')" ValidationGroup="g3" Visible='<%# Convert.ToInt32(Eval("HRMSEM_ActiveFlag")).Equals(0)? true:false %>'></asp:LinkButton>
                 
                                   </span>
                                   <span>
                                        <asp:LinkButton runat="server"  CssClass="text-danger" Text="Deactivate"  CommandName="delete" CommandArgument='<%#Eval("HRMSEM_Id") %>' OnClientClick="return confirm('are you sure you want to delete?')" ValidationGroup="g3" Visible='<%# Convert.ToInt32(Eval("HRMSEM_ActiveFlag")).Equals(1)? true:false %>'></asp:LinkButton>
                   
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
