<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KVTPLOGIN.aspx.cs" Inherits="KVTPLOGIN" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>KVTP LOGIN</title>
   <!-- Latest compiled and minified CSS -->
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous" />

<!-- Optional theme -->
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css" integrity="sha384-rHyoN1iRsVXV4nD0JutlnGaslCJuC7uwjduW9SVrLvRYooPp2bWYgmgJQIXwl/Sp" crossorigin="anonymous" />

<!-- Latest compiled and minified JavaScript -->
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
    
    <style>
    @import url("https://fonts.googleapis.com/css2?family=Nunito:wght@400;800&display=swap");

    :root {
        --main-color: #6dd5ed;
        --secondary-color: #2193b0;
        --gradient: linear-gradient( 135deg, var(--main-color), var(--secondary-color) );
    }

    * {
        box-sizing: border-box;
    }

    body {
        font-family: "Nunito", sans-serif;
        display: flex;
        flex-direction: column;
        align-items: center;
        justify-content: center;
        min-height: 100vh;
        margin: 1rem 0;
    }


    p {
        font-size: 14px;
        font-weight: 100;
        line-height: 20px;
        letter-spacing: 0.5px;
        margin: 20px 0 30px;
    }

    .social-container {
        margin: 20px 0;
    }

        .social-container a {
            border: 1px solid #dddddd;
            border-radius: 50%;
            display: inline-flex;
            justify-content: center;
            align-items: center;
            margin: 0 5px;
            height: 40px;
            width: 40px;
        }

    span {
        font-size: 12px;
    }

    a {
        color: #333;
        font-size: 14px;
        text-decoration: none;
        margin: 15px 0;
    }

    button {
        cursor: pointer;
        border-radius: 20px;
        border: 1px solid var(--main-color);
        background: var(--main-color);
        color: #fff;
        font-size: 12px;
        font-weight: bold;
        padding: 12px 45px;
        letter-spacing: 1px;
        text-transform: uppercase;
        transition: transform 80ms ease-out;
    }

        button:hover {
            background: var(--secondary-color);
        }

        button:active {
            transform: scale(0.95);
        }

        button:focus {
            outline: none;
        }

        button.ghost {
            background-color: transparent;
            border-color: #fff;
        }

            button.ghost:hover {
                background: #fff;
                color: var(--secondary-color);
            }

    .formab {
        background-color: #fff;
        display: flex;
        align-items: center;
        justify-content: center;
        flex-direction: column;
        padding: 0 50px;
        height: 100%;
        text-align: center;
    }

    input {
        background-color: #eee;
        border: none;
        padding: 12px 15px;
        margin: 8px 0;
        width: 100%;
        font-family: inherit;
    }

    .container {
        background-color: #fff;
        border-radius: 10px;
        box-shadow: 0 14px 28px rgba(0, 0, 0, 0.25), 0 10px 10px rgba(0, 0, 0, 0.22);
        position: relative;
        overflow: hidden;
        height: 700px;
        width: 100%;
        max-width: 100%;
    }

    .formab-container {
        position: absolute;
        top: 0;
        width: 100%;
        transition: all 0.6s ease-in-out;
    }

    .sign-in-container {
        top: 0;
        height: 50%;
        z-index: 2;
    }

    .container.right-panel-active .sign-in-container {
        transform: translateY(100%);
    }

    .sign-up-container {
        top: 0;
        height: 50%;
        opacity: 0;
        z-index: 1;
    }

    .container.right-panel-active .sign-up-container {
        transform: translateY(100%);
        opacity: 1;
        z-index: 5;
        animation: show 0.6s;
    }

    @keyframes show {
        0%, 49.99% {
            opacity: 0;
            z-index: 1;
        }

        50%, 100% {
            opacity: 1;
            z-index: 5;
        }
    }

    .overlay-container {
        position: absolute;
        left: 0;
        top: 50%;
        height: 50%;
        width: 100%;
        overflow: hidden;
        transition: transform 0.6s ease-in-out;
        z-index: 100;
    }

    .container.right-panel-active .overlay-container {
        transform: translateY(-100%);
    }

    .overlay {
        background: var(--secondary-color);
        background: var(--gradient);
        background-repeat: no-repeat;
        background-size: cover;
        background-position: 0 0;
        color: #fff;
        position: relative;
        top: -100%;
        width: 100%;
        height: 200%;
        transform: translateY(0);
        transition: transform 0.6s ease-in-out;
    }

    .container.right-panel-active .overlay {
        transform: translateY(50%);
    }

    .overlay-panel {
        position: absolute;
        display: flex;
        align-items: center;
        justify-content: center;
        flex-direction: column;
        padding: 0 40px;
        text-align: center;
        left: 0;
        width: 100%;
        height: 50%;
        transform: translateY(0);
        transition: transform 0.6s ease-in-out;
    }

    .overlay-left {
        transform: translateY(-20%);
    }

    .container.right-panel-active .overlay-left {
        transform: translateY(0);
    }

    .overlay-right {
        bottom: 0;
        transform: translateY(0);
    }

    .container.right-panel-active .overlay-right {
        transform: translateY(20%);
    }

    @media (min-width: 768px) {
        body {
            margin: -20px 0 50px;
        }

        .container {
            width: 768px;
            max-width: 100%;
            height: 480px;
        }

        .formab-container {
            top: 0;
            height: 100%;
            width: 50%;
        }

        .sign-in-container {
            left: 0;
            width: 50%;
            height: 100%;
        }

        .container.right-panel-active .sign-in-container {
            transform: translateX(100%);
        }

        .sign-up-container {
            left: 0;
            width: 50%;
            height: 100%;
        }

        .container.right-panel-active .sign-up-container {
            transform: translateX(100%);
        }

        .overlay-container {
            left: 50%;
            top: 0;
            height: 100%;
            width: 50%;
        }

        .container.right-panel-active .overlay-container {
            transform: translateX(-100%);
        }

        .overlay {
            top: 0;
            left: -100%;
            height: 100%;
            width: 200%;
            transform: translateX(0);
        }

        .container.right-panel-active .overlay {
            transform: translateX(50%);
        }

        .overlay-panel {
            top: 0;
            height: 100%;
            width: 50%;
            transform: translateX(0);
        }

        .overlay-left {
            transform: translateX(-20%);
        }

        .container.right-panel-active .overlay-left {
            transform: translateX(0);
        }

        .overlay-right {
            right: 0;
            top: 0;
            left: 50%;
            transform: translateX(0);
        }

        .container.right-panel-active .overlay-right {
            transform: translateX(20%);
        }
    }


    /*marquee*/
    .martop {
        background: linear-gradient(-45deg, #ee7752, #e73c7e, #23a6d5, #23d5ab);
        animation: gradient 2s ease infinite;
        text-align: center;
        color: white;
        font-size: 15px;
        padding-right: 50px;
        padding-left: 50px;
    }



    /***** Demo 3 *********/
    .opacity-animate3 {
        animation: opt-animation3 1s;
        -moz-animation-fill-mode: forwards -webkit-animation-fill-mode: forwards;
        animation-fill-mode: forwards;
    }

    @-webkit-keyframes opt-animation3 {
        0% {
            opacity: 0;
            transform: scale(0.75);
        }

        100% {
            opacity: 1;
            transform: scale(1);
        }
    }

    @-moz-keyframes opt-animation3 {
        0% {
            opacity: 0;
            transform: scale(0.75);
        }

        100% {
            opacity: 1;
            transform: scale(1);
        }
    }

    @-o-keyframes opt-animation3 {
        0% {
            opacity: 0;
            transform: scale(0.75);
        }

        100% {
            opacity: 1;
            transform: scale(1);
        }
    }

    @keyframes opt-animation3 {
        0% {
            opacity: 0;
            transform: scale(0.75);
        }

        100% {
            opacity: 1;
            transform: scale(1);
        }
    }

    /*footer*/

    textarea {
        resize: none;
    }

    .text {
        color: white;
        font-size: 15px;
        position: absolute;
        top: 50%;
        left: 50%;
        transform: translate(-50%, -50%);
        -ms-transform: translate(-50%, -50%);
        white-space: nowrap;
    }

    @charset "UTF-8";

    .svg-inline--fa {
        vertical-align: -0.200em;
    }

    .rounded-social-buttons {
        text-align: center;
    }

        .rounded-social-buttons .social-button {
            display: inline-block;
            position: relative;
            cursor: pointer;
            width: 2.125rem;
            height: 2.125rem;
            border: 0.125rem solid transparent;
            padding: 0;
            text-decoration: none;
            text-align: center;
            color: #fefefe;
            font-size: 1rem;
            font-weight: normal;
            line-height: 2em;
            border-radius: 1.6875rem;
            transition: all 0.5s ease;
            margin-right: 0.25rem;
            margin-bottom: 0.25rem;
        }

            .rounded-social-buttons .social-button:hover, .rounded-social-buttons .social-button:focus {
                -webkit-transform: rotate(360deg);
                -ms-transform: rotate(360deg);
                transform: rotate(360deg);
            }

        .rounded-social-buttons .fa-twitter, .fa-facebook-f, .fa-linkedin, .fa-youtube, .fa-instagram {
            font-size: 15px;
        }

        .rounded-social-buttons .social-button.facebook {
            background: #3b5998;
        }

            .rounded-social-buttons .social-button.facebook:hover, .rounded-social-buttons .social-button.facebook:focus {
                color: #3b5998;
                background: #fefefe;
                border-color: #3b5998;
            }

        .rounded-social-buttons .social-button.twitter {
            background: #55acee;
        }

            .rounded-social-buttons .social-button.twitter:hover, .rounded-social-buttons .social-button.twitter:focus {
                color: #55acee;
                background: #fefefe;
                border-color: #55acee;
            }

        .rounded-social-buttons .social-button.linkedin {
            background: #007bb5;
        }

            .rounded-social-buttons .social-button.linkedin:hover, .rounded-social-buttons .social-button.linkedin:focus {
                color: #007bb5;
                background: #fefefe;
                border-color: #007bb5;
            }

        .rounded-social-buttons .social-button.youtube {
            background: #bb0000;
        }

            .rounded-social-buttons .social-button.youtube:hover, .rounded-social-buttons .social-button.youtube:focus {
                color: #bb0000;
                background: #fefefe;
                border-color: #bb0000;
            }

        .rounded-social-buttons .social-button.instagram {
            background: #125688;
        }

            .rounded-social-buttons .social-button.instagram:hover, .rounded-social-buttons .social-button.instagram:focus {
                color: #125688;
                background: #fefefe;
                border-color: #125688;
            }
</style>
</head>

<body>
    <form id="form1" runat="server">
     





<div class="container-fluid" style="padding:30px;">


    <marquee target="_blank" style="margin-bottom:10px;" behavior="scroll" direction="left" onmouseover="this.stop();" onmouseout="this.start();">
        <span class="martop"><b>Pre - Admission started for *2021 - 2022* from 15th FEBRUARY to 31st APRIL</b></span>
    </marquee >
    <div class="row">
        <div class="col-md-4">

            <div class="container" style="height:100%; box-shadow:none;padding-left:10%">
                <div class="row">
                    <div class="col-md-4">  <img src="/images/vapsqr.png" style="height:100px;width:100px;"></div>
                    <div class="col-md-8">
                        <h5>
                            <a href=" https://vapstech.com/" target="_blank">
                                <!--https://bdcampusstrg.blob.core.windows.net/files/BCEHS HELP FILE.pdf-->
                                ABOUT VAPS
                            </a>
                        </h5>
                        <p style="font-size:12px;margin-top:-5px;">
                            VAPS Technosoft is an ISO 9001 established software development company based in Bangalore
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <p style="font-size:12px;margin-top:-30px;padding:10px;">
                            specialized in I-Vidyalaya Resource Management Software for educational institutions & universities ranging from Kinder Garden to Post Graduation.
                    </div>
                </div>
            </div>

            <img src="/images/bac1.png" style="width:90%;padding-left:10%;margin-top:-30px;"><br />

            <div class="rounded-social-buttons" style="margin-top:20px;">
                <span>
                    <a class="social-button facebook" style="background-color:#0060b1" href="https://www.facebook.com/" target="_blank"><i class="fa fa-phone"></i></a>+080-68112900 / 901-903
                </span>
                &nbsp;
                <span>
                    <a class="social-button facebook" style="background-color:#0060b1" href="mailto:info@vapstech.com" target="_blank"><i class="fa fa-envelope"></i></a>contact@vapstech.com
                </span>
            </div>



        </div>

        <div class="col-md-8">
            <div class="container" id="containerlog">

               

                <div class="formab-container sign-in-container">
                    
                    <div class="formab">
                       
                        <img src="images/kvtlogomain.png" style="width:93% !important;margin-bottom:43px" class="img-responsive" />
                        <input style="border: 2px solid #ccc" type="email" placeholder="Email" />
                        <input style="border: 2px solid #ccc" type="password" placeholder="Password" />

                       
                        <a data-toggle="modal" data-target="#demo1" href="#">Forgot your password?</a>
                        <%--<button style="border: 2px solid #ccc" onclick="return false;">LOGIN</button>--%>
                        <asp:Button runat="server" ID="btnlogin" OnClick="btnlogin_Click" Text="LOGIN" CssClass="btn btn-info" />
                        <footer style="margin-top:15px;">
                            <div class="rounded-social-buttons">
                                <a class="social-button facebook" href="https://www.facebook.com/" target="_blank"><i class="fab fa-facebook-f"></i></a>
                                <a class="social-button twitter" href="https://www.twitter.com/" target="_blank"><i class="fab fa-twitter"></i></a>
                                <a class="social-button linkedin" href="https://www.linkedin.com/" target="_blank"><i class="fab fa-linkedin"></i></a>
                                <a class="social-button youtube" href="https://www.youtube.com/" target="_blank"><i class="fab fa-youtube"></i></a>
                                <a class="social-button instagram" href="https://www.instagram.com/" target="_blank"><i class="fab fa-instagram"></i></a>
                            </div>
                        </footer>
                    </div>
                    
                </div>
                <div class="overlay-container">
                    <div class="overlay">
                        <div class="overlay-panel overlay-left">
                            <img src="images/IVR-Logo.png" style="height:80px;" />
                            <p>Please login with your personal info</p>
                            <button class="ghost" id="signIn">Sign In</button>
                        </div>
                        <div class="overlay-panel overlay-right">
                            <img src="images/IVR-Logo.png" style="height:80px;" />
                            <p>  &nbsp;&nbsp; Welcome to vaps technosoft pvt ltd is an e-campus applications and software development company in bangalore.</p>
                           
                    </div>
                </div>
            </div>
        </div>
    </div>



    <!-- Modal -->
   

</div>




    </div>

    </form>
</body>
   
    <script defer src="https://use.fontawesome.com/releases/v5.0.13/js/all.js" integrity="sha384-xymdQtn1n3lH2wcu0qhcdaOpQwyoarkgLVxC/wZ5q7h9gHtxICrpcaSUfygqZGOe" crossorigin="anonymous"></script>

</html>
 <div class=" modal fade" id="demo1" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog opacity-animate3">
            <div class="modal-content">

                <div class="modal-body">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"><i class="fas fa-times-circle"></i></button>
                    <h4>FORGOT USERNAME?</h4>

                    <input type="email" placeholder="Email" />
                    <input type="password" placeholder="Password" />
                    <div style="text-align:center;margin-top:10px;">
                        <button onclick="return false;"> Submit </button>
                    </div>
                </div>
            </div>
        </div>
    </div>
<%--<div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">Close</span></button>
   
      </div>
      <div class="modal-body">
       
        
        
       <iframe width="100%" height="700" style="overflow: hidden;" src="https://docs.google.com/forms/d/e/1FAIpQLSez3GlqtSHjfJuuHWiut4e9mEnhVrGx2XbcYf-5922TS7FmeA/viewform?embedded=true" frameborder="0" marginheight="0" marginwidth="0" scrolling="no">Loading&amp;#8230;</iframe>
        
        
        
      </div>

    </div>
  </div>
</div>--%>