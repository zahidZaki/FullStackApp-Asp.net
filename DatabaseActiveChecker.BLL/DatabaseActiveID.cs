using System.Data;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
namespace DatabaseActiveChecker.BLL
{


    
        public class DatabaseActiveID
        {
            readonly private IConfiguration _configuration;
            private readonly string _signalRHubUrl;
            private readonly string _connectionString;
            public DatabaseActiveID(IConfiguration configuration)
            {
                _configuration = configuration;
                _connectionString = _configuration.GetConnectionString("DefaultConnection");
                _signalRHubUrl = _configuration["HubUrl"];

            }

            public async Task UpdateSystemOutages()
            {
                try
                {
                    using (SqlConnection con = new(_connectionString))
                    {
                        SqlCommand cmd = new("usp_SystemOutageActiveStatus", con);
                        cmd.CommandType = CommandType.StoredProcedure;

                        await con.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                    }
                    await Task.Run(() => NotifyClientsAsync());
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            public async Task NotifyClientsAsync()
            {
                try
                {
                    var connection = new HubConnectionBuilder()
                   .WithUrl(_signalRHubUrl).Build();

                    await connection.StartAsync();
                    Console.WriteLine("started.");
                    await connection.InvokeAsync("SystemOutageActiveStatus");
                    Console.WriteLine("after SystemOutageActiveStatus call this.");
                    await connection.StopAsync();
                    await connection.DisposeAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"SignalR Notification Failed: {ex.Message}");
                }
            }

        }
    }


