<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Voucher.aspx.cs" Inherits="RevNetwork.Admin.Voucher" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/jquery-ui.min.js"></script>
    <script src="Scripts/Controller/Voucher.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox runat="server" ID="txtVoucherName" placeholder="Search"></asp:TextBox>
            <asp:TextBox runat="server" ID="txtVoucherCode" placeholder="VoucherValue"></asp:TextBox>
            <asp:CheckBox runat="server" ID="chkViewEnable" />
            <label>View enabled only</label>
        </div>
    </form>

    <asp:Repeater ID="rptBlogDetails" runat="server">
        <ItemTemplate>
         <div class="">

         </div>
        </ItemTemplate>
    </asp:Repeater>

</body>
</html>




