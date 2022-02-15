using Npgsql;
using POS_OJT.Properties;
using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Text;

namespace POS_OJT.Config
{
    public class DbConnection
    {
        public string iniPath = Constant.FILEPATH;

        public static string conStr = String.Empty;

        public static NpgsqlConnection conn = new NpgsqlConnection();

        public static NpgsqlCommand comm = new NpgsqlCommand();

        public static NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();

        public string GetConnection()
        {
            string DB_SERVER = GetIniString("DATABASE", "DB_SERVER", iniPath);
            string DB_PORT = GetIniString("DATABASE", "DB_PORT", iniPath);
            string DB_USERID = GetIniString("DATABASE", "DB_USERID", iniPath);
            string DB_PASSWORD = GetIniString("DATABASE", "DB_PASSWORD", iniPath);
            string DB_NAME = GetIniString("DATABASE", "DB_NAME", iniPath);
            string connstring = String.Format("Server={0};Port={1};" +
                    "User Id={2};Password={3};Database={4};",
                    DB_SERVER, DB_PORT, DB_USERID,
                    DB_PASSWORD, DB_NAME);

            return connstring;
        }

        public string GetImagePathSring(string folder_name, string path)
        {
            return GetIniString(folder_name, path, iniPath);
        }

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        internal static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

        public string GetIniString(String Section, String Keyname, String IniFile)
        {
            StringBuilder iniString = new StringBuilder(255);
            GetPrivateProfileString(Section, Keyname, "", iniString, iniString.Capacity, IniFile);
            return iniString.ToString();
        }

        public DataTable ExecuteDataTable(
            CommandType TypeOfCommand,
            string CmdText)
        {
            DataSet dtSet = new DataSet();
            conStr = GetConnection();

            using (NpgsqlConnection npgsqlcon = new NpgsqlConnection(conStr))
            {
                comm.Connection = npgsqlcon;
                comm.CommandText = CmdText;
                comm.CommandType = TypeOfCommand;
                comm.CommandTimeout = 200;

                if (conn.State != ConnectionState.Open)
                {
                    comm.Connection.Open();
                }

                adapter = new NpgsqlDataAdapter(CmdText, conn);
                adapter.SelectCommand = comm;
                dtSet.Reset();
                adapter.Fill(dtSet);
            }
            comm.Connection.Close();

            return dtSet.Tables[0];
        }

        public object ExecuteScalar(CommandType TypeOfCommand,
            string CmdText,
            NpgsqlParameter[] NpgsqlParams)
        {
            object objTemp = null;
            conStr = GetConnection();

            using (NpgsqlConnection npgSqlConn = new NpgsqlConnection(conStr))
            {
                comm.Connection = npgSqlConn;
                comm.CommandType = TypeOfCommand;
                comm.CommandText = CmdText;
                comm.CommandTimeout = 200;

                if (npgSqlConn.State != ConnectionState.Open)
                {
                    comm.Connection.Open();
                }

                if (NpgsqlParams != null)
                {
                    foreach (NpgsqlParameter npgSqlParam in NpgsqlParams)
                    {
                        npgSqlParam.Value = (npgSqlParam.Value == null || npgSqlParam.Value.ToString() == String.Empty ?
                        DBNull.Value : (object)npgSqlParam.Value);
                        comm.Parameters.Add(npgSqlParam);
                    }
                }

                objTemp = comm.ExecuteScalar();
                comm.Connection.Close();
                comm.Parameters.Clear();
            }

            return objTemp;
        }

        public int ExecuteNonQuery(
                                CommandType TypeOfCommand,
                                String CmdText,
                                NpgsqlParameter[] NpgSqlParams
                                )
        {
            int affectedRow = 0;
            conStr = GetConnection();

            using (NpgsqlConnection npgSqlConn = new NpgsqlConnection(conStr))
            {
                comm.Connection = npgSqlConn;
                comm.CommandText = CmdText;
                comm.CommandType = TypeOfCommand;
                comm.CommandTimeout = 200;

                if (npgSqlConn.State != ConnectionState.Open)
                {
                    comm.Connection.Open();
                }

                if (NpgSqlParams != null)
                {
                    foreach (NpgsqlParameter npgSqlParam in NpgSqlParams)
                    {
                        npgSqlParam.Value = (npgSqlParam.Value == null || npgSqlParam.Value.ToString() == String.Empty ?
                        DBNull.Value : (object)npgSqlParam.Value);
                        comm.Parameters.Add(npgSqlParam);
                    }
                }

                affectedRow = comm.ExecuteNonQuery();

                comm.Parameters.Clear();
                comm.Connection.Close();
            }

            return affectedRow;
        }

        public DataSet ExecuteDataSet(
                                        CommandType TypeOfCommand,
                                        String CmdText
                                    )
        {
            conStr = GetConnection();
            DataSet dsSet = new DataSet();
            using (NpgsqlConnection npgSqlConn = new NpgsqlConnection(conStr))
            {
                comm.Connection = npgSqlConn;
                comm.CommandText = CmdText;
                comm.CommandType = TypeOfCommand;
                comm.CommandTimeout = 200;

                if (npgSqlConn.State != ConnectionState.Open)
                {
                    comm.Connection.Open();
                }

                adapter.SelectCommand = comm;
                adapter.Fill(dsSet);
                comm.Connection.Close();
            }

            return dsSet;
        }
    }
}