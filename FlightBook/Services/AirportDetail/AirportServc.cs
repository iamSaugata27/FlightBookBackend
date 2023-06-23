using AutoMapper;
using FlightBook.Data;
using FlightBook.DTOs;
using FlightBook.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightBook.Services.AirportDetail
{
    public class AirportServc : IAirportServc
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly IMapper _mapper;

        public AirportServc(ApplicationDBContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<AirportDetails> AddAirport(AirportDetailsDTO airport)
        {
            var addedAirport= await _dbContext.Airports.AddAsync(_mapper.Map<AirportDetails>(airport));
            await _dbContext.SaveChangesAsync();
            return addedAirport.Entity;
        }

        public async Task<List<AirportDetails>> GetAirports()
        {
            return await _dbContext.Airports.ToListAsync();
        }
    }
}
