using System;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;

namespace Lab2Maistrenko.Helpers
{
    public class Printers
    {
        public static void PrintAddresses()
        {
            Console.WriteLine("1. Print all adresses");
            var result = Queries.NameAddress();
            foreach (var e in result)
            {
                Console.WriteLine($"Address: {e}");
            }
            Console.WriteLine();

        }

        public static void PrintAllDistricts()
        {
            Console.WriteLine("2. Print districts ");
            IEnumerable<XElement> elements = Queries.GetAll();
            foreach (XElement el in elements)
            {
                Console.WriteLine($"Name: {el.Element("name").Value} district");
            }
            Console.WriteLine();
        }

        public static void PrintRealtorsAgencies()
        {
            Console.WriteLine("3. Print realtor and his/her workplace, and phone number: ");
            IEnumerable<XElement> elements = Queries.AllRealtors();
            foreach(XElement el in elements)
            {
                Console.WriteLine($"Name: { el.Element("Name").Value}; Agency: {el.Element("agency").Value}; Phone Number: {el.Element("PhoneNumber").Value}");
            }
            Console.WriteLine();
        }


        public static void PrintRealtorsByAgencies()
        {
            Console.WriteLine("4. Print grouped realtors by agencies: ");
            var elements = Queries.GroupRealtorsByAgency();
            foreach (var el in elements)
            {
                Console.WriteLine($"Аgency: { el.Agency}");
                foreach (var b in el.Realtor)
                {
                    Console.WriteLine($"Realtor: {b}");
                }
            }
            Console.WriteLine();
        }

        public static void PrintApartmentsToRent()
        {
            Console.WriteLine("5. Print full apartment's information: ");
            IEnumerable<XElement> elements = Queries.ApartmentsToRent();
            foreach (XElement x in elements)
            {
                Console.WriteLine($"Address:  {x.Element("Address").Value} Flat: {x.Element("Flat").Value} Area: {x.Element("Area").Value} Price: {x.Element("Price").Value}");
            }
            Console.WriteLine();
        }

        public static void PrintAgenciesStartWith()
        {
            Console.WriteLine("6. Print agencies start with letter 'F': ");
            IEnumerable<XElement> elements = Queries.AllAgenciesStartWith();
            foreach (XElement x in elements)
            {
                Console.WriteLine($"Agency: {x.Element("Agency").Value}");
            }
            Console.WriteLine();
        }

        public static void PrintGroupedApartments()
        {
            Console.WriteLine("7. Print apartments, groupeb by district: ");
            IEnumerable<XElement> elements = Queries.GroupByDistrict();
            foreach (XElement x in elements)
            {
                Console.WriteLine($"District: {x.Element("Key").Value}, addresses: {x.Element("Value").Value} ");
            }
            Console.WriteLine();
        }

        public static void PrintGroupByPrice()
        {
            Console.WriteLine("8. Print apartments, grouped by price: ");
            IEnumerable<XElement> elements = Queries.GroupByPrice();
            foreach (XElement x in elements)
            {
                Console.WriteLine($"Price: {x.Element("Price").Value}, apartments: {x.Element("Value").Value}");
            }
            Console.WriteLine();
        }

        public static void PrintApartmentsWithRealtors()
        {
            Console.WriteLine("9. Print apartments with the realtors who work with the apartment: ");
            IEnumerable<XElement> elements = Queries.ApartmentByRealtor();
            foreach (XElement x in elements)
            {
                Console.WriteLine($"Realtor: {x.Element("Realtor").Value}; Apartment: {x.Element("Address").Value}, flat: {x.Element("Flat").Value}; Price: {x.Element("Price").Value}");
            }
            Console.WriteLine();
        }

        public static void PrintAverageAreaOfApartment()
        {
            Console.WriteLine("10. Print apartments which are less than average area of all apartments: ");
            IEnumerable<XElement> elements = Queries.AverageAreaOfApartment();
            foreach (XElement x in elements)
            {
                Console.WriteLine($"Address: {x.Element("Address").Value}, area: {x.Element("Area").Value}");
            }
            Console.WriteLine();
        }

        public static void PrintAgenciesDistricts()
        {
            Console.WriteLine("11. Print agencies with the districts where they have apartments: ");
            IEnumerable<XElement> elements = Queries.AgenciesDistricts();
            foreach (XElement x in elements)
            {
                Console.WriteLine($"Agency: {x.Element("Key").Value}, districts: {x.Element("Value").Value}");
            }
            Console.WriteLine();
        }

        public static void PrintOrder()
        {
            Console.WriteLine("12. Print districts ordered in aphabetical order: ");
            var elements = Queries.OrderDistrictInAphabeticOrder();
            foreach (var x in elements)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine();

        }

        public static void PrintApartmentsMoreThan10000()
        {
            Console.WriteLine("13. Print apartments which price is more then 10 000 UAH: ");
            IEnumerable<XElement> elements = Queries.ApartmentsMoreThan10000();
            foreach (XElement a in elements)
            {
                Console.WriteLine($"Apartment: {a.Element("Address").Value}, price: {a.Element("Price").Value}");
            }
            Console.WriteLine();
        }

        public static void PrintPriceInDollar()
        {
            Console.WriteLine("14. Print price of the apartment in $, but < 500$ in total: ");
            IEnumerable<XElement> elements = Queries.PriceInDollarLessThan500();
            foreach (XElement a in elements)
            {
                Console.WriteLine($"Apartment: {a.Element("Address").Value}, price: {a.Element("Price").Value}$");
            }
            Console.WriteLine();
        }

        public static void PrintRealtorsCount()
        {
            Console.WriteLine("15.Print agencies with the number of realtors who work in those agencies: ");
            IEnumerable<XElement> elements = Queries.AgencyRealtorsCount();
            foreach (XElement a in elements)
            {
                Console.WriteLine($"Agency: {a.Element("Agency").Value}, number of realtors: {a.Element("Realtor").Value}");
            }
            Console.WriteLine();
        }
    }
}
