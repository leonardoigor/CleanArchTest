using CleanApi.Application.Mappings;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CleanApi.MappingConfig
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection service)
        {

            if (service == null) throw new ArgumentException(nameof(service));


            service.AddAutoMapper(
                typeof(DomainToViewModelMappingProfile),
                typeof(ViewModelToDomainMappingProfile)
                );
        }
    }
}
