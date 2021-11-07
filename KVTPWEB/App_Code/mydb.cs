using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Net;
using System.Net.Mail;

public class mydb
{
    List<ListItem> list = new List<ListItem>();
    List<System.Data.Common.DbDataRecord> MyList = new List<System.Data.Common.DbDataRecord>();
    List<System.Data.Common.DbDataRecord> Sublist = new List<System.Data.Common.DbDataRecord>();
    SqlDataAdapter sqlda;
    SqlCommand cm;
    SqlConnection db;
    string con = "", st2 = "", st3 = "", st = "", st6 = "";
    string cn = "";
    DataSet ds = new DataSet();
    SqlDataReader dr;
    DataTable dt = new DataTable();
    int x;
    SqlCommandBuilder cb;
    public enum FieldTypes { Text, Number, Date, Memo }
    public mydb()
    {
        try
        {
            con = ConfigurationManager.AppSettings["con"];
            //con = @"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\projects\gsm_new1\App_Data\gsm.mdf;Integrated Security=True;User Instance=True";
            cn = ConfigurationManager.AppSettings["con"];
            db = new SqlConnection(cn);
            if (db.State == ConnectionState.Open)
            {
                db.Close();
            }
            db.Open();
        }
        catch (Exception) { }
    }
    public string conn()
    {
        if (ConfigurationManager.AppSettings["a"] != null)
        {
            //cn = "Data Source=" + ConfigurationManager.AppSettings["val"] + ";Initial Catalog=sinq_resto_new;Integrated Security=True;";
        }
        else
        {
            cn = ConfigurationManager.AppSettings["con"];
        }
        return cn;
    }
    public SqlConnection dbcon()
    {
        con = ConfigurationManager.AppSettings["con"];
        //con = @"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\projects\gsm_new1\App_Data\gsm.mdf;Integrated Security=True;User Instance=True";
        cn = ConfigurationManager.AppSettings["con"];
        db = new SqlConnection(con);
        if (db.State == ConnectionState.Open)
        {
            db.Close();
        }
        db.Open();
        return db;
    }

    public int readmax(string st)
    {
        try
        {
            if (db.State == ConnectionState.Closed)
            {
                db.Open();
            }
            cm = new SqlCommand(st, db);
            x = Convert.ToInt32(cm.ExecuteScalar());
            db.Close();
        }
        catch (Exception) { }
        return x;

    }
    public string nav_user(string f_id)
    {
        try
        {
            st2 = "<div class='navbar' style=' background-color:#ebebeb'><div class='navbar-inner'><div class='container'><div class='nav-collapse collapse navbar-responsive-collapse '><ul class='nav'>";
            //st3 = "SELECT DISTINCT dbo.file_master.f_group FROM dbo.file_master INNER JOIN dbo.file_allocation ON dbo.file_master.fl_id = dbo.file_allocation.fl_id WHERE (dbo.file_master.status <> 5) AND (dbo.file_allocation.f_id =" + f_id.ToString() + ")";
            //dr = readall(st3);
            //if (dr.HasRows == true)
            //{
            //MyList.Clear();
            //MyList = dr.Cast<System.Data.Common.DbDataRecord>().ToList();
            //dr.Close();
            //for (int i = 0; i < MyList.Count; i++)
            //{
            //  st2 += "<li id=" + MyList[i][0].ToString() + " class='dropdown'><a data-toggle='dropdown' class='dropdown-toggle' href='#'>" + MyList[i][0].ToString() + "<b class='caret'></b></a><ul class='dropdown-menu'>";

            //st6 = "SELECT DISTINCT dbo.file_master.sub_group FROM dbo.file_master INNER JOIN dbo.file_allocation ON dbo.file_master.fl_id = dbo.file_allocation.fl_id WHERE (dbo.file_master.status <> 5) AND file_allocation.f_id = " + f_id.ToString() + " AND f_group='" + MyList[i][0].ToString() + "'";
            //dr = readall(st6);
            // if (dr.HasRows == true)
            //{
            //   Sublist.Clear();
            //  Sublist = dr.Cast<System.Data.Common.DbDataRecord>().ToList();

            //for (int j = 0; j < Sublist.Count; j++)
            //{

            //st2 += "<li id=" + Sublist[j][0].ToString() + " class='dropdown-submenu'><a data-toggle='dropdown' class='dropdown-toggle' href='#'>" + Sublist[j][0].ToString() + " </a><ul class='dropdown-menu'>";
            //dr.Close();
            st = "SELECT DISTINCT file_master.fl_id, file_master.f_name, file_master.title FROM file_allocation INNER JOIN file_master ON file_allocation.fl_id = file_master.fl_id WHERE file_master.status <> 5 AND file_allocation.f_id = " + f_id.ToString() + "";
            dr = readall(st);
            if (dr.HasRows == true)
            {
                while (dr.Read() == true)
                {

                    st2 += "<li><a href='#'class='gg' id=" + dr[1].ToString() + ">" + dr[2].ToString() + "</a></li>";
                }
            }
            dr.Close();
            //st2 += "</ul></li>";
            //}
            //}
            //st2 += "</ul></li>";
            //}
            st2 += "</ul></div></div></div></div>";
            //}
            return st2;

        }
        catch
        {
            return st2;
        }
    }
    public string nav_admin()
    {
        try
        {
            st2 = "<div class='navbar' style=' background-color:#ebebeb'><div class='navbar-inner'><div class='container'><div class='nav-collapse collapse navbar-responsive-collapse nav-stacked'><ul class='nav'>";
            //st = "SELECT DISTINCT file_master.fl_id, file_master.f_name, file_master.title FROM file_allocation INNER JOIN file_master ON file_allocation.fl_id = file_master.fl_id WHERE file_master.status <> 5 AND file_allocation.f_id = " + f_id.ToString() + "";
            st = "SELECT DISTINCT fl_id, f_name, title FROM file_master WHERE (status = 1)";
            dr = readall(st);
            if (dr.HasRows == true)
            {
                while (dr.Read() == true)
                {

                    st2 += "<li><a href='#'class='gg' id=" + dr[1].ToString() + ">" + dr[2].ToString() + "</a></li>";
                }
            }
            dr.Close();
            st2 += "</ul></div></div></div></div>";
            return st2;
        }
        catch
        {
            return st2;
        }
    }
    public int return_affectedrow(string st)
    {
        if (db.State == ConnectionState.Closed)
        {
            db.Open();
        }
        try
        {
            x = 0;
            cm = new SqlCommand(st, db);
            x = (int)cm.ExecuteScalar();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return x;
      
    }

    public void fids(string st, GridView g1)
    {
        try
        {
            if (db.State == ConnectionState.Closed)
            {
                db.Open();
            }
            cm = new SqlCommand(st, db);
            sqlda = new SqlDataAdapter(cm);
            ds = new DataSet();
            ds.Clear();
            sqlda.Fill(ds, "tbl");
            g1.DataSource = ds.Tables["tbl"];
            g1.DataBind();
            db.Close();
        }
        catch (Exception) { }
    }
    //public SqlDataAdapter temp_fill(string st, GridView g1)
    //{
    //    try
    //    {
    //        cm = new SqlCommand(st, db);
    //        return sqlda = new SqlDataAdapter(cm);
    //    }
    //    catch (Exception) { }
    //}
    public int filldl(string st, DataList d1)
    {
        try
        {
            if (db.State == ConnectionState.Closed)
            {
                db.Open();
            }
            cm = new SqlCommand(st, db);
            sqlda = new SqlDataAdapter(cm);
            ds = new DataSet();
            ds.Clear();
            sqlda.Fill(ds, "tbl");
            d1.DataSource = ds.Tables["tbl"];
            d1.DataBind();
        }
        catch (Exception) { }
        db.Close();
        return 1;

    }
    public int ExeQuery(string st)
    {
        try
        {
            if (db.State == ConnectionState.Closed)
            {
                db.Open();
            }
            x = 0;
            cm = new SqlCommand(st, db);
            x = cm.ExecuteNonQuery();
        }
        catch (Exception) { }
        db.Close();
        return x;

    }

    public string ToSQL(string Param, FieldTypes Type)
    {
        if (Param == null || Param.Length == 0)
        {
            return "Null";
        }
        else
        {
            string str = Quote(Param);
            if (Type == FieldTypes.Number)
            {
                return str.Replace(',', '.');
            }
            else
            {
                return "\'" + str + "\'";
            }
        }
    }
    public string Quote(string Param)
    {
        if (Param == null || Param.Length == 0)
        {
            return "";
        }
        else
        {
            return Param.Replace("'", "''");
        }
    }
    public string Quote_Replace(string Param)
    {
        if (Param == null || Param.Length == 0)
        {
            return "";
        }
        else
        {
            return Param.Replace("'", " ");
        }
    }
    public SqlDataReader sdr(string st, DropDownList drop)
    {
        try
        {
            if (db.State == ConnectionState.Closed)
            {
                db.Open();
            }
            cm = new SqlCommand(st, db);
            dr = cm.ExecuteReader();
            drop.Items.Clear();
            if (dr.HasRows == true)
            {
                while (dr.Read() == true)
                {
                    if (dr[0].ToString().Trim() != "" || dr[0].ToString().Trim().Length != 0)
                    {
                        drop.Items.Add(dr[0].ToString().Trim());
                    }
                }



            }
            dr.Dispose();
        }
        catch (Exception) { }
        db.Close();
        return dr;

    }
    public SqlDataReader fill_list_Box(string st, ListBox drop)
    {
        try
        {
            if (db.State == ConnectionState.Closed)
            {
                db.Open();
            }
            cm = new SqlCommand(st, db);
            dr = cm.ExecuteReader();
            drop.Items.Clear();
            if (dr.HasRows == true)
            {
                while (dr.Read() == true)
                {
                    if (dr[0].ToString().Trim() != "" || dr[0].ToString().Trim().Length != 0)
                    {
                        drop.Items.Add(dr[0].ToString().Trim());
                    }
                }

            }
            dr.Dispose();
        }
        catch (Exception) { }
        db.Close();
        return dr;

    }
    public SqlDataReader sqldr(string st)
    {
        try
        {
            if (db.State == ConnectionState.Closed)
            {
                db.Open();
            }
            if (db.State == ConnectionState.Closed)
            { db.Open(); }
            cm = new SqlCommand(st, db);
            dr = cm.ExecuteReader();
        }
        catch (Exception) { }
        db.Close();
        return dr;

    }
    public string Encrypt(string clearText)
    {
        string EncryptionKey = "gnyan19871";
        byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.Close();
                }
                clearText = Convert.ToBase64String(ms.ToArray());
            }
        }
        return clearText;
    }

    public string Decrypt(string cipherText)
    {
        string EncryptionKey = "gnyan19871";
        cipherText = cipherText.Replace(" ", "+");
        //Regex.Replace(tb_f_name.Text, @"[$,]", " ")

        byte[] cipherBytes = Convert.FromBase64String(cipherText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);

            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cipherBytes, 0, cipherBytes.Length);
                    cs.Close();
                }

                cipherText = Encoding.Unicode.GetString(ms.ToArray());
            }
        }
        return cipherText;
    }
    public SqlDataReader readall(string st)
    {
        try
        {
            if (db.State == ConnectionState.Closed)
            {
                db.Open();
            }
            cm = new SqlCommand(st, db);
            dr = cm.ExecuteReader();
        }
        catch (Exception)
        {

        }
        return dr;

    }
    public SqlDataAdapter dss(string st, GridView g1)
    {
        try
        {
            if (db.State == ConnectionState.Closed)
            {
                db.Open();
            }
            cm = new SqlCommand(st, db);
            sqlda = new SqlDataAdapter(cm);
            ds = new DataSet();
            ds.Clear();
            sqlda.Fill(ds, "tbl");
            g1.DataSource = null;
            g1.DataBind();
            g1.DataSource = ds.Tables["tbl"];
            g1.DataBind();

        }
        catch (Exception) { }
        db.Close();
        return sqlda;
    }

    public DataTable GetData(string st, DataTable dt)
    {
        cm = new SqlCommand(st, db);
        SqlDataAdapter adp = new SqlDataAdapter(cm);
        adp.Fill(dt);
        return dt;

    }

    public DataSet dss1(string st)
    {
        try
        {
            if (db.State == ConnectionState.Closed)
            {
                db.Open();
            }
            cm = new SqlCommand(st, db);
            sqlda = new SqlDataAdapter(cm);
            ds = new DataSet();
            ds.Clear();
            sqlda.Fill(ds, "tbl");
            //g1.DataSource = null;
            //g1.DataBind();
            //g1.DataSource = ds.Tables["tbl"];
            //g1.DataBind();

        }
        catch (Exception) { }
        db.Close();
        return ds;
    }


    public string chk_ch(string ck)
    {
        if (ck.Length == 0 || ck == " ")
        {
            return (ck = " ");
        }
        else
        {
            return ck;
        }
    }
    public string chk_0(string ck)
    {
        if (ck.Length == 0 || ck == "")
        {
            return (ck = "0");
        }
        else
        {
            return ck;
        }
    }
    public string chk_image(string ck)
    {
        if (ck.Length == 0 || ck == " ")
        {
            return (ck = "0.jpg");
        }
        else
        {
            return ck;
        }
    }
    public string chk_dt(string param)
    {
        if ((param.Length == 0) || (param == ""))
        {
            return (param = "1/1/1900");
        }
        else
        {
            return param;
        }
    }
    public SqlDataAdapter dsude(string st, GridView g1)
    {
        try
        {
            if (db.State == ConnectionState.Closed)
            {
                db.Open();
            }
            cm = new SqlCommand(st, db);
            sqlda = new SqlDataAdapter(cm);
            SqlCommandBuilder cb = new SqlCommandBuilder(sqlda);
            sqlda.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            ds = new DataSet();
            ds.Clear();
            sqlda.Fill(ds, "tbl");
            g1.DataSource = ds.Tables["tbl"];
            g1.DataBind();

        }
        catch (Exception) { }
        db.Close();
        return sqlda;
    }
    public string nul_chk(string st)
    {
        if (st.ToString() == "")
        {
            return st = "NULL";
        }
        return st;
    }


    public void fill_repeater(string st, Repeater r1)
    {
        try
        {
            if (db.State == ConnectionState.Closed)
            {
                db.Open();
            }
            cm = new SqlCommand(st, db);
            sqlda = new SqlDataAdapter(cm);
            ds = new DataSet();
            ds.Clear();
            sqlda.Fill(ds, "tbl");
            r1.DataSource = null;
            r1.DataBind();
            r1.DataSource = ds.Tables["tbl"];
            r1.DataBind();


        }
        catch (Exception) { }
        db.Close();
    }
    public SqlDataAdapter fill_rptr_ret_sqlda(string st, Repeater r1)
    {
        try
        {
            cm = new SqlCommand(st, db);
            sqlda = new SqlDataAdapter(cm);
            ds = new DataSet();
            ds.Tables.Clear();
            sqlda.Fill(ds, "tbl");
            r1.DataSource = null;
            r1.DataBind();
            r1.DataSource = ds.Tables["tbl"];
            r1.DataBind();
            db.Close();

        }
        catch (Exception) { }
        return sqlda;
    }
    public SqlDataAdapter exe_ret_adapter(string st)
    {
        try
        {
            if (db.State == ConnectionState.Closed)
            {
                db.Open();
            }
            cm = new SqlCommand(st, db);
            sqlda = new SqlDataAdapter(cm);
        }
        catch (Exception) { }
        db.Close();
        return sqlda;
    }

    public void fill_drop_with_id(string st, DropDownList drop)
    {
        try
        {
            if (db.State == ConnectionState.Closed)
            { db.Open(); }
            cm = new SqlCommand(st, db);
            dr = cm.ExecuteReader();
            //try
            //{
            list.Clear();
            drop.Items.Clear();
            //}
            //catch (Exception ex) { } 
            while (dr.Read() == true)
            {
                if (dr[1].ToString() != "" || dr[1].ToString().Length != 0)
                {
                    list.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
                }
            }
            drop.DataSource = list;
            drop.DataTextField = "Text";
            drop.DataValueField = "Value";
            drop.DataBind();
            drop.Items.Insert(0, "Select");

            dr.Dispose();

        }
        catch (Exception) { }
        db.Close();
    }

    public void fill_drop_no_select(string st, DropDownList drop)
    {
        try
        {
            if (db.State == ConnectionState.Closed)
            { db.Open(); }
            cm = new SqlCommand(st, db);
            dr = cm.ExecuteReader();
            //try
            //{
            list.Clear();
            drop.Items.Clear();
            //}
            //catch (Exception ex) { } 
            while (dr.Read() == true)
            {
                if (dr[1].ToString() != "" || dr[1].ToString().Length != 0)
                {
                    list.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
                }
            }
            drop.DataSource = list;
            drop.DataTextField = "Text";
            drop.DataValueField = "Value";
            drop.DataBind();
            dr.Dispose();

        }
        catch (Exception) { }
        db.Close();
    }

    public void fill_ddl_no_select(string st, DropDownList drop)
    {
        try
        {
            if (db.State == ConnectionState.Closed)
            { db.Open(); }
            cm = new SqlCommand(st, db);
            dr = cm.ExecuteReader();
            //try
            //{
            list.Clear();
            drop.Items.Clear();
            //}
            //catch (Exception ex) { } 
            while (dr.Read() == true)
            {
                if (dr[1].ToString() != "" || dr[1].ToString().Length != 0)
                {
                    list.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
                }
            }
            drop.DataSource = list;
            drop.DataTextField = "Text";
            drop.DataValueField = "Value";
            drop.DataBind();

        }
        catch (Exception) { }
        dr.Dispose(); db.Close();
    }

    public void fill_drop(string st, DropDownList drop)
    {
        try
        {
            if (db.State == ConnectionState.Closed)
            { db.Open(); }
            cm = new SqlCommand(st, db);
            dr = cm.ExecuteReader();
            //try
            //{
            list.Clear();
            drop.Items.Clear();
            //}
            //catch (Exception ex) { } 
            while (dr.Read() == true)
            {
                if (dr[0].ToString() != "" || dr[0].ToString().Length != 0)
                {
                    list.Add(new ListItem(dr[0].ToString()));
                }
            }
            drop.DataSource = list;
            drop.DataTextField = "Text";
            drop.DataValueField = "Value";
            drop.DataBind();
            drop.Items.Insert(0, "Select");

            dr.Dispose();

        }
        catch (Exception) { }
        db.Close();
    }

    public void fill_drop_with_id_all(string st, DropDownList drop)
    {
        try
        {
            if (db.State == ConnectionState.Closed)
            { db.Open(); }
            cm = new SqlCommand(st, db);
            dr = cm.ExecuteReader();
            //try
            //{
            list.Clear();
            drop.Items.Clear();
            //}
            //catch (Exception ex) { } 
            list.Add(new ListItem("ALL", "0"));
            while (dr.Read() == true)
            {
                if (dr[1].ToString() != "" || dr[1].ToString().Length != 0)
                {
                    list.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
                }
            }
            drop.DataSource = list;
            drop.DataTextField = "Text";
            drop.DataValueField = "Value";
            drop.DataBind();
            drop.Items.Insert(0, "Select");

            dr.Dispose();

        }
        catch (Exception) { }
        db.Close();
    }

    public void fill_radio_button_list(string st, RadioButtonList rbl)
    {
        try
        {
            if (db.State == ConnectionState.Closed)
            { db.Open(); }
            cm = new SqlCommand(st, db);
            //dr = cm.ExecuteReader();

            //list.Clear();
            //rbl.Items.Clear();

            //list.Add(new ListItem("ALL", "0"));
            //while (dr.Read() == true)
            //{
            //    if (dr[1].ToString() != "" || dr[1].ToString().Length != 0)
            //    {
            //        list.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
            //    }
            //}
            rbl.DataSource = cm.ExecuteReader();
            rbl.DataTextField = "meal_plan";
            rbl.DataValueField = "id";
            rbl.DataBind();

            //dr.Dispose();

        }
        catch (Exception) { }
        db.Close();
    }

    public string read_val(string st)
    {
        string val = "";
        try
        {
            dr = readall(st);
            if (dr.Read() == true)
            {
                val = dr[0].ToString();
            }
            dr.Dispose();
        }
        catch (Exception) { }
        return val;
        db.Close();
    }


    public void fill_listbox_with_id(string st, ListBox drop)
    {
        try
        {
            if (db.State == ConnectionState.Closed)
            { db.Open(); }
            cm = new SqlCommand(st, db);
            dr = cm.ExecuteReader();
            list.Clear();
            drop.Items.Clear();
            while (dr.Read() == true)
            {
                if (dr[1].ToString() != "" || dr[1].ToString().Length != 0)
                {
                    list.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
                }
            }
            drop.DataSource = list;
            drop.DataTextField = "Text";
            drop.DataValueField = "Value";
            drop.DataBind();

            dr.Dispose();
            db.Close();
        }
        catch (Exception) { }
    }

    public void page_autho()
    {
        try
        {

            if (HttpContext.Current.Session["ent_by"].ToString() != "0")
            {
                System.IO.FileInfo file_name = new System.IO.FileInfo(System.Web.HttpContext.Current.Request.Url.AbsolutePath);
                string file = file_name.Name;
                string s = " SELECT user_setup_details.u_a_d_id, file_master.file_name, user_setup.fac_id FROM user_setup INNER JOIN";
                s += " user_setup_details ON user_setup.u_a_id = user_setup_details.u_a_id INNER JOIN file_master ON user_setup_details.f_id = file_master.f_id ";
                s += " where file_master.file_name='" + file.ToString() + "' and  user_setup.fac_id=" + HttpContext.Current.Session["ent_by"].ToString() + " ";
                dr = readall(s);
                if (dr.Read() == true)
                {
                    x = 1;
                }
                else
                {
                    HttpContext.Current.Response.Redirect("autho_error.htm");

                }
                dr.Dispose();
            }
        }
        catch
        { }
    }

    public void m_grade(string mrk)
    {
        //if(mrk>=91 && mrk<=100)
        //{
        //   return(mrk= "A1");
        //}
        //else if(mrk>=81 && mrk<=90)
        //{
        //       return(mrk= "A2");
        //}
        //else if(mrk>=71 && mrk<=80)
        //{
        //       return(mrk= "B1");
        //}
        //else if(mrk>=61 && mrk<=70)
        //{
        //       return(mrk= "A2");
        //}
        //else if(mrk>=61 && mrk<=70)
        //{
        //       return(mrk= "B2");
        //}
        //else if(mrk>=51 && mrk<=60)
        //{
        //       return(mrk= "C1");
        //}
        // else if(mrk>=41 && mrk<=50)
        //{
        //       return(mrk= "C2");
        //}
        // else if(mrk>=33 && mrk<=40)
        //{
        //       return(mrk= "D");
        //}
        // else if(mrk>=21 && mrk<=32)
        //{
        //       return(mrk= "E1");
        //}
        // else if(mrk>=00 && mrk<=20)
        //{
        //       return(mrk= "E2");
        //}

    }

    public List<System.Data.Common.DbDataRecord> execute_returnlist(string st)
    {
        List<System.Data.Common.DbDataRecord> MYLIST = new List<System.Data.Common.DbDataRecord>();
        if (db.State == ConnectionState.Open)
        {
            db.Close();
        }
        db.Open();

        cm = new SqlCommand(st, db);
        dr = cm.ExecuteReader();
        MYLIST = dr.Cast<System.Data.Common.DbDataRecord>().ToList();
        dr.Dispose();
        return MYLIST;
    }

    public string nul_chk_0(string st)
    {
        if (st.ToString() == "")
        {
            return st = "0";
        }
        return st;
    }

    public void fill_listbox_with_chk(string st, CheckBoxList chk)
    {
        //CheckBoxList checkboxlist1 = new CheckBoxList();
        try
        {
            if (db.State == ConnectionState.Open)
            {
                db.Close();
            }
            db.Open();
            cm = new SqlCommand(st, db);
            dr = cm.ExecuteReader();
            //chk.Clear();
            list.Clear();
            //chk.Items.Clear();
            while (dr.Read() == true)
            {
                list.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
            }
            chk.DataSource = list;
            chk.DataTextField = "Text";
            chk.DataValueField = "Value";
            chk.DataBind();
            dr.Dispose();
        }
        catch (Exception) { db.Close(); }
        finally { db.Close(); }
    }

    public string NumberToWords(int number)
    {
        if (number == 0)
            return "zero";

        if (number < 0)
            return "minus " + NumberToWords(Math.Abs(number));

        string words = "";
        if ((number / 1000000000) > 0)
        {
            words += NumberToWords(number / 1000000000) + " Billion ";
            number %= 1000000000;
        }

        if ((number / 10000000) > 0)
        {
            words += NumberToWords(number / 10000000) + " Crore ";
            number %= 10000000;
        }

        if ((number / 1000000) > 0)
        {
            words += NumberToWords(number / 1000000) + " million ";
            number %= 1000000;
        }


        if ((number / 100000) > 0)
        {
            words += NumberToWords(number / 100000) + " lakh ";
            number %= 100000;
        }


        if ((number / 1000) > 0)
        {
            words += NumberToWords(number / 1000) + " thousand ";
            number %= 1000;
        }

        if ((number / 100) > 0)
        {
            words += NumberToWords(number / 100) + " hundred ";
            number %= 100;
        }

        if (number > 0)
        {
            if (words != "")
                words += "and ";

            var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

            if (number < 20)
                words += unitsMap[number];
            else
            {
                words += tensMap[number / 10];
                if ((number % 10) > 0)
                    words += "-" + unitsMap[number % 10];
            }
        }

        return words;
    }

    public void ExportToExcel(string strFileName, GridView dg)
    {
        HttpContext.Current.Response.ClearContent();
        HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" + strFileName);
        HttpContext.Current.Response.ContentType = "application/excel";
        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        dg.HeaderRow.Style.Add("background-color", "#FFFFFF");
        for (int i = 0; i < dg.HeaderRow.Cells.Count; i++)
        {
            dg.HeaderRow.Cells[i].Style.Add("background-color", "#507CD1");
        }
        int j = 1;
        //This loop is used to apply stlye to cells based on particular row
        foreach (GridViewRow gvrow in dg.Rows)
        {
            //gvrow.BackColor = Color.White;
            if (j <= dg.Rows.Count)
            {
                if (j % 2 != 0)
                {
                    for (int k = 0; k < gvrow.Cells.Count; k++)
                    {
                        gvrow.Cells[k].Style.Add("background-color", "#EFF3FB");
                    }
                }
            }
            j++;
        }
        dg.RenderControl(htw);
        HttpContext.Current.Response.Write(sw.ToString());
        HttpContext.Current.Response.End();
    }

    public void db_close()
    {
        if (db.State == ConnectionState.Open)
        {
            db.Close();
        }
    }

    public String send_sms(string msg, string phone)
    {
        string result = "";
        
        return result;
    }

    public string send_mail(string mail_to, string subject, string content)
    {
        string msg = "";
        try
        {
            MailMessage mg = new MailMessage();
            mg.From = new MailAddress(ConfigurationManager.AppSettings["mailid"].ToString());
            string[] to = mail_to.Split(',');
            for (int i = 0; i < to.Length; i++)
            {
                mg.To.Add(new MailAddress(to[i].ToString()));
            }
            //mg.To.Add(new MailAddress(lbl_hotel_mail.Text));

            //mg.Subject = subject;
            //mg.Body = content;
            //mg.IsBodyHtml = true;
            ////mg.Priority = MailPriority.High;
            //SmtpClient sc = new SmtpClient();
            //sc.EnableSsl = false;
            //sc.Host = "w31.interactivedns.com";
            //sc.Port = 25;
            //sc.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["mailid"].ToString(), ConfigurationManager.AppSettings["pwd"].ToString());

            mg.Subject = subject;
            mg.Body = content;
            mg.IsBodyHtml = true;
            SmtpClient sc = new SmtpClient();
            sc.Host = "w31.interactivedns.com";//localhost
            sc.EnableSsl = false;
            NetworkCredential NetworkCred = new NetworkCredential(ConfigurationManager.AppSettings["mailid"].ToString(), ConfigurationManager.AppSettings["pwd"].ToString());
            sc.Credentials = NetworkCred;
            sc.Port = System.Convert.ToInt32("25");
            sc.Send(mg);

            //mg.Subject = subject;
            //mg.Body = content;
            //mg.IsBodyHtml = true;
            //mg.Priority = MailPriority.High;
            //SmtpClient sc = new SmtpClient();
            //sc.EnableSsl = true;
            //sc.Host = "smtp.gmail.com";
            //sc.Port = 587;
            //sc.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["mailid"].ToString(), ConfigurationManager.AppSettings["pwd"].ToString());
            //sc.Send(mg);

            msg = "";
        }
        catch (Exception ex)
        {
            msg = ex.Message.ToString();
        }
        return msg;
    }

    public string SqlValidate(string sql)
    {
        sql = sql.Replace(";", "");
        sql = sql.Replace("--", "");
        sql = sql.Replace("'", "''");
        sql = sql.Replace("<script", "''");
        sql = sql.Replace("</script>", "''");
        sql = sql.Replace("<SCRIPT", "''");
        sql = sql.Replace("</SCRIPT>", "''");
        sql = sql.Replace(";", "''");
        sql = sql.Replace("%", "''");
        sql = sql.Replace("?", "''");
        sql = sql.Replace("!", "''");
        sql = sql.Replace("EXEC(", "''");
        sql = sql.Replace("VARCHAR(", "''");
        sql = sql.Replace("exec(", "''");
        sql = sql.Replace("varchar(", "''");

        if (sql.IndexOf("<p>") > -1 && sql.LastIndexOf("</p>") > -1)
        {
            if (sql.Substring(0, 3).CompareTo("<p>") == 0)
            {
                //sql = sql.TrimStart('<', 'p', '>');
                //sql = sql.TrimEnd('<', '/', 'p', '>');
                sql = sql.Remove(0, 3);

            }
            if (sql.Substring(sql.Length - 4, 4).CompareTo("</p>") == 0)
            {
                sql = sql.Remove(sql.Length - 4, 4);
            }

        }
        //sql = sql.Replace("&nbsp;", "");
        return sql;
    }
}