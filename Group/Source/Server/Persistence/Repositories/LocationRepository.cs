using Server.Domain;

namespace Server.Persistence.Repositories
{
    public class LocationRepository : Repository<Location,RoadsDbContext>
    {
        public LocationRepository(RoadsDbContext pDbContext) : base(pDbContext)
        {

        }
    }
}
