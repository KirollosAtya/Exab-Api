

using System.Reflection;

namespace Exab.Test.Domain.Constants;
public static   class Permissions
{
   
        public const string Category_Read = "Category.Read";
        public const string Category_Create = "Category.Create";
        public const string Category_Update = "Category.Update";
        public const string Category_Delete = "Category.Delete";



    public static IList<string> GetAllPermissions() =>
        typeof(Permissions)
            .GetFields()
            .Select(field => (string)field.GetValue(field)!)
            .ToList();
}
