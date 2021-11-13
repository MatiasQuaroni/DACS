using System;

namespace Server.Application.Services.DataTransfer
{
    public class LegData
    {
        public Guid Id { get; set; }
        public LocationData StartLocation { get; set; }
        public LocationData? EndLocation { get; set; }
    }
}
