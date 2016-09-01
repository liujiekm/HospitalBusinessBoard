//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & 上海研发中心
//===================================================================================
// 本地数据库
//
//
//===================================================================================
// .Net Framework 4.5
// CLR版本： 4.0.30319.42000
// 创建人：  Jay
// 创建时间：2016/6/17 15:09:22
// 版本号：  V1.0.0.0
//===================================================================================




using HBB.DataContract.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBB.DataContract
{
    public class HBBContext:DbContext
    {
        public HBBContext():base("name=HBBEntites")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new UserEntityConfiguration());


        }



        /// <summary>
        /// 用户
        /// </summary>
        private IDbSet<User> _users; 
         public IDbSet<User> Users 
         { 
             get 
             { 
                 if(this._users == null) 
                 { 
                     this._users = base.Set<User>(); 
                      
                 } 
                 return this._users; 
             } 
         } 

    }
}
