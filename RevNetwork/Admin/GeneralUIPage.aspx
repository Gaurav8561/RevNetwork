<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="GeneralUIPage.aspx.cs" Inherits="WebStudentReferral.GeneralUIPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <header class="page-title-bar">
        <div class="d-sm-flex align-items-sm-center">
            <h1 class="page-title mr-sm-auto mb-0"><%= m_strPageTitle %></h1>
            <div class="btn-toolbar">
                <asp:LinkButton ID="LbtBackToListing" runat="server" class="btn btn-outline-secondary" OnClick="LbtBackToListing_Click"><i class="oi oi-arrow-left"></i><span class="ml-1"><%= Resources.Resources.btnBackToListing %></span></asp:LinkButton>
            </div>
        </div>
    </header>
    <section class="page-section">
        <section class="section-deck">
            <section class="card card-fluid">
                <div class="card-body">
                    <div id="DivErrorDisplay" runat="server" visible="false">
                        <div class="row">
                            <div class="col-md-12 mb-3">
                                <asp:Label ID="LblErrorDisplay" runat="server" ForeColor="Red" />
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12 order-md-1">
                        <asp:Panel ID="pnlContent" runat="server"></asp:Panel>
                        <hr class="mb-4">
                        <asp:Button ID="BtnCancel" runat="server" Text="<%$Resources:Resources, btnCancelText %>" class="btn btn-primary btn-lg btn-block" OnClick="BtnCancel_Click" Visible="<%# (new UIEntityMap.BaseUIEntityMap.UIEntityPropertyMap.PageModes [] { UIEntityMap.BaseUIEntityMap.UIEntityPropertyMap.PageModes.EDIT }).Contains(m_EUIMPageMode) && false %>" />
                        <asp:Button ID="BtnSubmit" runat="server" Text="<%$Resources:Resources, btnSubmitText %>" class="btn btn-primary btn-lg btn-block" OnClick="BtnSubmit_Click" Visible="<%# (new UIEntityMap.BaseUIEntityMap.UIEntityPropertyMap.PageModes [] { UIEntityMap.BaseUIEntityMap.UIEntityPropertyMap.PageModes.NEW, UIEntityMap.BaseUIEntityMap.UIEntityPropertyMap.PageModes.EDIT }).Contains(m_EUIMPageMode) %>" />
                        <asp:Button ID="BtnEdit" runat="server" Text="<%$Resources:Resources, btnEditText %>" class="btn btn-primary btn-lg btn-block" OnClick="BtnEdit_Click" Visible="<%# (new UIEntityMap.BaseUIEntityMap.UIEntityPropertyMap.PageModes [] { UIEntityMap.BaseUIEntityMap.UIEntityPropertyMap.PageModes.VIEW }).Contains(m_EUIMPageMode) %>" />
                    </div>
                </div>
            </section>
        </section>
    </section>
</asp:Content>