using System;
namespace Lab2Maistrenko.Models
{
    public class Realtor
    {
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Surname { get; set; }
        public int RealtorId { get; set; }
        public int AgencyId { get; set; }
        public string PhoneNumber { get; set; }

        public override string ToString()
        {
            return ($"Name: {Name} {Patronymic} {Surname}, Phone Number: {PhoneNumber}");
        }
    }
}
