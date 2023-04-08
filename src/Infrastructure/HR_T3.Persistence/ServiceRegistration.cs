using HR_T3.Application.Mapping;
using HR_T3.Context.Persistence;
using HR_T3.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HR_T3.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection serviceCollection, IConfiguration configuration = null)
        {
            serviceCollection.AddScoped<PersonRepository>();
            var connectionString = configuration.GetConnectionString("AppDbContextConnection") ?? throw new InvalidOperationException("Connection string 'AppDbContextConnection' not found.");
            serviceCollection.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

            //serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
            serviceCollection.AddAutoMapper(x => x.AddProfile(new GeneralMapping()));
        }

    }
}