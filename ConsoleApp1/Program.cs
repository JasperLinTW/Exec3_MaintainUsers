using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using iSpan.Utility;

namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string insertSql = @"INSERT into Users(Name, Account, Password, DateOfBirthd, Height) 
Values(@Name, @Account,@password,@DateOfBirthd,@Height) ";

            string updateSql = @"UPDATE Users SET Name=@Name, Account=@Account ,
Password=@password , DateOfBirthd=@DateOfBirthd , Height =@Height where id = @id";

            string deleteSql = @"DELETE FROM Users WHERE id = @id ";

            string selectSql = @"SELECT Id, Name, Account, Password, DateOfBirthd, Height FROM Users";

            //SqlParameter[] parameters = new sqlParameterBuilder()
            //.AddNvarchar("Name",50,"t4")
            //.AddNvarchar("Account", 50,"t4account")
            //.AddInt("Password", 123)
            //.AddDateTime("DateOfBirthd", "2022/8/7")
            //.AddInt("Height",111)
            //.AddInt("id",4)
            //.Build();
            var dbHelper = new sqlDbHelper("default");
            //dbHelper.Update(updateSql, parameters);

            #region 使用select時
            try
            {
                var parameters = new sqlParameterBuilder().AddInt("id", 0).Build();
                DataTable news = dbHelper.Select(selectSql, parameters);
                foreach (DataRow row in news.Rows)
                {
                    int id = row.Field<int>("Id");
                    string name = row.Field<string>("name");
                    Console.WriteLine($"Id={id}, Name={name}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"連線失敗, 原因 :{ex.Message}");
            }
            #endregion

        }
    }
}
