using AutoMapper;
using CleanApi.Application.ViewModels;
using CleanApi.Domain.Entities.Product;

namespace CleanApi.Application.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProductViewModel,Product>();
        }
    }
}
