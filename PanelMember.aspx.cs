using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication1
{
    public partial class PanelMember : System.Web.UI.Page
    {
        string FMID;
        protected void Page_Load(object sender, EventArgs e)
        {
            FMID = Session["ID"].ToString();
            using (SqlConnection connection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"))
            {
                connection.Open();
                string statusQuery = "SELECT P.Title FROM PanelMember PM, FYP_GROUPS FG, Project P WHERE(PM.PanelID = FG.PanelID) AND(PM.FacultyID = @FMID) AND(P.ProjectID = FG.ProjectID)";


                using (SqlCommand cmd = new SqlCommand(statusQuery, connection))
                {

                    cmd.Parameters.AddWithValue("@FMID", FMID);
                    
                    SqlDataAdapter d = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    d.Fill(dt);
                    GridView3.DataSource = dt;
                    GridView3.DataBind();
                    cmd.ExecuteNonQuery();
                }

                connection.Close();
            }

        }


        //View Group members
        protected void Button1_Click(object sender, EventArgs e)
        {
            //            Select S.Name from Student S inner join FYP_GROUP_MEMBERS F on S.RollNo = F.StudentID where F.GroupID = (Select GroupID from FYP_GROUPS where Supervisor = 221)
            using (SqlConnection connection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"))
            {
                connection.Open();
                string statusQuery = "Select S.Name from Student S inner join FYP_GROUP_MEMBERS F on S.RollNo = F.StudentID where F.GroupID = (Select GroupID from FYP_GROUPS where Supervisor = @FMID)";


                SqlCommand cmd = new SqlCommand(statusQuery, connection);

                cmd.Parameters.AddWithValue("@FMID", FMID);


                SqlDataReader reader = cmd.ExecuteReader();


                GridView4.DataSource = reader;
                GridView4.DataBind();

                connection.Close();
            }
        }

        //view description
        protected void Button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"))
            {
                connection.Open();
                string statusQuery = "Select Description = P.Details from Project P, FYP_Groups FG where P.ProjectID = FG.ProjectID and FG.Supervisor = @FMID";


                SqlCommand cmd = new SqlCommand(statusQuery, connection);

                cmd.Parameters.AddWithValue("@FMID", FMID);


                SqlDataReader reader = cmd.ExecuteReader();

                GridView2.DataSource = reader;
                GridView2.DataBind();

                connection.Close();

            }
        }

        //Check evaluation form
        protected void Button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"))
            {
                connection.Open();
                Response.Write(FMID);
                string statusQuery = "Select EvaluationStatus from PanelMember where FacultyID=@FMID";


                using (SqlCommand cmd = new SqlCommand(statusQuery, connection))
                {

                    cmd.Parameters.AddWithValue("@FMID", FMID);


                    SqlDataAdapter d = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    d.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        //Fill evaluation form
        protected void Button4_Click(object sender, EventArgs e)
        {
                Response.Redirect("EvaluationForm.aspx"); 
        }
    }
}