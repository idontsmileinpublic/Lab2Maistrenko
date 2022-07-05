using System;
namespace Lab2Maistrenko.Models
{
    public class Agency
    {
        public string Name { get; set; }
        public int AgencyId { get; set; }
        public int AddressId { get; set; }

        public override string ToString()
        {
            return ($"{Name}");
        }

    }
}
