using System.ComponentModel.DataAnnotations;
using System.Reflection;

public static class EnumExtensions
{
    /// <summary>
    /// Allows to get the display name of an enum value using the DisplayName attribute.
    /// </summary>
    /// <param name="enumValue"></param>
    /// <returns></returns>
    public static string GetDisplayName(this Enum enumValue)
    {
        return enumValue.GetType()
                        .GetMember(enumValue.ToString())
                        .First()
                        .GetCustomAttribute<DisplayAttribute>()
                        ?.GetName() ?? enumValue.ToString();
    }
}