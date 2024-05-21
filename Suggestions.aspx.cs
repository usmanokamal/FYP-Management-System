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
    public partial class About : Page
    {
        string FacultyID;
        protected void Page_Load(object sender, EventArgs e)
        {
            FacultyID = Session["ID"].ToString();
         
            if (IsPostBack)
                return;

            div1.Visible = false;

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

        protected void DropDownChange(object sender, EventArgs e)
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
                string query = "SELECT COUNT(1) FROM Supervisor_Reviews WHERE GroupID = @grpID";
                using (SqlCommand comm = new SqlCommand(query, con))
                {
                    comm.Parameters.AddWithValue("@grpID", groupID);
                    int count = Convert.ToInt32(comm.ExecuteScalar());
                    if (count == 1)
                    {
                        Label1.ForeColor = System.Drawing.Color.Green;
                        Label1.Text = "Review Status: Submitted";
                        Label1.ForeColor = System.Drawing.Color.Green;
                        div1.Visible = false;
                    }
                    else if (count == 0)
                    {
                        Label1.ForeColor = System.Drawing.Color.DarkRed;
                        Label1.Text = "Review Status: Not Submitted";
                        Label1.ForeColor = System.Drawing.Color.DarkRed;
                        //Display text box to make suggestion
                        div1.Visible = true;

                    }
                }
                con.Close();
            }
        }
        protected void sendReview(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"))
            {
                con.Open();
                //Add review
                string query = "INSERT INTO Supervisor_Reviews VALUES (@supervisorID, @groupID, @Review)";
                string review = TextBox1.Text.ToString();
                // get value from dropdown.
                string groupID = DropDownList1.SelectedValue.ToString();
                

                using (SqlCommand comm = new SqlCommand(query, con))
                {
                    comm.Parameters.AddWithValue("@supervisorID", FacultyID);
                    comm.Parameters.AddWithValue("@groupID", groupID);
                    comm.Parameters.AddWithValue("@Review", review);
                    int res = comm.ExecuteNonQuery();
                    if (res == 0)
                    {
                        Response.Write("<script>alert('Some error occured while sending review.');</script>");
                    }
                    else
                    {
                        Label1.ForeColor = System.Drawing.Color.Green;
                        Label1.Text = "Review Status: Submitted";
                    }
                }
                con.Close();
            }
        }
    }
}