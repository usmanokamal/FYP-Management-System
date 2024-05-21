using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;

namespace WebApplication1
{
    public partial class Student : Page
    {
        string RollNo; int groupID;
        protected void loadPanel()
        {
            //Load Panel member grid view
            using (SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"))
            {
                con.Open();
                string query = "SELECT F.Name FROM FYP_GROUPS FG, PanelMember PM, Faculty F WHERE(FG.GroupID = @grpID) AND(PM.PanelID = FG.PanelID) AND(F.FacultyID = PM.FacultyID)";
                string query2 = "SELECT P.Name FROM FYP_GROUPS FG, Panel P WHERE(FG.groupID = @grpID) AND(FG.PanelID = P.PanelID)";

                using (SqlCommand comm = new SqlCommand(query2, con))
                {
                    comm.Parameters.AddWithValue("@grpID", groupID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string title = reader.GetString(0);
                            //formulate the label.
                            Label5.Text = "Panel Title: " + " " + title;
                        }
                    }

                }
                using (SqlCommand comm = new SqlCommand(query, con))
                {
                    comm.Parameters.AddWithValue("@grpID", groupID);

                    SqlDataAdapter d = new SqlDataAdapter(comm);
                    DataTable dt = new DataTable();
                    d.Fill(dt);
                    GridView3.DataSource = dt;
                    GridView3.DataBind();
                    comm.ExecuteNonQuery();
                }

                con.Close();
            }
        }
        protected void loadProjectDetails()
        {
            //Load the proj title
            using (SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"))
            {
                con.Open();

                string query = "SELECT P.Title FROM Project P, FYP_GROUP_MEMBERS FM, FYP_GROUPS FG WHERE (FM.StudentID = @RollNo) AND (P.ProjectID = FG.ProjectID) AND (FM.GroupID = FG.GroupID)";
                SqlCommand comm = new SqlCommand(query, con);
                comm.Parameters.AddWithValue("@RollNo", RollNo);

                SqlDataReader reader = comm.ExecuteReader();
                if (reader.Read())
                {
                    string title = reader.GetString(0);
                    //formulate the label.
                    Label1.Text = "Project Title: " + " " + title;
                }

                con.Close();
            }//Load the proj description
            using (SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"))
            {
                con.Open();

                string query = "SELECT P.Details FROM Project P, FYP_GROUP_MEMBERS FM, FYP_GROUPS FG WHERE (FM.StudentID = @RollNo) AND (P.ProjectID = FG.ProjectID) AND (FM.GroupID = FG.GroupID)";
                SqlCommand comm = new SqlCommand(query, con);
                comm.Parameters.AddWithValue("@RollNo", RollNo);

                SqlDataReader reader = comm.ExecuteReader();
                if (reader.Read())
                {
                    string desc = reader.GetString(0);
                    //formulate the label.
                    Label4.Text = "Project Description: " + " " + desc;
                }

                con.Close();
            }
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-L3TS5LN\\SQLEXPRESS;Initial Catalog=FYPDB;Integrated Security=True"
                ))
            {
                con.Open();
                //supervisor
                string query2 = "SELECT F.Name FROM Faculty F, FYP_GROUPS FF, FYP_GROUP_MEMBERS FM WHERE (FM.StudentID = @RollNo) AND (FM.GroupID = FF.GroupID) AND (F.FacultyID = FF.Supervisor)";

                SqlCommand comm = new SqlCommand(query2, con);
                comm.Parameters.AddWithValue("@RollNo", RollNo);

                SqlDataReader reader = comm.ExecuteReader();
                if (reader.Read())
                {
                    string supervisor = reader.GetString(0);
                    //formulate the label.
                    Label2.Text = "Supervised By: " + " " + supervisor;
                }
                con.Close();
            }
            // Load the group members
            using (SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"))
            {
                con.Open();
                string query = "SELECT F.StudentID as ID, S.Name as Name FROM FYP_GROUP_MEMBERS F, Student S WHERE F.GroupID = (SELECT GroupID FROM FYP_GROUP_MEMBERS WHERE StudentID = @RollNo) AND(F.StudentID = S.RollNo)";

                SqlCommand comm = new SqlCommand(query, con);
                comm.Parameters.AddWithValue("@RollNo", RollNo);

                SqlDataAdapter d = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                d.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                GridView1.CellSpacing = 10;
                GridView1.CellPadding = 10;
                comm.ExecuteNonQuery();
                con.Close();
            }
        }
        protected void loadDeadline()
        {

            using (SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"))
            {
                con.Open();
                string query = "SELECT D.Type, D.dueDate FROM Deadline D, FYP_GROUPS FG WHERE(FG.GroupID = @grpID) AND(D.ProjectID = FG.ProjectID)";
                SqlCommand comm = new SqlCommand(query, con);
                comm.Parameters.AddWithValue("@grpID", groupID);

                SqlDataAdapter d = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                d.Fill(dt);
                GridView2.DataSource = dt;
                GridView2.DataBind();
                comm.ExecuteNonQuery();
                con.Close();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //Hide the error msg
            gradeNA.Visible = false;
            RollNo = Session["ID"].ToString();
            //Response.Write(RollNo);
            //Get groupID of user
            using (SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"))
            {
                con.Open();
                string query = "SELECT FG.GroupID FROM FYP_GROUP_MEMBERS FG WHERE FG.StudentID = @RollNo";
                SqlCommand comm = new SqlCommand(query, con);
                comm.Parameters.AddWithValue("@RollNo", RollNo);
                groupID = Convert.ToInt32(comm.ExecuteScalar());

                con.Close();
            }

            loadProjectDetails();
            loadDeadline();
            loadPanel();
        }
        // Generates grade from data
        protected void Button2_Click1(object sender, EventArgs e)
        {
            //Check if grade exists
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-L3TS5LN\\SQLEXPRESS;Initial Catalog=FYPDB;Integrated Security=True"
                ))
            {
                con.Open();
                string query = "SELECT F.Grade FROM FYP_GROUP_MEMBERS F WHERE F.StudentID = @RollNo";
                using (SqlCommand comm = new SqlCommand(query, con))
                {
                    comm.Parameters.AddWithValue("@RollNo", RollNo);

                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string grade = reader.GetString(0);
                            if (grade == "NA")
                            {
                                //Response.Write("Grade not Assigned! ");
                                gradeNA.Visible = true;
                                //Response.Write("<script>alert('Grade not yet assigned!');</script>");
                            }
                            else
                            {
                                Label1.ForeColor = System.Drawing.Color.Green;
                                gradeNA.Text = "Grade: " + grade;
                                Label1.ForeColor = System.Drawing.Color.Green;
                                gradeNA.Visible = true;
                            }
                        }
                    }
                }
                con.Close();
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"))
            {
                con.Open();
                string query = "SELECT FG.Evaluation FROM FYP_GROUP_MEMBERS FG WHERE FG.StudentID = @RollNo";
                using (SqlCommand comm = new SqlCommand(query, con))
                {
                    comm.Parameters.AddWithValue("@RollNo", RollNo);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string evaluation = reader.GetString(0);
                            if (evaluation == "NA")
                            {
                                Response.Write("<script>alert('Evaluation not yet submitted.');</script>");
                            }
                            else
                            {
                                Label1.ForeColor = System.Drawing.Color.Green;
                                gradeNA.Text = "Evaluation: " + evaluation;
                                Label1.ForeColor = System.Drawing.Color.Green;
                                gradeNA.Visible = true;
                            }
                        }
                    }
                }
                con.Close();
            }
        }
    }
}