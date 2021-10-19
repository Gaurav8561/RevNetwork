<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="RevNetwork.Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <header class="page-title-bar">
        <div class="d-sm-flex align-items-sm-center">
            <h1 class="page-title mr-sm-auto mb-0"><%=Resources.Resources.titleLabelContact %></h1>
        </div>
    </header>
    <div class="page-section">
        <div class="section-deck">

            <%--<div class="col-lg-4">


            <div class="card card-fluid">
                <h6 class="card-header">Details</h6>



                <div class="text-center">
            
                <h2 class="h4 mt-3 mb-0"> Beni Arisandi </h2>
                <div class="my-1">
                  <i class="fa fa-star text-yellow"></i>
                  <i class="fa fa-star text-yellow"></i>
                  <i class="fa fa-star text-yellow"></i>
                  <i class="fa fa-star text-yellow"></i>
                  <i class="far fa-star text-yellow"></i>
                </div>
                <p class="text-muted"> Project Manager @CreativeDivision </p>
                <p> Huge fan of HTML, CSS and Javascript. Web design and open source lover. </p>
              </div>


            </div>


            <div class="card card-fluid">
                <nav class="nav nav-tabs flex-column">
                <a href="user-profile-settings.html" class="nav-link active">Profile</a>
                <a href="user-account-settings.html" class="nav-link">Account</a>
                <a href="user-billing-settings.html" class="nav-link">Billing</a>
                <a href="user-notification-settings.html" class="nav-link">Notifications</a>
                </nav>
            </div>
            </div>--%>

            <div class="col-lg-12">
                <section class="card card-fluid">
                <div class="card-body">
                    <div class="col-md-12 order-md-1">

                        <%--<div class="row">
                            <div class="btn-toolbar">
                                <asp:LinkButton ID="LbtBack" runat="server" class="btn btn-outline-secondary" OnClick="LbtBack_Click"><i class="oi oi-arrow-left"></i><span class="ml-1"><%=Resources.Resources.linkLabelBack %></span></asp:LinkButton>
                            </div>
                        </div>
                        <br />--%>
                        <div id="DivErrorDisplay" runat="server" visible="false">
                            <div class="row">
                                <div class="col-md-12 mb-3">
                                    <asp:Label ID="LblErrorDisplay" Text="<%$Resources:Resources, fieldLabelName %>" runat="server" ForeColor="Red" />
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6 mb-3">
                                <label for="TxtPhoneNumber">
                                    <asp:Label ID="LblPhoneNumber" Text="<%$Resources:Resources, fieldLabelPhoneNumber %>" runat="server" />*</label>
                                <asp:TextBox ID="TxtPhoneNumber" runat="server" class="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6 mb-3">
                                <label for="TxtCreditBalance">
                                    <asp:Label ID="LblCreditBalance" Text="<%$Resources:Resources, fieldLabelCreditBalance %>" runat="server" />*</label>
                                <asp:TextBox ID="TxtCreditBalance" runat="server" class="form-control" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12 mb-3">
                                <label for="TxtName">
                                    <asp:Label ID="LblContactName" Text="<%$Resources:Resources, fieldLabelContactName %>" runat="server" />*</label>
                                <asp:TextBox ID="TxtContactName" runat="server" class="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6 mb-3">
                                <label for="TxtEmail">
                                    <asp:Label ID="LblEmail" Text="<%$Resources:Resources, fieldLabelEmail %>" runat="server" /></label>
                                <asp:TextBox ID="TxtEmail" runat="server" class="form-control" placeholder="user@mail.com"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6 mb-3">
                                <label for="RblGender">
                                    <asp:Label ID="LblGender" Text="<%$Resources:Resources, fieldLabelGender %>" runat="server" /></label>
                                <asp:RadioButtonList ID="RblGender" runat="server" CssClass="rbl" Width="500px"></asp:RadioButtonList>
                                <asp:TextBox ID="TxtGender" runat="server" class="form-control" ReadOnly="true" Visible="false"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6 mb-3">
                                <label for="TxtDOB">
                                    <asp:Label ID="LblDateOfBirth" Text="<%$Resources:Resources, fieldLabelDateOfBirth %>" runat="server" /></label>
                                <asp:TextBox ID="TxtDateOfBirth" TextMode="Date" runat="server" class="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6 mb-3">
                                <label for="DdlMaritalStatus">
                                    <asp:Label ID="LblMaritalStatus" Text="<%$Resources:Resources, fieldLabelMaritalStatus %>" runat="server" /></label>
                                <asp:DropDownList ID="DdlMaritalStatus" runat="server" class="custom-select d-block w-100">
                                </asp:DropDownList>
                                <asp:TextBox ID="TxtMaritalStatus" runat="server" class="form-control" ReadOnly="true" Visible="false"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6 mb-3">
                                <label for="DdlIDType">
                                    <asp:Label ID="LblIDType" Text="<%$Resources:Resources, fieldLabelIdType %>" runat="server" /></label>
                                <asp:DropDownList ID="DdlIDType" runat="server" class="custom-select d-block w-100">
                                </asp:DropDownList>
                                <asp:TextBox ID="TxtIDType" runat="server" class="form-control" ReadOnly="true" Visible="false"></asp:TextBox>
                            </div>
                            <div class="col-md-6 mb-3">
                                <label for="idnumber">
                                    <asp:Label ID="LblIdNumber" Text="<%$Resources:Resources, fieldLabelIdNumber %>" runat="server" /></label>
                                <asp:TextBox ID="TxtIdNumber" runat="server" class="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                                                        <div class="col-md-12 mb-3">
                                                            <label for="TxtAddressLine1">
                                                                <asp:Label ID="LblAddressLine1" Text="<%$Resources:Resources, fieldLabelAddressLine1 %>" runat="server" /></label>
                                                            <asp:TextBox ID="TxtAddressLine1" runat="server" class="form-control" MaxLength="100"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <div class="row">
                                                        <div class="col-md-12 mb-3">
                                                            <label for="TxtAddressLine2">
                                                                <asp:Label ID="LblAddressLine2" Text="<%$Resources:Resources, fieldLabelAddressLine2 %>" runat="server" /></label>
                                                            <asp:TextBox ID="TxtAddressLine2" runat="server" class="form-control" MaxLength="100"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <div class="row">
                                                        <div class="col-md-12 mb-3">
                                                            <label for="TxtAddressLine3">
                                                                <asp:Label ID="LblAddressLine3" Text="<%$Resources:Resources, fieldLabelAddressLine3 %>" runat="server" /></label>
                                                            <asp:TextBox ID="TxtAddressLine3" runat="server" class="form-control" MaxLength="100"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <div class="row">
                                                        <div class="col-md-6 mb-3">
                                                            <label for="TxtAddressPostcode">
                                                                <asp:Label ID="LblAddressPostcode" Text="<%$Resources:Resources, fieldLabelAddressPostcode %>" runat="server" /></label>
                                                            <asp:TextBox ID="TxtAddressPostcode" runat="server" class="form-control" MaxLength="50"></asp:TextBox>
                                                        </div>

                                                        <div class="col-md-6 mb-3">
                                                            <label for="TxtAddressCity">
                                                                <asp:Label ID="LblAddressCity" Text="<%$Resources:Resources, fieldLabelAddressCity %>" runat="server" /></label>
                                                            <asp:TextBox ID="TxtAddressCity" runat="server" class="form-control" MaxLength="50"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <div class="row">
                                                        <div class="col-md-6 mb-3">
                                                            <label for="TxtAddressState">
                                                                <asp:Label ID="LblAddressState" Text="<%$Resources:Resources, fieldLabelAddressState %>" runat="server" /></label>
                                                            <asp:TextBox ID="TxtAddressState" runat="server" class="form-control" MaxLength="50"></asp:TextBox>
                                                        </div>
                                                    </div>

                        

                        


                        


                        <%--<div class="row">
                            <div class="col-md-6 mb-3">
                                <label for="DdlBranch">
                                    <asp:Label ID="LblBranch" Text="<%$Resources:Resources, fieldLabelBranchParentCentre %>" runat="server" /></label>
                                <asp:DropDownList ID="DdlBranch" runat="server" class="custom-select d-block w-100">
                                </asp:DropDownList>
                                <asp:TextBox ID="TxtBranch" runat="server" class="form-control" ReadOnly="true" Visible="false"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6 mb-3">
                                <label for="DdlProgramme">
                                    <asp:Label ID="LblProgramme" Text="<%$Resources:Resources, fieldLabelProgramme %>" runat="server" /></label>
                                <asp:DropDownList ID="DdlProgramme" runat="server" class="custom-select d-block w-100">
                                </asp:DropDownList>
                                <asp:TextBox ID="TxtProgramme" runat="server" class="form-control" ReadOnly="true" Visible="false"></asp:TextBox>
                            </div>
                        </div>--%>


                        <%--<div class="row">
                            <div class="col-md-12 mb-3">
                                <label for="TxtAddressLine1">
                                    <asp:Label ID="LblAddressLine1" Text="<%$Resources:Resources, fieldLabelAddressLine1 %>" runat="server" /></label>
                                <asp:TextBox ID="TxtAddressLine1" runat="server" class="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12 mb-3">
                                <label for="TxtAddressLine2">
                                    <asp:Label ID="LblAddressLine2" Text="<%$Resources:Resources, fieldLabelAddressLine2 %>" runat="server" /></label>
                                <asp:TextBox ID="TxtAddressLine2" runat="server" class="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12 mb-3">
                                <label for="TxtAddressLine3">
                                    <asp:Label ID="LblAddressLine3" Text="<%$Resources:Resources, fieldLabelAddressLine3 %>" runat="server" /></label>
                                <asp:TextBox ID="TxtAddressLine3" runat="server" class="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6 mb-3">
                                <label for="TxtAddressPostcode">
                                    <asp:Label ID="LblAddressPostcode" Text="<%$Resources:Resources, fieldLabelAddressPostcode %>" runat="server" /></label>
                                <asp:TextBox ID="TxtAddressPostcode" runat="server" class="form-control"></asp:TextBox>
                            </div>

                            <div class="col-md-6 mb-3">
                                <label for="TxtAddressCity">
                                    <asp:Label ID="LblAddressCity" Text="<%$Resources:Resources, fieldLabelAddressCity %>" runat="server" /></label>
                                <asp:TextBox ID="TxtAddressCity" runat="server" class="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6 mb-3">
                                <label for="TxtAddressState">
                                    <asp:Label ID="LblAddressState" Text="<%$Resources:Resources, fieldLabelAddressState %>" runat="server" /></label>
                                <asp:TextBox ID="TxtAddressState" runat="server" class="form-control"></asp:TextBox>
                            </div>

                            <div class="col-md-6 mb-3">
                                <label for="DdlAddressCountry">
                                    <asp:Label ID="LblAddressCountry" Text="<%$Resources:Resources, fieldLabelAddressCountry %>" runat="server" /></label>
                                <asp:DropDownList ID="DdlAddressCountry" runat="server" class="custom-select d-block w-100"></asp:DropDownList>
                                <asp:TextBox ID="TxtAddressCountry" runat="server" class="form-control" ReadOnly="true" Visible="false"></asp:TextBox>
                            </div>
                        </div>--%>

                        <div class="row" id="DivStatus" runat="server" Visible="false">
                            <div class="col-md-6 mb-3">
                                <label for="RblStatus">
                                    <asp:Label ID="LblStatus" Text="<%$Resources:Resources, fieldLabelStatus %>" runat="server" /></label>
                                <asp:RadioButtonList ID="RblStatus" runat="server" CssClass="rbl" Width="500px"></asp:RadioButtonList>
                                <asp:TextBox ID="TxtStatus" runat="server" class="form-control" ReadOnly="true" Visible="false"></asp:TextBox>
                            </div>
                        </div>

                        <div id="DivRegisterBy" runat="server" visible="false">
                            <div class="row">
                                <div class="col-md-6 mb-3">
                                    <label for="TxtRegisterBy">
                                        <asp:Label ID="Label2" Text="<%$Resources:Resources, fieldLabelRegBy %>" runat="server" /></label>
                                    <asp:TextBox ID="TxtRegisterBy" TextMode="Date" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>








                        <%--<div id="DivStudentSignUp" runat="server" visible="false">
                            <div class="row" >
                                <div class="col-md-6 mb-3">
                                    <label for="ChkIsSignedUp">
                                        <asp:Label ID="Label3" Text="<%$Resources:Resources, fieldLabelStudentSignUp %>" runat="server" /></label>
                                        <asp:CheckBox ID="ChkIsSignedUp" Text="<%$Resources:Resources, fieldLabelStudentIsSignedUp %>" runat="server" CssClass="rbl" Width="500px" AutoPostBack="true" OnCheckedChanged="ChkIsSignedUp_CheckedChanged"></asp:CheckBox>
                                </div>
                                <div class="col-md-6 mb-3" id="DivStudentSignUpDate" runat="server" visible="false">
                                    <label for="TxtSignUpDate">
                                        <asp:Label ID="LblSignUpDate" Text="<%$Resources:Resources, fieldLabelSignUpDate %>" runat="server" /></label>
                                    <asp:TextBox ID="TxtSignUpDate" TextMode="Date" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>--%>












                        <%--<div id="DivStudentRegistration" runat="server" visible="false">
                            <div class="row" >
                                <div class="col-md-6 mb-3">
                                    <label for="ChkIsRegistered">
                                        <asp:Label ID="LblIsRegistered" Text="<%$Resources:Resources, fieldLabelStudentRegistration %>" runat="server" /></label>
                                        <asp:CheckBox ID="ChkIsRegistered" Text="<%$Resources:Resources, fieldLabelStudentIsRegistered %>" runat="server" CssClass="rbl" Width="500px" AutoPostBack="true" OnCheckedChanged="ChkIsRegistered_CheckedChanged"></asp:CheckBox>
                                </div>
                                <div class="col-md-6 mb-3" id="DivStudentRegistrationDate" runat="server" visible="false">
                                    <label for="RblStatus">
                                        <asp:Label ID="LblRegistrationDate" Text="<%$Resources:Resources, fieldLabelRegistrationDate %>" runat="server" /></label>
                                    <asp:TextBox ID="TxtRegistrationDate" TextMode="Date" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12 mb-3">
                                    <label><%=Resources.Resources.noteStudentRegistrationFinalised %></label>
                                    <hr class="mb-4" />
                                </div>
                            </div>
                        </div>--%>
                        <div id="DivAgentCommission" runat="server" visible="false">
                            <div class="row">
                                <div class="col-md-6 mb-3">
                                    <label for="RblStatus">
                                        <asp:Label ID="LblAgentName" Text="<%$Resources:Resources, fieldLabelAgentName %>" runat="server" /></label>
                                    <asp:TextBox ID="TxtAgentName" ReadOnly="true" runat="server" class="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-6 mb-3">
                                    <label for="RblStatus">
                                        <asp:Label ID="LblCommissionToPay" Text="<%$Resources:Resources, fieldLabelCommissionToPay %>" runat="server" /></label>
                                    <asp:TextBox ID="TxtCommissionToPay" ReadOnly="true" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 mb-3">
                                    <label for="RblStatus">
                                        <asp:Label ID="LblAgentBankName" Text="<%$Resources:Resources, fieldLabelAgentBankName %>" runat="server" /></label>
                                    <asp:TextBox ID="TxtAgentBankName" ReadOnly="true" runat="server" class="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-6 mb-3">
                                    <label for="RblStatus">
                                        <asp:Label ID="LblAgentBankACNumber" Text="<%$Resources:Resources, fieldLabelAgentBankACNumber %>" runat="server" /></label>
                                    <asp:TextBox ID="TxtAgentBankACNumber" ReadOnly="true" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <hr class="mb-4" />
                        </div>
                        <%--<div id="DivNewRegRequirement" runat="server">
                            <div class="row">
                                <div class="col-md-12 mb-3">
                                </div>
                                <div class="col-md-12 mb-3">
                                    <div id="ReCaptchContainer"></div>
                                </div>
                                <label id="LblRecaptchaMessage" runat="server" clientidmode="static"></label>
                            </div>

                            <hr class="mb-4" />

                            <div class="row">
                                <div class="col-md-12 mb-3">
                                    <asp:Label ID="Label1" Text="<%$Resources:Resources, messagePdpaTerms %>" runat="server" />
                                </div>
                                <div class="col-md-12 mb-3">
                                    <asp:CheckBox ID="ChkAgreePDPA" runat="server" />
                                    <asp:Label ID="LblAgreePDPA" Text="<%$Resources:Resources, fieldLabelAgree %>" runat="server" />
                                </div>
                            </div>
                        </div>--%>

                        <%--<div class="table-responsive" id="DivCommentList" runat="server">
                            <asp:GridView ID="gvCommentList" runat="server" AutoGenerateColumns="false" OnPreRender="gvList_PreRender" CssClass="table" GridLines="None" PageSize="50" AllowPaging="True" OnPageIndexChanging="gvList_PageIndexChanging" PagerStyle-HorizontalAlign="Center">
                                <Columns>
                                    <asp:BoundField DataField="StrPotentialStudentCommentLogCreatedBy" HeaderText="<%$Resources:Resources, tableHeaderReferralCommentUser %>" />
                                    <asp:BoundField DataField="DtePotentialStudentCommentLogCreatedDate" HeaderText="<%$Resources:Resources, tableHeaderReferralCommentDateTime %>" />
                                    <asp:BoundField DataField="StrPotentialStudentCommentLogContent" HeaderText="<%$Resources:Resources, tableHeaderReferralCommentContent %>" />
                                </Columns>
                            </asp:GridView>
                        </div>

                        <div class="col-md-12 mb-3" id="DivCommentTextArea" runat="server" visible="false">
                            <label for="RblStatus">
                                <asp:Label ID="LblComment" Text="<%$Resources:Resources, fieldLabelComment %>" runat="server" /></label>
                            <asp:TextBox ID="TxtComment" ReadOnly="false" runat="server" class="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
                        </div>--%>
                        <hr class="mb-4" />
                        <div class="row">
                            <div class="col-md-12 mb-3">
                                <asp:Button ID="BtnSubmit" runat="server" Text="<%$Resources:Resources, buttonLabelSubmit %>" class="btn btn-primary btn-lg btn-block" OnClick="BtnSubmit_Click" />
                                <asp:Button ID="BtnEdit" runat="server" Text="<%$Resources:Resources, buttonLabelEdit %>" class="btn btn-primary btn-lg btn-block" OnClick="BtnEdit_Click" Visible="false" />
                            </div>
                        </div>

                    </div>
                </div>
            </section>
            </div>



            
        </div>
    </div>



    <%--<script src="https://www.google.com/recaptcha/api.js?onload=renderRecaptcha&render=explicit" async defer></script>  

    <script type="text/javascript">  
    var your_site_key = '<%= ConfigurationManager.AppSettings["SiteKey"]%>';  
    var renderRecaptcha = function () {  
        grecaptcha.render('ReCaptchContainer', {  
            'sitekey': your_site_key,  
            'callback': reCaptchaCallback,  
            theme: 'light', //light or dark    
            type: 'image',// image or audio    
            size: 'normal'//normal or compact    
        });  
    };  
  
    var reCaptchaCallback = function (response) {  
        if (response !== '') {  
            jQuery('#lblMessage').css('color', 'green').html('Success');  
        }  
    };  
  
    jQuery('button[type="button"]').click(function(e) {  
        var message = 'Please checck the checkbox';  
        if (typeof (grecaptcha) != 'undefined') {  
            var response = grecaptcha.getResponse();  
            (response.length === 0) ? (message = 'Captcha verification failed') : (message = 'Success!');  
        }  
        jQuery('#lblMessage').html(message);  
        jQuery('#lblMessage').css('color', (message.toLowerCase() == 'success!') ? "green" : "red");  
    });  
  
</script>  --%>


</asp:Content>
