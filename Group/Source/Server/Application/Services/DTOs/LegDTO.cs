using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Application.Services.DTOs
{
    public class LegDTO
    {
        public Guid Id { get; set; }
        public LocationDTO StartLocation { get; set; }
        public LocationDTO EndLocation { get; set; }
    }
}
