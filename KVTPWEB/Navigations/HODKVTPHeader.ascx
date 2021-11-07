<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HODKVTPHeader.ascx.cs" Inherits="Navigations_HODKVTPHeader" %>
<!-- Google Font: Source Sans Pro -->
<link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback" />
<!-- Font Awesome -->
<link rel="stylesheet" href="plugins/fontawesome-free/css/all.min.css" />
<!-- Ionicons -->
<link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css" />
<!-- Tempusdominus Bootstrap 4 -->
<link rel="stylesheet" href="plugins/tempusdominus-bootstrap-4/css/tempusdominus-bootstrap-4.min.css" />
<!-- iCheck -->
<link rel="stylesheet" href="plugins/icheck-bootstrap/icheck-bootstrap.min.css" />
<!-- JQVMap -->
<link rel="stylesheet" href="plugins/jqvmap/jqvmap.min.css" />
<!-- Theme style -->
<link rel="stylesheet" href="dist/css/adminlte.min.css" />
<!-- overlayScrollbars -->
<link rel="stylesheet" href="plugins/overlayScrollbars/css/OverlayScrollbars.min.css" />
<!-- Daterange picker -->
<link rel="stylesheet" href="plugins/daterangepicker/daterangepicker.css" />
<!-- summernote -->
<link rel="stylesheet" href="plugins/summernote/summernote-bs4.min.css" />



<div class="wrapper">
   

    <!-- Navbar -->
    <nav class="main-header navbar navbar-expand" style="background-color: #3a5999 !important">
        <!-- Left navbar links -->
        <ul class="navbar-nav">
            <li class="nav-item">
                <a class="nav-link" data-widget="pushmenu" href="#" role="button" style="color: #fff !important"><i class="fas fa-bars"></i></a>
            </li>
        </ul>
        <!-- Right navbar links -->
        <ul class="navbar-nav ml-auto">
            <!-- Navbar Search -->
            <li class="nav-item">
                <!--<a class="nav-link" data-widget="navbar-search" href="#" role="button">
            <i class="fas fa-search"></i>
          </a>-->

                <div class="navbar-search-block">
                    <form class="form-inline">
                        <div class="input-group input-group-sm">
                            <input class="form-control form-control-navbar" type="search" placeholder="Search" aria-label="Search">
                            <div class="input-group-append">
                                <button class="btn btn-navbar" type="submit">
                                    <i class="fas fa-search"></i>
                                </button>
                                <button class="btn btn-navbar" type="button" data-widget="navbar-search">
                                    <i class="fas fa-times"></i>
                                </button>
                            </div>
                        </div>
                    </form>
                </div>
            </li>
            <!-- Messages Dropdown Menu -->
            <li class="nav-item dropdown">
                <a class="nav-link" data-toggle="dropdown" href="#">
                    <i class="far fa-comments" style="color: #fff !important"></i>
                    <span class="badge badge-danger navbar-badge">3</span>
                </a>
                <div class="dropdown-menu dropdown-menu-lg dropdown-menu-right">
                    <a href="#" class="dropdown-item">
                        <!-- Message Start -->
                        <div class="media">
                            <img src="dist/img/user1-128x128.jpg" alt="User Avatar" class="img-size-50 mr-3 img-circle">
                            <div class="media-body">
                                <h3 class="dropdown-item-title">Brad Diesel
                    <span class="float-right text-sm text-danger"><i class="fas fa-star"></i></span>
                                </h3>
                                <p class="text-sm">Call me whenever you can...</p>
                                <p class="text-sm text-muted"><i class="far fa-clock mr-1"></i>4 Hours Ago</p>
                            </div>
                        </div>
                        <!-- Message End -->
                    </a>
                    <div class="dropdown-divider"></div>
                    <a href="#" class="dropdown-item">
                        <!-- Message Start -->
                        <div class="media">
                            <img src="dist/img/user8-128x128.jpg" alt="User Avatar" class="img-size-50 img-circle mr-3">
                            <div class="media-body">
                                <h3 class="dropdown-item-title">John Pierce
                    <span class="float-right text-sm text-muted"><i class="fas fa-star"></i></span>
                                </h3>
                                <p class="text-sm">I got your message bro</p>
                                <p class="text-sm text-muted"><i class="far fa-clock mr-1"></i>4 Hours Ago</p>
                            </div>
                        </div>
                        <!-- Message End -->
                    </a>
                    <div class="dropdown-divider"></div>
                    <a href="#" class="dropdown-item">
                        <!-- Message Start -->
                        <div class="media">
                            <img src="dist/img/user3-128x128.jpg" alt="User Avatar" class="img-size-50 img-circle mr-3">
                            <div class="media-body">
                                <h3 class="dropdown-item-title">Nora Silvester
                    <span class="float-right text-sm text-warning"><i class="fas fa-star"></i></span>
                                </h3>
                                <p class="text-sm">The subject goes here</p>
                                <p class="text-sm text-muted"><i class="far fa-clock mr-1"></i>4 Hours Ago</p>
                            </div>
                        </div>
                        <!-- Message End -->
                    </a>
                    <div class="dropdown-divider"></div>
                    <a href="#" class="dropdown-item dropdown-footer">See All Messages</a>
                </div>
            </li>
            <!-- Notifications Dropdown Menu -->
            <li class="nav-item dropdown">
                <a class="nav-link" data-toggle="dropdown" href="#">
                    <i class="far fa-bell" style="color: #fff !important"></i>
                    <span class="badge badge-warning navbar-badge">15</span>
                </a>
                <div class="dropdown-menu dropdown-menu-lg dropdown-menu-right">
                    <span class="dropdown-item dropdown-header">15 Notifications</span>
                    <div class="dropdown-divider"></div>
                    <a href="#" class="dropdown-item">
                        <i class="fas fa-envelope mr-2"></i>4 new messages
              <span class="float-right text-muted text-sm">3 mins</span>
                    </a>
                    <div class="dropdown-divider"></div>
                    <a href="#" class="dropdown-item">
                        <i class="fas fa-users mr-2"></i>8 friend requests
              <span class="float-right text-muted text-sm">12 hours</span>
                    </a>
                    <div class="dropdown-divider"></div>
                    <a href="#" class="dropdown-item">
                        <i class="fas fa-file mr-2"></i>3 new reports
              <span class="float-right text-muted text-sm">2 days</span>
                    </a>
                    <div class="dropdown-divider"></div>
                    <a href="#" class="dropdown-item dropdown-footer">See All Notifications</a>
                </div>
            </li>
            <!-- Login Dropdown Menu -->


        </ul>
    </nav>
    <!-- /.navbar -->
    <!-- Main Sidebar Container -->
    <aside class="main-sidebar  elevation-4" style="background-color: #0d4073 !important">
        <!-- Brand Logo -->
        <a href="" class="brand-link" style="color: #fff !important; background-color: #0463c2 !important;">
            <img src="images/kvt3.jpeg" alt="AdminLTE Logo" class="brand-image img-circle elevation-3">
            <span class="brand-text" style="font-size: 14px!important; color: #fff !important; font-weight: 600 !important;margin-left:5px;">K.V.T POLYTECHNIC</span>
        </a>
        <!-- Sidebar -->
        <div class="sidebar" >
            <!-- Sidebar user panel (optional) -->
            <div class="user-panel mt-3 pb-3 mb-3 d-flex" >
                <div class="image">
                    <img src="https://dcampusstrg.blob.core.windows.net/files/17/EmployeeProfilePics/ba54c96f-f099-4f00-b8a1-8aa262ba298e.jpg" class="img-circle elevation-2" alt="User Image" style="height: 40px; width: 40px; border-radius: 50%">
                </div>
                <div class="info">
                    <a href="#" class="d-block" style="color: #fff!important; text-align: center!important; font-weight: 600 !important; font-size: 14px !important;margin-left:10px!important;">Rajkumar c</a>
                    <a style="font-size: 12px!important; color: #fff!important;margin-left:15px!important;"><i class="fa fa-circle text-success" aria-hidden="true"></i>Online</a>
                </div>
            </div>

            <!-- Sidebar Menu -->
            <nav class="mt-2">
                <ul class="nav nav-pills nav-sidebar flex-column" data-widget="treeview" role="menu" data-accordion="false" style="margin-top: -20px;">

                    <li class="nav-item ">
                        <a href="../dashboard.aspx" class="nav-link ">

                            <i class="nav-icon fa fa-home" style="color: #fff !important; font-size: 16px;margin-right:15px;h"></i>
                            <p style="color: #fff !important; font-size: 15px !important; font-weight: 700">
                                HOME
                 
                            </p>
                        </a>
                       
                    </li>
                  

                          <li class="nav-item ">
                        <a href="#" class="nav-link ">

                            <i class="nav-icon fa fa-cube" style="color: #fff !important; font-size: 16px;margin-right:15px;"></i>
                            <p style="color: #fff !important; font-size: 15px !important; font-weight: 700">
                            Re-Uploads
                  <i class="right fas fa-angle-left"></i>
                            </p>
                        </a>
                        <ul class="nav nav-treeview">
                            <li class="nav-item" style="border-bottom: 1px solid #ddd">
                                <a href="" class="nav-link">
                                    <i class="fa fa-cube nav-icon" style="color: #fff !important; font-size: 12px;margin-right:15px;"></i>
                                    <p style="color: #fff !important; font-size: 12px !important; font-weight: 700"> Noticeboard</p>
                                </a>
                            </li>
                        </ul>
                    </li>


                    <li class="nav-item ">
                        <a href="../Index.aspx" class="nav-link ">
                            <i class="nav-icon fa fa-arrow-circle-right" style="color: #fff !important; font-size: 16px;margin-right:15px;"></i>
                            <p style="color: #fff !important; font-size: 15px !important; font-weight: 700">Logout </p>
                        </a>
                    </li>
                </ul>
            </nav>
            <!-- /.sidebar-menu -->

        </div>
        <!-- /.sidebar -->
    </aside>

    <!-- Content Wrapper. Contains page content -->

    <!-- /.content-wrapper -->

</div>
<!-- ./wrapper -->
