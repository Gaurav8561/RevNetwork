<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="config.aspx.cs" Inherits="WebStudentReferral.config" %>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <header class="page-title-bar">
        <div class="d-sm-flex align-items-sm-center">
            <h1 class="page-title mr-sm-auto mb-0"><%= m_strPageTitle %></h1>
        </div>
    </header>
    <section class="page-section">
        <section class="section-deck">
            <section class="card card-fluid">
                <div class="card-body">
                    <div class="col-md-12 order-md-1">
                        <asp:Panel ID="pnlConfig" runat="server"></asp:Panel>
                        <hr class="mb-4">
                        <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-primary btn-lg btn-block" OnClick="btnSave_Click" />
                    </div>
                </div>
            </section>
        </section>
    </section>
</asp:Content>

