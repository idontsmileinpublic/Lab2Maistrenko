using System;
using Lab2Maistrenko.XML;
using Lab2Maistrenko.Helpers;
using Lab2Maistrenko.Models;
using Lab2Maistrenko.HelperMethods;

namespace Lab2Maistrenko
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.Clear();
            Console.Clear();
            Console.Clear();
            Console.Clear();
            Console.Clear();
            Console.Clear();
            Console.Clear();
            Console.Clear();


            XMLWrite.CreateXMLDocument();

            DataInput.InputDistrict();
            DataInput.InputAddress();
            DataInput.InputApartment();
            DataInput.InputRealtor();

            XMLRead read = new XMLRead();
            Queries.Address = read.XmlAddress;
            Queries.Agency = read.XmlAgency;
            Queries.Apartment = read.XmlApartment;
            Queries.Realtor = read.XmlRealtor;
            Queries.xmlDistrict = read.XmlDistrict;
            Queries.ApartmentRealtor = read.XmlApartmentRealtor;

            Printers.PrintAddresses();
            Printers.PrintAllDistricts();
            Printers.PrintRealtorsAgencies();
            Printers.PrintRealtorsByAgencies();
            Printers.PrintApartmentsToRent();
            Printers.PrintAgenciesStartWith();
            Printers.PrintGroupedApartments();
            Printers.PrintGroupByPrice();
            Printers.PrintApartmentsWithRealtors();
            Printers.PrintAverageAreaOfApartment();
            Printers.PrintAgenciesDistricts();
            Printers.PrintOrder();
            Printers.PrintApartmentsMoreThan10000();
            Printers.PrintPriceInDollar();
            Printers.PrintRealtorsCount();
        }
    }
}
