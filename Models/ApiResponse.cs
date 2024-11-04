using Newtonsoft.Json;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json.Converters;
using FakeAPI.Models;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FakeAPI.Models
{ 
       public class ApiResponse
        {
            internal static class Converter
            {
                public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
                {
                    MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                    DateParseHandling = DateParseHandling.None,
                    Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
                };
            }

            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("title")]
            public string? Title { get; set; }

            [JsonProperty("price")]
            public long Price { get; set; }

            [JsonProperty("description")]
            public string? Description { get; set; }

            [JsonProperty("category")]
            public Category? Category { get; set; }

            [JsonProperty("images")]
            public Uri[] Images { get; set; } = null!;
        }

        public partial class Category
        {
            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("name")]
            public string? Name { get; set; }

            [JsonProperty("image")]
            public Uri Image { get; set; } = null!;
        }

        public static class Serialize
        {
            public static string ToJson(this Producto4[] self)
            {
                return JsonConvert.SerializeObject(self, ApiResponse.Converter.Settings);
            }
        }


        public partial class Producto4
        {
            public static Producto4[] FromJson(string json)
            {
                return JsonConvert.DeserializeObject<Producto4[]>(json, ApiResponse.Converter.Settings);
            }

       
    }

    }






