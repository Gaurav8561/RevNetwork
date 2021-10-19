<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ContactList.aspx.cs" Inherits="RevNetwork.ContactList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">



    <header class="page-title-bar">
        <!-- .breadcrumb -->
        <!-- /floating action -->
        <!-- title and toolbar -->
        <div class="d-sm-flex align-items-sm-center">
            <h1 class="page-title mr-sm-auto mb-0"><%=Resources.Resources.titleLabelContactList %></h1>
            <!-- .btn-toolbar -->
            <div class="btn-toolbar">
                <asp:LinkButton ID="lbtNewContact" runat="server" class="btn btn-outline-secondary" OnClick="lbtNewContact_Click" ><i class="oi oi-plus"></i><span class="ml-1"><%=Resources.Resources.linkLabelNewContact %></span></asp:LinkButton>
            </div>
            <!-- /.btn-toolbar -->
        </div>
        <!-- /title and toolbar -->
    </header>
    <!-- .page-section -->
    <div class="page-section">
        <!-- .card -->
        <section class="card card-fluid">

            <%--<header class="card-header">
            
                <ul class="nav nav-tabs card-header-tabs">
                    <li class="nav-item">
                    <a class="nav-link active show" data-toggle="tab" href="#tab1">Add</a>
                    </li>
                    <li class="nav-item">
                    <a class="nav-link" data-toggle="tab" href="#tab2">Edit</a>
                    </li>
                    <li class="nav-item">
                    <a class="nav-link" data-toggle="tab" href="#tab3">Delete</a>
                    </li>
                </ul>

            </header>--%>
            <!-- .card-body -->
            <div class="card-body">
                <!-- .form-group -->
                <%--<div class="form-group">
                    <!-- .input-group -->
                    <div class="input-group input-group-alt">
                        <!-- .input-group-prepend -->
                        <div class="input-group-prepend">
                            <asp:DropDownList ID="ddlFilterBy" runat="server" class="custom-select">
                                <asp:ListItem Value="" Selected="True">Filter By</asp:ListItem>
                                <asp:ListItem Value="StrContactName" Text="<%$Resources:Resources, tableHeaderContactName %>"></asp:ListItem>
                                <asp:ListItem Value="GenderContactGender.StrDispText" Text="<%$Resources:Resources, tableHeaderGender %>"></asp:ListItem>
                                <asp:ListItem Value="DteContactDOB" Text="<%$Resources:Resources, tableHeaderDateOfBirth %>"></asp:ListItem>
                                <asp:ListItem Value="DteContactCreatedDate" Text="<%$Resources:Resources, tableHeaderCreatedDate %>"></asp:ListItem>
                            </asp:DropDownList>
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
                </div>--%>
                <!-- /.form-group -->
                <!-- .table-responsive -->
                <div class="table-responsive">
                    <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="false" OnPreRender="gvList_PreRender" CssClass="table" GridLines="None" PageSize="50" AllowPaging="True" OnPageIndexChanging="gvList_PageIndexChanging" PagerStyle-HorizontalAlign="Center" OnRowCommand="gvList_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="<%$Resources:Resources, tableHeaderContactName %>">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LnkContactName" runat="server" CommandArgument='<%#Eval("StrContactID")%>' Text='<%#Eval("StrContactName") %>' CommandName="selectContact"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="ContactContactWalletPocketMaster.DecCreditBalance" HeaderText="<%$Resources:Resources, tableHeaderCreditBalance %>" />

                            <%--<asp:BoundField DataField="StrContactEmail" HeaderText="<%$Resources:Resources, tableHeaderEmail %>" />--%>

                            <asp:BoundField DataField="GenderEnumeratorContactGender.StrDispText" HeaderText="<%$Resources:Resources, tableHeaderGender %>" />

                            <asp:BoundField DataField="DteContactDOB" HeaderText="<%$Resources:Resources, tableHeaderDateOfBirth %>" />

                            <asp:TemplateField HeaderText="<%$Resources:Resources, tableHeaderCreatedDate %>">
                                <ItemTemplate>
                                    <asp:Label ID="LblCreatedDate" runat="server" Text='<%# Eval("DteContactCreatedDate", "{0:dd/MM/yyyy}") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <%--<asp:BoundField DataField="StrPotenStudIDNumber" HeaderText="<%$Resources:Resources, tableHeaderIdNumber %>" />
                            <asp:BoundField DataField="ProgrammePotenStudProgramme.StrProgrammeTitle" HeaderText="<%$Resources:Resources, tableHeaderProgramme %>" />
                            <asp:TemplateField HeaderText="<%$Resources:Resources, tableHeaderReferredDate %>">
                                <ItemTemplate>
                                    <asp:Label ID="LblCreatedDate" runat="server" Text='<%# Eval("DtePotenStudCreatedDate", "{0:dd/MM/yyyy}") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="StatusPotenStudStatus.StrDispText" HeaderText="<%$Resources:Resources, tableHeaderStatus %>" />

                            <asp:BoundField DataField="RegistrationStatus.StrDispText" HeaderText="<%$Resources:Resources, tableHeaderRegistration %>" />--%>


                        </Columns>
                    </asp:GridView>
                 
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


