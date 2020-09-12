using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Skinet.Core.Interfaces;
using Skinet.Infrastructure.Data;
using Skinet.Infrastructure.Data.ConcreteRepository;
using skinetAPI.Errors;

namespace skinetAPI.Extensions
{
    // make the class a static one then cut out application related services to this
    public static class ApplicationServiceExtensions
    {
        //extending the IServiceCollection class in the startup how? with the this KEYWORD  
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //AddScoped specified the life time of our service.ASide that, we also have Transient and Singleton

            services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.Configure<ApiBehaviorOptions>(Options =>
            {
                Options.InvalidModelStateResponseFactory = actioncontext =>
                {
                    var errors = actioncontext.ModelState.Where(e => e.Value.Errors.Count > 0).SelectMany(x => x.Value.Errors).Select(x => x.ErrorMessage).ToArray();

                    var errorResponse = new ApiValidationErrorResponse
                    {
                        Errors = errors
                    };
                    return new BadRequestObjectResult(errorResponse);
                };
            });

            return services;
        }
    }
}