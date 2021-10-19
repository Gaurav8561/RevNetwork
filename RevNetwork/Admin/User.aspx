<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="RevNetwork.User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <header class="page-title-bar">
        <div class="d-sm-flex align-items-sm-center">
            <h1 class="page-title mr-sm-auto mb-0"><%=Resources.Resources.titleLabelAdminAccount %></h1>
        </div>
    </header>
    <div class="page-section">
        <!-- .section-deck -->
        <div class="section-deck">
            <!-- .card -->
            <section class="card card-fluid">
                <!-- .card-body -->
                <div class="card-body">
                    <div id="DivErrorDisplay" runat="server" visible="false">
                        <div class="row">
                            <div class="col-md-12 mb-3">
                                <asp:Label ID="LblErrorDisplay" Text="<%$Resources:Resources, fieldLabelName %>" runat="server" ForeColor="Red" />
                            </div>
                        </div>
                    </div>
                    <fieldset>
                        <div class="form-group">
                            <label for="TxtEmail">
                                <asp:Label ID="LblEmail" Text="<%$Resources:Resources, fieldLabelEmail %>" runat="server" />
                            </label>
                            <asp:TextBox ID="TxtEmail" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <div class="mb-3">
                                <label for="TxtName">
                                    <asp:Label ID="LblName" Text="<%$Resources:Resources, fieldLabelName %>" runat="server" /></label>
                                <asp:TextBox ID="TxtName" runat="server" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <!-- .form-group -->
                        <div class="form-group">
                            <div id="DivCurrentPassword" runat="server" visible="false">
                                <label for="TxtCurrentPassword">
                                    <asp:Label ID="LblCurrentPassword" Text="<%$Resources:Resources, fieldLabelCurrentPassword %>" runat="server" /></label>
                                <asp:TextBox ID="TxtCurrentPassword" runat="server" class="form-control" placeholder="Current Password" TextMode="Password"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="TxtNewPassword">
                                <asp:Label ID="LblNewPassword" Text="<%$Resources:Resources, fieldLabelNewPassword %>" runat="server" /></label>
                            <asp:TextBox ID="TxtNewPassword" runat="server" class="form-control" placeholder="New Password" TextMode="Password"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="TxtRetypeNewPassword">
                                <asp:Label ID="LblRetypeNewPassword" Text="<%$Resources:Resources, fieldLabelRetypeNewPassword %>" runat="server" /></label>
                            <asp:TextBox ID="TxtRetypeNewPassword" runat="server" class="form-control" placeholder="Retype New Password" TextMode="Password"></asp:TextBox>
                        </div>
                        <%--<div class="form-group">
                            <label for="RblBranchRole">
                                <asp:Label ID="LblAdminRole" Text="<%$Resources:Resources, fieldLabelAdminRole %>" runat="server" /></label>
                            <asp:RadioButtonList ID="RblBranchRole" runat="server" CssClass="rbl" Width="500px" OnSelectedIndexChanged="RblBranchRole_SelectedIndexChanged" AutoPostBack="true"></asp:RadioButtonList>
                        </div>--%>

                       <div class="form-group">
                            <label for="DdlRole">
                                <asp:Label ID="LblRole" Text="<%$Resources:Resources, fieldLabelUserRole %>" runat="server" /></label>
                            <asp:DropDownList ID="DdlRole" runat="server" class="custom-select">
                            </asp:DropDownList>
                            <asp:TextBox ID="TxtRole" runat="server" class="form-control" ReadOnly="true" Visible="false"></asp:TextBox>
                        </div>

                        <%-- <div class="form-group">
                            <label for="DdlBranch">
                                <asp:Label ID="LblBranch" Text="<%$Resources:Resources, fieldLabelBranchParentGroup %>" runat="server" /></label>
                            <asp:DropDownList ID="DdlBranch" runat="server" class="custom-select">
                            </asp:DropDownList>
                            <asp:TextBox ID="TxtBranch" runat="server" class="form-control" ReadOnly="true" Visible="false"></asp:TextBox>
                        </div>--%>
                        
                        <div class="form-group" id="DivStatus" runat="server" Visible="false">
                            <label for="DdlStatus">
                                <asp:Label ID="LblStatus" Text="<%$Resources:Resources, fieldLabelStatus %>" runat="server" /></label>
                            <%--<asp:DropDownList ID="DdlStatus" runat="server" class="custom-select">
                            </asp:DropDownList>--%>
                            <asp:RadioButtonList ID="RblStatus" runat="server" CssClass="rbl" Width="500px"></asp:RadioButtonList>
                            <asp:TextBox ID="TxtStatus" runat="server" class="form-control" ReadOnly="true" Visible="false"></asp:TextBox>
                        </div>
                        <!-- /.form-group -->
                    </fieldset>
                </div>
                <!-- /.card-body -->
            </section>
            <!-- /.card -->
        </div>
        <!-- /.section-deck -->

        <asp:Label ID="lblWarning" runat="server" class="text-danger"></asp:Label>

        <%--<div class="row" id="DivShowNotice" runat="server" visible="false">
            <p class="mb-4"><%=Resources.Resources.noteAccountActivationNotice %></p>
        </div>--%>

        <asp:Button ID="BtnSubmit" runat="server" Text="Submit" class="btn btn-primary btn-lg btn-block" OnClick="BtnSubmit_Click" />
        <asp:Button ID="BtnEdit" runat="server" Text="Edit" class="btn btn-primary btn-lg btn-block" OnClick="BtnEdit_Click" Visible="false" />
        <!-- /.section-block -->
    </div>
    <!-- /.page-section -->
</asp:Content>
