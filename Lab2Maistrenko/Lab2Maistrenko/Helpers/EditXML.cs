using System;
using System.Xml;

namespace Lab2Maistrenko.Helpers
{
    public class EditXML
    {
        public static void AddNewNodeDistrict(string districtId, string name)
        {
            XmlDocument docDistrict = new XmlDocument();
            docDistrict.Load("district.xml");
            XmlElement xRoot = docDistrict.DocumentElement;

            XmlElement districtElement = docDistrict.CreateElement("district");

            XmlElement idElement = docDistrict.CreateElement("districtId");
            XmlElement nameElement = docDistrict.CreateElement("name");

            XmlText idText = docDistrict.CreateTextNode(districtId);
            XmlText nameText = docDistrict.CreateTextNode(name);

            idElement.AppendChild(idText);
            nameElement.AppendChild(nameText);

            districtElement.AppendChild(idElement);
            districtElement.AppendChild(nameElement);

            xRoot?.AppendChild(districtElement);
            docDistrict.Save("district.xml");
        }

        public static void AddNewNodeAddress(string addressId, string districtId, string name)
        {
            XmlDocument docAddress = new XmlDocument();
            docAddress.Load("address.xml");
            XmlElement xRoot = docAddress.DocumentElement;

            XmlElement addressElement = docAddress.CreateElement("address");

            XmlElement idElement = docAddress.CreateElement("addressId");
            XmlElement districtElement = docAddress.CreateElement("districtId");
            XmlElement nameElement = docAddress.CreateElement("nameAddress");

            XmlText idText = docAddress.CreateTextNode(addressId);
            XmlText idDistrict = docAddress.CreateTextNode(districtId);
            XmlText nameText = docAddress.CreateTextNode(name);

            idElement.AppendChild(idText);
            districtElement.AppendChild(idDistrict);
            nameElement.AppendChild(nameText);

            addressElement.AppendChild(idElement);
            addressElement.AppendChild(districtElement);
            addressElement.AppendChild(nameElement);

            xRoot?.AppendChild(addressElement);
            docAddress.Save("address.xml");
        }

        public static void AddNewNodeApartment(string idApartment, string idAddress, string area, string price, string flat)
        {
            XmlDocument docApartment = new XmlDocument();
            docApartment.Load("apartment.xml");
            XmlElement xRoot = docApartment.DocumentElement;

            XmlElement apartmentElement = docApartment.CreateElement("apartment");

            XmlElement idElement = docApartment.CreateElement("apartmentId");
            XmlElement addressElement = docApartment.CreateElement("addressId");
            XmlElement areaElement = docApartment.CreateElement("area");
            XmlElement priceElement = docApartment.CreateElement("price");
            XmlElement flatElement = docApartment.CreateElement("flat");

            XmlText idText = docApartment.CreateTextNode(idApartment);
            XmlText addressText = docApartment.CreateTextNode(idAddress);
            XmlText areaText = docApartment.CreateTextNode(area);
            XmlText priceText = docApartment.CreateTextNode(price);
            XmlText flatText = docApartment.CreateTextNode(flat);

            idElement.AppendChild(idText);
            addressElement.AppendChild(addressText);
            areaElement.AppendChild(areaText);
            priceElement.AppendChild(priceText);
            flatElement.AppendChild(flatText);

            apartmentElement.AppendChild(idElement);
            apartmentElement.AppendChild(addressElement);
            apartmentElement.AppendChild(areaElement);
            apartmentElement.AppendChild(priceElement);
            apartmentElement.AppendChild(flatElement);

            xRoot?.AppendChild(apartmentElement);
            docApartment.Save("apartment.xml");
        }

        public static void AddNewNodeRealtor(string id, string name, string patronymic, string surname, string phonenumber, string agencyid)
        {
            XmlDocument docRealtor = new XmlDocument();
            docRealtor.Load("realtor.xml");
            XmlElement xRoot = docRealtor.DocumentElement;

            XmlElement realtorElement = docRealtor.CreateElement("realtor");

            XmlElement idElement = docRealtor.CreateElement("realtorId");
            XmlElement nameElement = docRealtor.CreateElement("realtorName");
            XmlElement patronymicElement = docRealtor.CreateElement("realtorPatronymic");
            XmlElement surnameElement = docRealtor.CreateElement("realtorSurname");
            XmlElement numberElement = docRealtor.CreateElement("realtorPhoneNumber");
            XmlElement agencyElement = docRealtor.CreateElement("agencyId");

            XmlText idText = docRealtor.CreateTextNode(id);
            XmlText nameText = docRealtor.CreateTextNode(name);
            XmlText patronymicText = docRealtor.CreateTextNode(patronymic);
            XmlText surnameText = docRealtor.CreateTextNode(surname);
            XmlText numberText = docRealtor.CreateTextNode(phonenumber);
            XmlText agencyText = docRealtor.CreateTextNode(agencyid);

            idElement.AppendChild(idText);
            nameElement.AppendChild(nameText);
            patronymicElement.AppendChild(patronymicText);
            surnameElement.AppendChild(surnameText);
            numberElement.AppendChild(numberText);
            agencyElement.AppendChild(agencyText);

            realtorElement.AppendChild(idElement);
            realtorElement.AppendChild(nameElement);
            realtorElement.AppendChild(patronymicElement);
            realtorElement.AppendChild(surnameElement);
            realtorElement.AppendChild(numberElement);
            realtorElement.AppendChild(agencyElement);

            xRoot?.AppendChild(realtorElement);
            docRealtor.Save("realtor.xml");
        }

    }
}
