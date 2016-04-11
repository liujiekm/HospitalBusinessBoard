//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & Net 开发组
//=================================================================================== 
// ASP.NET WEB API Model Binder 
// 对Array类型的参数进行绑定
// 
//===================================================================================
// .Net Framework 4.5
// CLR版本： 4.0.30319.42000
// 创建人：  liu
// 创建时间：2016/4/11 9:44:22
// 版本号：  V1.0.0.0
//===================================================================================

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;

namespace HBB.API.ModelBinder
{
    public class ArrayModelBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            var key = bindingContext.ModelName;
            var val = bindingContext.ValueProvider.GetValue(key);

            if(val !=null)
            {
                var actualValue = val.AttemptedValue;
                if(actualValue!=null)
                {
                    var elementType = bindingContext.ModelType.GetElementType();
                    var converter = TypeDescriptor.GetConverter(elementType);


                    //转换字符串为数组
                    var values = Array.ConvertAll(actualValue.Split(new[] {","},StringSplitOptions.RemoveEmptyEntries),
                        x=> { return converter.ConvertFromString(x != null ? x.Trim() : x); });

                    var typedValues = Array.CreateInstance(elementType, values.Length);

                    values.CopyTo(typedValues, 0);

                    bindingContext.Model = typedValues;
                }
                else
                {
                    //返回空数组
                    bindingContext.Model = Array.CreateInstance(bindingContext.ModelType.GetElementType(), 0);
                }
                return true;
            }

            return false;
        }
    }
}