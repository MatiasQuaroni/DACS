using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Domain;

namespace Server.Persistence.Repositories
{
    public class ItineraryRepository : Repository<Itinerary, RoadsDbContext>
    {
        public ItineraryRepository(RoadsDbContext pDbContext) : base(pDbContext)
        {

        }
    }
}
