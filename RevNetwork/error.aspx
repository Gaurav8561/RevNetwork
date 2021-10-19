<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="error.aspx.cs" Inherits="WebStudentReferral.error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <!-- Required meta tags -->
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <!-- End Required meta tags -->
    <!-- Begin SEO tag -->
    <title>Student Referral</title>
    <link rel="canonical" href="https://uselooper.com/" />
    <!-- End SEO tag -->
    <!-- FAVICONS -->
    <link rel="apple-touch-icon-precomposed" sizes="144x144" href="https://uselooper.com/1.0.0/assets/apple-touch-icon.png" />
    <link rel="shortcut icon" href="https://uselooper.com/1.0.0/assets/favicon.ico" />
    <meta name="theme-color" content="#3063A0" />
    <!-- End FAVICONS -->
    <script src="Scripts/pace.min.js"></script>
    <!-- BEGIN BASE STYLES -->
    <link href="Content/pace.min.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/open-iconic-bootstrap.min.css" rel="stylesheet" />
    <link href="Content/fontawesome-all.min.css" rel="stylesheet" />
    <!-- END BASE STYLES -->
    <!-- BEGIN PLUGINS STYLES -->
    <link href="Content/flatpickr.min.css" rel="stylesheet" />
    <!-- END PLUGINS STYLES -->
    <!-- BEGIN THEME STYLES -->
    <link href="Content/main.min.css" rel="stylesheet" />
    <link href="Content/custom.css" rel="stylesheet" />
    <!-- END THEME STYLES -->
    <style type="text/css">
        /* Chart.js */
        @-webkit-keyframes chartjs-render-animation {
            from {
                opacity: 0.99
            }

            to {
                opacity: 1
            }
        }

        @keyframes chartjs-render-animation {
            from {
                opacity: 0.99
            }

            to {
                opacity: 1
            }
        }

        .chartjs-render-monitor {
            -webkit-animation: chartjs-render-animation 0.001s;
            animation: chartjs-render-animation 0.001s;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <!-- .app -->
        <div class="app">
            <!-- .app-header -->
            <header class="app-header">
                <!-- .top-bar -->
                <div class="top-bar">
                    <!-- .top-bar-brand -->
                    <div class="top-bar-brand">
                        <a href="#">
                            <img src="Resource/brand-inverse.png" height="32" />
                        </a>
                    </div>
                </div>
            </header>

            <main class="app-main" style="padding-left: 0;">
                <div class="wrapper">
                    <div class="page">
                        <div class="sidebar-backdrop"></div>
                        <div class="page-inner">
                            <div class="page-section">
                                <div class="section-deck">
                                    <section class="card card-fluid">
                                        <div class="card-body">
                                            <div class="col-md-12 order-md-1">
                                                <h4 class="mb-3"><%=Resources.Resources.titleLabelError %></h4>
                                                <div class="row">
                                                    <div class="col-md-6 mb-3">
                                                        <asp:Label ID="LblError" Text="<%$Resources:Resources, messageGeneralError %>" runat="server" /></label>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="btn-toolbar">
                                                        <asp:LinkButton ID="LbtBack" runat="server" class="btn btn-outline-secondary" OnClick="LbtBack_Click"><i class="oi oi-arrow-left"></i><span class="ml-1"><%=Resources.Resources.linkLabelBack %></span></asp:LinkButton>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </section>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </main>
            <!-- /.app-main -->
            <div class="app-backdrop"></div>
        </div>
        <!-- /.app -->
        <!-- BEGIN BASE JS -->
        <script src="Scripts/jquery-3.4.1.min.js"></script>
        <script src="Scripts/umd/popper.min.js"></script>
        <script src="Scripts/bootstrap.min.js"></script>
        <!-- END BASE JS -->
        <!-- BEGIN PLUGINS JS -->
        <script src="Scripts/stacked-menu.min.js"></script>
        <script src="Scripts/perfect-scrollbar.min.js"></script>
        <script src="Scripts/flatpickr.min.js"></script>
        <%--<script src="Scripts/jquery.easypiechart.min.js"></script>--%>
        <script src="Scripts/Chart.min.js"></script>
        <!-- END PLUGINS JS -->
        <!-- BEGIN THEME JS -->
        <script src="Scripts/main.min.js"></script>
        <script src="Scripts/chartjs-others-demo.js"></script>
        <script src="Scripts/chartjs-line-demo.js"></script>
        <!-- END THEME JS -->
        <!-- BEGIN PAGE LEVEL JS -->
        <%--<script src="Scripts/easypiechart-demo.js"></script>
      <script src="Scripts/dashboard-demo.js"></script>--%>
        <!-- END PAGE LEVEL JS -->
    </form>
</body>
</html>
