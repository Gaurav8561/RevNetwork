<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="RevNetwork.UserList" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <header class="page-title-bar">
        <div class="d-sm-flex align-items-sm-center">
            <h1 class="page-title mr-sm-auto mb-0"><%=Resources.Resources.titleLabelUserList %></h1>
            <div class="btn-toolbar">
                <asp:LinkButton ID="lbtNewUser" runat="server" class="btn btn-outline-secondary" OnClick="lbtNewUser_Click"><i class="oi oi-plus"></i><span class="ml-1">New User</span></asp:LinkButton>
            </div>
        </div>
    </header>
    <div class="page-section">
        <section class="card card-fluid">
            <div class="card-body">
                <%--<div class="form-group">
                    <div class="input-group input-group-alt">
                        <div class="input-group-prepend">
                            <asp:DropDownList ID="ddlFilterBy" runat="server" class="custom-select">
                                <asp:ListItem Value="" Selected="True">Filter By</asp:ListItem>
                                <asp:ListItem Value="StrUserName" Text="<%$Resources:Resources, tableHeaderAdminName %>"></asp:ListItem>
                                <asp:ListItem Value="BranchUserBranch.StrBranchName" Text="<%$Resources:Resources, tableHeaderGroup %>"></asp:ListItem>
                                <asp:ListItem Value="UserRoleUserRole.StrKey" Text="<%$Resources:Resources, tableHeaderUserRole %>"></asp:ListItem>
                                <asp:ListItem Value="StatusUserStatus.StrKey" Text="<%$Resources:Resources, tableHeaderStatus %>"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
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
                    </div>
                </div>--%>
                <div class="table-responsive">
                    <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="false" OnPreRender="gvList_PreRender" CssClass="table" GridLines="None" PageSize="50" AllowPaging="True" OnPageIndexChanging="gvList_PageIndexChanging" PagerStyle-HorizontalAlign="Center" OnRowCommand="gvList_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="<%$Resources:Resources, tableHeaderName %>">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkUserName" runat="server" CommandArgument='<%#Eval("strUserID")%>' Text='<%#Eval("strUserName") %>' CommandName="selectUser"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:BoundField DataField="BranchUserBranch.StrBranchName" HeaderText="<%$Resources:Resources, tableHeaderGroup %>" />
                            <asp:BoundField DataField="UserRoleUserRole.StrDispText" HeaderText="<%$Resources:Resources, tableHeaderUserRole %>" />--%>
                            <asp:BoundField DataField="StatusUserStatus.StrDispText" HeaderText="<%$Resources:Resources, tableHeaderStatus %>" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </section>
    </div>
</asp:Content>