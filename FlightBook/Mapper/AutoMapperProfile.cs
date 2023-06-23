using AutoMapper;
using FlightBook.DTOs;
using FlightBook.Models;

namespace FlightBook.Mapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<FlightOperatorDTO, FlightOperator>().ReverseMap();
            CreateMap<AirportDetailsDTO, AirportDetails>().ReverseMap();
            CreateMap<PassengerDTO, Passengers>().ReverseMap();
        }
    }
}
