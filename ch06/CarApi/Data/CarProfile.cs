using AutoMapper;
using CarApi.Data.Entities;

namespace CarApi.Data
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<CarDto, Car>()
            .ForMember(car => car.Id, opt => opt.MapFrom(carDto => carDto.Id))
            .ForMember(car => car.name, opt => opt.MapFrom(carDto => carDto.Name))
            .ForMember(car => car.mpg, opt => opt.MapFrom(carDto => carDto.Mpg))
            .ForMember(car => car.cylinders, opt => opt.MapFrom(carDto => carDto.Cylinders))
            .ForMember(car => car.displacement, opt => opt.MapFrom(carDto => carDto.Displacement))
            .ForMember(car => car.horsepower, opt => opt.MapFrom(carDto => carDto.Horsepower))
            .ForMember(car => car.weight, opt => opt.MapFrom(carDto => carDto.Weight))
            .ForMember(car => car.acceleration, opt => opt.MapFrom(carDto => carDto.Acceleration))
            .ForMember(car => car.model_year, opt => opt.MapFrom(carDto => carDto.ModelYear))
            .ForMember(car => car.origin, opt => opt.MapFrom(carDto => carDto.Origin))
            .ReverseMap();
        }
    }
}
