using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace STUDENT_FORM
{
    public partial class StudentREG : System.Web.UI.Page
    {
        ConnectionCls conobj = new ConnectionCls();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string ch = "";
            for (int j = 0; j < CheckBoxList1.Items.Count; j++)
            {
                if (CheckBoxList1.Items[j].Selected)
                {
                    ch += CheckBoxList1.Items[j].Text + ",";
                }
            }

            string strins = "Insert into StudentReg_tb (Student_Firstname, Student_Lastname, Age, DOB, Gender, Email_Id, Phone_Number, Username, Password)" + "values('" + TextBox1.Text + "', '" + TextBox2.Text + "', " + TextBox3.Text + ", '" + TextBox4.Text + "', '" + RadioButtonList1.SelectedValue + "', '" + TextBox5.Text + "', '" + TextBox6.Text + "', '" + TextBox7.Text + "', '" + TextBox8.Text + "')";
            int i = conobj.Fn_Nonquery(strins);

            if (i == 1)
            {

                string selectStudentId = "SELECT IDENT_CURRENT('StudentReg_tb')";
                int studentId = Convert.ToInt32(conobj.Fn_Scalar(selectStudentId));


                string insert = "Insert into Qualification_tb (Student_Id, Course, University, Year, Percentage) " +
                                "values(" + studentId + ", '" + ch + "', '" + TextBox13.Text + "', '" + TextBox12.Text + "', '" + TextBox10.Text + "')";
                int j = conobj.Fn_Nonquery(insert);


                Label16.Visible = true;
                Label16.Text = "Successfully Inserted";
            }
        }
    }
}