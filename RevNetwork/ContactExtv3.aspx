<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContactExtv3.aspx.cs" Inherits="RevNetwork.ContactExtv3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <!-- Required meta tags -->

    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <!-- End Required meta tags -->
    <title><%=Resources.Resources.labelMerchantName %></title>

    <!-- FAVICONS -->
    <link rel="shortcut icon" href="https://uselooper.com/1.0.0/assets/favicon.ico">
    --%>
    <meta name="theme-color" content="#3063A0">
    <!-- End FAVICONS -->
    <script src="~/Scripts/pace.min.js"></script>

    <!-- BEGIN BASE STYLES -->
    <link href="~/Content/pace.min.css" rel="stylesheet" />


    <link href="~/Content/bootstrap.min.css" rel="stylesheet" />


    <link href="~/Content/open-iconic-bootstrap.min.css" rel="stylesheet" />



    <link href="~/Content/fontawesome-all.min.css" rel="stylesheet" />

    <!-- END BASE STYLES -->
    <!-- BEGIN PLUGINS STYLES -->

    <link href="~/Content/flatpickr.min.css" rel="stylesheet" />

    <!-- END PLUGINS STYLES -->
    <!-- BEGIN THEME STYLES -->
    <link href="~/Content/main.min.css" rel="stylesheet" />



    <link href="~/Content/custom.css" rel="stylesheet" />

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

    <script src="https://www.google.com/recaptcha/api.js"></script>

    <!--Added javascript, allow only numeric-->
    <!--Modified by Dickson 11/09/2021-->
    <script type="text/javascript">
        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }

    </script>

</head>
<body>
    <form id="form1" runat="server">
        <!-- .app -->
        <div class="app">
            <!-- .app-header -->
            <header class="app-header" style="background-color: #C5262B; height: 150px;">
                <!-- .top-bar -->
                <div class="top-bar" style="height: 150px;">
                    <!-- .top-bar-brand -->
                    <div class="top-bar-brand" style="height: 150px;">
                        <a href="#">
                            <img src="../Resource/nbg.png" height="32" />
                        </a>
                    </div>


                    <div class="top-bar-list" style="background-color: #C5262B;">
                        <div class="top-bar-item px-2 d-md-none d-lg-none d-xl-none">

                            <div style="position: absolute; margin-left: 26vw;">
                                <a href="ContactDashboard.aspx">
                                    <img src="../Resource/nbg.png" height="50" />
                                </a>
                            </div>
                        </div>
                    </div>


                </div>
            </header>

            <main class="app-main" style="padding-left: 0;">

                <div class="wrapper">
                    <div class="page">
                        <div class="sidebar-backdrop"></div>
                        <div class="page-inner" style="background-color: white;">
                            <header class="page-title-bar" style="text-align: center; padding-top: 20px; color: #C5262B;">
                                <div class="d-sm-flex align-items-sm-center">
                                    <h1 class="page-title mr-sm-auto mb-0"><%=Resources.Resources.linkLabelContactRegistration %></h1>
                                </div>
                            </header>
                            <div class="page-section">
                                <div class="section-deck">
                                    <section class="card card-fluid">
                                        <div class="card-body">
                                            <div class="col-md-12 order-md-1">

                                                <div id="DivThankYou" runat="server" visible="false">
                                                    <div class="row">
                                                        <div class="col-md-6 mb-3">
                                                            <label><%=Resources.Resources.noteMemberSignupThankYou %></label>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="btn-toolbar">
                                                            <asp:LinkButton ID="LbtBack" runat="server" class="btn btn-outline-secondary" OnClick="LbtBack_Click"><i class="oi oi-arrow-left"></i><span class="ml-1"><%=Resources.Resources.linkLabelReturnToLogin %></span></asp:LinkButton>
                                                        </div>
                                                    </div>
                                                </div>



                                                <div id="DivMainContactForm" runat="server" visible="false">
                                                    <div id="DivErrorDisplay" runat="server" visible="false">
                                                        <div class="row">
                                                            <div class="col-md-12 mb-3">
                                                                <asp:Label ID="LblErrorDisplay" Text="<%$Resources:Resources, fieldLabelName %>" runat="server" ForeColor="Red" />
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="row">
                                                        <div class="col-md-6 mb-3">
                                                            <label for="TxtPhoneNumber">
                                                                <asp:Label ID="LblPhoneNumber" Text="<%$Resources:Resources, fieldLabelPhoneNumber %>" runat="server" />* <i>eg: 0123456789</i></label>
                                                            <asp:TextBox ID="TxtPhoneNumber" runat="server" class="form-control" MaxLength="50" onkeypress="return isNumber(event)" oncopy="return false" onpaste="return false"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <div class="row">
                                                        <div class="col-md-6 mb-3">
                                                            <label for="TxtNewPassword">
                                                                <asp:Label ID="LblNewPassword" Text="<%$Resources:Resources, fieldLabelNewPassword %>" runat="server" />*</label>
                                                            <asp:TextBox ID="TxtNewPassword" runat="server" class="form-control" MaxLength="50" type="password"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <div class="row">
                                                        <div class="col-md-12 mb-3">
                                                            <div class="g-recaptcha" data-sitekey="6LeTiVwcAAAAAJ6DbH5YnLomnNK87F3wGS11AjIl"></div>
                                                        </div>
                                                    </div>





                                                    <div>

                                                        <div class="row">
                                                            <div class="col-md-12 mb-3">
                                                                <asp:Label ID="Label1" Text="<%$Resources:Resources, messagePdpaTerms %>" runat="server" />
                                                            </div>
                                                            <div class="col-md-12 mb-3">
                                                                <asp:CheckBox ID="ChkAgreePDPA" runat="server" Checked="True" />
                                                                <asp:Label ID="LblAgreePDPA" Text="<%$Resources:Resources, fieldLabelAgree %>" runat="server" />
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <asp:Label ID="lblWarning" runat="server" class="text-danger"></asp:Label>

                                                    <div class="row">
                                                        <div class="col-md-12 mb-3">
                                                            <asp:Button ID="BtnSubmit" runat="server" Text="<%$Resources:Resources, buttonLabelSubmit %>" class="btn btn-primary btn-lg btn-block" OnClick="BtnSubmit_Click" Style="background: #C5262B; border-color: #C5262B;" />
                                                        </div>
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



        <script>

            Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
            function BeginRequestHandler(sender, args) { var oControl = args.get_postBackElement(); oControl.disabled = true; }


            function triggerTimer() {

                var countDownDate = new Date(new Date().getTime() + 60000);

                // Update the count down every 1 second
                var x = setInterval(function () {

                    // Get today's date and time
                    var now = new Date().getTime();

                    // Find the distance between now and the count down date
                    var distance = countDownDate - now;

                    // Time calculations for days, hours, minutes and seconds
                    var days = Math.floor(distance / (1000 * 60 * 60 * 24));
                    var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
                    var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
                    var seconds = Math.floor((distance % (1000 * 60)) / 1000);

                    // Display the result in the element
                    document.getElementById("timerCountdown").innerHTML = "Your may request for OTP again in " + seconds + " second(s)";

                    // Count down is finished
                    if (distance < 0) {
                        clearInterval(x);
                        document.getElementById("timerCountdown").innerHTML = "Click the following button to request for OTP again";
                        document.getElementById("btnRequestOTP").removeAttribute("disabled");

                    }
                }, 1000);
            }
        </script>

        <script src="~/Scripts/jquery-3.4.1.min.js"></script>
        <script src="~/Scripts/umd/popper.min.js"></script>
        <script src="~/Scripts/bootstrap.min.js"></script>

        <!-- END BASE JS -->
        <!-- BEGIN PLUGINS JS -->
        <script src="~/Scripts/stacked-menu.min.js"></script>

        <!-- END PLUGINS JS -->
        <!-- BEGIN THEME JS -->
        <script src="~/Scripts/main.min.js"></script>

        <!-- END THEME JS -->
        <!-- BEGIN PAGE LEVEL JS -->

        <!-- END PAGE LEVEL JS -->
    </form>
</body>
</html>
