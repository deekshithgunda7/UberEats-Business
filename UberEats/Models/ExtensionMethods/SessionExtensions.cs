using Azure.Core.GeoJson;
using System.Runtime.Intrinsics.X86;
using System.Text.Json;
using System;
using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;

namespace UberEats.Models
{


    public static class SessionExtensions
    {
        public static void SetObject<T>(this ISession session, string key, T value)
        {
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                MaxDepth = 256 // Adjust the depth value as needed
            };

            session.SetString(key, JsonSerializer.Serialize(value, options));
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
    }
   }
    