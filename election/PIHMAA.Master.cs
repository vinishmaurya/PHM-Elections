using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PIHMAA : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (Session["Name"] != null)
        {
           
        }
     //   else { Response.Redirect("~/Login.aspx"); }
    }

    private void Logged_Out()
    {
        Literal1.Text = "Guest";
        lbLoginLogout.Text = "Login";
        lbRegister.Text = "Register";
        lbRegister.Visible = true;
    }

    private void Logged_In()
    {
        Literal1.Text = (string)Session["Name"];
        lbLoginLogout.Text = "Logout";
    }

    private bool Is_Logged_In()
    {
        if (!string.IsNullOrEmpty((string)Session["Name"]))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    protected void lbLoginLogout_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty((string)Session["Name"]))
        {
            Response.Redirect("~/Login.aspx");
        }
        else
        {
            Session.Abandon();
            Response.Redirect("~/Login.aspx");
        }
    }

    protected void lbRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/NewMemberRegistration.aspx");
    }
}
