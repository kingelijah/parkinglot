using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ParkingLot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingLot.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ParkingContext _context;


        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ParkingContext context)
        {
            _logger = logger;
            _context = context;

        }

        [HttpPost]
        public double GetTicket(Request request)
        {
            try
            {
                double result = 0;

                TimeSpan ns = (Convert.ToDateTime(request.Exit) - Convert.ToDateTime(request.Entry));

                double calc1 = Convert.ToDouble(ns.TotalHours);
                int calc2 = (int)Math.Round(calc1 + 0.5);

                if (calc2 > 1)
                {
                    int mult = calc2 - 1;

                    result = _context.parkingRules.FirstOrDefault(ptc => ptc.Id == 1).Amount + _context.parkingRules.FirstOrDefault(ptc => ptc.Id == 2).Amount + (mult * _context.parkingRules.FirstOrDefault(ptc => ptc.Id == 3).Amount);
                }

                else
                {
                    result = 2;
                }

                var ticket = new ParkingTicket() { Name = "Elijah", AmountToPay = result, EntryTime = request.Entry, ExitTime = request.Exit, Date = DateTime.Now };

                _context.parkingTicket.Add(ticket);
                _context.SaveChanges();
                

                return result;
            }
            catch(Exception ex)
            {
                return 0;
            }
           
        }
    }
}
