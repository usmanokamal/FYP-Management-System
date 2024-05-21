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
    public partial class NewStudent: System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
            lblSuccess.Visible = false;
            //Load values for dropdown
            using (SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"))
            {
                string dropQuery = "SELECT F.Name as Name, S.FacultyID as ID FROM Faculty F, Supervisor S WHERE F.FacultyID = S.FacultyID GROUP BY F.Name, S.facultyID HAVING COUNT(S.FacultyID) < 6";
                con.Open();
                using (SqlCommand comm = new SqlCommand(dropQuery, con))
                {
                    SqlDataAdapter SDA = new SqlDataAdapter(comm);
                    DataSet ds = new DataSet();
                    SDA.Fill(ds);
                    DropDownList.DataTextField = ds.Tables[0].Columns["Name"].ToString();
                    DropDownList.DataValueField = ds.Tables[0].Columns["ID"].ToString();

                    DropDownList.DataSource = ds.Tables[0];
                    DropDownList.DataBind();
                }
                con.Close();
            }

        }


        protected bool doesStudentExist(string ID)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"))
            {
                con.Open();
                string grpQuery = "SELECT COUNT(1) FROM STUDENT S WHERE S.RollNo = @RollNo";
                using (SqlCommand comm = new SqlCommand(grpQuery, con))
                {
                    comm.Parameters.AddWithValue("@RollNo", ID);
                    int exists = Convert.ToInt32(comm.ExecuteScalar());


                    con.Close();
                    if (exists == 0)
                    {
                        return false;
                    }
                    else return true;
                }
            }
        }
        protected bool isStudentUnassigned(string ID)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"))
            {
                con.Open();
                string grpQuery = "SELECT COUNT(1) FROM FYP_GROUP_MEMBERS FG WHERE FG.StudentID = @RollNo";
                using (SqlCommand comm = new SqlCommand(grpQuery, con))
                {
                    comm.Parameters.AddWithValue("@RollNo", ID);
                    int isStudentRegistered = Convert.ToInt32(comm.ExecuteScalar());


                    con.Close();
                    if (isStudentRegistered == 0)
                    {
                        return true;
                    }
                    else return false;
                }
            }
        }

        protected void Insert_data_Click(object sender, EventArgs e)
        {

            using (SqlConnection connection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"))
            {
                string ID = DropDownList.SelectedValue.ToString();
                connection.Open();

                // Validation Checks
                // Check if student exists in DB
                bool validStu1 = doesStudentExist(input1.Text);
                bool validStu2 = doesStudentExist(input2.Text);
                bool validStu3 = doesStudentExist(input3.Text);

                bool stu1 = isStudentUnassigned(input1.Text);
                bool stu2 = isStudentUnassigned(input2.Text);
                bool stu3 = isStudentUnassigned(input3.Text);

                if (!validStu1 || !validStu1 || !validStu1)
                {
                    Response.Write("<script>alert('One of the students does not exist in database');</script>");
                }
                else if (!stu1 || !stu2 || !stu3)
                {
                    Response.Write("<script>alert('One of the students is already registered in another FYP!');</script>");
                }
                else
                {
                    //Generate New IDs
                    string nextIDQueryForGroup = "SELECT MAX(groupID) + 1 FROM FYP_GROUPS";
                    string nextIDQueryForProject = "SELECT MAX(ProjectID) + 1 FROM PROJECT";
                    int nextIDGroup, nextIDProject;
                    using (SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"))
                    {
                        con.Open();
                        using (SqlCommand comm = new SqlCommand(nextIDQueryForGroup, con))
                        {
                            nextIDGroup = Convert.ToInt32(comm.ExecuteScalar());
                        }
                        con.Close();
                    }
                    using (SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"))
                    {
                        con.Open();
                        using (SqlCommand comm = new SqlCommand(nextIDQueryForProject, con))
                        {
                            nextIDProject = Convert.ToInt32(comm.ExecuteScalar());
                        }
                        con.Close();
                    }

                    string addFYPGroup = "INSERT INTO FYP_GROUPS VALUES(@groupID, @SupervisorID, @ProjectID, @PanelID, 'Not Submitted', 'Not Submitted', 'Not Submitted')";
                    string addProject = "INSERT INTO PROJECT VALUES (@ProjectID, @ProjectTitle, @ProjectDesc)";
                    string addGroupMember = "INSERT INTO FYP_GROUP_MEMBERS VALUES (@groupID, @RollNo, 'NA', 'NA')";
                    string assignToSupervisor = "INSERT INTO Supervisor VALUES (@SupervisorID, @ProjectID)";

                    //First add new project.
                    using (SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"))
                    {
                        con.Open();
                        //First add new project
                        using (SqlCommand comm = new SqlCommand(addProject, con))
                        {
                            comm.Parameters.AddWithValue("@ProjectID", nextIDProject);
                            comm.Parameters.AddWithValue("@ProjectTitle", input4.Text.ToString());
                            comm.Parameters.AddWithValue("@ProjectDesc", input5.Text.ToString());
                            comm.ExecuteNonQuery();
                        }
                        //Next add new group
                        using (SqlCommand comm = new SqlCommand(addFYPGroup, con))
                        {
                            comm.Parameters.AddWithValue("@groupID", nextIDGroup);
                            comm.Parameters.AddWithValue("@SupervisorID", ID);
                            comm.Parameters.AddWithValue("@ProjectID", nextIDProject);
                            comm.Parameters.AddWithValue("@PanelID", 1); //TO UPDATE
                            comm.ExecuteNonQuery();
                        }
                        //Next add the members
                        // Member 1
                        using (SqlCommand comm = new SqlCommand(addGroupMember, con))
                        {
                            comm.Parameters.AddWithValue("@groupID", nextIDGroup);
                            comm.Parameters.AddWithValue("@RollNo", input1.Text.ToString());
                            comm.ExecuteNonQuery();
                        }
                        // Member 2
                        using (SqlCommand comm = new SqlCommand(addGroupMember, con))
                        {
                            comm.Parameters.AddWithValue("@groupID", nextIDGroup);
                            comm.Parameters.AddWithValue("@RollNo", input2.Text.ToString());
                            comm.ExecuteNonQuery();
                        }
                        // Member 3
                        using (SqlCommand comm = new SqlCommand(addGroupMember, con))
                        {
                            comm.Parameters.AddWithValue("@groupID", nextIDGroup);
                            comm.Parameters.AddWithValue("@RollNo", input3.Text.ToString());
                            comm.ExecuteNonQuery();
                        }
                        // Assign to supervisor
                        using (SqlCommand comm = new SqlCommand(assignToSupervisor, con))
                        {
                            comm.Parameters.AddWithValue("@SupervisorID", ID);
                            comm.Parameters.AddWithValue("@ProjectID", nextIDProject);
                            comm.ExecuteNonQuery();
                        }
                        // Finally add deadlines
                        string addDeadlines = "INSERT INTO DEADLINE VALUES (@ProjectID,'Presentation','01/20/22 23:59')";
                        using (SqlCommand comm = new SqlCommand(addDeadlines, con))
                        {
                            comm.Parameters.AddWithValue("@ProjectID", nextIDProject);
                            comm.ExecuteNonQuery();
                        }
                        addDeadlines = "INSERT INTO DEADLINE VALUES (@ProjectID,'Assessment','02/20/22 23:59')";
                        using (SqlCommand comm = new SqlCommand(addDeadlines, con))
                        {
                            comm.Parameters.AddWithValue("@ProjectID", nextIDProject);
                            comm.ExecuteNonQuery();
                        }
                        addDeadlines = "INSERT INTO DEADLINE VALUES (@ProjectID,'FinalSubmission','05/20/22 23:59')";
                        using (SqlCommand comm = new SqlCommand(addDeadlines, con))
                        {
                            comm.Parameters.AddWithValue("@ProjectID", nextIDProject);
                            comm.ExecuteNonQuery();
                        }
                        //Display success message
                        lblSuccess.Visible = true;
                        con.Close();
                    }
                }
                connection.Close();
            }       

            

        }
    }
}