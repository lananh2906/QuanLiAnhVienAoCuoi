using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;// Sử dụng hàm MessageBox

namespace QuanLiAnhVienAoCuoi.Class
{
    class Functions
    {
        public static SqlConnection Conn; //Khai báo đối tượng kết nối
        public static string connString; //Khai báo biến chứa chuỗi kết nối
        public static void Connect()
        {
            //Thiết lập giá trị cho chuỗi kết nối
            connString = "Data Source = localhost\\SQLEXPRESS; Initial Catalog = QuanLiAnhVienAoCuoi; Integrated Security = True";
            Conn = new SqlConnection(); //Cấp phát đối tượng
            Conn.ConnectionString = connString; //Kết nối
            Conn.Open(); //Mở kết nối
        }
        public static void Disconnect()
        {
            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close(); //Đóng kết nối
                Conn.Dispose(); //Giải phóng tài nguyên
                Conn = null;
            }
        }

        public static DataTable GetDataToTable(string sql)
        {
            SqlDataAdapter Mydata;
            Mydata = new SqlDataAdapter(sql, Conn);
            DataTable table = new DataTable();

            Mydata.Fill(table);
            return table;
        }

        public static string GetFieldValues(string sql)
        {
            string ma = "";
            SqlCommand cmd = new SqlCommand(sql, Functions.Conn);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ma = reader.GetValue(0).ToString();
            }
            reader.Close();
            return ma;
        
        }
    }
}
