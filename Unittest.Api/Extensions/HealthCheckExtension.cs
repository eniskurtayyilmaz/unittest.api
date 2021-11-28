using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json;

namespace Unittest.Api.Extensions
{
    public static class HealthCheckExtension
    {
        public static void ConfigureHealthCheck(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/health-check", new HealthCheckOptions
            {
                ResponseWriter = async (c, r) =>
                {
                    var result = JsonConvert.SerializeObject(new
                    {
                        status = r.Status.ToString(),
                        components = r.Entries.Select(e => new {key = e.Key, value = e.Value.Status.ToString()})
                    });
                    c.Response.StatusCode = r.Status == HealthStatus.Healthy
                        ? (int) HttpStatusCode.OK
                        : (int) HttpStatusCode.ServiceUnavailable;
                    c.Response.ContentType = "application/json";
                    await c.Response.WriteAsync(result);
                }
            });
        }
    }
}