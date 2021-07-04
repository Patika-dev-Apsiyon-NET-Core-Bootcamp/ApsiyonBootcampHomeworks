using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CookieAndSession.Extensions
{
    public static class CookieSessionExtension
    {
        public static void SetSessionType<T>(this ISession session, string key, T type)
        {
            var serializedData = JsonSerializer.Serialize(type);
            session.SetString(key, serializedData);
        }

        public static T GetSessionType<T>(this ISession session, string key)
        {
            var dataWithSession = session.GetString(key);
            var desializedData = JsonSerializer.Deserialize<T>(dataWithSession);
            if (desializedData!=null)
            {
                return desializedData;
            }
            return default;
        }

    }
}
