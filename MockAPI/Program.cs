﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Net;

namespace SimpleMockApi
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .ConfigureServices(services =>
                {
                    services.AddRouting();
                })
                .Configure(app =>
                {
                    app.UseRouting();

                    app.UseEndpoints(endpoints =>
                    {
                        endpoints.MapGet("/api/data", async context =>
                        {
                            var data = new List<Item>
                            {
                                new Item { Id = 1, Name = "Item 1" },
                                new Item { Id = 2, Name = "Item 2" },
                                new Item { Id = 3, Name = "Item 3" }
                            };

                            var jsonData = JsonConvert.SerializeObject(data);
                            context.Response.StatusCode = (int)HttpStatusCode.OK;
                            context.Response.ContentType = "application/json";
                            await context.Response.WriteAsync(jsonData);
                        });
                    });
                })
                .Build();

            await host.RunAsync();
        }
    }
}
