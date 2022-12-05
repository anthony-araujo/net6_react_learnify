using Entity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Infraestructure
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context)
        {
			try
			{
				if (!context.Courses.Any())
				{
					var courseData = File.ReadAllText("../Infraestructure/SeedData/courses.json");
					var courses = JsonSerializer.Deserialize<List<Course>>(courseData);
					foreach (var item in courses)
					{
						context.Courses.Add(item);
					}
					await context.SaveChangesAsync();
				}
			}
			catch (Exception ex)
			{
				//logger.LogError(ex.Message);
			}

        }
    }
}
