using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

//STUFF TO DO:
/* NEED TO ADD SUPERVISOR STUFF
    NEED TO ADD STUDENTS TO 2 MORE TABLES FYP GROUPS AND FYP GROUP MEMBERS 
 
 */


namespace WebApplication1
{
    public partial class NewUser : System.Web.UI.Page
    {
        static string success;
        static string btn;
        void dropdown_Data()//Check current index of drop down and display stuff related to it
        {
            string value = DropDownList.SelectedValue.ToString();

            if (value == "Faculty")
            {
                Label1.Text = "Faculty Id: ";
                Label2.Text = "Name: ";
                Label3.Text = "Password: ";
                Label4.Text = "Part of Committe (Y/N): ";
                Label1.Visible = true;
                Label2.Visible = true;
                Label3.Visible = true;
                Label4.Visible = true;
                Insert_data.Text=btn;
                input1.Visible = true;
                input2.Visible = true;
                input3.Visible = true;
                input3.TextMode = TextBoxMode.Password;
                input4.Visible = true;
                display_Allfaculty();
            }

            else if (value == "Student")
            {
                Label1.Text = "Roll Number: ";
                Label2.Text = "Name: ";
                Label3.Text = "Password: ";
                Insert_data.Text=btn;
                Label1.Visible = true;
                Label2.Visible = true;
                Label3.Visible = true;

                input1.Visible = true;
                input2.Visible = true;
                input3.Visible = true;
                input3.TextMode = TextBoxMode.Password;

            }

            else if (value == "Panel Member")
            {
                //fill_facultyDropdown();
                Label1.Text = "Faculty ID: ";
                Label2.Text = "Panel ID: ";
                Insert_data.Text=btn;
                Label1.Visible = true;
                Label2.Visible = false;
                //showFaculty.Visible=true;
                DropDown_Faculty.Visible=true;
                input2.Visible = false; ;
                Check_newPanel.Visible = true;
                Check_ExistingPanel.Visible = true;
                Lbl_Check1.Visible=true;
                Lbl_Check2.Visible=true;

                if(Check_ExistingPanel.Checked)
                {
                    Label3.Visible = true;
                    Label3.Text = "Panel ID: ";

                    Exist_panel.Visible= true;
                    display_panels();
                }

                else
                {
                    Exist_panel.Visible= false;
                    GridView1.Visible = false;
                    Label3.Visible = true;
                    Label3.Text = "New Panel ID: ";
                    input3.Visible= true;
                    Label4.Visible = true;
                    Label4.Text = "New Panel Name: ";
                    input4.Visible= true;
                    input4.TextMode=TextBoxMode.SingleLine;
                    input3.TextMode=TextBoxMode.SingleLine;
                    Check_ExistingPanel.Checked=false;
                    full_panel();
                   
                   
                }


                display_faculty();               
               

            }
            else if (value == "Supervisor")
            {
                

                //Have to display Faculty members for this to make it easier for 
                Label1.Text = "Faculty ID: ";
                DropDown_Faculty.Visible=true;
                Label2.Text = "Project ID: ";
                Label1.Visible = true;
                Label2.Visible = true;
                input2.Visible = true;
                Insert_data.Text="Update";
                display_faculty();
                GridView1.Visible = true;


                SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;");
                SqlCommand comm = new SqlCommand("Select Facultyid AS SupervisorID, Supervisor.Projectid , Project.Title FROM Supervisor INNER JOIN Project on Supervisor.Projectid=Project.ProjectID ", con);

                con.Open();

                try
                {
                    SqlDataAdapter Adp = new SqlDataAdapter(comm);
                    DataTable dt1 = new DataTable();
                    Adp.Fill(dt1);
                    GridView1.DataSource = dt1;
                    GridView1.DataBind();
                }

                catch (SqlException ex)
                {


                }
                con.Close();

                //Fill Drop down again with ALL FACULTY
                

            }


        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
               success=lblSuccess.Text;
                btn=Insert_data.Text;
                //Filling Dropboxes
                //For Faculty
                fill_facultyDropdown();
             
                fill_PanelDropdown();
            }

            

            lblError.Visible = false;
            lblSuccess.Visible = false;
            GridView.Visible = false;
            GridView1.Visible = false;

            hide_all();


            //Show in Grid when the page first loads
            //Faculty
            SqlConnection connection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;");
            SqlCommand command = new SqlCommand("SELECT FacultyID, Name from Faculty where  FacultyID = '" + DropDown_Faculty.SelectedValue + "'", connection);
            connection.Open();
            try
            {
                SqlDataAdapter Adpt = new SqlDataAdapter(command);
                DataTable dt2 = new DataTable();
                Adpt.Fill(dt2);
                GridView.DataSource = dt2;
                GridView.DataBind();

            }
            
            catch(SqlException ex)
            {

            }

            //Show in Grid when the page first loads
            //Panels
            SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;");
            SqlCommand comm = new SqlCommand("SELECT PanelID, Name from Panel where  PanelID = '" + Exist_panel.SelectedValue + "'", con);
            //SqlCommand comm = new SqlCommand("SELECT PanelID, Name from Panel ", con);
            con.Open();
            try
            {
                SqlDataAdapter Adp = new SqlDataAdapter(comm);
                DataTable dt1 = new DataTable();
                Adp.Fill(dt1);
                GridView1.DataSource = dt1;
                GridView1.DataBind();
            }

            catch (SqlException ex)
            {

            }
            dropdown_Data();



        }
        void display_faculty()
        {
            GridView.Visible=true;
            SqlConnection connection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;");
            SqlCommand command = new SqlCommand("SELECT FacultyID, Name from Faculty where  FacultyID = '" + DropDown_Faculty.SelectedValue + "'", connection);
            connection.Open();

            try
            {
                SqlDataAdapter Adpt = new SqlDataAdapter(command);
                DataTable dt2 = new DataTable();
                Adpt.Fill(dt2);
                GridView.DataSource = dt2;
                GridView.DataBind();
            }
            catch (SqlException ex)
            {


            }


            connection.Close();

        }



        void display_Allfaculty()
        {
            GridView.Visible=true;
            SqlConnection connection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;");
            SqlCommand command = new SqlCommand("SELECT * from Faculty", connection);
            connection.Open();

            try
            {
                SqlDataAdapter Adpt = new SqlDataAdapter(command);
                DataTable dt2 = new DataTable();
                Adpt.Fill(dt2);
                GridView.DataSource = dt2;
                GridView.DataBind();
            }
            catch (SqlException ex)
            {


            }


            connection.Close();

        }




        void display_panels()
        {
            GridView1.Visible = true;


            SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;");
            SqlCommand comm = new SqlCommand("SELECT PanelID, Name from Panel where  PanelID = '" + Exist_panel.SelectedValue + "'", con);
            //SqlCommand comm = new SqlCommand("SELECT PanelID, Name from Panel ", con);
            con.Open();

            try
            {
                SqlDataAdapter Adp = new SqlDataAdapter(comm);
                DataTable dt1 = new DataTable();
                Adp.Fill(dt1);
                GridView1.DataSource = dt1;
                GridView1.DataBind();
            }

            catch (SqlException ex)
            {


            }
            con.Close();


        }

        void fill_PanelDropdown()
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"))
            {

                string Query = "SELECT * From Panel";
                conn.Open();
                SqlDataAdapter adpter = new SqlDataAdapter(Query, conn);
                DataTable dta = new DataTable();
                adpter.Fill(dta);
                Exist_panel.DataSource = dta;
                Exist_panel.DataBind();
                Exist_panel.DataTextField = "PanelID";
                Exist_panel.DataValueField = "PanelID";
                Exist_panel.DataBind();
                conn.Close();

            }

        }

        //Fills with those that are not panel members
        void fill_facultyDropdown()
        {
            using (SqlConnection connec = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"))
            {

                string dropQuery = "SELECT FacultyID From Faculty WHERE FacultyID NOT IN(SELECT FacultyID FROM PanelMember)";
                connec.Open();
                SqlDataAdapter adpt = new SqlDataAdapter(dropQuery, connec);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                DropDown_Faculty.DataSource = dt;
                DropDown_Faculty.DataBind();
                DropDown_Faculty.DataTextField = "FacultyID";
                DropDown_Faculty.DataValueField = "FacultyID";
                DropDown_Faculty.DataBind();
                connec.Close();

            }

        }
        void full_panel()
        {
            GridView1.Visible = true;


            SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;");
            SqlCommand comm = new SqlCommand("SELECT PanelID, Name from Panel ", con);
            
            con.Open();

            try
            {
                SqlDataAdapter Adp = new SqlDataAdapter(comm);
                DataTable dt1 = new DataTable();
                Adp.Fill(dt1);
                GridView1.DataSource = dt1;
                GridView1.DataBind();
            }

            catch (SqlException ex)
            {


            }
            con.Close();


        }
        protected void DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            hide_all();
            dropdown_Data();
            
        }


        void hide_all()//Hide input area
        {
            DropDown_Faculty.Visible=false;
            Label1.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
            Label4.Visible = false;
            input1.Visible = false;
            input2.Visible = false;
            input3.Visible = false;
            input4.Visible = false;
            Exist_panel.Visible=false;
            Check_newPanel.Visible = false;
            Check_ExistingPanel.Visible = false;
            Lbl_Check1.Visible=false;
            Lbl_Check2.Visible=false;
            //showFaculty.Visible=false;

        }

     

        //Adds data after click of the button
        protected void Insert_data_Click(object sender, EventArgs e)
        {

            using (SqlConnection connection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"))
            {
                string value = DropDownList.SelectedValue.ToString();
                connection.Open();

                if (value == "Faculty")
                {
                    string query1 = "INSERT INTO Faculty VALUES(@FacultyID, @name,@password,@bitval)";
                    SqlCommand comm = new SqlCommand(query1, connection);

                    comm.Parameters.AddWithValue("@FacultyID", input1.Text);

                    comm.Parameters.AddWithValue("@name", input2.Text.ToString());
                    comm.Parameters.AddWithValue("@password", input3.Text.ToString());

                    if (input4.Text.ToString()=="Y" || input4.Text.ToString() == "y")
                    {
                        comm.Parameters.AddWithValue("@bitval", 1);


                    }


                    else if (input4.Text.ToString() == "n" || input4.Text.ToString() == "N")
                    {
                        comm.Parameters.AddWithValue("@bitval", 0);

                    }

                    else
                    {
                        lblSuccess.Visible = false;
                        lblError.Visible = true;
                    }

                    try
                    {
                        lblError.Visible =false;
                        comm.ExecuteNonQuery();
                        lblSuccess.Text=success;
                        lblSuccess.Visible = true;
                    }
                    catch (SqlException ex)
                    {
                        
                        lblSuccess.Visible = false;
                        lblError.Visible = true;
                    }

                    display_Allfaculty();

                }

                else if (value == "Student")
                {
                    string query1 = "INSERT INTO Student VALUES(@Rollno, @name,@password)";
                    SqlCommand comm = new SqlCommand(query1, connection);

                    comm.Parameters.AddWithValue("@Rollno", input1.Text);
                    comm.Parameters.AddWithValue("@name", input2.Text.ToString());
                    comm.Parameters.AddWithValue("@password", input3.Text.ToString());

                    try
                    {
                        comm.ExecuteNonQuery();
                        lblSuccess.Text=success;
                        lblSuccess.Visible = true;
                    }
                    catch (SqlException ex)
                    {
                        lblError.Visible = true;
                    }



                }

                else if (value == "Panel Member")
                {


                    //If Existing Panel is selected just add inputs from existing one
                    if (Check_ExistingPanel.Checked)
                    {
                        string query1 = "INSERT INTO PanelMember VALUES(@FacultyID, @Panelid,@status)";
                        SqlCommand comm = new SqlCommand(query1, connection);

                        comm.Parameters.AddWithValue("@Facultyid", DropDown_Faculty.SelectedValue);
                        comm.Parameters.AddWithValue("@Panelid", Exist_panel.SelectedValue);
                        comm.Parameters.AddWithValue("@status", "Missing");

                        try
                        {
                            comm.ExecuteNonQuery();

                            display_panels();
                            lblSuccess.Text=success;
                            lblSuccess.Visible = true;

                            //Re-enter into dropdown since 1 faculty gone into a panel
                            using (SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"))
                            {

                                string dropQuery = "SELECT FacultyID From Faculty WHERE FacultyID NOT IN(SELECT FacultyID FROM PanelMember) AND isComittee=0";
                                con.Open();
                                SqlDataAdapter adpt = new SqlDataAdapter(dropQuery, con);
                                DataTable dt = new DataTable();
                                adpt.Fill(dt);
                                DropDown_Faculty.DataSource = dt;
                                DropDown_Faculty.DataBind();
                                DropDown_Faculty.DataTextField = "FacultyID";
                                DropDown_Faculty.DataValueField = "FacultyID";
                                DropDown_Faculty.DataBind();
                                con.Close();

                            }
                            display_faculty();

                        }
                        catch (SqlException ex)
                        {
                            lblError.Visible = true;
                        }

                    }



                    else
                    {
                        //First Add new Panel to Panel table
                        string query1 = "INSERT INTO Panel VALUES(@PanelID, @PanelName)";
                        SqlCommand comm = new SqlCommand(query1, connection);

                        comm.Parameters.AddWithValue("@PanelID", input3.Text);
                        comm.Parameters.AddWithValue("@PanelName", input4.Text.ToString());
                       

                        try
                        {
                            comm.ExecuteNonQuery();

                            //display_panels();
                            full_panel();

                            //Now Add this New Panel With Faculty ID
                            query1 = "INSERT INTO PanelMember VALUES(@FacultyID, @Panelid,@status)";

                            using (SqlCommand comman = new SqlCommand(query1, connection))
                            {
                                comman.Parameters.AddWithValue("@Panelid", input3.Text);
                                comman.Parameters.AddWithValue("@Facultyid", DropDown_Faculty.SelectedValue);
                                comman.Parameters.AddWithValue("@status", "Missing");

                                try
                                {
                                    comman.ExecuteNonQuery();
                                   lblSuccess.Text=success ;
                                    lblSuccess.Visible = true;

                                    //For Panels
                                    using (SqlConnection conn = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"))
                                    {

                                        string Query = "SELECT * From Panel";
                                        conn.Open();
                                        SqlDataAdapter adpter = new SqlDataAdapter(Query, conn);
                                        DataTable dta = new DataTable();
                                        adpter.Fill(dta);
                                        Exist_panel.DataSource = dta;
                                        Exist_panel.DataBind();
                                        Exist_panel.DataTextField = "PanelID";
                                        Exist_panel.DataValueField = "PanelID";
                                        Exist_panel.DataBind();
                                        conn.Close();

                                    }



                                }

                                catch (SqlException ex)
                                {
                                    lblError.Visible = true;
                                }

                            }




                            //Re-enter into dropdown since 1 faculty gone into a panel
                            using (SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"))
                            {

                                string dropQuery = "SELECT FacultyID From Faculty WHERE FacultyID NOT IN(SELECT FacultyID FROM PanelMember) AND isComittee=0";
                                con.Open();
                                SqlDataAdapter adpt = new SqlDataAdapter(dropQuery, con);
                                DataTable dt = new DataTable();
                                adpt.Fill(dt);
                                DropDown_Faculty.DataSource = dt;
                                DropDown_Faculty.DataBind();
                                DropDown_Faculty.DataTextField = "FacultyID";
                                DropDown_Faculty.DataValueField = "FacultyID";
                                DropDown_Faculty.DataBind();
                                con.Close();

                            }

                            display_faculty();


                            //Fill Panel Dropbox again since new Panel added
                        }
                        catch (SqlException ex)
                        {
                            lblError.Visible = true;
                        }


                    }
                    
                }

                else if(value == "Supervisor") ////Only ppl that are not in panel can become supervisors
                {

                    string query1 = "UPDATE Supervisor SET Facultyid = @newID WHERE Projectid = @Projid ";
                    SqlCommand comm = new SqlCommand(query1, connection);

                    comm.Parameters.AddWithValue("@newID", DropDown_Faculty.SelectedValue);
                    comm.Parameters.AddWithValue("@Projid", input2.Text);




                    try
                    {
                        int rowsaffected=comm.ExecuteNonQuery();


                        if(rowsaffected==0)
                        {
                            lblError.Visible = true;
                        }

                        else
                        {
                            //Update Fyp_Group
                            query1 = "UPDATE FYP_GROUPS SET Supervisor = @newID WHERE ProjectID = @Projid ";
                            SqlCommand coma = new SqlCommand(query1, connection);

                            coma.Parameters.AddWithValue("@newID", DropDown_Faculty.SelectedValue);
                            coma.Parameters.AddWithValue("@Projid", input2.Text);

                            try
                            {
                                coma.ExecuteNonQuery();
                                lblSuccess.Text="Data Updated Successfully";
                                lblSuccess.Visible = true;
                            }

                            catch (SqlException ex)
                            {
                                lblError.Visible = true;
                            }

                        }



                    }
                    catch (SqlException ex)
                    {
                        lblError.Visible = true;
                    }






                    GridView1.Visible = true;
                    //Show Updated Supervisor Table
                    using (SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"))
                    {
                        SqlCommand comma = new SqlCommand("Select Facultyid AS SupervisorID, Supervisor.Projectid , Project.Title FROM Supervisor INNER JOIN Project on Supervisor.Projectid=Project.ProjectID ", con);

                        con.Open();

                        try
                        {
                            SqlDataAdapter Adp = new SqlDataAdapter(comma);
                            DataTable dt1 = new DataTable();
                            Adp.Fill(dt1);
                            GridView1.DataSource = dt1;
                            GridView1.DataBind();
                        }

                        catch (SqlException ex)
                        {


                        }

                        con.Close();


                        display_faculty();
                    
                   
                    }


                }

                connection.Close();
            }

            fill_facultyDropdown();
        }

        

        protected void Check_newPanel_CheckedChanged(object sender, EventArgs e)
        {
  
            if (!Check_newPanel.Checked)
            {
                Check_ExistingPanel.Checked=true;
            }

            else
            {
                Exist_panel.Visible= false;
                GridView1.Visible = false;
                Label3.Visible = true;
                Label3.Text = "New Panel ID: ";
                input3.Visible= true;
                Label4.Visible = true;
                Label4.Text = "New Panel Name: ";
                input4.Visible= true;
                input4.TextMode=TextBoxMode.SingleLine;
                input3.TextMode=TextBoxMode.SingleLine;
                Check_ExistingPanel.Checked=false;
                full_panel();
            }

        }

        protected void Check_ExistingPanel_CheckedChanged(object sender, EventArgs e)
        {
            if (!Check_ExistingPanel.Checked)
            {
                Check_newPanel.Checked=true;
            }

            else
            {
                Exist_panel.Visible= true;
                GridView1.Visible = true;
                Label3.Visible = true;
                Label3.Text = "Panel ID: ";
                input3.Visible= false;
                Check_newPanel.Checked=false;
            }
        }

        protected void Exist_panel_SelectedIndexChanged(object sender, EventArgs e)
        {
            display_panels();
        }

        protected void DropDown_Faculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            display_faculty();
            
        }
    }

}