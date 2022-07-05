using System;
using System.Xml;
using System.Xml.Linq;
using System.Collections.Generic;

namespace Lab2Maistrenko.XML
{
    public class XMLRead
    {
        public XDocument XmlAddress { get; set; }
        public XDocument XmlDistrict { get; set; }
        public XDocument XmlAgency { get; set; }
        public XDocument XmlApartment { get; set; }
        public XDocument XmlRealtor { get; set; }
        public XDocument XmlApartmentRealtor { get; set; }

        public XMLRead()
        {
            XmlDistrict = XDocument.Load("district.xml");

            foreach (XElement districtElement in
            XmlDistrict.Element("districts").Elements("district"))
            {
                XElement nameAttribute = districtElement.Element("name");
                XElement idElement = districtElement.Element("districtId");
            }

            XmlAddress = XDocument.Load("address.xml");

            foreach (XElement addressElement in
            XmlAddress.Element("addresses").Elements("address"))
            {
                XElement nameAttribute = addressElement.Element("nameAddress");
                XElement ownIdElement = addressElement.Element("addressId");
                XElement foreignIdElement = addressElement.Element("districtId");
            }

            XmlAgency = XDocument.Load("agency.xml");

            foreach (XElement agencyElement in
            XmlAgency.Element("agencies").Elements("agency"))
            {
                XElement nameAttribute = agencyElement.Element("nameAgency");
                XElement ownIdElement = agencyElement.Element("agencyId");
                XElement foreignIdElement = agencyElement.Element("addressId");
            }

            XmlRealtor = XDocument.Load("realtor.xml");

            foreach (XElement realtorElement in
            XmlRealtor.Element("realtors").Elements("realtor"))
            {
                XElement elementId = realtorElement.Element("realtorId");
                XElement nameAttribute = realtorElement.Element("realtorName");
                XElement patronymicAttribute = realtorElement.Element("realtorPatronymic");
                XElement surnameAttribute = realtorElement.Element("realtorSurname");
                XElement numberElement = realtorElement.Element("realtorPhoneNumber");
                XElement foreignIdElement = realtorElement.Element("agencyId");
            }

            XmlApartment = XDocument.Load("apartment.xml");

            foreach (XElement apartmentElement in
            XmlApartment.Element("apartments").Elements("apartment"))
            {
                XElement elementId = apartmentElement.Element("apartmentId");
                XElement foreignIdElement = apartmentElement.Element("addressId");
                XElement areaElement = apartmentElement.Element("area");
                XElement flatElement = apartmentElement.Element("flat");
                XElement priceElement = apartmentElement.Element("price");
            }

            XmlApartmentRealtor = XDocument.Load("apartmentrealtor.xml");

            foreach (XElement apartmentrealtorElement in
            XmlApartmentRealtor.Element("apartmentsrealtor").Elements("apartmentrealtor"))
            {
                XElement elementId = apartmentrealtorElement.Element("apartmentsrealtorId");
                XElement idrealElement = apartmentrealtorElement.Element("realtorId");
                XElement idapartmentElement = apartmentrealtorElement.Element("apartmentId");
                XElement overpriceElement = apartmentrealtorElement.Element("overPrice");
            }
        }
    }
}
