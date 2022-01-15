using Microsoft.EntityFrameworkCore;
using ParkingLot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class ParkingContext : DbContext
    {
        public ParkingContext(DbContextOptions<ParkingContext> options)
          : base(options)
        { 

        }

        public DbSet<ParkingRules> parkingRules { get; set; }
        public DbSet<ParkingTicket> parkingTicket { get; set; }
    }

}
