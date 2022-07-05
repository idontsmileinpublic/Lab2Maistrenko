using System;
using System.Collections.Generic;

namespace Lab2Maistrenko.Models
{
    public class Data
    {
        public static List<Address> Addresses = new List<Address>
        {
            new Address
            {
                AddressId = 1,
                DistrictId = 1,
                AddressName = "Bulhakova, 12"
            }
        };
        public static List<Agency> Agencies = new List<Agency>
        {
            new Agency
            {
                Name = "FlatFy",
                AddressId = 1,
                AgencyId = 1
            },

            new Agency
            {
                Name = "DomRia",
                AddressId = 1,
                AgencyId = 2
            }
        };
        public static List<Apartment> Apartments = new List<Apartment>
        {
            new Apartment
            {
                ApartmentId = 1,
                AddressId = 1,
                Area = 50,
                Price = 10500,
                Flat = 4
            },

            new Apartment
            {
                ApartmentId = 2,
                AddressId = 1,
                Area = 70,
                Price = 11500,
                Flat = 3
            },

            new Apartment
            {
                ApartmentId = 3,
                AddressId = 1,
                Area = 20,
                Price = 9500,
                Flat = 2
            }
        };
        public static List<District> Districts = new List<District>
        {
            new District()
            {
                DistrictId = 1,
                NameDistrict = "Shevchenkovskyi"
            }
        };
        public static List<Realtor> Realtors = new List<Realtor>
        {
            new Realtor()
            {
                Name = "Ivanna",
                Patronymic = "Boryslavivna",
                Surname = "Shevchenko",
                RealtorId = 1,
                AgencyId = 1,
                PhoneNumber = "380990339719"
            },

            new Realtor() {
                Name = "Mariia",
                Patronymic = "Oleksandrivna",
                Surname = "Khvostova",
                RealtorId = 2,
                AgencyId = 1,
                PhoneNumber = "38077839023"
            },

            new Realtor()
            {
                Name = "Viacheslav",
                Patronymic = "Mstyslavovych",
                Surname = "Lubianets",
                RealtorId = 3,
                AgencyId = 2,
                PhoneNumber = "3809902295671"
            }
        };
        public static List<ApartmentRealtor> ApartmentRealtors = new List<ApartmentRealtor>
        {
            new ApartmentRealtor
            {
                ApartmentId = 1,
                RealtorId = 1,
                ApartmentRealtorId = 1,
                OverPrice = 400
            }
        };
    }
}
