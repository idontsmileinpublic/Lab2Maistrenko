using System;
namespace Lab2Maistrenko.Models
{
    public class Address
    {
        public string AddressName { get; set; }
        public int AddressId { get; set; }
        public int DistrictId { get; set; }

        public override string ToString()
        {
            return ($"Address: {AddressName}");
        }
    }
}
