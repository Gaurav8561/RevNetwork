<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Backend/Admin.Master" AutoEventWireup="true" CodeBehind="Voucher.aspx.cs" Inherits="RevNetwork.Admin.Backend.Voucher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper">
        <div class="content-wrapper">
            <section class="content" style="margin-top:8px">
                <div class="container-fluid">
                    <!-- Info boxes -->
                    <div class="row">
                        <div class="col-12 col-sm-6 col-md-3">
                            <div class="info-box">
                                <span class="info-box-icon bg-info elevation-1"><i class="fas fa-cog"></i></span>

                                <div class="info-box-content">
                                    <span class="info-box-text">Cash Voucher</span>
                                    <span class="info-box-number">
                  <small></small>
                                    </span>
                                </div>
                                <!-- /.info-box-content -->
                            </div>
                            <!-- /.info-box -->
                        </div>
                        <!-- /.col -->
                        <div class="col-12 col-sm-6 col-md-3">
                            <div class="info-box mb-3">
                                <span class="info-box-icon bg-danger elevation-1"><i class="fas fa-thumbs-up"></i></span>

                                <div class="info-box-content">
                                    <span class="info-box-text">Discount Voucher</span>
                                    <span class="info-box-number"></span>
                                </div>
                                <!-- /.info-box-content -->
                            </div>
                            <!-- /.info-box -->
                        </div>
                        <!-- /.col -->
                        <!-- fix for small devices only -->
                        <div class="clearfix hidden-md-up"></div>

                        <div class="col-12 col-sm-6 col-md-3">
                            <div class="info-box mb-3">
                                <span class="info-box-icon bg-success elevation-1"><i class="fas fa-shopping-cart"></i></span>

                                <div class="info-box-content">
                                    <span class="info-box-text">Gift Voucher</span>
                                    <span class="info-box-number"></span>
                                </div>
                                <!-- /.info-box-content -->
                            </div>
                            <!-- /.info-box -->
                        </div>
                        <!-- /.col -->
                        <div class="col-12 col-sm-6 col-md-3">
                            <div class="info-box mb-3">
                                <span class="info-box-icon bg-warning elevation-1"><i class="fas fa-users"></i></span>

                                <div class="info-box-content">
                                    <span class="info-box-text">Free Delivery</span>
                                    <span class="info-box-number"></span>
                                </div>
                                <!-- /.info-box-content -->
                            </div>
                            <!-- /.info-box -->
                        </div>
                        <!-- /.col -->
                    </div>
                </div>
            </section>
            <div class="content-header">
                <div class="container-fluid">
                    <asp:TextBox runat="server" ID="txtVoucherName" placeholder="Search"></asp:TextBox>
                    <asp:TextBox runat="server" ID="txtVoucherCode" placeholder="VoucherValue"></asp:TextBox>
                    <asp:CheckBox runat="server" ID="chkViewEnable" />
                    <label>View enabled only</label>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
