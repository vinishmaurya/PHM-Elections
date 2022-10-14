<%@ Page EnableViewStateMac="false" Language="C#" AutoEventWireup="true" CodeFile="ElectionReport.aspx.cs" Inherits="ElectionReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">


<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />

    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <meta name="description" content="" />
    <meta name="google-site-verification" content="sKH6fAHJAmScENtPMN45EHUMJAnVRqsXj7gUZyFZArs" />
    <link rel="icon" href="https://pihmaa.org/images/favicon_icon.jpg" />
    <title>Welcome to PIHMAA</title>


    <!-- bootsrap css links start -->
    <link href="Content/style.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <!-- bootsrap css links end -->
    <!-- navigation js link start -->

    <script src="http://code.jquery.com/jquery-latest.min.js" type="text/javascript"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="scripts/jquery-1.3.2.min.js" type="text/javascript"></script>
    
       
    <style type="text/css">
        .auto-style1 {
            width: 427px;
        }
    </style>
</head>



<body>
    <form id="form1" runat="server">
    
    
     <header>

         <div class="container-fluid">
                <div class="container">
                    <div class="row">
                        <div class="col-lg-4 col-md-4">
                            <a href="https://pihmaa.org/">
                                <img src="images/logo.png" alt="PIHMAA Logo" class="img-responsive" />
                            </a>
                        </div>
                        <div class="col-lg-4 col-md-4 col-lg-offset-4 col-md-offset-4 pull-right">
                            <div class="row">
                                <div class="col-lg-12 col-md-12">
                                    <h4>PIHMAA Online Election 2019<small>                                       
                                    </small>
                                    </h4>
                                </div>
                                <!--<div class="col-lg-6 col-md-6 list-inline">
                                      <a id="lbLoginLogout" class="btn btn-info" href="javascript:__doPostBack('ctl00$lbLoginLogout','')">Login</a> 
                                    <a class="btn btn-info btn-md" href="login.aspx" style="float: right; margin: 10px; padding: 10px;">Logout</a>
                                </div>-->
                            </div>

                        </div>

                    </div>
                </div>
            </div>
        </header>
    
       <BR><BR><BR><BR><BR><BR>
    
<div>
            <table style="width:100%;">
                <tr>
                    <td width="184">&nbsp;</td>
                    <td class="auto-style1">Election Report</td>
                  <td width="255">&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style1"><asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" Height="38px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="331px" AutoPostBack="True"> </asp:DropDownList></td>
                    <td>&nbsp;</td>
                </tr>
                

                <tr>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" EnableModelValidation="True" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
        <asp:TemplateField HeaderText="Candidate Name">
            <ItemTemplate>
                <asp:Label ID="txtCode" runat="server" Text='<%# Eval("CandidateName") %>'>                </asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Block Name">
            <ItemTemplate>
                <asp:Label ID="txtTitle" runat="server" Text='<%# Eval("BlockName") %>'>                </asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
                              
        <asp:TemplateField HeaderText="Vote Count" ItemStyle-HorizontalAlign="Right">
            <ItemTemplate>
                <asp:Label ID="txtClass" runat="server" Text='<%# Eval("VoteCount") %>'>                </asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        </asp:GridView>                    </td>
                    <td>&nbsp;</td>
                </tr>
      </table>
            <BR><BR><BR><BR><BR><BR><BR>
            <footer>
			  <div class="container-fluid footer_cpy_right">
                <div class="container">
                    <div class="row">
                      <div class="col-xs-12 col-md-6 text-right2">Copyright © 2019. PIHMAA, All Rights Reserved</div>
                        <div class="col-xs-12 col-md-6 text-right1">Powered By : <a href="http://odysseyin.com/" target="_blank">Odyssey</a></div>
                    </div>
                </div>
            </div>
        </footer>
            
      </div>
    </form>
</body>
</html>
