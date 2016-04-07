//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & Net 开发组
//=================================================================================== 
// 动态生成配置文件
// Data Access Application Block
// 
//===================================================================================
// .Net Framework 4.5
// CLR版本： 4.0.30319.42000
// 创建人：  liu
// 创建时间：2016/4/6 16:19:01
// 版本号：  V1.0.0.0
//===================================================================================

using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data.Configuration;
using Oracle.DataAccess.Client;
using HBB.DataContext.Configuration;

namespace HBB.DataContext
{
    public class ConfigurationSource
    {
        public static DictionaryConfigurationSource GenerateConfiguration()
        {
            DictionaryConfigurationSource source = new DictionaryConfigurationSource();
            source.Add(DatabaseSettings.SectionName, GenerateDatabaseSettings());
            source.Add(OracleConnectionSettings.SectionName, GenerateOracleConnectionSettings());
            source.Add("connectionStrings", GenerateConnectionStringSection());
            return source;
        }

        private static DatabaseSettings GenerateDatabaseSettings()
        {
            DatabaseSettings settings = new DatabaseSettings();
            settings.DefaultDatabase = "Service_Dflt";
            settings.ProviderMappings.Add(new DbProviderMapping("Oracle.DataAccess.Client", "HBB.DataContext.OracleDatabase, HBB.DataContext, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"));
            return settings;
        }

        private static OracleConnectionSettings GenerateOracleConnectionSettings()
        {
            OracleConnectionSettings settings = new OracleConnectionSettings();
            OracleConnectionData data = new OracleConnectionData();
            data.Name = "Service_Dflt";
            data.Packages.Add(new OraclePackageData("PKGNORTHWIND", "NWND_"));
            data.Packages.Add(new OraclePackageData("PKGENTLIB", "RegionSelect"));
            settings.OracleConnectionsData.Add(data);
            return settings;
        }

        private static ConnectionStringsSection GenerateConnectionStringSection()
        {
            ConnectionStringsSection section = new ConnectionStringsSection();
            section.ConnectionStrings.Add(new ConnectionStringSettings("Service_Dflt", "Data Source=ORACLE82;User id=system;Password=aaaabbbccc;", "Oracle.DataAccess.Client"));
            section.ConnectionStrings.Add(new ConnectionStringSettings("NewDatabase", "Data Source=XE;User id=system;Password=admin;", "Oracle.DataAccess.Client"));
            section.ConnectionStrings.Add(new ConnectionStringSettings("DbWithOracleAuthn", "Data Source=XE;User id=system;Password=admin;", "Oracle.DataAccess.Client"));
            section.ConnectionStrings.Add(new ConnectionStringSettings("NwindPersistFalse", "Data Source=XE;User id=system;Password=admin;Persist Security Info=false;", "Oracle.DataAccess.Client"));
            return section;
        }
    }
}