using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace RTask
{

    internal class DataBase
    {
        private int Id;
        private static List<List<string>> RowsDB;

        public DataBase()
        {
            RowsDB = new List<List<string>>();
        }

        public int ID
        {
            get
            {
                return Id;
            }
            set
            {
                Id = value;
            }
        }

        public List<List<string>> ROWS
        {
            get
            {
                return RowsDB;
            }
            set
            {
                RowsDB = value;
            }
        }

        public int GetLastID()
        {
            if (UpdateRowsFromDB())
            {
                List<string> LRow = ROWS[ROWS.Count-1];
                if (!string.IsNullOrEmpty(LRow[0]))
                {
                    Id = Convert.ToInt32(LRow[0]);
                }
            }
            return Id;
        }

        public List<string> GetNamesItms()
        {
            List<string> Names = new List<string>();

            if (UpdateRowsFromDB())
            {
                foreach (List<string> rw in ROWS)
                { 
                    if(!string.IsNullOrEmpty(rw[1]))
                    {
                        Names.Add(rw[1]);
                    }
                }
            }

            return Names;
        }

        public bool GetValuesByPath(string thePath)
        {
            Entyti Ent = new Entyti();
            SqlDataReader Data = null;
            bool result = false;
            string val = string.Empty;
            string connect = ConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString;
            using (var con = new SqlConnection(connect))
            {
                if (!string.IsNullOrEmpty(thePath))
                {
                    string cmdString = "Select Id, Name, Path, Type, Id_P From TblVD where Path = '" + thePath + "'";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = cmdString;
                        try
                        {
                            con.Open();
                            Data = cmd.ExecuteReader();
                            if (Data.HasRows)
                            {
                                while (Data.Read())
                                {
                                    Entyti.VALUE.Clear();
                                    val = Data.GetValue("Id").ToString();
                                    Entyti.VALUE.Add(val);
                                    val = Data.GetValue("Name").ToString();
                                    Entyti.VALUE.Add(val);
                                    val = Data.GetValue("Path").ToString();
                                    Entyti.VALUE.Add(val);
                                    val = Data.GetValue("Type").ToString();
                                    Entyti.VALUE.Add(val);
                                    val = Data.GetValue("Id_P").ToString();
                                    Entyti.VALUE.Add(val);
                                    result = true;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            result = false;
                        }
                    }
                }
            }
            return result;
        }

        public void Clear()
        {
            List<string> vals = new List<string>();
            SqlDataReader Data = null;
            string connect = ConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString;
            using (var con = new SqlConnection(connect))
            {
                    string cmdString = "Select Id From TblVD";
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = cmdString;
                    try
                    {
                        con.Open();
                        Data = cmd.ExecuteReader();
                        if (Data.HasRows)
                        {
                            while (Data.Read())
                            {
                                vals.Add(Data.GetValue("Id").ToString());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                    con.Close();
                }

                foreach (string vl in vals)
                {
                    cmdString = "Delete From TblVD where Id = " + vl;
                    using (SqlCommand cmd1 = new SqlCommand())
                    {
                        cmd1.Connection = con;
                        cmd1.CommandText = cmdString;
                        try
                        {
                            con.Open();
                            Data = cmd1.ExecuteReader();
                        }
                        catch (Exception ex)
                        {
                        }
                        con.Close();
                    }
                }
            }
        }

        public string GetNameByID(int theID)
        {
            Entyti Ent = new Entyti();
            SqlDataReader Data = null;
            string val = string.Empty;
            string connect = ConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString;
            using (var con = new SqlConnection(connect))
            {
                if (theID > 0)
                {
                    string cmdString = "Select Name From TblVD where Id = " + theID.ToString();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = cmdString;
                        try
                        {
                            con.Open();
                            Data = cmd.ExecuteReader();
                            if (Data.HasRows)
                            {
                                while (Data.Read())
                                {
                                    val = Data.GetValue("Name").ToString();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            val = string.Empty;
                        }
                    }
                }
            }
            return val;
        }

        public bool GetValuesByName(string theName)
        {
            Entyti Ent = new Entyti();
            SqlDataReader Data = null;
            bool result = false;
            string val = string.Empty;
            string connect = ConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString;
            using (var con = new SqlConnection(connect))
            {
                if (!string.IsNullOrEmpty(theName))
                {
                    string cmdString = "Select Id, Name, Path, Type, Id_P From TblVD where Name = '" + theName + "'";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = cmdString;
                        try
                        {
                            con.Open();
                            Data = cmd.ExecuteReader();
                            if (Data.HasRows)
                            {
                                while (Data.Read()) 
                                {
                                    Entyti.VALUE.Clear();
                                    val = Data.GetValue("Id").ToString();
                                    Entyti.VALUE.Add(val);
                                    val = Data.GetValue("Name").ToString();
                                    Entyti.VALUE.Add(val);
                                    val = Data.GetValue("Path").ToString();
                                    Entyti.VALUE.Add(val);
                                    val = Data.GetValue("Type").ToString();
                                    Entyti.VALUE.Add(val);
                                    val = Data.GetValue("Id_P").ToString();
                                    Entyti.VALUE.Add(val);
                                    result = true;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            result = false;
                        }
                    }
                }
            }
            return result;
        }

        public bool IsertItem()
        {
            bool result = false;

            string connect = ConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString;
            using (var con = new SqlConnection(connect))
            {
                string cmdString = "INSERT INTO TblVD (Id, Name, Path, Type, Id_P) VALUES (@val1, @val2, @val3, @val4, @val5)";
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = cmdString;
                    cmd.Parameters.AddWithValue("@val1", Entyti.VALUE[0].ToString());
                    cmd.Parameters.AddWithValue("@val2", Entyti.VALUE[1]);
                    cmd.Parameters.AddWithValue("@val3", Entyti.VALUE[2]);
                    cmd.Parameters.AddWithValue("@val4", Entyti.VALUE[3]);
                    cmd.Parameters.AddWithValue("@val5", Entyti.VALUE[4].ToString());
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        result = true;
                    }
                    catch (Exception ex)
                    {
                        result = false;
                    }
                    con.Close();
                }
            }

            return result;
        }

        public bool UpdateRowsFromDB()
        {
            bool result = false;
            string val = string.Empty;
            List<string> VlRow = new List<string>();
            SqlDataReader Data = null;
            string connect = ConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString;
            using (var con = new SqlConnection(connect))
            {
                string cmdString = "Select Id, Name, Path, Type, Id_P From TblVD";
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = cmdString;
                    try
                    {
                        con.Open();
                        Data = cmd.ExecuteReader();
                        if (Data.HasRows)
                        {
                            while (Data.Read())
                            {
                                val = Data.GetValue("Id").ToString();
                                VlRow.Add(val);
                                val = Data.GetValue("Name").ToString();
                                VlRow.Add(val);
                                val = Data.GetValue("Path").ToString();
                                VlRow.Add(val);
                                val = Data.GetValue("Type").ToString();
                                VlRow.Add(val);
                                val = Data.GetValue("Id_P").ToString();
                                VlRow.Add(val);
                                RowsDB.Add(new List<string>() { VlRow[0], VlRow[1], VlRow[2], VlRow[3], VlRow[4] });
                                VlRow.Clear();
                                if (!result)
                                {
                                    result = true;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        result = false;
                    }
                    con.Close();
                }
            }

            return result;
        }

        public bool UpdateValue()
        {
            bool result = false;
            string connect = ConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString;
            using (var con = new SqlConnection(connect))
            {
                string cmdString = "UPDATE TblVD SET Name = @val1, Path = @val2 WHERE Id = @val3";
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = cmdString;
                    cmd.Parameters.AddWithValue("@val1", Entyti.VALUE[1]);
                    cmd.Parameters.AddWithValue("@val2", Entyti.VALUE[3]);
                    cmd.Parameters.AddWithValue("@val3", Entyti.VALUE[0].ToString());
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        result = true;
                    }
                    catch (Exception ex)
                    {
                        result = false;
                    }
                    con.Close();
                }
            }

            return result;
        }

        public bool DeleteValue()
        {
            bool result = false;
            string connect = ConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString;
            using (var con = new SqlConnection(connect))
            {
                string cmdString = "DELETE FROM TblVD WHERE Id = @val";
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = cmdString;
                    cmd.Parameters.AddWithValue("@val", Entyti.VALUE[0].ToString());
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        result = true;
                    }
                    catch (Exception ex)
                    {
                        result = false;
                    }
                    con.Close();
                }
            }

            return result;
        }
    }
}
