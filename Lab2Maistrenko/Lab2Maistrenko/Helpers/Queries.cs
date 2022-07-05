using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using Lab2Maistrenko.Models;
using Lab2Maistrenko.HelperMethods;

namespace Lab2Maistrenko.Helpers
{
    public class Queries
    {
        public static XDocument Address { get; set; }
        public static XDocument Agency { get; set; }
        public static XDocument Apartment { get; set; }
        public static XDocument Realtor { get; set; }
        public static XDocument xmlDistrict { get; set; }
        public static XDocument ApartmentRealtor { get; set; }

        //1
        public static IEnumerable<string> NameAddress()
        {
            return Address.Descendants("address").Select(x => x.Element("nameAddress").Value);
        }

        //2 
        public static IEnumerable<XElement> GetAll()
        {
            return
                from el in xmlDistrict.Descendants("district")
                orderby el.Element("name").Value
                select el;
        }

        //3
        public static IEnumerable<XElement> AllRealtors()
        {
            return
                from el in Realtor.Descendants("realtor")
                join el2 in Agency.Descendants("agency")
                on el.Element("agencyId").Value equals el2.Element("agencyId").Value
                select new XElement("RealtorInAgency",
                new XElement("Name", el.Element("realtorName").Value,
                    el.Element("realtorPatronymic").Value,
                    el.Element("realtorSurname").Value),
                new XElement("agency", el2.Element("nameAgency").Value),
                new XElement("PhoneNumber", el.Element("realtorPhoneNumber")));
        }

        //4 
        public static IEnumerable<RealtorAgency> GroupRealtorsByAgency()
        {
            return
                from el in Realtor.Descendants("realtor")
                join el2 in Agency.Descendants("agency")
                on el.Element("agencyId").Value equals el2.Element("agencyId").Value
                group el.Element("realtorSurname").Value by el2.Element("nameAgency").Value into grouping
                select new RealtorAgency() { Agency = grouping.Key, Realtor = grouping };
        }

        //5
        public static IEnumerable<XElement> ApartmentsToRent()
        {
            return
                from e1 in Apartment.Descendants("apartment")
                join e2 in Address.Descendants("address")
                on e1.Element("addressId").Value equals e2.Element("addressId").Value
                select new XElement("ApartmentAddress",
                new XElement("Flat", e1.Element("flat").Value),
                new XElement("Area", e1.Element("area").Value),
                new XElement("Price", e1.Element("price").Value),
                new XElement("Address", e2.Element("nameAddress").Value));
        }

        //6
        public static IEnumerable<XElement> AllAgenciesStartWith()
        {
            return
                from ag in Agency.Descendants("agency")
                where ag.Element("nameAgency").Value.ToUpper().StartsWith(char.ToUpper('F'))
                select new XElement("Agency", new XElement("Agency", ag.Element("nameAgency")));
        }

        //7
        public static IEnumerable<XElement> GroupByDistrict()
        {
            return
                from e1 in Apartment.Descendants("apartment")
                join e2 in Address.Descendants("address") on e1.Element("addressId").Value equals e2.Element("addressId").Value
                join e3 in xmlDistrict.Descendants("district") on e2.Element("districtId").Value equals e3.Element("districtId").Value
                group e2.Element("nameAddress").Value by e3.Element("name").Value into grouping
                select new XElement("GroupedApartments",
                new XElement("Key", grouping.Key),
                new XElement("Value", grouping));
        }

        //8
        public static IEnumerable<XElement> GroupByPrice()
        {
            return
                from e1 in Apartment.Descendants("apartment")
                join e2 in Address.Descendants("address") on e1.Element("addressId").Value equals e2.Element("addressId").Value
                group e2.Element("nameAddress").Value by e1.Element("price").Value into grouping
                select new XElement("GroupByPrice", new XElement("Price", grouping.Key), new XElement("Value", grouping));
        }

        //9
        public static IEnumerable<XElement> ApartmentByRealtor()
        {
            return
                from e1 in Apartment.Descendants("apartment")
                join e2 in ApartmentRealtor.Descendants("apartmentrealtor") on e1.Element("apartmentId").Value equals e2.Element("apartmentId").Value
                join e3 in Realtor.Descendants("realtor") on e2.Element("realtorId").Value equals e3.Element("realtorId").Value
                join e4 in Address.Descendants("address") on e1.Element("addressId").Value equals e4.Element("addressId").Value
                select new XElement("ApartmentByRealtor", new XElement("Address", e4.Element("nameAddress")),
                new XElement("Flat", e1.Element("flat").Value),
                new XElement("Realtor", e3.Element("realtorSurname").Value),
                new XElement("Price", (int.Parse(e1.Element("price").Value) + int.Parse(e2.Element("overPrice").Value))));

        }

        //10
        public static IEnumerable<XElement> AverageAreaOfApartment()
        {
            return from address in Address.Descendants("address")
                   join apartment in Apartment.Descendants("apartment") on address.Element("addressId").Value equals apartment.Element("addressId").Value
                   where int.Parse(apartment.Element("area").Value) < Apartment.Descendants("apartment").Select(apartment => int.Parse(apartment.Element("area").Value)).Average()
                   select new XElement("Selected", new XElement("Address", address.Element("nameAddress").Value), new XElement("Area", int.Parse(apartment.Element("area").Value)));
        }


        //11
        public static IEnumerable<XElement> AgenciesDistricts()
        {
            return from agency in Agency.Descendants("agency")
                   join realtor in Realtor.Descendants("realtor") on agency.Element("agencyId").Value equals realtor.Element("agencyId").Value
                   join apartment_realtor in ApartmentRealtor.Descendants("apartmentrealtor") on realtor.Element("realtorId").Value equals apartment_realtor.Element("realtorId").Value
                   join apartment in Apartment.Descendants("apartment") on apartment_realtor.Element("apartmentId").Value equals apartment.Element("apartmentId").Value
                   join address in Address.Descendants("address") on apartment.Element("addressId").Value equals address.Element("addressId").Value
                   join district in xmlDistrict.Descendants("district") on address.Element("districtId").Value equals district.Element("districtId").Value
                   group district.Element("name").Value by agency.Element("nameAgency").Value into grouping
                   select new XElement("AgencyAndDistricts", new XElement("Key", grouping.Key), new XElement("Value", grouping));
        }

        //12
        public static IEnumerable<string> OrderDistrictInAphabeticOrder()
        {
            return Agency.Descendants("agency").Select(a => a.Element("nameAgency").Value).OrderBy(a => a);
        }

        //13
        public static IEnumerable<XElement> ApartmentsMoreThan10000()
        {
            return from e1 in Apartment.Descendants("apartment")
                   join e2 in Address.Descendants("address") on e1.Element("addressId").Value equals e2.Element("addressId").Value
                   where (int.Parse(e1.Element("price").Value)) > 10000
                   select new XElement("Selected", new XElement("Address", e2.Element("nameAddress")), new XElement("Price", e1.Element("price").Value));
        }

        //14
        public static IEnumerable<XElement> PriceInDollarLessThan500()
        {
            return from e1 in Apartment.Descendants("apartment")
                   join e2 in ApartmentRealtor.Descendants("apartmentrealtor") on e1.Element("apartmentId").Value equals e2.Element("apartmentId").Value
                   join e3 in Realtor.Descendants("realtor") on e2.Element("realtorId").Value equals e3.Element("realtorId").Value
                   join e4 in Address.Descendants("address") on e1.Element("addressId").Value equals e4.Element("addressId").Value
                   where (int.Parse(e1.Element("price").Value) + int.Parse(e2.Element("overPrice").Value)) / 29 < 500
                   orderby e1.Element("apartmentId").Value
                   select new XElement("PriceInDollar",
                   new XElement("Address", e4.Element("nameAddress")),
                   new XElement("Price", (int.Parse(e1.Element("price").Value) + int.Parse(e2.Element("overPrice").Value))/29));
        }

        //15
        public static IEnumerable<XElement> AgencyRealtorsCount()
        {

            return Agency.Descendants("agency")
                        .GroupJoin(
                            Realtor.Descendants("realtor"),
                            agency => agency.Element("agencyId").Value,
                            realtor => realtor.Element("agencyId").Value,
                            (agency, realtors) => new XElement("RealtorsCount", new XElement("Agency", agency), new XElement("Realtor", realtors.Count())) 
                        );
        }
    }
}
