using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace iSpan.Utility
{
	public class sqlParameterBuilder
	{

		//public SqlParameter Insert()
		//{
		//}
		private List<SqlParameter> parameters = new List<SqlParameter>();
		public sqlParameterBuilder AddNvarchar(string name, int length, string value)
		{
			SqlParameter param = new SqlParameter(name, SqlDbType.NVarChar, length) { Value = value};
			parameters.Add(param);
			return this;
		}
		public sqlParameterBuilder AddInt(string name, int value)
		{
			SqlParameter param = new SqlParameter(name, SqlDbType.Int) { Value = value };
			parameters.Add(param);
			return this;
		}
		public sqlParameterBuilder AddDateTime(string name, string value)
		{
			SqlParameter param = new SqlParameter(name, SqlDbType.DateTime) { Value = Convert.ToDateTime(value)};
			parameters.Add(param);
			return this;
		}
		public SqlParameter[] Build()
		{
			return parameters.ToArray();
		}
	}
}
