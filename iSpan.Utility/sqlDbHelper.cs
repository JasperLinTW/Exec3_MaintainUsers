using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSpan.Utility
{
	public class sqlDbHelper
	{
		private string connString;
		public sqlDbHelper(string keyOfConnString)
		{
			connString = System.Configuration.ConfigurationManager.ConnectionStrings[keyOfConnString].ConnectionString;
		}
		public void ExcuteNonQuery(string sql, SqlParameter[] parameters)
		{
			using(var conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand(sql, conn);
				conn.Open();
				cmd.Parameters.AddRange(parameters);
				cmd.ExecuteNonQuery();
			}			
		}
		public void Insert(string sql, SqlParameter[] parameters)
		{
            try
            {                
                ExcuteNonQuery(sql, parameters);
                Console.WriteLine("已紀錄資料");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void Update(string sql, SqlParameter[] parameters)
        {
            try
            {         
                ExcuteNonQuery(sql, parameters);
                Console.WriteLine("已更新資料");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void Delete(string sql, SqlParameter[] parameters)
        {
            try
            {
                ExcuteNonQuery(sql, parameters);
                Console.WriteLine("已刪除資料");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public DataTable Select(string sql, SqlParameter[] parameters)
        {
            using (var conn = new SqlConnection(connString))
            {
                var command = new SqlCommand(sql, conn);
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet dataset = new DataSet();

                adapter.Fill(dataset, "Genshin");
                return dataset.Tables["Genshin"];

            }
        }




    }
}
