using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PIHMAA
{
    public partial class Archive
    {
        private SqlConnection conn = new SqlConnection(connectionString);
        private SqlCommand cmd;
        private SqlDataAdapter da;
       // private DataSet ds;
       // private DataTable dt;
        private static string connectionString = ConfigurationManager.ConnectionStrings["PIHMAA"].ConnectionString;

        public static string ConnectionString
        {
            get
            {
                return connectionString;
            }
        }

        public DataTable Load_Member_Profile(string MembershipNo)
        {
            string cmdText = string.Empty;
            cmdText = @"SELECT * FROM PHM_View_Member_Profile WHERE Membership_No = " + MembershipNo;
            cmd = new SqlCommand(cmdText, conn);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable BindDDl()
        {
            string cmdText = string.Empty;
            cmdText = @"select Event_id, Event_Short_Nm from PHM_Event_Master where Event_Status='Active' and IsEventPagePublished='1'";
            cmd = new SqlCommand(cmdText, conn);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        /// <summary>
        /// added by shahbaz akhtar 2017-10-31
        /// </summary>
        /// <returns></returns>
        public DataTable BindFeedback(string mno)
        {
            string cmdText = string.Empty;
            cmdText = @"select  Batch_Year,  First_Name+' '+ Last_Name as Name, Email_ID, Mobile_No FROM         MemberRegister where   Membership_No=@MemberShip";
            cmd = new SqlCommand(cmdText, conn);
            cmd.Parameters.Add("@MemberShip", SqlDbType.NVarChar).Value = mno;
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable BindDDllist()
        {
            string cmdText = string.Empty;
            cmdText = @"select Event_id, Event_Short_Nm from PHM_Event_Master where Event_Status!='Inactive' and IsEventPagePublished='1'";
            cmd = new SqlCommand(cmdText, conn);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable bindgdevent(int eventname)
        {
            string cmdText = string.Empty;
            //cmdText = @"select Product_Id,product_name,product_price from Phm_Product where Event_Id=" + eventname + "";
            cmdText = "SelectProductFee";           
            cmd = new SqlCommand(cmdText, conn);
            cmd.Parameters.Add("@eventid", SqlDbType.Int).Value = eventname;
            cmd.CommandType = CommandType.StoredProcedure;

            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        /// <summary>
        /// Added by Shahbaz Akhtar-2017-10-05
        /// Binding events on the basis of Member Type
        /// </summary>
        

        public DataTable bindgdeventPrice(int eventname,string MemberType,string MemberSubType)
        {
            string cmdText = string.Empty;
          
            cmdText = "Proc_SelectProductFee_Member";
            cmd = new SqlCommand(cmdText, conn);
            cmd.Parameters.Add("@eventid", SqlDbType.Int).Value = eventname;
            cmd.Parameters.Add("@memberid", SqlDbType.VarChar).Value = MemberType;
            cmd.Parameters.Add("@membersubtypeid", SqlDbType.VarChar).Value = MemberSubType;
            cmd.CommandType = CommandType.StoredProcedure;

            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable bindmemberfee(int id)
        {
            string cmdText = string.Empty;
            //cmdText = @"select Product_Id,product_name,product_price from Phm_Product where Event_Id=" + eventname + "";
            cmdText = "select * from PHM_Member_Type where Member_Type_ID=@membertypeid";
            cmd = new SqlCommand(cmdText, conn);
            cmd.Parameters.Add("@membertypeid", SqlDbType.NVarChar).Value = id;
            //cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        /*
        Added shahbaz akhtar 2017-10-04 bind membertpe
         */
        public DataTable bindmembertype()
        {
            string cmdText = string.Empty;
            //cmdText = @"select Product_Id,product_name,product_price from Phm_Product where Event_Id=" + eventname + "";
            cmdText = "select Member_Type_ID,Member_Type_Nm from PHM_Member_Type ";
            cmd = new SqlCommand(cmdText, conn);
           
            //cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable bindmembersubtype()
        {
            string cmdText = string.Empty;
            //cmdText = @"select Product_Id,product_name,product_price from Phm_Product where Event_Id=" + eventname + "";
            cmdText = "select Member_SubType_ID,Member_SubType_Nm from PHM_Member_SubType ";
            cmd = new SqlCommand(cmdText, conn);

            //cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        //--------------END-----------------------
        public DataTable bind(string id)
        {
            string cmdText = string.Empty;
            cmdText = "select * from SelectMember where Role='"+id+"'";
            cmd = new SqlCommand(cmdText, conn);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
      
        public DataSet getCourse()
        {
            string cmdText = string.Empty;
            cmdText = @"SELECT * FROM Courses";
            cmd = new SqlCommand(cmdText, conn);
            da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataSet getTitle()
        {
            string cmdText = string.Empty;
            cmdText = @"SELECT * FROM PHM_Title";
            cmd = new SqlCommand(cmdText, conn);
            da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataSet getbaseproduct()
        {
            string cmdText = string.Empty;
            cmdText = @"SELECT * FROM PHM_Product WHERE Event_ID IS NULL and Product_Active=1";
            cmd = new SqlCommand(cmdText, conn);
            da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataSet geteventproduct(string Event_ID)
        {
            string cmdText = string.Empty;
           // cmdText = @"SELECT * FROM PIHMAA_db.dbo.PHM_Product WHERE Event_ID IS NOT NULL and Event_ID='" + Event_ID + "' AND Product_Active='Active' ORDER BY Display_Order";
            cmdText = @"SELECT * FROM dbo.PHM_Product WHERE Event_ID IS NOT NULL and Event_ID='" + Event_ID + "' AND Product_Active=1 ORDER BY Display_Order";
            cmd = new SqlCommand(cmdText, conn);
            da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public string geteventproduct_Price(string Product_ID)
        {
            string Product_Price = string.Empty;
            string cmdText = string.Empty;
            cmdText = @"SELECT Product_Price FROM PHM_Product WHERE Product_ID='" + Product_ID + "' AND Product_Active=1";
            cmd = new SqlCommand(cmdText, conn);
            da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Product_Price = ds.Tables[0].Rows[0]["Product_Price"].ToString();
            }
            return Product_Price;
        }

        public string geteventproduct_Price_New(string Product_ID)
        {
            string New_Price = "";
            string cmdText = string.Empty;
            string cmdText1 = "";
            string Event_ID = "";
            cmdText1 = @"SELECT Event_ID FROM PHM_Product WHERE Product_ID='" + Product_ID + "' AND Product_Active=1";
            SqlCommand mycmd1 = new SqlCommand(cmdText1, conn);
            SqlDataAdapter adap1 = new SqlDataAdapter(mycmd1);
            DataSet ds1 = new DataSet();
            adap1.Fill(ds1);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                Event_ID = ds1.Tables[0].Rows[0]["Event_ID"].ToString();
            }
            if (string.IsNullOrEmpty(Event_ID))
            {
                cmdText = @"SELECT Product_Price AS Product_Price FROM PHM_Product WHERE Product_ID='" + Product_ID + "' AND Product_Active=1";
            }
            else
            {
                cmdText = @"SELECT New_Price AS Product_Price FROm PHM_Product WHERE Product_ID='" + Product_ID + "' AND Product_Active=1";
            }
            cmd = new SqlCommand(cmdText, conn);
            da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                New_Price = ds.Tables[0].Rows[0]["Product_Price"].ToString();
            }
            return New_Price;
        }

        public string geteventshortname(string Event_ID)
        {
            string Event_Short_Nm = "";
            string cmdText = string.Empty;
            cmdText = @"SELECT Event_Short_Nm FROM PHM_Event_Master WHERE Event_ID='" + Event_ID + "'";
            cmd = new SqlCommand(cmdText, conn);
            da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Event_Short_Nm = ds.Tables[0].Rows[0]["Event_Short_Nm"].ToString();
            }
            return Event_Short_Nm;
        }

        public string getMAXid(string Event_ID)
        {
            string astring = string.Empty;
            int MaxID = 0;
            string cmdText = string.Empty;
            cmdText = @"SELECT MAX(ID) AS MaxId FROM PHM_Event_Register WHERE Event_ID='" + Event_ID + "'";
            cmd = new SqlCommand(cmdText, conn);
            da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["MaxID"].ToString() == "")
                {
                    MaxID = 0;
                }
                else
                {
                    MaxID = Convert.ToInt32(ds.Tables[0].Rows[0]["MaxID"].ToString());
                }
                int length = 4;
                astring = MaxID.ToString("D" + length);
            }
            return astring;
        }

        public string getRegistration_Count()
        {
            string Registration_Count = string.Empty;
            string cmdText = string.Empty;
            cmdText = @"SELECT COUNT(*) AS Registration_Count FROM PHM_PG_Response_dtl";
            cmd = new SqlCommand(cmdText, conn);
            da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Registration_Count = ds.Tables[0].Rows[0]["Registration_Count"].ToString();
            }
            return Registration_Count;
        }

        public string geteventproductIDbtName(string Product_Name)
        {
            string Product_ID = string.Empty;
            string cmdText = string.Empty;
            cmdText = @"SELECT Product_ID FROM PHM_Product WHERE Product_Name='" + Product_Name + "' AND  Product_Active=1 AND Event_ID=0";
            cmd = new SqlCommand(cmdText, conn);
            da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Product_ID = ds.Tables[0].Rows[0]["Product_ID"].ToString();
            }
            return Product_ID;
        }

        public string geteventproductnmebyId(string Product_Id)
        {
            string Product_Name = string.Empty;
            string cmdText = string.Empty;
            cmdText = @"SELECT Product_Name FROM PHM_Product WHERE Product_ID='" + Product_Id + "' AND Product_Active='1'";
            cmd = new SqlCommand(cmdText, conn);
            da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Product_Name = ds.Tables[0].Rows[0]["Product_Name"].ToString();
            }
            return Product_Name;
        }

        public DataSet getexistingmember(string batchyear)
        {
            string cmdText = string.Empty;
            if (batchyear != "")
            {
                cmdText = @"SELECT * FROM PHM_Membership_Tbl WHERE Batch='" + batchyear + "'";
            }
            else
            {
                cmdText = @"SELECT * FROM PHM_Membership_Tbl";
            }
            cmd = new SqlCommand(cmdText, conn);
            da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public bool PHM_Event_Registration(string Registration_No, string Are_You_Member, string Membership_No, string Batch_Year, int Course, int Title, string First_Name, string Middle_Name, string Last_Name, string Email_ID, string Mobile_1, string Mobile_2, string STD_Code, string Contact_No, string City, string Company_Name, string Designation, string Session_Knowledge, double Total_Amt, int Event_ID, DateTime Entry_Dt, string Payment_Ref_No, string Last_Four_Char, string Payment_Status, string Transaction_ID, string Address, string Pin, string State)
        {
            bool flag = false;
            cmd = new SqlCommand();
            cmd.CommandText = "PHM_Event_Registration";
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Registration_No", SqlDbType.NVarChar, 20).Value = Registration_No;
            cmd.Parameters.Add("@Are_You_Member", SqlDbType.NVarChar, 5).Value = Are_You_Member;
            cmd.Parameters.Add("@Membership_No", SqlDbType.NVarChar, 50).Value = Membership_No;
            cmd.Parameters.Add("@Batch_Year", SqlDbType.NVarChar, 50).Value = Batch_Year;
            cmd.Parameters.Add("@Course", SqlDbType.Int).Value = Course;
            cmd.Parameters.Add("@Title", SqlDbType.Int).Value = Title;
            cmd.Parameters.Add("@First_Name", SqlDbType.NVarChar, 100).Value = First_Name;
            cmd.Parameters.Add("@Middle_Name", SqlDbType.NVarChar, 100).Value = Middle_Name;
            cmd.Parameters.Add("@Last_Name", SqlDbType.NVarChar, 100).Value = Last_Name;
            cmd.Parameters.Add("@Email_ID", SqlDbType.NVarChar, 150).Value = Email_ID;
            cmd.Parameters.Add("@Mobile_1", SqlDbType.NVarChar, 15).Value = Mobile_1;
            cmd.Parameters.Add("@Mobile_2", SqlDbType.NVarChar, 15).Value = Mobile_2;
            cmd.Parameters.Add("@STD_Code", SqlDbType.NVarChar, 15).Value = STD_Code;
            cmd.Parameters.Add("@Contact_No", SqlDbType.NVarChar, 15).Value = Contact_No;
            cmd.Parameters.Add("@City", SqlDbType.NVarChar, 100).Value = City;
            cmd.Parameters.Add("@Company_Name", SqlDbType.NVarChar, 100).Value = Company_Name;
            cmd.Parameters.Add("@Designation", SqlDbType.NVarChar, 100).Value = Designation;
            cmd.Parameters.Add("@Session_Knowledge", SqlDbType.NVarChar, 5).Value = Session_Knowledge;
            cmd.Parameters.Add("@Total_Amt", SqlDbType.Float).Value = Total_Amt;
            cmd.Parameters.Add("@Event_ID", SqlDbType.Int).Value = Event_ID;
            cmd.Parameters.Add("@Entry_Dt", SqlDbType.DateTime).Value = Entry_Dt;
            cmd.Parameters.Add("@Payment_Ref_No", SqlDbType.NVarChar, 100).Value = Payment_Ref_No;
            cmd.Parameters.Add("@Last_Four_Char", SqlDbType.NVarChar, 5).Value = Last_Four_Char;
            cmd.Parameters.Add("@Payment_Status", SqlDbType.NVarChar, 10).Value = Payment_Status;
            cmd.Parameters.Add("@Transaction_ID", SqlDbType.NVarChar, 50).Value = Transaction_ID;
            cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 150).Value = Address;
            cmd.Parameters.Add("@Pin", SqlDbType.VarChar, 10).Value = Pin;
            cmd.Parameters.Add("@State", SqlDbType.VarChar, 20).Value = State;
            try
            {
                conn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    flag = true;
                }
            }
            catch (SqlException exception)
            {
                throw exception;
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
            return flag;
        }

        public bool PHM_Event_Registration_Trans(string Registration_No, int Product_ID, string Product_Nm, double Product_Amt, string Membership_No)
        {
            bool flag = false;
            cmd = new SqlCommand();
            cmd.CommandText = "Insert_PHM_Event_Trans";
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Registration_No", SqlDbType.NVarChar, 20).Value = Registration_No;
            cmd.Parameters.Add("@Product_ID", SqlDbType.Int).Value = Product_ID;
            cmd.Parameters.Add("@Product_Nm", SqlDbType.NVarChar, 20).Value = Product_Nm;
            cmd.Parameters.Add("@Product_Amt", SqlDbType.Float).Value = Product_Amt;
            cmd.Parameters.Add("@Membership_No", SqlDbType.NVarChar, 50).Value = Membership_No;

            try
            {
                conn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    flag = true;
                }
            }
            catch (SqlException exception)
            {
                throw exception;
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
            return flag;
        }

        public DateTime SplitDate(string date)
        {
            string[] arrDate;
            arrDate = date.Split('/');

            if (arrDate.Length == 1)
            {
                Array.Clear(arrDate, 0, arrDate.Length);
                arrDate = date.Split('-');

            }

            int day = Convert.ToInt32(arrDate[0]);
            int month = Convert.ToInt32(arrDate[1]);
            int year = Convert.ToInt32(arrDate[2]);
            DateTime splitdate = new DateTime(year, month, day);
            return splitdate;
        }

        public bool WhichModuleAssign(string MembershipNo, int module)
        {
            bool value = false;
            cmd = new SqlCommand();
            cmd.CommandText = "WhichModule";
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@module", SqlDbType.Int).Value = module;
            cmd.Parameters.Add("@membershipno", SqlDbType.NVarChar,15).Value = MembershipNo;
            var outPutParameter = new SqlParameter("@value", SqlDbType.Bit);           
            outPutParameter.Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(outPutParameter);
            try
            {
                conn.Open();
                cmd.ExecuteReader();               
                value = (bool)outPutParameter.Value;
            }
            catch (SqlException exception)
            {
                throw exception;
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
            return value;
        }
    }
}