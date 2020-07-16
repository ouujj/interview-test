using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class SeedDataChart
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApiModelsContext(
                serviceProvider.GetRequiredService<
                 DbContextOptions<ApiModelsContext>>()))
            {
                if (context.charts.Any())
                {
                    return;   // DB has been seeded
                }
                context.charts.AddRange(
                    new chart
                    {
                        intent = "reset",
                        subintent = "ad",
                        point = 10
                    },
                    new chart
                    {
                        intent = "change",
                        subintent = "ad",
                        point = 5
                    },
                    new chart
                    {
                        intent = "unlock",
                        subintent = "ad",
                        point = 6
                    },
                    new chart
                    {
                        intent = "Reset",
                        subintent = "sap",
                        point = 7
                    },
                    new chart
                    {
                        intent = "Change",
                        subintent = "sap",
                        point = 8
                    },
                    new chart
                    {
                        intent = "unlock",
                        subintent = "sap",
                        point = 9
                    }
                );
                context.SaveChanges();
            }

        }

    }
}
