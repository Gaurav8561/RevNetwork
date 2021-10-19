namespace Utility
{
    public class ResxManager
    {
        private static global::System.Resources.ResourceManager resourceMan;

        //[global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]

        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        //[global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    //global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Resources.Resources", global::System.Reflection.Assembly.Load("App_GlobalResources"));
                    //resourceMan = temp;
                    resourceMan = new global::System.Resources.ResourceManager("Resources.Resources", global::System.Reflection.Assembly.Load("App_GlobalResources"));
                }
                return resourceMan;
            }
        }

        //private static readonly Func<string, string, string, string> FuncGetResxString = new Func<string, string, string, string>((strResourcesAsemblyName, strResourcesName, strResxKey) => (new global::System.Resources.ResourceManager(strResourcesName, global::System.Reflection.Assembly.Load(strResourcesAsemblyName))).GetString(strResxKey));

        //public static string GetResxString(string strResourcesAsemblyName, string strResourcesName, string strResxKey)
        //{
        //    return FuncGetResxString(strResourcesAsemblyName, strResourcesName, strResxKey);
        //}

        //public static string GetResxString(string strResourcesName, string strResxKey)
        //{
        //    return FuncGetResxString("App_GlobalResources", strResourcesName, strResxKey);
        //}

        //public static string GetResxString(string strResxKey)
        //{
        //    return FuncGetResxString("App_GlobalResources", "Resources.Resources", strResxKey);
        //}
    }
}
