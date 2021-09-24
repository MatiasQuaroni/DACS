using System;

public class Location
{
    public Guid Id { get; set; }
    public string Coordinates{ get; set; }
    public int PostalCode { get; set; }
    public string Address { get; set; }
    public string Floor { get; set; }
    public string Number { get; set; }
    public LocationType Type { get; set; }
    public enum LocationType 
    {warehouse=0,
    mailOffice=1,
    endPoint=2}
}
