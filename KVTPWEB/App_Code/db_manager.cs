using System;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Web;
using System.Drawing;
using System.Web.SessionState;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.ComponentModel;
using System.Collections.Generic;

/// <summary>
/// Summary description for db_manager
/// </summary>
public class db_manager
{
    List<ListItem> list = new List<ListItem>();
    SqlConnection _connection;
    SqlCommand _command;
    DataTable _dataTable;
    SqlDataReader dr;
    string var;
    public db_manager()
    {

    }

    /// <summary>
    /// Method to call when you want to execute stored procedure and returns a rowset from stored pocedure, i.e used 'Select' query to return from SP 
    /// </summary>
    /// <param name="_SpName"></param>
    /// <param name="_parameters"></param>
    /// <returns></returns>
    public DataTable executeStoredProcedure_datatable(string _SpName, SqlParameter[] _parameters)
    {
        try
        {
            _connection = new SqlConnection(ConfigurationManager.AppSettings["con"]);
            _command = new SqlCommand(_SpName, _connection);
            _command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter _param in _parameters)
            {
                _command.Parameters.Add(_param);
            }
            _connection.Open();
            _dataTable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(_command);
            da.Fill(_dataTable);
            _connection.Close();
        }
        catch (Exception)
        {
            _connection.Close();
        }
        return _dataTable;
    }

    /// <summary>
    /// Method to call when you want to execute stored procedure and returns a integer value from stored pocedure, i.e used 'OUTPUT PARAMETER' in SP 
    /// </summary>
    /// <param name="_SpName"></param>
    /// <param name="_parameters"></param>
    /// <returns></returns>
    public int executeStoredProcedure_int(string _SpName, SqlParameter[] _parameters)
    {
        try
        {
            _connection = new SqlConnection(ConfigurationManager.AppSettings["con"]);
            _command = new SqlCommand(_SpName, _connection);
            _command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter _param in _parameters)
            {
                _command.Parameters.Add(_param);
            }
            //_command.Parameters.Add("@rid", SqlDbType.Int).Direction = ParameterDirection.Output; 
            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
            
        }
        catch(Exception)
        {
            _connection.Close();
        }
        return int.Parse(_command.Parameters[_command.Parameters.IndexOf("@output_id")].SqlValue.ToString());
    }
    public SqlDataReader readall(string _SpName, SqlParameter[] _parameters)
    {
        try
        {
            _connection = new SqlConnection(ConfigurationManager.AppSettings["con"]);
            _command = new SqlCommand(_SpName, _connection);
            _command.CommandType = CommandType.StoredProcedure;

            foreach (SqlParameter _param in _parameters)
            {
                _command.Parameters.Add(_param);
            }
            _connection.Open();
            dr = _command.ExecuteReader();
        }
        catch (Exception)
        {
            _connection.Close();
        }
        return dr;
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
    public void fill_drop_with_id(string st, SqlParameter[] _parameters, DropDownList drop)
    {
        try
        {

            _connection = new SqlConnection(ConfigurationManager.AppSettings["con"]);
            _command = new SqlCommand(st, _connection);
            _command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter _param in _parameters)
            {
                _command.Parameters.Add(_param);
            }
            _connection.Open();
            dr = _command.ExecuteReader();
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
        _connection.Close();
    }
    //public void readall(string st, SqlParameter[] _parameters)
    //{
    //    try
    //    {
    //        _connection = new SqlConnection(ConfigurationManager.AppSettings["con"]);
    //        _command = new SqlCommand(st, _connection);
    //        _command.CommandType = CommandType.StoredProcedure;

    //        _connection.Open();
    //        dr = _command.ExecuteReader();
    //    }
    //    catch (Exception) { }
    //    dr.Close();
       
    //}

  
}
