using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace E25ProjetEtendu.Extensions
{
    public static class CookieExtensions
    {
        public static void SetObject(this IResponseCookies cookies, string key, object value, int days = 7)
        {
            var options = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(days),
                HttpOnly = true, // empêche accès JS
                Secure = false   // true si HTTPS
            };

            var json = JsonSerializer.Serialize(value);
            cookies.Append(key, json, options);
        }

        public static T GetObject<T>(this IRequestCookieCollection cookies, string key)
        {
            var value = cookies[key];
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
    }
}
