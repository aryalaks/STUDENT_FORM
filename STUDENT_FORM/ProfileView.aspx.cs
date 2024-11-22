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
    public partial class WebForm1 : System.Web.UI.Page
    {
        ConnectionCls conobj = new ConnectionCls();
        protected void Page_Load(object sender, EventArgs e)
        {
            string selct = "select Student_Firstname,Student_Lastname,Age,DOB,Gender,Email_Id,Phone_Number from StudentReg_tb Where Student_Id=" + Session["uid"] + "";
            SqlDataReader dr = conobj.Fn_Reader(selct);
            while (dr.Read())
            {
                Label8.Text = dr["Student_Firstname"].ToString();
                Label9.Text = dr["Student_Lastname"].ToString();
                Label10.Text = dr["Age"].ToString();
                DateTime date = Convert.ToDateTime(dr["DOB"]);
                Label11.Text = date.ToString("yyy/MM/dd");
                Label12.Text = dr["Gender"].ToString();
                Label13.Text = dr["Email_Id"].ToString();
                Label14.Text = dr["Phone_Number"].ToString();

            }
        }
    }
}