using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Lab2Maistrenko.Models;

namespace Lab2Maistrenko.XML
{
    public class XMLWrite
    {
        public static void CreateXMLDocument()
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            using (XmlWriter writer = XmlWriter.Create("district.xml", settings))
            {
                writer.WriteStartElement("districts");

                foreach (District district in Data.Districts)
                {
                    writer.WriteStartElement("district");
                    writer.WriteElementString("districtId", district.DistrictId.ToString());
                    writer.WriteElementString("name", district.NameDistrict);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }

            using (XmlWriter writer = XmlWriter.Create("address.xml", settings))
            {
                writer.WriteStartElement("addresses");

                foreach (Address address in Data.Addresses)
                {
                    writer.WriteStartElement("address");
                    writer.WriteElementString("addressId", address.AddressId.ToString());
                    writer.WriteElementString("districtId", address.DistrictId.ToString());
                    writer.WriteElementString("nameAddress", address.AddressName);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }

            using (XmlWriter writer = XmlWriter.Create("agency.xml", settings))
            {
                writer.WriteStartElement("agencies");

                foreach (Agency agency in Data.Agencies)
                {
                    writer.WriteStartElement("agency");
                    writer.WriteElementString("agencyId", agency.AgencyId.ToString());
                    writer.WriteElementString("addressId", agency.AddressId.ToString());
                    writer.WriteElementString("nameAgency", agency.Name);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }

            using (XmlWriter writer = XmlWriter.Create("apartment.xml", settings))
            {
                writer.WriteStartElement("apartments");

                foreach (Apartment apartment in Data.Apartments)
                {
                    writer.WriteStartElement("apartment");
                    writer.WriteElementString("apartmentId", apartment.ApartmentId.ToString());
                    writer.WriteElementString("addressId", apartment.AddressId.ToString());
                    writer.WriteElementString("area", apartment.Area.ToString());
                    writer.WriteElementString("price", apartment.Price.ToString());
                    writer.WriteElementString("flat", apartment.Flat.ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }

            using (XmlWriter writer = XmlWriter.Create("realtor.xml", settings))
            {
                writer.WriteStartElement("realtors");

                foreach (Realtor realtor in Data.Realtors)
                {
                    writer.WriteStartElement("realtor");
                    writer.WriteElementString("realtorId", realtor.RealtorId.ToString());
                    writer.WriteElementString("realtorName", realtor.Name);
                    writer.WriteElementString("realtorPatronymic", realtor.Patronymic);
                    writer.WriteElementString("realtorSurname", realtor.Surname);
                    writer.WriteElementString("realtorPhoneNumber", realtor.PhoneNumber);
                    writer.WriteElementString("agencyId", realtor.AgencyId.ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }

            using (XmlWriter writer = XmlWriter.Create("apartmentrealtor.xml", settings))
            {
                writer.WriteStartElement("apartmentsrealtor");

                foreach (ApartmentRealtor apartmentrealtor in Data.ApartmentRealtors)
                {
                    writer.WriteStartElement("apartmentrealtor");
                    writer.WriteElementString("realtorId", apartmentrealtor.RealtorId.ToString());
                    writer.WriteElementString("apartmentId", apartmentrealtor.ApartmentId.ToString());
                    writer.WriteElementString("apartmentsrealtorId", apartmentrealtor.ApartmentRealtorId.ToString());
                    writer.WriteElementString("overPrice", apartmentrealtor.OverPrice.ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
        }
    }
}
