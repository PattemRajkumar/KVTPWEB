<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<%@ Register Src="~/Navigations/KVTPHeader.ascx" TagPrefix="uc1" TagName="KVTPHeader" %>
<%@ Register Src="~/Navigations/KVTPFooter.ascx" TagPrefix="uc1" TagName="KVTPFooter" %>
<!DOCTYPE html>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
<head runat="server">
    <title>KVTP LOGIN</title>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!--===============================================================================================-->
    <link rel="icon" type="image/png" href="images/kvt3.jpeg" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="vendor/bootstrap/css/bootstrap.min.css" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="fonts/font-awesome-4.7.0/css/font-awesome.min.css" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="vendor/animate/animate.css" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="vendor/css-hamburgers/hamburgers.min.css" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="vendor/select2/select2.min.css" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="css/util.css" />
    <link rel="stylesheet" type="text/css" href="css/main.css" />
</head>

<body>


    <form id="form1" runat="server">
        <div class="limiter">
            <div class="container-login100" >
                <div class="wrap-login100">
                    <div class="login100-pic js-tilt" data-tilte>
                        <img src="images/logonew.jpeg"  alt ="IMG" />
                    </div>

                    <div class="login100-form validate-form">
                        <span class="login100-form-title">
                            User Login
                        </span>

                        <div class="wrap-input100 validate-input" data-validate="Valid email is required: ex@abc.xyz" >
                           <asp:TextBox runat="server" ID="txt_email" CssClass="input100" placeholder="User_id">

                           </asp:TextBox>
                           <%-- <input class="input100" type="text" name="email" placeholder="Email" />--%>
                            <span class="focus-input100"></span>
                            <span class="symbol-input100">
                                <i class="fa fa-envelope" aria-hidden="true"></i>
                            </span>
                        </div>

                        <div class="wrap-input100 validate-input" data-validate="Password is required">
                            <asp:TextBox runat="server" ID="txt_pwd" CssClass="input100" type="password" placeholder="Password"  ></asp:TextBox>
                         <%--   <input class="input100" type="password" name="pass" placeholder="Password" />
                          --%>  <span class="focus-input100"></span>
                            <span class="symbol-input100">
                                <i class="fa fa-lock" aria-hidden="true"></i>
                            </span>
                        </div>

                        <div class="container-login100-form-btn">
                            <asp:Button runat="server" ID="btnlogin" CssClass="login100-form-btn" Text="Login" OnClick="btnlogin_Click" />
                            <%-- <button class="">
                                Login
                            </button>--%>
                        </div>

                        <div class="text-center p-t-12">
                            <span class="txt1">
                                Forgot
                            </span>
                            <a class="txt2" href="#">
                                Username / Password?
                            </a>
                        </div>

                        <div class="text-center p-t-136">
                            <a class="txt2" href="#">
                               
                               
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>






    </form>

</body>
</html>
<!--===============================================================================================-->
<script src="vendor/jquery/jquery-3.2.1.min.js"></script>
<!--===============================================================================================-->
<script src="vendor/bootstrap/js/popper.js"></script>
<script src="vendor/bootstrap/js/bootstrap.min.js"></script>
<!--===============================================================================================-->
<script src="vendor/select2/select2.min.js"></script>
<!--===============================================================================================-->
<script src="vendor/tilt/tilt.jquery.min.js"></script>
<script>
    $('.js-tilt').tilt({
        scale: 1.1
    })
</script>
<!--===============================================================================================-->
<script src="js/main.js"></script>