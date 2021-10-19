<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="GeneralUIList.aspx.cs" Inherits="WebStudentReferral.GeneralUIList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">



    <header class="page-title-bar">
        <!-- .breadcrumb -->
        <!-- /floating action -->
        <!-- title and toolbar -->
        <div class="d-sm-flex align-items-sm-center">
            <h1 class="page-title mr-sm-auto mb-0"><%= m_strPageTitle %></h1>
            <!-- .btn-toolbar -->
            <div class="btn-toolbar">
                <asp:LinkButton ID="lbtNew" runat="server" class="btn btn-outline-secondary" OnClick="LbtNew_Click"><i class="oi oi-plus"></i><span class="ml-1"><%= m_linkLabelNew %></span></asp:LinkButton>
            </div>
            <!-- /.btn-toolbar -->
        </div>
        <!-- /title and toolbar -->
    </header>
    <!-- .page-section -->
    <div class="page-section">
        <!-- .card -->
        <section class="card card-fluid">
            <!-- .card-body -->
            <div class="card-body">
                <!-- .form-group -->
                <div class="form-group">
                    <!-- .input-group -->
                    <div class="input-group input-group-alt" id="DivSearchGroup" runat="server">
                        <!-- .input-group-prepend -->
                        <div class="input-group-prepend">
                            <asp:DropDownList ID="ddlFilterBy" runat="server" class="custom-select" />
                        </div>
                        <!-- /.input-group-prepend -->
                        <!-- .input-group -->
                        <div class="input-group">
                            <div class="input-group-prepend">
                                <span class="input-group-text">
                                    <span class="oi oi-magnifying-glass"></span>
                                </span>
                            </div>
                            <asp:TextBox ID="txtSearch" runat="server" class="form-control" placeholder="Keyword"></asp:TextBox>
                        </div>

                        <div class="input-group-append">
                            <asp:Button ID="BtnSearch" runat="server" Text="Search" class="btn btn-secondary" OnClick="BtnSearch_Click" />
                        </div>

                        <!-- /.input-group -->
                    </div>
                    <!-- /.input-group -->
                </div>
                <!-- /.form-group -->
                <!-- .table-responsive -->
                <div class="table-responsive">
                    <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="false" OnPreRender="gvList_PreRender" CssClass="table" GridLines="None" PageSize="50" AllowPaging="True" OnPageIndexChanging="gvList_PageIndexChanging" PagerStyle-HorizontalAlign="Center" />
                    <!-- .table -->
                    <!-- /.table -->
                </div>
                <!-- /.table-responsive -->
                <!-- .pagination -->
                <!-- /.pagination -->
            </div>
            <!-- /.card-body -->
        </section>
        <!-- /.card -->
    </div>
</asp:Content>


