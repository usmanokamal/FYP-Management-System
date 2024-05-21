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
    public partial class EvaluationForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RadioButtonList2.RepeatDirection = RepeatDirection.Horizontal;
            RadioButtonList3.RepeatDirection = RepeatDirection.Horizontal;
            RadioButtonList4.RepeatDirection = RepeatDirection.Horizontal;
            RadioButtonList5.RepeatDirection = RepeatDirection.Horizontal;
            RadioButtonList6.RepeatDirection = RepeatDirection.Horizontal;
            RadioButtonList7.RepeatDirection = RepeatDirection.Horizontal;
            RadioButtonList8.RepeatDirection = RepeatDirection.Horizontal;
            RadioButtonList9.RepeatDirection = RepeatDirection.Horizontal;
            RadioButtonList10.RepeatDirection = RepeatDirection.Horizontal;
            RadioButtonList11.RepeatDirection = RepeatDirection.Horizontal;
            RadioButtonList12.RepeatDirection = RepeatDirection.Horizontal;
            RadioButtonList13.RepeatDirection = RepeatDirection.Horizontal;
            RadioButtonList14.RepeatDirection = RepeatDirection.Horizontal;
            RadioButtonList15.RepeatDirection = RepeatDirection.Horizontal;
            RadioButtonList16.RepeatDirection = RepeatDirection.Horizontal;
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"))
            {

            }
        }


        //fyp poster
        protected void RadioButtonList5_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"))
            {
                RadioButtonList5.RepeatDirection = RepeatDirection.Horizontal;
            }


        }


        //2
        protected void RadioButtonList6_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"))
            {
                RadioButtonList6.RepeatDirection = RepeatDirection.Horizontal;
            }
        }


        //3
        protected void RadioButtonList7_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"))
            {
                RadioButtonList7.RepeatDirection = RepeatDirection.Horizontal;
            }
        }


        //4
        protected void RadioButtonList8_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"))
            {
                RadioButtonList8.RepeatDirection = RepeatDirection.Horizontal;
            }
        }


        //5
        protected void RadioButtonList9_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"))
            {
                RadioButtonList9.RepeatDirection = RepeatDirection.Horizontal;
            }
        }


        //6
        protected void RadioButtonList10_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"))
            {
                RadioButtonList10.RepeatDirection = RepeatDirection.Horizontal;
            }
        }


        //7
        protected void RadioButtonList11_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"))
            {
                RadioButtonList11.RepeatDirection = RepeatDirection.Horizontal;
            }
        }


        //8
        protected void RadioButtonList12_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"))
            {
                RadioButtonList10.RepeatDirection = RepeatDirection.Horizontal;
            }
        }


        //9
        protected void RadioButtonList13_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"))
            {
                RadioButtonList13.RepeatDirection = RepeatDirection.Horizontal;
            }
        }



        //10
        protected void RadioButtonList14_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"))
            {
                RadioButtonList14.RepeatDirection = RepeatDirection.Horizontal;
            }
        }



        //11
        protected void RadioButtonList15_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"))
            {
                RadioButtonList15.RepeatDirection = RepeatDirection.Horizontal;
            }
        }


        //12
        protected void RadioButtonList16_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"))
            {
                RadioButtonList16.RepeatDirection = RepeatDirection.Horizontal;
            }
        }


        //13
        protected void RadioButtonList4_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"))
            {
                RadioButtonList4.RepeatDirection = RepeatDirection.Horizontal;
            }
        }


        //14
        protected void RadioButtonList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"))
            {
                RadioButtonList3.RepeatDirection = RepeatDirection.Horizontal;
            }
        }


        //15
        protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"))
            {
                RadioButtonList2.RepeatDirection = RepeatDirection.Horizontal;
            }
        }

        //16
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //button which submits the value
        protected void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;initial Catalog=FYPDB;Integrated Security=True;"))
            {
                //              string finalVal = "";
                // if (RadioButtonList5)
                {

                }

                int r1 = Int16.Parse(RadioButtonList5.SelectedValue);
                int r2 = Int16.Parse(RadioButtonList6.SelectedValue);
                int r3 = Int16.Parse(RadioButtonList7.SelectedValue);
                int r4 = Int16.Parse(RadioButtonList8.SelectedValue);
                int r5 = Int16.Parse(RadioButtonList9.SelectedValue);
                int r6 = Int16.Parse(RadioButtonList10.SelectedValue);
                int r7 = Int16.Parse(RadioButtonList11.SelectedValue);
                int r8 = Int16.Parse(RadioButtonList12.SelectedValue);
                int r9 = Int16.Parse(RadioButtonList13.SelectedValue);
                int r10 = Int16.Parse(RadioButtonList14.SelectedValue);
                int r11 = Int16.Parse(RadioButtonList15.SelectedValue);
                int r12 = Int16.Parse(RadioButtonList16.SelectedValue);
                int r13 = Int16.Parse(RadioButtonList4.SelectedValue);
                int r14 = Int16.Parse(RadioButtonList3.SelectedValue);
                int r15 = Int16.Parse(RadioButtonList2.SelectedValue);


                int sum = r1 + r2 + r3 + r4 + r5 + r6 + r7 + r8 + r9 + r10 + r11 + r12 + r13 + r14 + r15;

                float avg = (float)sum / 150;

                avg = avg * 100;
                //now average has our percentage marks


                //now for the grade
                string grade = "";
                if (avg >= 90)
                    grade = "A+";
                else if (avg >= 86)
                    grade = "A";
                else if (avg >= 82)
                    grade = "A-";
                else if (avg >= 78)
                    grade = "B+";
                else if (avg >= 74)
                    grade = "B";
                else if (avg >= 70)
                    grade = "B-";
                else if (avg >= 66)
                    grade = "C+";
                else if (avg >= 62)
                    grade = "C";
                else if (avg >= 58)
                    grade = "C-";
                else if (avg >= 54)
                    grade = "D+";
                else if (avg >= 50)
                    grade = "D";
                else
                    grade = "F";





                //                int result =  + RadioButtonList2.SelectedValue + RadioButtonList2.SelectedValue + RadioButtonList2.SelectedValue + RadioButtonList2.SelectedValue + RadioButtonList2.SelectedValue + RadioButtonList2.SelectedValue + RadioButtonList2.SelectedValue + RadioButtonList2.SelectedValue;

                //                RadioButton2.SelectedValue;
                Label1.Text = "The generated grade is " + grade;

                connection.Open();

                string pid = DropDownList1.SelectedValue.ToString(); //panel id is what the user selects from dropdown
                string fid = Session["ID"].ToString(); //we get facultyid from previous page
                string panid = ""; //panelid, generated using a query


                //for panel id we run the following query
                //Select PanelID from PanelMember where FacultyID = @facultyid

                string newquery = "Select PanelID from PanelMember where FacultyID = @fid";
                SqlCommand cmd = new SqlCommand(newquery, connection);

                cmd.Parameters.AddWithValue("@fid", fid);
                SqlDataReader reader = cmd.ExecuteReader();
                //                panid = reader.ToString();

                if (reader.Read())
                {
                    panid = reader[0].ToString();
                }
                connection.Close();
                //Now we have our required values for data insertion.
                //Label2.Text = "ProjectID = " + pid + " FacultyID = " + fid + " PanelID = " + panid;

                //INSERT INTO FYP_GROUPS VALUES(2002,225,322,3,'Not Submitted','Not Submitted','Not Submitted');
                string resultquery = "INSERT INTO PanelMemberGrade(@panid,@fid,@pid,'Completed',@grade)";
                SqlCommand comm = new SqlCommand(resultquery, connection);

                comm.Parameters.AddWithValue("@panid", panid);
                comm.Parameters.AddWithValue("@fid", fid);
                comm.Parameters.AddWithValue("@pid", pid);
                comm.Parameters.AddWithValue("@grade", grade);

                connection.Open();
                // comm.ExecuteNonQuery();
                connection.Close();

                Session["ID"] = fid;
                Response.Redirect("PanelMember.aspx");

            }

        }


    }
}