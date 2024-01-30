using System.Runtime.CompilerServices;

namespace P09.IOC_Container_DI_Using_Attribute.CustomAttributes
{

    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class AutowiredAttribute : Attribute
    {
        /// <summary>
        /// 接口
        /// </summary>
        public Type Iface { get; set; }
        /// <summary>
        /// 实现类名
        /// </summary>
        public string ImplClassName { get; set; }

        public AutowiredAttribute(Type iface, [CallerMemberName] string implClassName = "")
        {
            Iface = iface;
            ImplClassName = implClassName;
        }
    }
}
