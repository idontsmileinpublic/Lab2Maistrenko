using System;
namespace Lab2Maistrenko.Models
{
    public class District
    {
        public int DistrictId { get; set; }
        public string NameDistrict { get; set; }

        public override string ToString()
        {
            return ($"District: {NameDistrict}");
        }
    }
}
