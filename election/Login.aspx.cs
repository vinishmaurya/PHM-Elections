using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

public partial class Login : System.Web.UI.Page
{
    private string connectionString = ConfigurationManager.ConnectionStrings["PIHMAA"].ConnectionString;
    private string name;
    string MembershipNo;

    protected void Page_Load(object sender, EventArgs e)
    {
        UserName.Focus();
        string pwd = Password.Text;
        Password.Attributes.Add("value", pwd);
        UserName.Attributes.Add("placeholder", "Primary Mobile Number / email");
        Password.Attributes.Add("placeholder", "Password");
    }

    protected void LoginButton_Click(object sender, EventArgs e)
    {
        //Archive obj = new Archive();  
        //obj.WhichModuleAssign("111127",2);
        Validate();
        if (Page.IsValid)
        {
            string QueryString;
            SqlConnection conn = new SqlConnection(connectionString);
            //QueryString = "SELECT (ISNULL(mr.First_Name,'')+' '+ISNULL(mr.Last_Name,'')) as Name, Membership_No AS MembershipNo, ai.RoleId as Role,mr.Member_Type as MemberType FROM MemberRegister mr INNER JOIN PHM_AccountInfo ai ON mr.Email_ID = ai.EmailId WHERE (MembershipNo = @UserName OR EmailId = @UserName OR MobileNo = @UserName) AND Password = @Password AND Status <> 'Inactive' And Membership_No not in (select done_membership_no from PHM_EDone)";
            QueryString = "SELECT (membername) as Name, MembershipNo, RoleId as Role,Member_Type as MemberType FROM PHM_ELoginInfo WHERE (MembershipNo = @UserName OR EmailId = @UserName OR MobileNo = @UserName) AND Password = @Password AND Status <> 'Inactive' And MembershipNo not in (select done_membership_no from PHM_EDone)";
            SqlCommand cmd = new SqlCommand(QueryString, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = UserName.Text.Trim();
            cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = Password.Text.Trim();
            conn.Open();
            try
            {
                name = (string)cmd.ExecuteScalar();
                if (!string.IsNullOrEmpty(name))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        string member1;
                        MembershipNo = dr["MembershipNo"].ToString();
                        int RoleId = Convert.ToInt32(dr["Role"]);
                        member1 = dr["MemberType"].ToString();
                    
                         if (RoleId == 2)
                        {
                            Session["MembershipNo"] = MembershipNo.ToString();
                            Session["UserName"] = UserName.Text.Trim();
                            Session["Name"] = name;
                            Session["Member"] = member1;
                            Session["Role"] = "User";

                            Response.Redirect("~/ElectionProcess.aspx");
                         


                        }
                         if (RoleId == 1)
                        {
                            Session["MembershipNo"] = MembershipNo.ToString();
                            Session["UserName"] = UserName.Text.Trim();
                            Session["Name"] = name;
                            Session["Member"] = member1;
                            Session["Role"] = "User";

                            Response.Redirect("~/ElectionProcess.aspx");
                         


                        }
                         if (RoleId == 0)
                        {
                            Session["MembershipNo"] = MembershipNo.ToString();
                            Session["UserName"] = UserName.Text.Trim();
                            Session["Name"] = name;
                            Session["Member"] = member1;
                            Session["Role"] = "User";

                            Response.Redirect("~/ElectionProcess.aspx");
                         


                        }
                     
                        dr.Close();
                    }
                }
                else
                {
					
                    FailureText.Text = "Invalid Login Credentials or You have already voted, and are not permitted to vote again";
					//FailureText.Text = "Voting will start at 6:00 pm today";
					UserName.Text = "";
					Password.Text = "";
                }
            }
            catch (SqlException ex)
            {
                FailureText.Text = ex.Message;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }

    protected void Password_TextChanged(object sender, EventArgs e)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT (ISNULL(mr.First_Name,'')+' '+ISNULL(mr.Last_Name,'')) as Name, Membership_No AS MembershipNo, ai.RoleId as Role FROM MemberRegister mr INNER JOIN PHM_AccountInfo ai ON mr.Email_ID = ai.EmailId WHERE (MembershipNo = @UserName OR EmailId = @UserName OR MobileNo = @UserName) AND Password = @Password", conn))
            {
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = UserName.Text.Trim();
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = Password.Text.Trim();
                conn.Open();
                try
                {
                    name = (string)cmd.ExecuteScalar();
                    if (!string.IsNullOrEmpty(name))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            string MembershipNo = dr["MembershipNo"].ToString();
                            int roleId = Convert.ToInt32(dr["Role"]);

                            if (roleId == 2)
                            {
                                //LoginwithFacebook.Enabled = true;
                                //LoginwithFacebook.CssClass = "btn btn-primary";
                                //LoginwithFacebook.NavigateUrl = "https://www.facebook.com/v2.4/dialog/oauth/?client_id=" + ConfigurationManager.AppSettings["FacebookAppId"] + "&redirect_uri=http://" + Request.ServerVariables["SERVER_NAME"] + ":" + Request.ServerVariables["SERVER_PORT"] + "/Default.aspx&response_type=code&state=1";
                                //LoginwithGoogle.Enabled = true;
                                //LoginwithGoogle.CssClass = "btn btn-primary";
                                Session["MembershipNo"] = MembershipNo.ToString();
                                Session["UserName"] = UserName.Text.Trim();
                                Session["Name"] = name;
                                Session["Role"] = "User";
                            }
                            else
                            {
                                //LoginwithFacebook.Enabled = false;
                                //LoginwithFacebook.CssClass = "btn disabled";
                                //LoginwithGoogle.Enabled = false;
                                //LoginwithGoogle.CssClass = "btn btn disabled";
                            }
                            dr.Close();
                        }
                    }
                }
                catch (SqlException ex)
                {
                    FailureText.Text = ex.Message;
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }
    }
    public bool CheckFirstLogin()
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand("Select HasChanged from PHM_AccountInfo WHERE MembershipNo=" + MembershipNo, conn))
            {
                conn.Open();
                object obj = cmd.ExecuteScalar();
                if (obj != null)
                {
                    string Check = (string)obj;
                    if (Check == "NO")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
