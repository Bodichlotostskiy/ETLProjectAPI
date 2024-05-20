using System.Reflection;

namespace ETLProjectAPI.Infrastructure.Extensions
{
    public class StringExtension
    {
        public static void  TrimStrings(object obj)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (property.PropertyType == typeof(string))
                {
                    string value = (string)property.GetValue(obj);
                    if (value != null)
                    {
                        string trimmedValue = value.Trim();
                        property.SetValue(obj, trimmedValue);
                    }
                }
            }
        }
    }
}
