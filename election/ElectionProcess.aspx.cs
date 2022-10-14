using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.Services;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



public partial class ElectionProcess : System.Web.UI.Page
{
    public DataTable dtBatch;
    public DataTable dtBatch2;
    public int IsVoted;


    string connectionString = WebConfigurationManager.ConnectionStrings["PIHMAA"].ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (System.Web.HttpContext.Current.Session["MembershipNo"] == null || System.Web.HttpContext.Current.Session["Name"] == null)
        {

            Response.Redirect("Login.aspx");
        }

        if (!scriptManager1.IsInAsyncPostBack)
        {
            if (Session["timeout"] == null)
            {
                Session["timeout"] = DateTime.Now.AddMinutes(2).ToString();
            }

        }
        if (!IsPostBack)
        {
            string Membership_No = "";
            Membership_No =  Convert.ToString(Session["MembershipNo"]);
            // Membership_No = "11111";
            // Session["UserId"] = "1";
            string ProcessQuery = "select* from phm_Eprocess where  getdate()  > process_time_From and getdate() < process_time_To";
            SqlDataAdapter daProcess = new SqlDataAdapter(ProcessQuery, connectionString);
            DataTable dtProcess = new DataTable();
            daProcess.Fill(dtProcess);
            int Process_Id = 0;
            if (dtProcess.Rows.Count > 0)
            {
                 Process_Id =int.Parse( dtProcess.Rows[0]["Process_Id"].ToString());
                 string sqlTextBatch = @"SELECT 
                 BATCH_BLOCK_ID
                ,BATCH_BLOCK_NAME
                ,BATCH_BLOCK_SEATS
                ,BATCH_ACTIVE
                ,PROCESS_ID
                ,CANDIDATES
                ,BATCH_MESSAGE
                FROM PHM_Candidate_Count where Process_Id= " + Process_Id;

                SqlDataAdapter daBatch = new SqlDataAdapter(sqlTextBatch, connectionString);
                dtBatch = new DataTable();
                daBatch.Fill(dtBatch);
				lblEnabled.Text = dtBatch.Rows.Count.ToString();

				if (dtBatch.Rows.Count > 0)
            	{
                 	string sqlTextBatch2 = @"SELECT BATCH_BLOCK_ID,BATCH_BLOCK_NAME,BATCH_BLOCK_SEATS,BATCH_ACTIVE,PROCESS_ID,CANDIDATES FROM PHM_Candidate_Count where BATCH_BLOCK_SEATS < CANDIDATES and BATCH_BLOCK_SEATS > 0 and Process_Id= " + Process_Id + " and BATCH_BLOCK_ID not in (select BATCH_BLOCK_ID from PHM_ELECTION where Process_Id=" + Process_Id + " and membership_no = " + Membership_No + ")";

                	SqlDataAdapter daBatch2 = new SqlDataAdapter(sqlTextBatch2, connectionString);
                	dtBatch2 = new DataTable();
                	daBatch2.Fill(dtBatch2);
					lblVoting.Text = dtBatch2.Rows.Count.ToString();

				}

            }               
        }
	    
    }



	protected void Page_LoadComplete(object sender, EventArgs e)
    {
      lblName.Text = "Welcome, " + Session["Name"];
      btnFinish.Enabled = false;
    }

    public DataTable GetCandidatesByBatchID(int BATCH_BLOCK_ID)
    {
        IsVoted = 0;
        string Membership_No = Convert.ToString(Session["MembershipNo"]);
        string sqlTextCandidate = "";
        sqlTextCandidate = @"SELECT P.PROCESS_ID, P.PROCESS_DATE, P.PROCESS_NAME, P.PROCESS_TIME_FROM, P.PROCESS_TIME_TO,
        B.BATCH_BLOCK_ID , B.BATCH_BLOCK_NAME, B.BATCH_BLOCK_SEATS, C.CAND_ID, C.CAND_NAME, C.CAND_YEAR, C.CAND_PIC, ISNULL(E.Cand_ID,0) AS Cand_ID2
        FROM PHM_EPROCESS P INNER JOIN PHM_EBATCH B ON B.PROCESS_ID = P.PROCESS_ID INNER JOIN PHM_ECANDIDATE C ON C.PROCESS_ID = B.PROCESS_ID 
		AND C.BATCH_BLOCK_ID = B.BATCH_BLOCK_ID LEFT JOIN ( Select Cand_ID,PROCESS_ID,BATCH_BLOCK_ID from PHM_Election where Membership_No=@membership_no 
		and BATCH_BLOCK_ID = @BATCH_BLOCK_ID) E ON E.Cand_ID=C.Cand_ID and E.PROCESS_ID=P.PROCESS_ID AND E.BATCH_BLOCK_ID=B.BATCH_BLOCK_ID
        WHERE P.PROCESS_ACTIVE=1 AND B.BATCH_ACTIVE=1 AND C.CAND_ACTIVE=1 and B.BATCH_BLOCK_ID= @BATCH_BLOCK_ID";

        SqlDataAdapter daCandidate = new SqlDataAdapter(sqlTextCandidate, connectionString);
        daCandidate.SelectCommand.Parameters.AddWithValue("@BATCH_BLOCK_ID", BATCH_BLOCK_ID);
        daCandidate.SelectCommand.Parameters.AddWithValue("@membership_no", Membership_No);
        DataTable dt = new DataTable();
        daCandidate.Fill(dt);
		
		string ProcessQuery = "select* from PHM_ELECTION where BATCH_BLOCK_ID= @BATCH_BLOCK_ID and Membership_No=@Membership_No";
        SqlDataAdapter daProcess = new SqlDataAdapter(ProcessQuery, connectionString);
        daProcess.SelectCommand.Parameters.AddWithValue("@BATCH_BLOCK_ID", BATCH_BLOCK_ID);
        daProcess.SelectCommand.Parameters.AddWithValue("@Membership_No", Membership_No);
        DataTable dtProcess = new DataTable();
        daProcess.Fill(dtProcess);
        if (dtProcess.Rows.Count > 0)
        { 
          IsVoted = 1; 
		}
		else
		{
        	string ProcessQuery1 = "select batch_block_id,batch_block_name,batch_block_seats,candidates from PHM_Candidate_Count where BATCH_BLOCK_ID= @BATCH_BLOCK_ID";
        	SqlDataAdapter daProcess1 = new SqlDataAdapter(ProcessQuery1, connectionString);
        	daProcess1.SelectCommand.Parameters.AddWithValue("@BATCH_BLOCK_ID", BATCH_BLOCK_ID);
        	DataTable dtProcess1 = new DataTable();
        	daProcess1.Fill(dtProcess1);
			if (dtProcess1.Rows.Count > 0)
        	{ 
				int myNum = Convert.ToInt32(dtProcess1.Rows[0][2]);
				int myNum2 = Convert.ToInt32(dtProcess1.Rows[0][3]);
				if (myNum < myNum2)
				{
					if (myNum == 0)
					{
						IsVoted = 1;
					}
					else
					{
						IsVoted = 0;
					}
				}
				else
				{
					IsVoted = 1;
				}
			}
		}
        return dt;
    }

    [System.Web.Services.WebMethod]
    public static string SaveElectionDetails(string selected_candidate_ids)
    {

        string Membership_No = Convert.ToString(System.Web.HttpContext.Current.Session["MembershipNo"]);
        string Member_Name = Convert.ToString(System.Web.HttpContext.Current.Session["Name"]);
        string sqlText = @"INSERT INTO PHM_Election(Batch_Block_ID,Cand_ID,Membership_No,Member_Name,Elect_Date_Time,Process_ID) 
                            SELECT B.BATCH_BLOCK_ID ,C.CAND_ID,'"+ Membership_No + @"','"+Member_Name+@"',DATEADD(MINUTE,+30,DATEADD(HOUR,+5,GETUTCDATE())),P.PROCESS_ID
                            FROM PHM_EPROCESS P INNER JOIN PHM_EBATCH B ON B.PROCESS_ID = P.PROCESS_ID
                            INNER JOIN PHM_ECANDIDATE C ON C.PROCESS_ID = B.PROCESS_ID AND C.BATCH_BLOCK_ID = B.BATCH_BLOCK_ID
                            WHERE C.CAND_ID IN (SELECT VALUE FROM DBO.FN_SPLIT_STRING_TO_COLUMN(@SELECTED_CANDIDATE_IDS,','))";

        SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["PIHMAA"].ToString());
        SqlCommand command = new SqlCommand(sqlText, connection);
        command.Parameters.AddWithValue("@SELECTED_CANDIDATE_IDS", selected_candidate_ids);
        command.CommandType = CommandType.Text;
        connection.Open();
        int recordsInserted = command.ExecuteNonQuery();
        connection.Close();

        string status = "";
        if(recordsInserted > 0)
		{
            status= "Submitted Successfully!";
			//string s = lblVoting.Text.ToString();
            //int i = Convert.ToInt32(s);
            //i = i - 1;
            //lblVoting.Text = i.ToString();
		}
        else
		{
            status = "Failed";
		}
        return status;
    }

    [System.Web.Services.WebMethod]
    public static string Logout(int selected_candidate_ids)
    {
        
        string ss= System.Web.HttpContext.Current.Session["UserId"].ToString();
        return "Login.aspx";
       
    }

    protected void timer1_tick(object sender, EventArgs e)
    {
        if (Session["timeout"] != null)
        {
            if (0 > DateTime.Compare(DateTime.Now, DateTime.Parse(Convert.ToString(Session["timeout"]))))
            {
                lblTimer.Text = string.Format("Time Left: {0} min:{1} sec", ((Int32)DateTime.Parse(Session["timeout"].ToString()).Subtract(DateTime.Now).TotalMinutes).ToString(), ((Int32)DateTime.Parse(Session["timeout"].ToString()).Subtract(DateTime.Now).Seconds).ToString());

                if (lblTimer.Text == "Time Left: 0 min:1 sec")
                {
                    string script = " <script type=\"text/javascript\"> var val = confirm('Yor Session time about to expire, do you want to extend the time ???');  if(val){calfun();}  </script> ";

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
                 
                }
            }
            else
            {
                Session["timeout"] = null;
                timer1.Enabled = true;
                Response.Redirect("Login.aspx");

            }
        }
    }

    [System.Web.Services.WebMethod]
    public static string IncreaseTime()
    {
        System.Web.HttpContext.Current.Session["timeout"] = DateTime.Now.AddMinutes(2).ToString();
        return "dsds";

    }
    protected void btnFinish_Click(object sender, EventArgs e)
    {
        	string Membership_No = Convert.ToString(System.Web.HttpContext.Current.Session["MembershipNo"]);
        	string Member_Name = Convert.ToString(System.Web.HttpContext.Current.Session["Name"]);
        	string sqlText = @"INSERT INTO PHM_EDone(Done_Membership_No,Done_Membership_Name,Done_Membership_Date) Values (@Membership_No,@Member_Name,DATEADD(MINUTE,+30,DATEADD(HOUR,+5,GETUTCDATE())))";
        	SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["PIHMAA"].ToString());
        	SqlCommand command = new SqlCommand(sqlText, connection);
        	command.Parameters.AddWithValue("@Membership_No", Membership_No);
        	command.Parameters.AddWithValue("@Member_Name", Member_Name);
        	command.CommandType = CommandType.Text;
        	connection.Open();
        	int recordsInserted = command.ExecuteNonQuery();
        	connection.Close();

        	if(recordsInserted > 0)
			{
        		Session["MembershipNo"] = null;
        		Session["Name"] = null;
        		Session["timeout"] = null;
				ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Thank you for voting'); window.location = '" + Page.ResolveUrl("~/Login.aspx") + "';", true);
			}
        	else
			{
            	//status = "Error";
			}
	
	}

}
 