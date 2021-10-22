<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Backend/Admin.Master" AutoEventWireup="true" CodeBehind="Voucher.aspx.cs" Inherits="RevNetwork.Admin.Backend.Voucher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper">
        <div class="content-wrapper">

            <section class="content">
                <div class="container-fluid">
                    <!-- Small boxes (Stat box) -->
                    <div class="row">
                        <div class="col-lg-3 col-6">
                            <!-- small box -->
                            <div class="small-box bg-info">
                                <div class="inner">
                                    <h3>150</h3>

                                    <p>New Orders</p>
                                </div>
                                <div class="icon">
                                    <i class="ion ion-bag"></i>
                                </div>
                                <a href="#" class="small-box-footer">Cash Voucher</a>
                            </div>
                        </div>
                        <!-- ./col -->
                        <div class="col-lg-3 col-6">
                            <!-- small box -->
                            <div class="small-box bg-success">
                                <div class="inner">
                                    <h3>53<sup style="font-size: 20px">%</sup></h3>

                                    <p>Bounce Rate</p>
                                </div>
                                <div class="icon">
                                    <i class="ion ion-stats-bars"></i>
                                </div>
                                <a href="#" class="small-box-footer">Discount Voucher</a>
                            </div>
                        </div>
                        <!-- ./col -->
                        <div class="col-lg-3 col-6">
                            <!-- small box -->
                            <div class="small-box bg-warning">
                                <div class="inner">
                                    <h3>44</h3>

                                    <p>User Registrations</p>
                                </div>
                                <div class="icon">
                                    <i class="ion ion-person-add"></i>
                                </div>
                                <a href="#" class="small-box-footer">Gift Voucher</a>
                            </div>
                        </div>
                        <!-- ./col -->
                        <div class="col-lg-3 col-6">
                            <!-- small box -->
                            <div class="small-box bg-danger">
                                <div class="inner">
                                    <h3>65</h3>

                                    <p>Unique Visitors</p>
                                </div>
                                <div class="icon">
                                    <i class="ion ion-pie-graph"></i>
                                </div>
                                <a href="#" class="small-box-footer">Free Delivery</a>
                            </div>
                        </div>
                        <!-- ./col -->
                    </div>
                    <!-- /.row -->
                    <!-- Main row -->

                    <!-- /.row (main row) -->
                </div>
                <!-- /.container-fluid -->
            </section>


            <section class="container">

                <div class="content-header">
                    <div class="container-fluid">
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-md-3">
                                <asp:TextBox runat="server" ID="txtVoucherName" Width="240px" placeholder="Search"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox runat="server" ID="txtVoucherCode" Width="240px" placeholder="VoucherValue"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:CheckBox runat="server" ID="chkViewEnable" Width="240px" Text="View enabled only" />
                            </div>
                            <div class="col-md-2">
                                <%--<img src="Content/Images/QR_Code/QrCode.jpg" style="width: 20px; height: 20px; align-content: center;" />--%>
                                <span style="height: 30px; width: 30px;"><i class="fa fa-plus-circle"></i></span>
                            </div>
                        </div>
                        <div class="row" id="dvVoucher">
                            <asp:Repeater ID="rptVoucher" runat="server">
                                <ItemTemplate>
                                    <table class="tblCustomer" cellpadding="2" cellspacing="0">
                                        <tr>
                                            <td>
                                                <div class="card" style="border: solid; height: 280px; width: 700px;">
                                                    <div class="row">
                                                        <div class="card-body">
                                                            <h3 class="card-title" title='<%#Eval("VoucherName") %>'><strong></strong></h3>
                                                            <br />
                                                            <br />
                                                            <div class="row">
                                                                <div class="col-sm-3" style="border: solid; height: 200px;">
                                                                    <label>Min Spend</label><br />
                                                                    <label>Max Discount Value</label><br />
                                                                    <label>Claimable quantity</label><br />
                                                                    <label>Max Per User</label><br />
                                                                    <label>Valid From</label><br />
                                                                    <label>Expired Date</label>
                                                                </div>
                                                                <div class="col-sm-4" style="border: solid;">
                                                                    <asp:TextBox ID="txtMinSpend" runat="server" Text="0"></asp:TextBox>
                                                                    <br />
                                                                    <asp:TextBox ID="txtMaxDiscountValue" runat="server" Text='<%# Eval("VoucherDiscountAmount") %>'></asp:TextBox>
                                                                    <br />
                                                                    <asp:TextBox ID="txtClaimableQuantity" runat="server" Text='<%#Eval("VoucherUsage") %>'></asp:TextBox>
                                                                    <br />
                                                                    <asp:TextBox ID="txtMaxPerUser" runat="server" Text='<%#Eval("VoucherLimit") %>'></asp:TextBox>
                                                                    <br />
                                                                    <asp:TextBox ID="txtValidFrom" runat="server" Text='<%#Eval("VoucherValidFrom") %>'></asp:TextBox>
                                                                    <br />
                                                                    <asp:TextBox ID="txtExpiredDate" runat="server" Text='<%#Eval("VoucherValidTo") %>'></asp:TextBox>
                                                                </div>
                                                                <div class="col-sm-4" style="border: solid; align-items: center;">
                                                                    <img src="Content/Images/QR_Code/QrCode.jpg" style="width: 80px; height: 80px; align-content: center;" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </section>
        </div>
    </div>
    <!-- Voucher JS -->

</asp:Content>


