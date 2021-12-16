using Server.Domain;

namespace Server.Persistence.Repositories
{
    public class CustomerInfoRepository : Repository<CustomerInfo,RoadsDbContext>
    {
        public CustomerInfoRepository(RoadsDbContext pDbContext) : base(pDbContext)
        {

        }
    }
}
