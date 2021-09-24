using System;


namespace Server
{
    public class Location
    {
        private int id;
        private string coordinates;
        public int PostalCode { get; set; }
        public string Address { get; set; }
        public string Floor { get; set; }
        public string Number { get; set; }
        public LocationType Type { get; set; }

    }
}

