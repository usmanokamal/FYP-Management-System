using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
/*
 SqlCommand.ExecuteNonQuery Method:
You can use the ExecuteNonQuery to perform catalog operations (for example, querying the structure of a database or creating database objects such as
tables), or to change the data in a database without using a DataSet by executing UPDATE, INSERT, 
or DELETE statements. Although the ExecuteNonQuery returns no rows, any output parameters or return 
values mapped to parameters are populated with data. For UPDATE, INSERT, and DELETE statements, 
the return value is the number of rows affected by the command. When a trigger exists on a table 
being inserted or updated, the return value includes the number of rows affected by both the insert 
or update operation and the number of rows affected by the trigger or triggers. For all other types
of statements, the return value is -1. If a rollback occurs, the return value is also -1. 

SqlCommand.ExecuteScalar Method 
Executes a Transact-SQL statement against the connection and returns the number of rows affected.
So to get no. of statements returned by SELECT statement you have to use ExecuteScalar method.
*/
namespace WebApplication1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LblErrormsg.Text = "Incorrect Username or Password";
            LblErrormsg.Visible = false;
            Lblsuccess.Visible = false;
        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"))
            {
                bool authenticated = false;
                if (txtusername.Text == "" || txtpassword.Text == "")
                    return;
                if (RadioButtonList1.SelectedItem == null)
                {
                    Response.Write("<script>alert('You did not choose an option.');</script>");
                    return;
                }
                string optionChosen = RadioButtonList1.SelectedItem.Value.ToString();
                if (optionChosen == "Student")
                {
                    connection.Open();
                    //Using parameterised query
                    string query1 = "SELECT COUNT(1) from Student WHERE RollNo=@username AND Password=@password";

                    //To get type from database of entered user to redirect to specific dashboard
                    string query2 = "SELECT type from Student WHERE RollNo=@username AND Password=@password";


                    SqlCommand cmd = new SqlCommand(query1, connection);


                    //Will put the value of the text boxes inside the @parameters we used above
                    cmd.Parameters.AddWithValue("@username", txtusername.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", txtpassword.Text.Trim());


                    //Returns number of rows found with username and password
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    //If atleast 1 row found with matching password and username
                    if (count == 1)
                    {
                        Lblsuccess.Visible = true;
                        authenticated = true;

                    }
                    else
                    {
                        LblErrormsg.Visible = true;
                    }

                    //Decide which dashboard to move to


                    //if logged in
                    if (authenticated)
                    {
                        //SqlCommand cmd2 = new SqlCommand(query2, connection);
                        //cmd2.Parameters.AddWithValue("@username", txtusername.Text.Trim());
                        //cmd2.Parameters.AddWithValue("@password", txtpassword.Text.Trim());
                        //SqlDataReader reader = cmd2.ExecuteReader();



                        //if (reader.Read())
                        //{
                        //string type_authority = reader.GetString(0);


                        ////If member is fypCommitte go to google
                        //if (type_authority == "Student")
                        {
                            Session["ID"] = txtusername.Text;
                            // Check if student exists in FYP_GROUP_MEMBERS, or else take to register page.
                            using (SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"))
                            {
                                con.Open();
                                string grpQuery = "SELECT COUNT(1) FROM FYP_GROUP_MEMBERS FG WHERE FG.StudentID = @RollNo";
                                using (SqlCommand comm = new SqlCommand(grpQuery, con))
                                {
                                    comm.Parameters.AddWithValue("@RollNo", txtusername.Text);
                                    int isStudentRegistered = Convert.ToInt32(comm.ExecuteScalar());
                                    //Response.Write(isStudentRegistered);
                                    if (isStudentRegistered == 1)
                                    {
                                        Response.Redirect("Student.aspx");
                                    }
                                    else
                                    {
                                        //Response.Write("Not Registered");
                                        Response.Redirect("NewStudent.aspx");
                                        //Redirect to registration page.
                                    }
                                }

                                con.Close();
                            }

                        }
                    }

                    connection.Close();
                }
                else if (optionChosen == "Supervisor")
                {
                    connection.Open();
                    //Check if supervisor exists
                    string query_CheckUser = "SELECT COUNT(1) from Faculty WHERE FacultyID = @FacultyID AND Password = @Password";
                    using (SqlCommand cmd = new SqlCommand(query_CheckUser, connection))
                    {
                        cmd.Parameters.AddWithValue("@FacultyID", txtusername.Text.ToString());
                        cmd.Parameters.AddWithValue("@Password", txtpassword.Text.ToString());
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        if (count == 1)
                        {
                            //Check if he has supervisor priveleges
                            string query_CheckRole = "SELECT COUNT(1) FROM Supervisor where facultyID = @facultyID";
                            using (SqlCommand cmd2 = new SqlCommand(query_CheckRole, connection))
                            {
                                cmd2.Parameters.AddWithValue("@facultyID", txtusername.Text.ToString());
                                int assignedProjects = Convert.ToInt32(cmd2.ExecuteScalar());
                                if (assignedProjects >= 1)
                                {
                                    //Success
                                    Session["ID"] = txtusername.Text;
                                    Response.Redirect("Supervisor.aspx");
                                }
                                else
                                {
                                    LblErrormsg.Text = "No projects assigned to " + txtusername.Text.ToString();
                                    LblErrormsg.Visible = true;
                                }
                            }

                        }
                        else LblErrormsg.Visible = true;
                    }
                    connection.Close();
                    Response.Write("TEST");
                }
                else if (optionChosen == "PanelMember")
                {
                    connection.Open(); string query_CheckUser = "SELECT COUNT(1) from Faculty WHERE FacultyID = @FacultyID AND Password = @Password";
                    using (SqlCommand cmd = new SqlCommand(query_CheckUser, connection))
                    {
                        cmd.Parameters.AddWithValue("@FacultyID", txtusername.Text.ToString());
                        cmd.Parameters.AddWithValue("@Password", txtpassword.Text.ToString());
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        if (count == 1)
                        {
                            //Check if he has supervisor priveleges
                            string query_CheckRole = "SELECT COUNT(1) FROM PanelMember where facultyID = @facultyID";
                            using (SqlCommand cmd2 = new SqlCommand(query_CheckRole, connection))
                            {
                                cmd2.Parameters.AddWithValue("@facultyID", txtusername.Text.ToString());
                                int panelCount = Convert.ToInt32(cmd2.ExecuteScalar());
                                if (panelCount >= 1)
                                {
                                    //Grant access
                                    Session["ID"] = txtusername.Text;
                                    Response.Redirect("PanelMember.aspx");
                                }
                                else
                                {

                                }
                            }
                        }
                        else LblErrormsg.Visible = true;
                    }
                    connection.Close();
                }
                else if (optionChosen == "FYPCommittee")
                {
                    connection.Open();
                    string query_checkCommmittee = "SELECT COUNT(1) FROM Faculty F WHERE F.FacultyID = @FacultyID AND F.Password = @Password AND F.isComittee = '1'";
                    using (SqlCommand cmd = new SqlCommand(query_checkCommmittee, connection))
                    {
                        cmd.Parameters.AddWithValue("@FacultyID", txtusername.Text.ToString());
                        cmd.Parameters.AddWithValue("@Password", txtpassword.Text.ToString());
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        if (count == 1)
                        {
                            Session["ID"] = txtusername.Text;
                            Response.Redirect("FypCommittee.aspx");
                        }
                        else LblErrormsg.Visible = true;
                    }
                    connection.Close();
                }


            }


        }
    }
}