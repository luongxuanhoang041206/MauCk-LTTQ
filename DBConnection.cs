using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MauLTTQCK
{
    /// <summary>
    /// Lớp tiện ích kết nối CSDL dùng chung cho toàn ứng dụng.
    /// Sử dụng ADO.NET với SqlConnection + SqlDataAdapter / SqlCommand.
    /// </summary>
    internal static class DBConnection
    {
        // Lấy chuỗi kết nối từ App.config một lần duy nhất
        public static readonly string ConnectionString =
            ConfigurationManager.ConnectionStrings["QLNhanSu"].ConnectionString;

        /// <summary>Trả về DataTable từ câu lệnh SELECT (có thể kèm tham số).</summary>
        public static DataTable GetDataTable(string sql, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        /// <summary>Thực thi INSERT / UPDATE / DELETE, trả về số dòng bị ảnh hưởng.</summary>
        public static int ExecuteNonQuery(string sql, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
