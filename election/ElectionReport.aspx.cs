using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ElectionReport : System.Web.UI.Page
{
    string connectionString = WebConfigurationManager.ConnectionStrings["PIHMAA"].ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string ProcessQuery = "select * from phm_Eprocess where process_active =1";
            SqlDataAdapter daProcess = new SqlDataAdapter(ProcessQuery, connectionString);
            DataTable dtProcess = new DataTable();
            daProcess.Fill(dtProcess);
            if (dtProcess.Rows.Count > 0)
            { 
                DropDownList1.DataTextField = "Process_Name";
                DropDownList1.DataValueField = "Process_ID";
                DropDownList1.DataSource = dtProcess;
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, "Select Process");
            }
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
     GridView1.DataSource = null;
     GridView1.DataBind();

	 try
     {

       if (DropDownList1.SelectedIndex != 0)
       {
            int process_ID = int.Parse(DropDownList1.SelectedValue);
            string ProcessQuery = @"select 
    		C.CAND_NAME as CandidateName,
    		B.BATCH_BLOCK_NAME as BlockName,
    		E.Cand_ID,
			count(E.Cand_ID) as VoteCount
            FROM [dbo].[PHM_Election] as E
            left JOIN [dbo].PHM_EBATCH as  B on E.BATCH_BLOCK_ID=B.BATCH_BLOCK_ID
            left join [dbo].PHM_ECANDIDATE C ON C.Cand_ID = E.Cand_ID
    		WHERE   E.process_ID= @process_ID  group by E.Cand_ID, B.BATCH_BLOCK_NAME, C.CAND_NAME order by VoteCount desc";

            SqlDataAdapter daProcess = new SqlDataAdapter(ProcessQuery, connectionString);
            daProcess.SelectCommand.Parameters.AddWithValue("@process_ID", process_ID);
            DataTable dtProcess = new DataTable();
            daProcess.Fill(dtProcess);
            if (dtProcess.Rows.Count > 0)
            {
                GridView1.DataSource = dtProcess;
                GridView1.DataBind();
            }
        }
    	else
	    {
           GridView1.DataSource = null;
           GridView1.DataBind();
		}
	 }

 	 catch(Exception ex)
     {
      //context.Response.Redirect("/Errors/GeneralError.aspx");
      throw new HttpException(404, "Error Message");
      }

    }
}