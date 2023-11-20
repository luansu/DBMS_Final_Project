using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBMS_CodeDoAn.DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
        private DataProvider() 
        {
            LoginUser();
        }
        private void LoginUser()
        {
            string filePath = "log.txt";
            // Kiểm tra xem tệp tin có tồn tại không
            List<string> tk_mk = new List<string>();
            if (File.Exists(filePath))
            {
                // Mở tệp tin để đọc
                using (StreamReader reader = new StreamReader(filePath))
                {
                    // Đọc từng dòng và hiển thị ra màn hình
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        Console.WriteLine(line);
                        tk_mk.Add(line);
                    }
                }
                strCon = @"Data Source=.;Initial Catalog=DBMS_DOAN_QUANLYCUAHANGXE;Persist Security Info=True;;" + "User ID=" + tk_mk[0] + "; Password=" + tk_mk[1] + ";";
                
            }
        }
        public DataTable ExcuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();
            LoginUser();
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
            LoginUser();
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
            LoginUser();
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

        public byte[] converImgToByte(System.Windows.Forms.TextBox txtPathImage)
        {
            FileStream fs;
            fs = new FileStream(txtPathImage.Text, FileMode.Open, FileAccess.Read);
            byte[] picbyte = new byte[fs.Length];
            fs.Read(picbyte, 0, Convert.ToInt32(fs.Length));
            fs.Close();
            return picbyte;
        }

        // Method Convert Byte arr to Image
        public Image ByteToImg(string byteString)
        {
            if (byteString == "")
                 return null;
            byte[] imgBytes = Convert.FromBase64String(byteString);
            MemoryStream ms = new MemoryStream(imgBytes, 0, imgBytes.Length);
            ms.Write(imgBytes, 0, imgBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }

    }
}
