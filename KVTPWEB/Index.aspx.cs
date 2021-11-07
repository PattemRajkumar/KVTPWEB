using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Index : System.Web.UI.Page
{

    
    protected void Page_Load(object sender, EventArgs e)
    {
      
    }

    protected void btnlogin_Click(object sender, EventArgs e)
    {
        //
        mydb db = new mydb();
        string st;
        int x;
        SqlDataReader dr;
        string Roleflag = "";
        st = "Select * from KVTP_ADMIN where KVTP_EmailID='" + txt_email.Text + "' and KVTP_Password='" + txt_pwd.Text + "' and KVTP_Flag=1";
        dr = db.readall(st);
        if (dr.Read())
        {

            Session["KVTP_Admin"] = dr["KVTP_Admin"].ToString();
            Response.Redirect("dashboard.aspx");
            dr.Dispose(); db.db_close();
        }
        else
        {
            dr.Dispose(); db.db_close();
            st = "";
           
            st = "Select * from IVRM_Staff_User_Login where IVRMSTAUL_UserName='" + txt_email.Text + "' and IVRMSTAUL_Password='" + txt_pwd.Text + "' and IVRMSTAUL_ActiveFlag=1";
            dr = db.readall(st);
            if (dr.Read())
            {

                Session["IVRMUL_ID"] = dr["IVRMUL_ID"].ToString();
                Session["KVTP_RoleFlag"] = dr["KVTP_RoleFlag"].ToString();
                Roleflag = dr["KVTP_RoleFlag"].ToString();
                if (Session["KVTP_RoleFlag"] !=null && Roleflag == "STUDENT")
                {
                    Response.Redirect("StaffDashboard.aspx");
                }
                if (Session["KVTP_RoleFlag"] != null && Roleflag == "STAFF")
                {
                    Response.Redirect("StaffDashboard.aspx");
                }
                
                dr.Dispose(); db.db_close();
            }
           
        }

    }
}