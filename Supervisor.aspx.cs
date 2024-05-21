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
    public partial class Supervisor : Page
    {
        string FacultyID;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Hide the error msg
            gradeNA.Visible = false;
            FacultyID = Session["ID"].ToString();
            //Response.Write(RollNo);
            //Populate the FYP Dropdown
            if (IsPostBack)
                return;

            using (SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"))
            {
                con.Open();
                //display all FYPs under a supervisor X
                string query = "SELECT FG.GroupID as ID FROM FYP_GROUPS FG WHERE FG.Supervisor = @facultyID";


                using (SqlCommand comm = new SqlCommand(query, con))
                {
                    comm.Parameters.AddWithValue("@facultyID", FacultyID);

                    SqlDataAdapter SDA = new SqlDataAdapter(comm);
                    DataSet ds = new DataSet();
                    SDA.Fill(ds);
                    DropDownList1.DataTextField = ds.Tables[0].Columns["ID"].ToString();
                    DropDownList1.DataValueField = ds.Tables[0].Columns["ID"].ToString();

                    DropDownList1.DataSource = ds.Tables[0];
                    DropDownList1.DataBind();
                }
                con.Close();
            }
        }
        // Give Suggestions
        protected void Button2_Click1(object sender, EventArgs e)
        {
            //Redirect to suggestion page
            Session["ID"] = FacultyID;
            Response.Redirect("Suggestions.aspx");
        }
        // View Panel Suggestions
        protected void Button1_Click1(object sender, EventArgs e)
        {
        }
        protected void DropDownChange (object sender, EventArgs e)
        {
            //Validation for default
            if (DropDownList1.SelectedValue == "0")
                return;

            // get value from dropdown.
            string groupID = DropDownList1.SelectedValue.ToString();
            //load new data 
            using (SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"))
            {
                con.Open();
                // Populate the FYP Group Gridview
                string query = "SELECT S.Name as 'Name', FGM.Grade as 'Grade' FROM FYP_GROUP_MEMBERS FGM, Student S WHERE FGM.GroupID = @groupID AND (S.RollNo = FGM.StudentID)";
                using (SqlCommand comm = new SqlCommand(query, con))
                {
                    comm.Parameters.AddWithValue("@groupID", groupID);

                    SqlDataAdapter d = new SqlDataAdapter(comm);
                    DataTable dt = new DataTable();
                    d.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    comm.ExecuteNonQuery();
                }
                //Set Project Title
                query = "SELECT P.Title FROM FYP_GROUPS FG, Project P WHERE(FG.ProjectID = P.ProjectID) AND (FG.GroupID = @grpID)";
                using (SqlCommand comm = new SqlCommand(query, con))
                {
                    comm.Parameters.AddWithValue("@grpID", groupID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string title = reader.GetString(0);
                            //formulate the label.
                            Label1.Text = "Project Title: " + " " + title;
                        }
                    }
                }
                //Set Proj Description
                query = "SELECT P.Details FROM FYP_GROUPS FG, Project P WHERE(FG.ProjectID = P.ProjectID) AND (FG.GroupID = @grpID)";
                using (SqlCommand comm = new SqlCommand(query, con))
                {
                    comm.Parameters.AddWithValue("@grpID", groupID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string title = reader.GetString(0);
                            //formulate the label.
                            Label4.Text = "Project Title: " + " " + title;
                        }
                    }
                }

                // Populate the Panel Gridview
                query = "SELECT F.Name FROM FYP_GROUPS FG, PanelMember PM, Faculty F WHERE(FG.GroupID = @groupID) AND(PM.PanelID = FG.PanelID) AND(F.FacultyID = PM.FacultyID)";
                using (SqlCommand comm = new SqlCommand(query, con))
                {
                    comm.Parameters.AddWithValue("@groupID", groupID);

                    SqlDataAdapter d = new SqlDataAdapter(comm);
                    DataTable dt = new DataTable();
                    d.Fill(dt);
                    GridView3.DataSource = dt;
                    GridView3.DataBind();
                    comm.ExecuteNonQuery();
                }
                // Load Panel Title
                query = "SELECT P.Name FROM FYP_GROUPS FG, Panel P WHERE(FG.groupID = @grpID) AND(FG.PanelID = P.PanelID)";
                using (SqlCommand comm = new SqlCommand(query, con))
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
                // Populate the FYP Deadlines
                query = "SELECT D.Type, D.dueDate FROM Deadline D, FYP_GROUPS FG WHERE(FG.GroupID = @groupID) AND(D.ProjectID = FG.ProjectID)";
                using (SqlCommand comm = new SqlCommand(query, con))
                {
                    comm.Parameters.AddWithValue("@groupID", groupID);

                    SqlDataAdapter d = new SqlDataAdapter(comm);
                    DataTable dt = new DataTable();
                    d.Fill(dt);
                    GridView2.DataSource = dt;
                    GridView2.DataBind();
                    comm.ExecuteNonQuery();
                }


                con.Close();
            }
        }
    }
}