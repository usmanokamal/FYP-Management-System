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
    public partial class FypCommittee : System.Web.UI.Page
    {
        static int count = 0;
        static string l1;
        static string l2;
        static string l4;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {





                Label1.Visible = false;
                Label2.Visible = false;
                Label3.Visible = false;
                Label4.Visible = false;
                LblError.Visible = false;
                heading1.Visible=false;
                heading2.Visible=false;
                lblError2.Visible = false;
                lblSuccess2.Visible = false;
                lbl_Deadlineerr.Visible=false;
                grp_members.Visible = false;
                Grid_Students.Visible = false;
                GridView_WorkLoad.Visible=false;
                GridView_Report1.Visible=false;
                GridView_Report2.Visible=false;
                GridView_AllProjects.Visible=false;
                fill_SupervisorDropdown();
                fill_ProjectDropdown();

                display_supervisors();
                display_Project();
            }

            GridView_AllProjects.Visible=true;
            using (SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"
               ))
            {
                string query = "SELECT Project.ProjectID,title AS Project_Title,Deadline.dueDate as Deadline FROM Project INNER JOIN Deadline ON Deadline.ProjectID=Project.ProjectID  WHERE Project.ProjectID=" + DropDown_projidDead.SelectedValue + "";
                SqlCommand comma = new SqlCommand(query, con);
                con.Open();

                SqlDataReader reader = comma.ExecuteReader();

                GridView_AllProjects.DataSource = reader;
                GridView_AllProjects.DataBind();

                con.Close();

            }

        }

        protected void newUser_Click(object sender, EventArgs e)
        {

            Response.Redirect("NewUser.aspx");

        }


        //Shows grp and project details of searched student
        protected void search_Click1(object sender, EventArgs e)
        {

            if (count==0)
            {
                l1 = Label1.Text;
                l4 = Label4.Text;
                l2 = Label2.Text;

            }

            count++;
            if (count>0)
            {
                Label1.Text=l1;
                Label4.Text=l4;
                Label2.Text=l2;
            }



            //Proj title
            using (SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"
                 ))
            {
                con.Open();

                string query = "SELECT P.Title FROM Project P, FYP_GROUP_MEMBERS FM, FYP_GROUPS FG WHERE (FM.StudentID = @RollNo) AND (P.ProjectID = FG.ProjectID) AND (FM.GroupID = FG.GroupID)";
                SqlCommand comm = new SqlCommand(query, con);
                comm.Parameters.AddWithValue("@RollNo", search_bar.Text);


                try
                {
                    SqlDataReader reader = comm.ExecuteReader();

                    if (reader.Read())
                    {
                        Label1.Visible = true;
                        string title = reader.GetString(0);


                        //formulate the label.
                        Label1.Text = Label1.Text + " " + title;
                    }

                }
                catch (SqlException ex)
                {
                    LblError.Visible = true;
                }


                con.Close();
            }
            //Proj Description
            using (SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"
                ))
            {
                con.Open();

                string query = "SELECT P.Details FROM Project P, FYP_GROUP_MEMBERS FM, FYP_GROUPS FG WHERE (FM.StudentID = @RollNo) AND (P.ProjectID = FG.ProjectID) AND (FM.GroupID = FG.GroupID)";
                SqlCommand comm = new SqlCommand(query, con);
                comm.Parameters.AddWithValue("@RollNo", search_bar.Text);


                try
                {
                    SqlDataReader reader = comm.ExecuteReader();
                    if (reader.Read())
                    {
                        Label2.Visible = true;
                        Label3.Visible = true;
                        Label4.Visible = true;


                        string desc = reader.GetString(0);
                        //formulate the label.
                        Label4.Text = Label4.Text + " " + desc;

                    }
                }

                catch (SqlException ex)
                {
                    LblError.Visible = true;
                }

                con.Close();
            }


            //Supervisor
            using (SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"
                ))
            {
                con.Open();
                //supervisor
                string query2 = "SELECT F.Name FROM Faculty F, FYP_GROUPS FF, FYP_GROUP_MEMBERS FM WHERE (FM.StudentID = @RollNo) AND (FM.GroupID = FF.GroupID) AND (F.FacultyID = FF.Supervisor)";

                SqlCommand comm = new SqlCommand(query2, con);
                comm.Parameters.AddWithValue("@RollNo", search_bar.Text);
                try
                {
                    SqlDataReader reader = comm.ExecuteReader();
                    if (reader.Read())
                    {


                        string supervisor = reader.GetString(0);
                        //formulate the label.
                        Label2.Text = Label2.Text + " " + supervisor;
                    }
                }

                catch (SqlException ex)
                {
                    LblError.Visible = true;
                }

                con.Close();
            }

            //Get grp members
            using (SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"
                 ))
            {
                con.Open();
                string query = "SELECT F.StudentID, S.Name FROM FYP_GROUP_MEMBERS F, Student S WHERE F.GroupID = (SELECT GroupID FROM FYP_GROUP_MEMBERS WHERE StudentID = @RollNo) AND(F.StudentID = S.RollNo)";
                grp_members.Visible = true;
                SqlCommand comm = new SqlCommand(query, con);
                comm.Parameters.AddWithValue("@RollNo", search_bar.Text);


                try
                {

                    SqlDataAdapter d = new SqlDataAdapter(comm);
                    DataTable dt = new DataTable();
                    d.Fill(dt);
                    grp_members.DataSource = dt;
                    grp_members.DataBind();

                    comm.ExecuteNonQuery();

                }


                catch (SqlException ex)
                {
                    LblError.Visible = true;
                }
                con.Close();

            }




        }

        void display_supervisors()
        {
            GridView_Supervisor.Visible=true;
            SqlConnection connection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;");
            SqlCommand command = new SqlCommand("SELECT Facultyid as SupervisorID, Name from Faculty where  FacultyID = '" + Dropdown_Supervisor.SelectedValue + "'", connection);
            connection.Open();

            try
            {
                SqlDataAdapter Adpt = new SqlDataAdapter(command);
                DataTable dt2 = new DataTable();
                Adpt.Fill(dt2);
                GridView_Supervisor.DataSource = dt2;
                GridView_Supervisor.DataBind();
            }
            catch (SqlException ex)
            {


            }


            connection.Close();

        }
        void display_Project()
        {
            GridView_Project.Visible=true;
            using (SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"
               ))
            {
                string query = "SELECT  Supervisor.Facultyid AS Current_SupervisorID , Supervisor.Projectid AS Project_ID, Project.title AS Project_Title FROM Supervisor inner join Project on Supervisor.Projectid=Project.ProjectID WHERE  Supervisor.Projectid= '" + Dropdown_Projects.SelectedValue + "'";
                SqlCommand comm = new SqlCommand(query, con);
                con.Open();

                SqlDataReader reader = comm.ExecuteReader();



                GridView_Project.DataSource = reader;
                GridView_Project.DataBind();

                con.Close();

            }


        }

        //Shows all registered students
        protected void btn_students_Click(object sender, EventArgs e)
        {
            if (Grid_Students.Visible)
            {
                Grid_Students.Visible=false;
            }
            else
            {
                Grid_Students.Visible=true;
            }

            using (SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"
                 ))
            {
                string query = "SELECT RollNo, Name FROM Student";
                SqlCommand comm = new SqlCommand(query, con);
                con.Open();

                SqlDataReader reader = comm.ExecuteReader();

                if (reader.Read())
                {

                    Grid_Students.DataSource = reader;
                    Grid_Students.DataBind();

                    con.Close();
                }
            }

        }



        protected void btn_Workload_Click(object sender, EventArgs e)
        {

            if (GridView_WorkLoad.Visible)
            {
                GridView_WorkLoad.Visible=false;
            }
            else
            {
                GridView_WorkLoad.Visible=true;
            }


            using (SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"
                ))
            {
                //string query = "SELECT  Supervisor.Facultyid AS SupervisorID, Name , COUNT(Projectid) AS FYPS FROM Supervisor INNER JOIN Faculty on Faculty.FacultyID=Supervisor.Facultyid GROUP BY Supervisor.Facultyid,Name";
                string query = "SELECT Supervisor.Facultyid AS SupervisorID , Supervisor.Projectid AS Project_ID, Project.title AS Project_Title FROM Supervisor inner join Project on Supervisor.Projectid=Project.ProjectID WHERE Supervisor.Facultyid= '" + Dropdown_Supervisor.SelectedValue  + "'";
                SqlCommand comm = new SqlCommand(query, con);
                con.Open();

                SqlDataReader reader = comm.ExecuteReader();



                GridView_WorkLoad.DataSource = reader;
                GridView_WorkLoad.DataBind();

                con.Close();

            }


        }

        protected void btn_supervisors_Click(object sender, EventArgs e)
        {



            //Workloud count

            using (SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"
                ))
            {
                //+Dropdown_Supervisor.SelectedValue +
                string query = "SELECT  Supervisor.Facultyid AS SupervisorID, Name , COUNT(Projectid) AS FYPS FROM Supervisor INNER JOIN Faculty on Faculty.FacultyID=Supervisor.Facultyid GROUP BY Supervisor.Facultyid,Name";

                SqlCommand comm = new SqlCommand(query, con);
                con.Open();

                SqlDataReader reader = comm.ExecuteReader();

                heading1.Visible=true;
                heading1.Text="Supervisors and Number of FYPs they supervise";
                GridView_Report1.Visible = true;
                GridView_Report1.DataSource = reader;
                GridView_Report1.DataBind();

                con.Close();

            }

            //What fyps they taking

            using (SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"
                ))
            {
                string query = " Select Facultyid AS SupervisorID, Supervisor.Projectid , Project.Title FROM Supervisor INNER JOIN Project on Supervisor.Projectid=Project.ProjectID";
                SqlCommand comm = new SqlCommand(query, con);
                con.Open();

                SqlDataReader reader = comm.ExecuteReader();

                heading2.Visible=true;

                heading2.Text="Supervisors and FYPs";
                GridView_Report2.Visible = true;
                GridView_Report2.DataSource = reader;
                GridView_Report2.DataBind();

                con.Close();

            }
        }

        protected void btn_Evaluations_Click(object sender, EventArgs e)
        {
            heading2.Visible=false;
            heading2.Text="Statistics of Grades";
            GridView_Report2.Visible = false;
            //Missing Evaluations by Panel

            using (SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"
                ))
            {
                string query = "SELECT Name, PanelMember.FacultyID ,EvaluationStatus from PanelMember INNER JOIN Faculty on Faculty.FacultyID=PanelMember.FacultyID  WHERE EvaluationStatus = 'Missing'";
                SqlCommand comm = new SqlCommand(query, con);
                con.Open();

                SqlDataReader reader = comm.ExecuteReader();


                heading1.Visible=true;
                heading1.Text="Missing Evaluation by Faculty";
                GridView_Report1.Visible = true;
                GridView_Report1.DataSource = reader;
                GridView_Report1.DataBind();

                con.Close();

            }

            //Other Faculty needed

            //Missing Evaluation by Students
        }

        void fill_SupervisorDropdown()
        {
            using (SqlConnection connec = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"))
            {

                string dropQuery = "SELECT DISTINCT Facultyid From Supervisor";
                connec.Open();
                SqlDataAdapter adpt = new SqlDataAdapter(dropQuery, connec);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                Dropdown_Supervisor.DataSource = dt;
                Dropdown_Supervisor.DataBind();
                Dropdown_Supervisor.DataTextField = "Facultyid";
                Dropdown_Supervisor.DataValueField = "Facultyid";
                Dropdown_Supervisor.DataBind();
                connec.Close();

            }

        }


        void fill_ProjectDropdown()
        {
            using (SqlConnection connec = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"))
            {

                string dropQuery = "SELECT ProjectID From Project";
                connec.Open();
                SqlDataAdapter adpt = new SqlDataAdapter(dropQuery, connec);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                Dropdown_Projects.DataSource = dt;
                Dropdown_Projects.DataBind();
                Dropdown_Projects.DataTextField = "ProjectID";
                Dropdown_Projects.DataValueField = "ProjectID";
                Dropdown_Projects.DataBind();
                connec.Close();

            }

            using (SqlConnection connec = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"))
            {

                string dropQuery = "SELECT ProjectID From Project";
                connec.Open();
                SqlDataAdapter adpt = new SqlDataAdapter(dropQuery, connec);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                DropDown_projidDead.DataSource = dt;
                DropDown_projidDead.DataBind();
                DropDown_projidDead.DataTextField = "ProjectID";
                DropDown_projidDead.DataValueField = "ProjectID";
                DropDown_projidDead.DataBind();
                connec.Close();

            }



        }
        protected void btn_Grades_Click(object sender, EventArgs e)
        {

            heading2.Visible=false;
            heading2.Text="Statistics of Grades";
            GridView_Report2.Visible = false;

            using (SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"
               ))
            {
                string query = "SELECT GRADE AS GRADE, COUNT(grade)*100/(SELECT COUNT(grade) FROM FYP_GROUP_MEMBERS) AS Percentage FROM FYP_GROUP_MEMBERS GROUP BY GRADE";
                SqlCommand comm = new SqlCommand(query, con);
                con.Open();

                SqlDataReader reader = comm.ExecuteReader();


                heading1.Visible=true;
                heading1.Text="Statistics of Grades";
                GridView_Report1.Visible = true;
                GridView_Report1.DataSource = reader;
                GridView_Report1.DataBind();

                con.Close();

            }




        }

        protected void Dropdown_Supervisor_SelectedIndexChanged(object sender, EventArgs e)
        {
            display_supervisors();
        }

        protected void Dropdown_Projects_SelectedIndexChanged(object sender, EventArgs e)
        {
            display_Project();
        }

        protected void btn_Allocate_Click(object sender, EventArgs e)
        {
            lblError2.Visible = false;
            lblSuccess2.Visible = false;
            using (SqlConnection connection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"))
            {
                string query1 = "UPDATE Supervisor SET Facultyid = @newID WHERE Projectid = @Projid ";
                SqlCommand comm = new SqlCommand(query1, connection);

                comm.Parameters.AddWithValue("@newID", Dropdown_Supervisor.SelectedValue);
                comm.Parameters.AddWithValue("@Projid", Dropdown_Projects.SelectedValue);
                connection.Open();



                try
                {
                    int rowsaffected = comm.ExecuteNonQuery();


                    if (rowsaffected==0)
                    {
                        lblError2.Visible = true;
                    }

                    else
                    {
                        //Update Fyp_Group
                        query1 = "UPDATE FYP_GROUPS SET Supervisor = @newID WHERE ProjectID = @Projid ";
                        SqlCommand coma = new SqlCommand(query1, connection);

                        coma.Parameters.AddWithValue("@newID", Dropdown_Supervisor.SelectedValue);
                        coma.Parameters.AddWithValue("@Projid", Dropdown_Projects.SelectedValue);

                        try
                        {
                            coma.ExecuteNonQuery();

                            lblSuccess2.Visible = true;
                        }

                        catch (SqlException ex)
                        {
                            lblError2.Visible = true;
                        }

                    }



                }
                catch (SqlException ex)
                {
                    lblError2.Visible = true;
                }

                display_Project();

                connection.Close();
            }
        }

        protected void DropDown_projidDead_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView_AllProjects.Visible=true;
            using (SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"
               ))
            {
                string query = "SELECT Project.ProjectID,title AS Project_Title,Deadline.dueDate as Deadline FROM Project INNER JOIN Deadline ON Deadline.ProjectID=Project.ProjectID  WHERE Project.ProjectID=" + DropDown_projidDead.SelectedValue + "";
                SqlCommand comm = new SqlCommand(query, con);
                con.Open();

                SqlDataReader reader = comm.ExecuteReader();

                GridView_AllProjects.DataSource = reader;
                GridView_AllProjects.DataBind();

                con.Close();

            }
        }


        protected void btn_UpdateDeadline_Click(object sender, EventArgs e)
        {

            using (SqlConnection connection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"))
            {
                string query1 = "UPDATE Deadline SET dueDate = @Date WHERE Projectid = @Projid ";
                SqlCommand comm = new SqlCommand(query1, connection);
                string Date = tbox_month.Text.ToString() + '/' + tbox_day.Text.ToString() + '/' +  tbox_year.Text.ToString();

                comm.Parameters.AddWithValue("@Date", Date);
                comm.Parameters.AddWithValue("@Projid", DropDown_projidDead.SelectedValue);
                connection.Open();

                try
                {
                    comm.ExecuteNonQuery();

                    GridView_AllProjects.Visible=true;
                    using (SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"
                       ))
                    {
                        string query = "SELECT Project.ProjectID,title AS Project_Title,Deadline.dueDate as Deadline FROM Project INNER JOIN Deadline ON Deadline.ProjectID=Project.ProjectID  WHERE Project.ProjectID=" + DropDown_projidDead.SelectedValue + "";
                        SqlCommand comma = new SqlCommand(query, con);
                        con.Open();

                        SqlDataReader reader = comma.ExecuteReader();

                        GridView_AllProjects.DataSource = reader;
                        GridView_AllProjects.DataBind();

                        con.Close();

                    }

                }

                catch (SqlException x)
                {
                    lbl_Deadlineerr.Visible=true;

                }
            }



            //Deadline code
        }
    }
}