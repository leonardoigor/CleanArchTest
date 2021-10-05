using AutoMapper;
using CleanApi.Application.ViewModels;
using CleanApi.Domain.Entities.Product;

namespace CleanApi.Application.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Product, ProductViewModel>();
        }
    }
}
