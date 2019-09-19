using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repository.Context;
using System;

namespace PadawanStore.Infra.Data.Seed.Migrations.Manager
{
    public static class MigrationManager
    {
        public static IWebHost MigrarDatabase(this IWebHost host)
        {
            using (var escopo = host.Services.CreateScope())
            {
                using (var dbContext = escopo.ServiceProvider.GetRequiredService<StoreContext>())
                {
                    try
                    {
                        dbContext.Database.Migrate();
                    }
                    catch (System.Exception ex)
                    {
                        Console.WriteLine("Algo de errado não está certo - MigrarDatabase Method" + ex.ToString());
                        throw;
                    }
                }
            }
            return host;
        }
    }
}
