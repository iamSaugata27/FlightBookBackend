using AutoMapper;
using Dapper;
using FlightBook.Context;
using FlightBook.Data;
using FlightBook.DTOs;
using FlightBook.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBook.Services.FlightCreationService
{
    public class FlightServc : IFlightServc
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDBContext _dBContext;
        private readonly DapperContext _dapperContext;

        public FlightServc(IMapper mapper, ApplicationDBContext dBContext, DapperContext dapperContext)
        {
            _mapper = mapper;
            _dBContext = dBContext;
            _dapperContext = dapperContext;
        }
        public async Task<List<FlightOperatorDTO>> AddFlightDetails(FlightOperatorDTO operatorDetails)
        {
            // EF Approch
            //var operatorDetail = _mapper.Map<FlightOperator>(operatorDetails);
            //await _dBContext.Operators.AddAsync(operatorDetail);
            //await _dBContext.SaveChangesAsync();
            //var data= (_dBContext.Operators.Select(fl => _mapper.Map<FlightOperatorDTO>(fl))).ToList();
            //return data;

            // Dapper Approach
            var postquery = "INSERT into Operators (FlightId,Capacity,OperatorName,SourceCity,DestCity,StartTime,EndTime) values (@FlightId,@Capacity,@OperatorName,@SourceCity,@DestCity,@StartTime,@EndTime)";
            using var connection = _dapperContext.CreateConnection();
            await connection.ExecuteAsync(postquery, operatorDetails);
            var getquery = "SELECT * FROM Operators";
            var allFlights = await connection.QueryAsync<FlightOperator>(getquery);
            return (allFlights.Select(fl => _mapper.Map<FlightOperatorDTO>(fl))).ToList();
        }

        public async Task<List<FlightOperatorDTO>> GetFlightDetails()
        {
            // Dapper Approach
            var query = "SELECT * FROM Operators";
            using var connection = _dapperContext.CreateConnection();
            var allFlights = await connection.QueryAsync<FlightOperator>(query);
            return (allFlights.Select(fl => _mapper.Map<FlightOperatorDTO>(fl))).ToList();

            // EF Approch
            //var allFlights = await _dBContext.Operators.ToListAsync();
            //return (allFlights.Select(fl => _mapper.Map<FlightOperatorDTO>(fl))).ToList();
        }
        public async Task<List<FlightOperatorDTO>> GetFlights(SearchFlightDTO searchQuery)
        {
            // Dapper Approach
            var query = "SELECT * FROM Operators WHERE SourceCity=@Src AND DestCity=@Dest AND StartTime LIKE '@On%'";
            using var connection = _dapperContext.CreateConnection();
            //var getFlightAtGivenInstances = await connection.QueryAsync<FlightOperator>(query, new { searchQuery.Src, searchQuery.Dest, searchQuery.On.Date });

            // EF Approch
            var getFlightAtGivenInstances = await _dBContext.Operators
                .Where(fl => fl.SourceCity == searchQuery.Src)
                .Where(fl => fl.DestCity == searchQuery.Dest)
                .Where(fl => fl.StartTime.Date == searchQuery.On.Date).ToListAsync();
            return (getFlightAtGivenInstances.Select(fl => _mapper.Map<FlightOperatorDTO>(fl))).ToList();
        }
    }
}
