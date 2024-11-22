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
    public partial class LoginForm : System.Web.UI.Page
    {
        ConnectionCls conobj = new ConnectionCls();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string s = "select count(Student_Id) from StudentReg_tb  where Username='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'";
            string cid = conobj.Fn_Scalar(s);
            if (cid == "1")
            {
                int id1 = 0;
                string str = "select Student_Id from StudentReg_tb where Username='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'";
                SqlDataReader dr = conobj.Fn_Reader(str);
                while (dr.Read())
                {
                    id1 = Convert.ToInt32(dr["Student_Id"].ToString());
                }

                Session["uid"] = id1;
                Response.Redirect("ProfileView.aspx");
            }
        }
    }
}