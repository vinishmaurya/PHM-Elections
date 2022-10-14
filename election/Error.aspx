<%@ Page Title="" Language="C#" MasterPageFile="~/PIHMAA.Master" AutoEventWireup="true" CodeFile="Error.aspx.cs" Inherits="Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="construction-bg page_height">
              <div class="row">
                 <div class="auto-style1">
                    <div class="panel panel-default">
                        <div class="panel-body">
                <b><%--<center>--%>
                    
                    Your session has expired.<%--</center>--%></b> 
                    <p>
                        <%--<center>--%>
                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Click Here To Login Again.</asp:LinkButton><%--</center>--%>
                    </p>
                            </div>
                        </div>
                     </div>
                  </div>
                    
                 
        </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

