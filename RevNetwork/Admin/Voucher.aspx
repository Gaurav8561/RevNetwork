<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Voucher.aspx.cs" Inherits="RevNetwork.Admin.Voucher" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
   <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css"/>
  <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/jquery-ui.min.js"></script>
    <script src="Scripts/Controller/Voucher.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:textbox runat="server" id="txtVoucherName" placeholder="Search"></asp:textbox>
            <asp:textbox runat="server" id="txtVoucherCode" placeholder="VoucherValue"></asp:textbox>
            <asp:CheckBox runat="server" id="chkViewEnable"/>
            <label>View enabled only</label>
        </div>
    </form>
</body>
</html>




