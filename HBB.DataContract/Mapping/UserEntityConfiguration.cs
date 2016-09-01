//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & 上海研发中心
//===================================================================================
// User实体数据库配置映射
//
//
//===================================================================================
// .Net Framework 4.5
// CLR版本： 4.0.30319.42000
// 创建人：  Jay
// 创建时间：2016/6/17 10:37:10
// 版本号：  V1.0.0.0
//===================================================================================




using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBB.DataContract.Mapping
{
    public class UserEntityConfiguration: EntityTypeConfiguration<User>
    {
        public UserEntityConfiguration()
        {

            HasKey<Guid>(p => p.Id);
            Property(p => p.Id).HasColumnName("U_Id");
            Property(p => p.Account).HasColumnName("U_Account").HasMaxLength(50).IsRequired();
            Property(p => p.Password).HasColumnName("U_Password").HasMaxLength(50).IsRequired();
            Property(p => p.Name).HasColumnName("U_Name").HasMaxLength(50).IsRequired();


            this.HasMany(p => p.Roles).WithMany(p => p.Users).Map(m => {
                m.ToTable("HBB_UserRole");
                m.MapLeftKey("U_Id");
                m.MapRightKey("R_Id");
            });


            this.HasMany(p => p.Configurations).WithOptional(p => p.User).HasForeignKey(p => p.User);


            ToTable("HBB_User");


        }
    }
}
