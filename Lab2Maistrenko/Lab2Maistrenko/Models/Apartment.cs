using System;
using System.Xml.Serialization;

namespace Lab2Maistrenko.Models
{
    
    public class Apartment
    {
        public int ApartmentId { get; set; }
        public int AddressId { get; set; }
        public double Area { get; set; }
        public decimal Price { get; set; }
        public int Flat { get; set; }

        public override string ToString()
        {
            return ($"Flat: {Flat}, Area: {Area}, Price: {Price}");
        }
    }
}
