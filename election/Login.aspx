<%@ Page EnableViewStateMac="false" Language="C#" MasterPageFile="~/PIHMAA.master" AutoEventWireup="true"  CodeFile="Login.aspx.cs" Inherits="Login" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <section>
        <div class="container">
            <div class="col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <div class="panel-title"> Kindly log-in here to cast your votes </div>
                    </div>
                    <div class="panel-body">
                        <div class="form-group">
                            <div class="input-group">
                                <span class="input-group-addon"><span class="glyphicon glyphicon-user"></span></span>
                                <asp:TextBox ID="UserName" CssClass="form-control"  runat="server" ></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="UserNameValidator" runat="server" ErrorMessage="Primary Mobile Number / email ." ForeColor="Red" ControlToValidate="UserName" ValidationGroup="Signin"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <div class="input-group">
                                <span class="input-group-addon"><span class="glyphicon glyphicon-lock"></span></span>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="Password" TextMode="Password" CssClass="form-control" runat="server" AutoPostBack="true" OnTextChanged="Password_TextChanged"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <asp:RequiredFieldValidator ID="PasswordValidator" runat="server" ErrorMessage="Password is required." ForeColor="Red" ControlToValidate="Password" ValidationGroup="Signin"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <asp:Button ID="LoginButton" CssClass="btn btn-primary" Text="Log in" OnClick="LoginButton_Click" runat="server" ValidationGroup="Signin" />
                            </div>
                        </div>
                        <div class="col-md-9">
                            <div class="form-group">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <div class="col-md-6">
                                            <asp:HyperLink ID="LoginwithFacebook" CssClass="btn btn-primary" runat="server" Visible="false">Log in with Facebook</asp:HyperLink>
                                        </div>
                                        <div class="col-md-6">
                                            <asp:HyperLink ID="LoginwithGoogle" CssClass="btn btn-primary" runat="server" Visible="false">Log in with Google</asp:HyperLink>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="Password" EventName="TextChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="FailureText" runat="server" ForeColor="Red"></asp:Label>
                        </div>
                    </div>
                    <div class="panel-footer panel-info">
                        <div class="row">
                            <div class="col-md-8">
                                <div class="form-group">
                                    <div>If you are not a Life Member yet! <a href="https://pihmaa.org/NewMemberRegistration">Sign up here</a></div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <!--<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="https://www.pihmaa.org/ForgotPassword">Forgot Password</asp:HyperLink>-->
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
