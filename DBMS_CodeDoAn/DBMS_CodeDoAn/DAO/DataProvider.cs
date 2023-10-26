using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using DBMS_CodeDoAn.DTO;

namespace DBMS_CodeDoAn.DAO
{
    public class DataProvider
    {
        private static DataProvider instance;

        public static DataProvider Instance 
        {
            get { if (instance == null) instance = new DataProvider(); return instance; }
            private set => instance = value; 
        }

        private string strCon = @"Data Source=.;Initial Catalog=DBMS_DOAN_QUANLYCUAHANGXE;Integrated Security=True";
        private DataProvider() { }

        public DataTable ExcuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();

            using (SqlConnection sqlCon = new SqlConnection(strCon))
            {
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand(query, sqlCon);

                if (parameter != null)
                {
                    // Split query
                    string[] listPara = query.Split(' ');
                    int idx = 0;

                    foreach (string para in listPara)
                    {
                        if (para.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(para, parameter[idx]);
                            idx++;
                        }
                    }

                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(data);

                sqlCon.Close();
            }

            return data;
        }

        public int ExcuteNonQuery(string query, object[] parameters = null)
        {
            int data = 0;

            using (SqlConnection sqlCon = new SqlConnection(strCon))
            {
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand(query, sqlCon);

                if (parameters != null)
                {
                    string[] listPara = query.Split(' ');
                    int idx = 0;

                    foreach(string para in listPara)
                    {
                        if (para.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(para, parameters[idx]);
                            idx++;
                        }
                    }
                }

                 data = cmd.ExecuteNonQuery();

                sqlCon.Close();
            }
            return data;
        }

        public object ExcuteScalar(string query, object[] parameters = null)
        {
            object data = 0;

            using (SqlConnection sqlCon = new SqlConnection(strCon))
            {
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand(query, sqlCon);

                if (parameters != null)
                {
                    string[] listPara = query.Split(' ');
                    int idx = 0;

                    foreach(string para in listPara)
                    {
                        if (para.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(para, parameters[idx]);
                            idx++;
                        }
                    }
                }
                data = cmd.ExecuteScalar();
            }
            return data;
        }

        //public byte[] 
    }
}
