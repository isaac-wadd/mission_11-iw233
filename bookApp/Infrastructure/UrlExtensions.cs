
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace bookApp.Infrastructure {
    public static class UrlExtensions {
        public static string PathAndQuery(this HttpRequest req) =>
            req.QueryString.HasValue ? $"{req.Path}{req.QueryString}" : req.Path.ToString();
    }
}
