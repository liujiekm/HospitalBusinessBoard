using System;
using System.Configuration;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WYYY.HDGM.DataContext.Test
{
    [TestClass]
    public class OracleDataAccessFixture
    {
        private IConfigurationSource configurationSource;

        //生成配置文件
        [TestInitialize]
        public void SetUp()
        {
            configurationSource = TestConfigurationSource.GenerateConfiguration();
        }


        //样例数据库代码
        [TestMethod]
        public void Test1()
        {
            ConnectionStringSettings data = GetConnectionString("DbWithOracleAuth");
            OracleDatabase db = new OracleDatabase(data.ConnectionString);

            using (DbConnection dbConnection = db.CreateConnection())
            {
                dbConnection.Open();
                DbCommand command = db.GetSqlStringCommand("");
                using (DbTransaction trans = dbConnection.BeginTransaction())
                {
                    db.ExecuteNonQuery(command, trans);
                    
                }
            }
           
        }



        //根据名称获取连接字符串
        private ConnectionStringSettings GetConnectionString(string name)
        {
            return
                ((ConnectionStringsSection) this.configurationSource.GetSection("connectionString")).ConnectionStrings[
                    name];
        }
    }
}
