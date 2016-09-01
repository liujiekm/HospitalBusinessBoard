//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & 上海研发中心
//===================================================================================
// 实体类基类
//
//
//===================================================================================
// .Net Framework 4.5
// CLR版本： 4.0.30319.42000
// 创建人：  Jay
// 创建时间：2016/6/16 14:10:37
// 版本号：  V1.0.0.0
//===================================================================================




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBB.DataContract
{
    public abstract class BaseEntity
    {

        /// <summary>
        /// 主键
        /// </summary>
        private Guid _id;
        public virtual Guid Id
        {
            get
            {
                return this._id;
            }
            protected set //不允许从外部修改
            {
                this._id = value;
            }
        }


        //有生命周期的实体id不为空、换言之值临时的无id
        public bool IsTransient()
        {
            return this.Id == Guid.Empty;
        }




        public void GenerateNewIdentity()
         { 
             if (IsTransient()) 
             { 
                 this.Id = IdentityGenerator.NewSequentialGuid(); 
             } 
                  
         } 
 

 

         public void ChangeCurrentIdentity(Guid identity)
         { 
             if(identity!=Guid.Empty) 
             { 
                 this.Id = identity; 
             } 
         } 





        #region override 一致性、相等性
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is BaseEntity))
            {
                return false;
            }

            var item = (BaseEntity)obj;

            return item.Id == this.Id;

        }


        private int? _requestedHashCode;

        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue)
                {
                    _requestedHashCode = this.Id.GetHashCode() ^ 31;
                }
                return _requestedHashCode.Value;
            }

            return base.GetHashCode();
        }

        #endregion





    }
}
