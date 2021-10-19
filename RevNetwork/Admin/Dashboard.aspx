<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="RevNetwork.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <header class="page-title-bar">
        <p class="lead">
            <span class="font-weight-bold"><%= string.Format(Resources.Resources.messageWelcome, m_usriCurrent.Name)  %>.</span>
            <span class="d-block text-muted"><%=Resources.Resources.messageSummary %></span>
        </p>
    </header>

    <main class="page-section">
        <div class="section-block">
            <!-- Current Month -->
            <!-- metric row -->

            <%--<label class="switcher-control"><asp:CheckBox ID="CheckBox1" runat="server" /></label>

            <div class="custom-control custom-switch">
                
                <label class="custom-control-label" for="customSwitch1">
                    Toggle this switch element
                </label>
            </div>--%>

            <%--<marquee onmouseover="this.stop()" onmouseout="this.start()" scrollamount="10" scrolldelay="0" height="105px" direction="left"> 
                 <b>NOTICE: THERE WILL BE A SCHEDULED SYSTEM MAINTENANCE AT 12:00AM - 03:00AM</b>
             </marquee>--%>
            
            <div class="metric-row">
                <div class="col-md-6 mb-3">
                    <span class="font-weight-bold"><%=Resources.Resources.labelMetricsMember %></span>
                </div>
                <div class="col-lg-9">
                    <div class="metric-row metric-flush">
                        <!-- metric column -->
                        <div class="col">
                            <!-- .metric -->
                            <%--<a href="<%= string.Format("/ReferralList.aspx?{0}={1}", Utility.Constant.QUERY_STRING_NAME_PARAM, Utility.Constant.QUERY_STRING_NAME_CURRENT_MONTH_ALL) %>" class="metric metric-bordered align-items-center">--%>
                            <div class="metric metric-bordered align-items-center">
                                <h2 class="metric-label"><%=Resources.Resources.labelTotalSignedUp %></h2>
                                <p class="metric-value h3">
                                    <sub>
                                        <i class="oi oi-people"></i>
                                    </sub>
                                    <span class="value">
                                        <asp:Label ID="LblTotalSignedUp" runat="server" /></span>
                                </p>
                            </div>
                            <!-- /.metric -->
                        </div>
                        <!-- /metric column -->
                        <!-- metric column -->
                        <div class="col">
                            <!-- .metric -->

                            <%--<a href="<%= string.Format("/ReferralList.aspx?{0}={1}", Utility.Constant.QUERY_STRING_NAME_PARAM, Utility.Constant.QUERY_STRING_NAME_CURRENT_MONTH_PENDING) %>" class="metric metric-bordered align-items-center">--%>
                            <%--<div class="metric metric-bordered align-items-center">
                                <h2 class="metric-label"><%=Resources.Resources.labelTotalReferred %></h2>
                                <p class="metric-value h3">
                                    <sub>
                                        <i class="oi oi-fork"></i>
                                    </sub>
                                    <span class="value">
                                        <asp:Label ID="LblTotalReferred" runat="server" /></span>
                                </p>
                            </div>--%>
                            <!-- /.metric -->
                        </div>
                        <!-- /metric column -->
                        <!-- metric column -->
                        <%--<div class="col">
                            <!-- .metric -->
                            <a href="<%= string.Format("/ReferralList.aspx?{0}={1}", Utility.Constant.QUERY_STRING_NAME_PARAM, Utility.Constant.QUERY_STRING_NAME_CURRENT_MONTH_SIGNEDUP) %>" class="metric metric-bordered align-items-center">
                                <h2 class="metric-label"><%=Resources.Resources.labelTotalSignedUp %></h2>
                                <p class="metric-value h3">
                                    <sub>
                                        <i class="fa fa-tasks"></i>
                                    </sub>
                                    <span class="value">
                                        <asp:Label ID="LblTotalSignedUp" runat="server" /></span>
                                </p>
                            </a>
                            <!-- /.metric -->
                        </div>--%>
                        <div class="col">
                            <!-- .metric -->
                            <%--<a href="<%= string.Format("/ReferralList.aspx?{0}={1}", Utility.Constant.QUERY_STRING_NAME_PARAM, Utility.Constant.QUERY_STRING_NAME_CURRENT_MONTH_EXPIRED) %>" class="metric metric-bordered align-items-center">--%>
                            <div class="metric metric-bordered align-items-center">
                                <h2 class="metric-label"><%=Resources.Resources.labelTotalActiveMember24Hours %></h2>
                                <p class="metric-value h3">
                                    <sub>
                                        <i class="fa fa-tasks"></i>
                                    </sub>
                                    <span class="value">
                                        <asp:Label ID="LblTotalActiveMember24Hours" runat="server" /></span>
                                </p>
                            </div>
                            <!-- /.metric -->
                        </div>
                        <!-- /metric column -->
                    </div>
                </div>
                <!-- metric column -->
                <div class="col-lg-3">
                    <!-- .metric -->
                    <div class="metric metric-bordered">

                        <h2 class="metric-label"><%=Resources.Resources.labelTotalToppedUp %></h2>

                        <p class="metric-value h3">
                            <sub>
                                <i class="oi oi-dollar"></i>
                            </sub>
                            <span class="value">
                                <asp:Label ID="LblTotalToppedUp" runat="server" /></span>
                        </p>
                    </div>
                    <!-- /.metric -->
                </div>
                <!-- /metric column -->
            </div>
            <!-- /metric row -->

            <!-- Previous Month -->
            <!-- metric row -->
            <div class="metric-row">
                <div class="col-md-6 mb-3">
                    <span class="font-weight-bold"><%=Resources.Resources.labelMetricsWallet %></span>
                </div>
                <div class="col-lg-9">
                    <div class="metric-row metric-flush">
                        <!-- metric column -->
                        <div class="col">
                            <!-- .metric -->
                            <%--<a href="<%= string.Format("/ReferralList.aspx?{0}={1}", Utility.Constant.QUERY_STRING_NAME_PARAM, Utility.Constant.QUERY_STRING_NAME_PREVIOUS_MONTH_ALL) %>" class="metric metric-bordered align-items-center">--%>
                            <div class="metric metric-bordered align-items-center">
                                <h2 class="metric-label"><%=Resources.Resources.labelTotalMasterPocket %></h2>
                                <p class="metric-value h3">
                                    <sub>
                                        <i class="fa fa-plus-square"></i>
                                    </sub>
                                    <span class="value">
                                        <asp:Label ID="LblTotalMasterTopupToday" runat="server" /></span>
                                </p>
                            </div>
                            <!-- /.metric -->
                        </div>


                        <div class="col">
                            <!-- .metric -->
                            <%--<a href="<%= string.Format("/ReferralList.aspx?{0}={1}", Utility.Constant.QUERY_STRING_NAME_PARAM, Utility.Constant.QUERY_STRING_NAME_PREVIOUS_MONTH_ALL) %>" class="metric metric-bordered align-items-center">--%>
                            <div class="metric metric-bordered align-items-center">
                                <h2 class="metric-label"><%=Resources.Resources.labelTotalMasterPocket %></h2>
                                <p class="metric-value h3">
                                    <sub>
                                        <i class="fa fa-plus-square"></i>
                                    </sub>
                                    <span class="value">
                                        <asp:Label ID="lblTotalMasterTopupMonth" runat="server" /></span>
                                </p>
                            </div>
                            <!-- /.metric -->
                        </div>



                        <!-- /metric column -->
                        <!-- metric column -->
                        <%--<div class="col">
                            <!-- .metric -->
                            <a href="<%= string.Format("/ReferralList.aspx?{0}={1}", Utility.Constant.QUERY_STRING_NAME_PARAM, Utility.Constant.QUERY_STRING_NAME_PREVIOUS_MONTH_PENDING) %>" class="metric metric-bordered align-items-center">
                                <h2 class="metric-label"><%=Resources.Resources.labelTotalBonusPocket %></h2>
                                <p class="metric-value h3">
                                    <sub>
                                        <i class="fa fa-plus-square"></i>
                                    </sub>
                                    <span class="value">
                                        <asp:Label ID="LblTotalBonusCredited" runat="server" /></span>
                                </p>
                            </a>
                            <!-- /.metric -->
                        </div>--%>
                        <!-- /metric column -->
                        <!-- metric column -->
                        <%--<div class="col">
                            <!-- .metric -->
                            <a href="<%= string.Format("/ReferralList.aspx?{0}={1}", Utility.Constant.QUERY_STRING_NAME_PARAM, Utility.Constant.QUERY_STRING_NAME_PREVIOUS_MONTH_SIGNEDUP) %>" class="metric metric-bordered align-items-center">
                                <h2 class="metric-label"><%=Resources.Resources.labelTotalEarningPocket %></h2>
                                <p class="metric-value h3">
                                    <sub>
                                        <i class="fa fa-plus-square"></i>
                                    </sub>
                                    <span class="value">
                                        <asp:Label ID="LblTotalEarningCredited" runat="server" /></span>
                                </p>
                            </a>
                            <!-- /.metric -->
                        </div>--%>
                        <%--<div class="col">
                            <!-- .metric -->
                            <a href="<%= string.Format("/ReferralList.aspx?{0}={1}", Utility.Constant.QUERY_STRING_NAME_PARAM, Utility.Constant.QUERY_STRING_NAME_PREVIOUS_MONTH_EXPIRED) %>" class="metric metric-bordered align-items-center">
                                <h2 class="metric-label"><%=Resources.Resources.labelTotalSubmissionExpired %></h2>
                                <p class="metric-value h3">
                                    <sub>
                                        <i class="fa fa-tasks"></i>
                                    </sub>
                                    <span class="value">
                                        <asp:Label ID="LblTotalSubmissionExpiredPreviousMonth" runat="server" /></span>
                                </p>
                            </a>
                            <!-- /.metric -->
                        </div>--%>
                        <!-- /metric column -->
                    </div>
                </div>
                <!-- metric column -->
                <%--<div class="col-lg-3">
                    <!-- .metric -->
                    <div class="metric metric-bordered">

                        <h2 class="metric-label"><%=Resources.Resources.labelComissionPaidToDate %></h2>

                        <p class="metric-value h3">
                            <sub>
                                <i class="oi oi-timer"></i>
                            </sub>
                            <span class="value">
                                <asp:Label ID="LblComissionPaidLastMonth" runat="server" /></span>
                        </p>
                    </div>
                    <!-- /.metric -->
                </div>--%>
                <!-- /metric column -->
            </div>
            <!-- /metric row -->
        </div>
    </main>



    <%--<div class="page-section">
        <div id="DivReferralCode" runat="server" visible="false">
            <div class="row">
                <div class="col-md-12">
                    <div class="alert alert-warning has-icon" role="alert">
                        <button type="button" class="close" data-dismiss="alert">×</button>
                        <div class="alert-icon">
                            <span class="fa fa-bullhorn"></span>
                        </div>
                        <h4 class="alert-heading">Tips</h4>
                        <p class="mb-0">To refer, put in the following referral code or click on the referral link.</p>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-6 mb-3">
                    <div class="card-body border-top">
                        <div class="form-row">
                            <label><%=Resources.Resources.fieldLabelYourReferralCode %></label>
                            <asp:Label ID="LblReferralCode" runat="server" class="form-control"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="col-md-6 mb-3">
                    <div class="card-body border-top">
                        <div class="form-row">
                            <label><%=Resources.Resources.fieldLabelYourReferralLink %></label>
                            
                            <asp:LinkButton ID="LnkReferralLink" runat="server" class="form-control">LinkButton</asp:LinkButton>
          
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>--%>

    <div class="page-section">
        <div class="row">
            <div class="col-lg-6">
                <!-- .card -->
                <section class="card card-fluid">
                    <!-- .card-body -->
                    <div class="card-body">
                        <canvas id="referralsummaryline" class="chartjs"></canvas>
                    </div>
                    <!-- /.card-body -->
                    <!-- .card-footer -->
                    <!-- /.card-footer -->
                </section>
                <!-- /.card -->
            </div>

            <div class="col-lg-6">
                <!-- .card -->
                <section class="card card-fluid">
                    <!-- .card-body -->
                    <div class="card-body">
                        <canvas id="referralsummarylinecommissionpaid" class="chartjs"></canvas>
                    </div>
                    <!-- /.card-body -->
                </section>
                <!-- /.card -->
            </div>
        </div>

        <div class="row">
            <div class="col-lg-6">
                <!-- .card -->
                <section class="card card-fluid">
                    <!-- .card-body -->
                    <div class="card-body">
                        <canvas id="referralsummarydonut" class="chartjs"></canvas>
                    </div>
                    <!-- /.card-body -->
                </section>
                <!-- /.card -->
            </div>

            <div class="col-lg-6">
                <!-- .card -->
                <section class="card card-fluid">
                    <!-- .card-body -->
                    <div class="card-body">
                        <canvas id="referralsummarydonutpreviousmonth" class="chartjs"></canvas>
                    </div>
                    <!-- /.card-body -->
                </section>
                <!-- /.card -->
            </div>
        </div>
    </div>

    <script type="text/javascript">

        var dataline = {
            type: 'line',
            data: {
                labels: [<%= m_strLineChartMonthLabels %>],
                datasets: [{
                    label: '<%=Resources.Resources.labelTotalSubmission %>',
              backgroundColor: '#B76BA3',
              borderColor: '#B76BA3',
              data: [<%= m_strLineChartData_totalSubmission %>],
              fill: false
          }, {
                  label: '<%=Resources.Resources.labelTotalSignedUp %>',
                  backgroundColor: '#5F4B8B',
                  borderColor: '#5F4B8B',
                  data: [<%= m_strLineChartData_totalSignedUp %>],
                  fill: false
              }, {
                  label: '<%=Resources.Resources.labelTotalSubmissionExpired %>',
                  backgroundColor: '#F7C46C',
                  borderColor: '#F7C46C',
                  data: [<%= m_strLineChartData_totalExpired %>],
                        fill: false
                    }
                ]
            },
            options: {
                responsive: true,
                legend: {
                    display: true
                },
                title: {
                    display: true,
                    text: '<%=Resources.Resources.chartTitlePerformanceSubmissions %>'
                },
                tooltips: {
                    mode: 'index',
                    intersect: false
                },
                hover: {
                    mode: 'nearest',
                    intersect: true
                },
                scales: {
                    xAxes: [{
                        ticks: {
                            maxRotation: 0,
                            maxTicksLimit: 5
                        }
                    }]
                }
            }
            // init chart line
        };

        var dataline_totalcommission = {
            type: 'line',
            data: {
                labels: [<%= m_strLineChartMonthLabels %>],
                datasets: [{
                    label: '<%=Resources.Resources.labelComissionPaidToDate %>',
                    backgroundColor: '#CA002A',
                    borderColor: '#CA002A',
                    data: [<%= m_strLineChartData_totalCommission %>],
                    fill: false
                }]
            },
            options: {
                responsive: true,
                legend: {
                    display: true
                },
                title: {
                    display: true,
                    text: '<%=Resources.Resources.chartTitlePerformanceCommission %>'
                },
                tooltips: {
                    mode: 'index',
                    intersect: false
                },
                hover: {
                    mode: 'nearest',
                    intersect: true
                },
                scales: {
                    xAxes: [{
                        ticks: {
                            maxRotation: 0,
                            maxTicksLimit: 5
                        }
                    }]
                }
            }
            // init chart line
        };

        var datadonut = {
            type: 'doughnut',
            data: {
                datasets: [{
                    data: [<%= m_strDoughnutData %>],
                    backgroundColor: ['#B76BA3', '#5F4B8B', '#F7C46C'],
                    label: 'Dataset 1'
                }],
                labels: ['<%=Resources.Resources.labelTotalPending %>', '<%=Resources.Resources.labelTotalSignedUp %>', '<%=Resources.Resources.labelTotalSubmissionExpired %>']
            },
            options: {
                responsive: true,
                legend: {
                    display: true
                },
                title: {
                    display: true,
                    text: '<%=Resources.Resources.chartTitleSubmissionBreakdownCurrentMonth %>'
                },
                animation: {
                    animateScale: true,
                    animateRotate: true
                }
            }

            // init chart doughnut
        };

        var datadonut_previousmonth = {
            type: 'doughnut',
            data: {
                datasets: [{
                    data: [<%= m_strDoughnutData_previousMonth %>],
                    backgroundColor: ['#B76BA3', '#5F4B8B', '#F7C46C'],
                    label: 'Dataset 1'
                }],
                labels: ['<%=Resources.Resources.labelTotalPending %>', '<%=Resources.Resources.labelTotalSignedUp %>', '<%=Resources.Resources.labelTotalSubmissionExpired %>']
            },
            options: {
                responsive: true,
                legend: {
                    display: true
                },
                title: {
                    display: true,
                    text: '<%=Resources.Resources.chartTitleSubmissionBreakdownPreviousMonth %>'
                },
                animation: {
                    animateScale: true,
                    animateRotate: true
                }
            }

            // init chart doughnut
        };

        window.onload = function () {

            //var ctxDispositionCountChart = document.getElementById('referralsummary').getContext('2d');

            var canvasline = $('#referralsummaryline')[0].getContext('2d');

            window.myLine = new Chart(canvasline, dataline);

            var canvasline_totalcommision = $('#referralsummarylinecommissionpaid')[0].getContext('2d');

            window.myLine = new Chart(canvasline_totalcommision, dataline_totalcommission);

            var canvasdonut = $('#referralsummarydonut')[0].getContext('2d');

            window.myDoughnut = new Chart(canvasdonut, datadonut);

            var canvasdonut_previousmonth = $('#referralsummarydonutpreviousmonth')[0].getContext('2d');

            window.myDoughnut = new Chart(canvasdonut_previousmonth, datadonut_previousmonth);
        };


       

    </script>



</asp:Content>


