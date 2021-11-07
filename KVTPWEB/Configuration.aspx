<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Configuration.aspx.cs" Inherits="Configuration" %>

<%@ Register Src="~/Navigations/KVTPHeader.ascx" TagPrefix="uc1" TagName="KVTPHeader" %>
<%@ Register Src="~/Navigations/KVTPFooter.ascx" TagPrefix="uc1" TagName="KVTPFooter" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title></title>
  <meta charset="utf-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1"/>
   
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
                            <div class="card-header"  style="border-bottom: 1px solid #ff9800;border-top: 3px solid #3a5999">
                                <h4 class="card-title kvttext1"> <b>KVTP Configuration</b></h4>

                                <div class="card-tools">
                                    <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                        <i class="fas fa-minus"></i>
                                    </button>

                                </div>

                            </div>

                            <div class="card-body" ">

                               <div class="row kvt">
                                   <div class="col-md-3"></div>
                                   <div class="col-md-6 ">
                                        <div class="row padding">
                                                <label class="col-md-4 kvttext">Department Name<span style="color: red">*</span></label>
                                                <div class="col-md-8">
                                                 <asp:TextBox runat="server" CssClass="form-control" placeholder="Department Name" ID="KVTB_DeptName"></asp:TextBox>
                                                </div>
                                            
                                            </div>
                                       
                                       <div class="row padding">
                                                <label class="col-md-4 kvttext">Department Code<span style="color: red">*</span></label>
                                                <div class="col-md-8">
                                                 <asp:TextBox runat="server" CssClass="form-control" placeholder="Department Code" ID="KVTB_DeptCode"></asp:TextBox>
                                                </div>
                                            
                                            </div>
                                       <div class="row padding">
                                            <label class="col-md-4 kvttext">Department Block <span style="color: red">*</span></label>
                                                <div class="col-md-8">
                                                 <asp:TextBox runat="server" CssClass="form-control" placeholder="Department Block" ID="KVTB_Order"></asp:TextBox>
                                                </div>
                                       </div>
                                       <br />
                                         <div class="row">
                                                    
                                                <div class="col-md-12" style="text-align:center">
                                                    <asp:Button runat="server" ID="btndept" CssClass="btn btn-primary" Text="SAVE"  ValidationGroup="g1"   /> &nbsp;&nbsp;
                                                    <asp:Button runat="server" ID="btncansel" CssClass="btn btn-warning" Text="CANCEL" ValidationGroup="g2" />                                                  </div>
                                            
                                                  

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
                                <h4 class="card-title kvttext1"> <b>KVTP Configuration</b></h4>

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
                                                 <asp:Repeater runat="server" ID="rptdescdep">
                          <HeaderTemplate>
                      <thead style="background-color:#3a5999 !important;color:#fff !important">
                          <tr>
                             <th>Sl No</th>
                                           <th>Department Name</th>
                                           <th>
                                               Department Code
                                           </th>
                                           <th>
                                               Department Block
                                           </th>
                                           <th>
                                               Action
                                           </th>
                          </tr>
                      </thead></HeaderTemplate>
                          <ItemTemplate>
                      <tbody>
                          <tr>
                              <td>
                                   <asp:Label runat="server" Text='<%#Container.ItemIndex + 1 %>' ></asp:Label>
                             
                              </td>
                               <td>
                                    <asp:HiddenField runat="server" Value='<%#Eval("KVTB_DepId") %>' />
                                    <asp:Label runat="server" Text='<%#Eval("KVTB_DeptName") %>'></asp:Label>
                                
                               </td>
                              <td>
                                   <asp:Label runat="server" Text='<%#Eval("KVTB_DeptCode") %>'></asp:Label>
                                
                             
                              </td>
                              <td>
                                  <asp:Label runat="server" Text='<%#Eval("KVTB_Order") %>'></asp:Label>
                              </td>
                               
                               <td>
                                   <span>
                                          <asp:LinkButton runat="server" CssClass="text-green" Text="Activate"  CommandName="deletetwo" CommandArgument='<%#Eval("KVTB_DepId") %>' OnClientClick="return confirm('Do you Want Delete ?')" ValidationGroup="g3" Visible='<%# Convert.ToInt32(Eval("KVTB_ActiveFlag")).Equals(0)? true:false %>'></asp:LinkButton>
                 
                                   </span>
                                   <span>
                                        <asp:LinkButton runat="server" CssClass="text-danger" Text="Deactivate"  CommandName="delete" CommandArgument='<%#Eval("KVTB_DepId") %>' OnClientClick="return confirm('Do you Want Delete ?')" ValidationGroup="g3" Visible='<%# Convert.ToInt32(Eval("KVTB_ActiveFlag")).Equals(1)? true:false %>'></asp:LinkButton>
                   
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
        tinymce.init({ selector: 'textarea', width: 400 });
    };
    Sys.WebForms.PageRequestManager.getInstance().add_initializeRequest(intiatefunction)
    function intiatefunction(sender, args) {
        validate();



    }


</script>