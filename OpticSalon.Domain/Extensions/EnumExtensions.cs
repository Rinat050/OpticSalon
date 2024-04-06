using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace OpticSalon.Domain.Extensions
{
    public static class EnumExtensions
    {
        public static string? GetDisplayName(this Enum type)
        {
            return type.GetType().GetField(type.ToString())?.GetCustomAttribute<DisplayAttribute>()?.Name;
        }

        public static T GetValueFromName<T>(this string name) where T : Enum
        {
            var type = typeof(T);
            foreach (var field in type.GetFields())
            {
                if (Attribute.GetCustomAttribute(field, typeof(DisplayAttribute)) is DisplayAttribute attribute)
                {
                    if (attribute.Name == name)
                    {
                        return (T)field.GetValue(null);
                    }
                }
                if (field.Name == name)
                {
                    return (T)field.GetValue(null);
                }
            }
            throw new ArgumentOutOfRangeException(nameof(name));
        }
    }
}
