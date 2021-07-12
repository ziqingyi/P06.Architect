using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Text;
using P02.ORMExplore.Framework.Validation;

namespace P02.ORMExplore.Framework.SqlMapping
{
    public static class MappingExtend
    {
        /*   member info can be type or property
         *
         * abstract class: Type : MemberInfo, IReflect
         *
         * abstract class: PropertyInfo : MemberInfo
         */
        public static string GetMappingNameFromAttr(this MemberInfo memberInfo)
        {
            if (memberInfo.IsDefined(typeof(ORMAbstractMappingAttribute), true))
            {
                var attribute = memberInfo.GetCustomAttribute<ORMAbstractMappingAttribute>();

                return attribute.GetMappingName();
            }
            else
            {
                return memberInfo.Name;
            }
        }

        public static string GetTableNameFromAttr(this Type type)
        {
            if (type.IsDefined(typeof(ORMdbTableAttribute), true))
            {
                ORMdbTableAttribute attribute = type.GetCustomAttribute<ORMdbTableAttribute>();
                return attribute.GetMappingName();
            }
            else
            {
                return type.Name;
            }
        }

        public static string GetColumnNameFromAttr(this PropertyInfo prop)
        {
            if (prop.IsDefined(typeof(ORMdbColumnAttribute), true))
            {
                ORMdbColumnAttribute attribute = prop.GetCustomAttribute<ORMdbColumnAttribute>();
                return attribute.GetMappingName();
            }
            else
            {
                return prop.Name;
            }

        }

        #region old Extension for PropertyInfo

        //1 use this method to display more user friendly property's name.
        public static string GetPropertyMappingNameOld(this PropertyInfo property)
        {
            //method 1, without delegate
            //if(property.IsDefined(typeof(ORMAbstractMappingAttribute), true))
            //{
            //    ORMAbstractMappingAttribute attribute =
            //        (ORMAbstractMappingAttribute) property.GetCustomAttribute(typeof(ORMAbstractMappingAttribute), true);
            //    return attribute.GetMappingName();
            //}
            //else
            //{
            //    // if not define this attribute,just show property's name
            //    return property.Name;
            //}
            // method 2, use with delegate
            Func<PropertyInfo, bool> funcParam1 = p => p.IsDefined(typeof(ORMAbstractMappingAttribute), true);
            Func<PropertyInfo, string> funcParam2 = p =>
            {
                ORMAbstractMappingAttribute attribute = (ORMAbstractMappingAttribute)p.GetCustomAttribute(typeof(ORMAbstractMappingAttribute), true);
                return attribute.GetMappingName();
            };

            return property.GetAttributeName(funcParam1, funcParam2);

        }
        ///2 get the db column name of property through its' attribute.
        /// note: this is used for the instance of PropertyInfo,
        /// this means you can get them by Type type = typeof(T); without creating a T object.
        public static string GetColumnNameOld(this PropertyInfo property)
        {
            if (property.IsDefined(typeof(ORMdbColumnAttribute), true))
            {
                ORMdbColumnAttribute attribute =
                (ORMdbColumnAttribute)property.GetCustomAttribute(typeof(ORMdbColumnAttribute), true);
                return attribute.GetMappingName();// no format
            }
            else
            {
                return property.Name;
            }
        }
        /// <summary>
        ///  3 combine 1 and 2 to get property's attribute's information. inside the attribute obj,
        ///     you can get string used for mark column name or some other information.
        ///     need to use delegate
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        private static string GetAttributeName(this PropertyInfo property, Func<PropertyInfo, bool> func, Func<PropertyInfo, string> funcString)
        {
            if (func.Invoke(property))
            {
                return funcString.Invoke(property);
            }
            else
            {
                return property.Name;
            }
        }

        //---------------------------------for Instance mapping to class------------------------------------------------

        // can not limit the T because this will not allow MySqlBuilder's type to get this mapping
        public static string ClassMapping<T>(this T t) //where T:BaseModel
        {
            Type type = t.GetType();
            if (type.IsDefined(typeof(ORMdbTableAttribute), true))
            {
                ORMdbTableAttribute att = (ORMdbTableAttribute)type.GetCustomAttribute(typeof(ORMdbTableAttribute), true);
                return att.GetMappingName();
            }
            else
            {
                return type.Name;
            }
        }

        //-----------------------------validate -----------------------------------------------


        public static ValidateErrorModel ValidateAll<T>(this T t)
        {
            Type type = t.GetType();
            foreach (var prop in type.GetProperties())
            {
                if (prop.IsDefined(typeof(AbstractValidateAttribute), true))
                {
                    object oValue = prop.GetValue(t);
                    foreach (AbstractValidateAttribute att in prop.GetCustomAttributes(typeof(AbstractValidateAttribute), true))
                    {
                        var result = att.Validate(oValue);
                        if (!result.Result)
                            return result;
                    }
                }
            }
            return new ValidateErrorModel() { Result = true, Message = "Success" };
        }
        public static List<ValidateErrorModel> ValidateAllResults<T>(this T t)
        {
            List<ValidateErrorModel> validates = new List<ValidateErrorModel>();
            Type type = t.GetType();
            foreach (var prop in type.GetProperties())
            {
                if (prop.IsDefined(typeof(AbstractValidateAttribute), true))
                {
                    object oValue = prop.GetValue(t);
                    foreach (AbstractValidateAttribute att in prop.GetCustomAttributes(typeof(AbstractValidateAttribute), true))
                    {
                        var result = att.Validate(oValue);
                        validates.Add(result);
                    }
                }
            }
            return validates;
            //validates.Where(m => !m.Result);//return the model which validate is false 
        }

        #endregion




    }
}
