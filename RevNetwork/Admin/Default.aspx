<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RevNetwork.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <!-- End Required meta tags -->

    <title><%=Resources.Resources.labelSystemName %></title>

    <!-- Favicons -->
    <link rel="apple-touch-icon-precomposed" sizes="144x144" href="assets/apple-touch-icon.png">
    <link rel="shortcut icon" href="assets/favicon.ico">
    <meta name="theme-color" content="#3063A0">
    <!-- BEGIN BASE STYLES -->
    <%--<link rel="stylesheet" href="assets/vendor/bootstrap/css/bootstrap.min.css">--%>
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" />

    <%--<link rel="stylesheet" href="assets/vendor/font-awesome/css/fontawesome-all.min.css">--%>
    <link href="~/Content/fontawesome-all.min.css" rel="stylesheet" />

    <!-- END BASE STYLES -->
    <!-- BEGIN THEME STYLES -->
    <%--<link rel="stylesheet" href="assets/stylesheets/main.min.css">--%>
    <link href="~/Content/main.min.css" rel="stylesheet" />

    <%--<link rel="stylesheet" href="assets/stylesheets/custom.css">--%>
    <link href="~/Content/custom.css" rel="stylesheet" />

    <!-- END THEME STYLES -->
</head>
<body>
    <%--<form id="form1" runat="server">--%>
        <!-- .auth -->
        <main class="auth">
          <header id="auth-header" class="auth-header" style="background-image: url(assets/images/illustration/img-1.png);">
            <h1>
              <%--<img src="assets/images/brand-inverse.png" alt="" height="72">--%>
                <img src="../Resource/logo.png" alt="RevNetwork"/>

              <span class="sr-only">Sign In</span>
            </h1>
              <p></p>
            <%--<p> Don't have a account?
              <a href="auth-signup.html">Create One</a>
            </p>--%>
          </header>
          <!-- form -->
          <form id="form1" runat="server" class="auth-form">
              <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

            <!-- .form-group -->
            <div class="form-group">
              <div style="position: relative;">
                <%--<input type="text" id="inputUser" class="form-control" placeholder="Username" required="" autofocus="">--%>
                  <asp:TextBox ID="txtUsername" runat="server" class="form-control" placeholder="Username" style="padding: .75rem;" required="" oninvalid="this.setCustomValidity('Please enter username')" oninput="setCustomValidity('')" ></asp:TextBox>
                <%--<label for="inputUser">Username</label>--%>
              </div>
            </div>
            <!-- /.form-group -->
            <!-- .form-group -->
            <div class="form-group">
              <div style="position: relative;">
                <%--<input type="password" id="inputPassword" class="form-control" placeholder="Password" required="">--%>
                  <asp:TextBox ID="txtPassword" runat="server" class="form-control" placeholder="Password" style="padding: .75rem;" required="" TextMode="Password"></asp:TextBox>
                <%--<label for="inputPassword">Password</label>--%>
              </div>
            </div>

            <asp:Label ID="lblWarning" runat="server" class="text-danger"></asp:Label>
            <!-- /.form-group -->
            <!-- .form-group -->
            <div class="form-group">
                <asp:Button ID="btnLogin" runat="server" Text="Login" class="btn btn-lg btn-primary btn-block" OnClick="btnLogin_Click"/>

              <%--<button class="btn btn-lg btn-primary btn-block" type="submit">Sign In</button>--%>
            </div>
            <!-- /.form-group -->
            <!-- .form-group -->
            <%--<div class="form-group text-center">
              <div class="custom-control custom-control-inline custom-checkbox">
                
                  <asp:CheckBox ID="ChkRememberMe" runat="server" />
                <label for="remember-me">Keep me logged in</label>
              </div>
            </div>--%>
            <!-- /.form-group -->
            <!-- recovery links -->
            <div class="text-center pt-3">
              <%--<a href="" class="link">Forgot Username?</a>
              <span class="mx-2">·</span>--%>
                <%--<a href="AgentExt.aspx" class="link"><%=Resources.Resources.linkLabelAgentRegistration %></a>
                <span class="mx-2">·</span>--%>
                <%--<a href="forgotpassword.aspx" class="link"><%=Resources.Resources.linkLabelForgotPassword %></a>
                <br />--%>
                <%--<asp:linkbutton id="LnkViewFile" runat="server" text="How do I become a Referrer? Is that possible?" style="font-weight: bold;" onclick="LnkViewFile_Click" />--%>
            </div>
             
              

            <!-- /recovery links -->
          </form>
          <!-- /.auth-form -->
          <!-- copyright -->
          <footer class="auth-footer"> © 2021 All Rights Reserved.
            <a href="#">Privacy</a> and
            <a href="#">Terms</a>
          </footer>
        </main>
        <!-- /.auth -->
        <!-- BEGIN PLUGINS JS -->

    <script>
        Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
        function BeginRequestHandler(sender, args) { var oControl = args.get_postBackElement(); oControl.disabled = true; }
    </script>


        <script src="assets/vendor/particles.js/particles.min.js"></script>
        <script>
          /* particlesJS.load(@dom-id, @path-json, @callback (optional)); */
          particlesJS.load('auth-header', 'assets/javascript/particles.json');
        </script>
        <!-- END PLUGINS JS -->

    <%--</form>--%>
</body>
</html>
