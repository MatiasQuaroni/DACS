using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
