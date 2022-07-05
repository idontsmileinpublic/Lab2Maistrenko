using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using Lab2Maistrenko.Models;
using Lab2Maistrenko.HelperMethods;
using System.Xml;
using Lab2Maistrenko.Helpers;

namespace Lab2Maistrenko.HelperMethods
{
    public class DataInput
    {
        public static string Input(XElement doc, string nameOfKey)
        {
            int k = int.Parse((string)doc.Descendants(nameOfKey).Last());

            Console.WriteLine($"The last element's key is: {k}");
            Console.WriteLine("Enter the key for the element: ");
            string enter = Console.ReadLine();
            if (int.Parse(enter) != k + 1)
            {
                Console.WriteLine("This key is not valid. Please, enter the valid key");
                Input(doc, nameOfKey);
            }

            return enter;
        }

        public static string EnterName()
        {
            Console.WriteLine($"Make sure it does not contain any digits");

            string name = Console.ReadLine();
            bool check = HasNum(name);
            if (check == true)
            {
                Console.WriteLine("The name has digits! Please, try again");
                EnterName();
            }
            return name;
        }

        public static bool HasNum(string tocheck)
        {
            bool flag = false;
            for (int i = 0; i < tocheck.Length; i++)
            {
                if (tocheck[i] >= '0' && tocheck[i] <= '9')
                {
                    flag = true;
                }
            }
            return flag;
        }

        public static string EnteringDigit()
        {
            string element = Console.ReadLine();
            bool check = HasNum(element);
            if (check == false)
            {
                Console.WriteLine("Invalid input. Please, try again!");
                EnteringDigit();
            }

            return element;
        }

        public static string EnterPhoneNumber()
        {
            string phonenumber = Console.ReadLine();
            if (phonenumber.Length < 9)
            {
                Console.WriteLine("Invalid. Please, try again.");
                EnterPhoneNumber();
            }

            return phonenumber;
        }


        public static void ReturnDistrict()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("district.xml");

            foreach (XmlNode node in doc.DocumentElement) {
                string name = node["name"].InnerText;
                string districtId = node["districtId"].InnerText;
                Console.WriteLine(string.Format($"District: {name}, key: {districtId}"));
            };
        }

        public static void ReturnAddress()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("address.xml");

            foreach (XmlNode node in doc.DocumentElement)
            {
                string address = node["nameAddress"].InnerText;
                string addressId = node["addressId"].InnerText;
                Console.WriteLine(string.Format($"Address: {address}, key: {addressId}"));
            }
        }

        public static void ReturnApartment()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("apartment.xml");

            foreach (XmlNode node in doc.DocumentElement)
            {
                string addressId = node["addressId"].InnerText;
                string apartmentId = node["apartmentId"].InnerText;
                string area = node["area"].InnerText;
                string price = node["price"].InnerText;
                string flat = node["flat"].InnerText;
                Console.WriteLine(string.Format($"Address key: {addressId}, apartment key: {apartmentId}, area: {area}, flat: {flat}, price: {price}"));
            }
        }

        public static void ReturnRealtor()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("realtor.xml");

            foreach (XmlNode node in doc.DocumentElement)
            {
                string realtorName = node["realtorName"].InnerText;
                string realtorPatronymic = node["realtorPatronymic"].InnerText;
                string realtorSurname = node["realtorSurname"].InnerText;
                string realtorId = node["realtorId"].InnerText;
                Console.WriteLine(string.Format($"Name: {realtorName} {realtorPatronymic} {realtorSurname}, key: {realtorId}"));
            }
        }

        public static void ReturnAgency()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("agency.xml");

            foreach(XmlNode node in doc.DocumentElement)
            {
                string agencyName = node["nameAgency"].InnerText;
                string agencyId = node["agencyId"].InnerText;
                Console.WriteLine(string.Format($"Name: {agencyName}, key: {agencyId}"));
            }
        }

        public static void InputDistrict()
        {
            XElement doc = XElement.Load("district.xml");
            string enter = Input(doc, "districtId");
            string name = EnterName();
            EditXML.AddNewNodeDistrict(enter, name);
            Console.WriteLine();
        }

        public static void InputAddress()
        {
            XElement doc = XElement.Load("address.xml");
            Console.WriteLine("Adding address:");
            string enter = Input(doc, "addressId");
            Console.WriteLine("Enter the name of the street: ");
            string nameOfAddress = EnterName();
            Console.WriteLine("Enter the name of the apartment block / house: ");
            string number = Console.ReadLine();
            nameOfAddress = nameOfAddress + ", " + number;
            ReturnDistrict();
            string districtId = Console.ReadLine();
            EditXML.AddNewNodeAddress(enter, districtId, nameOfAddress);
            Console.WriteLine();
        }

        
        public static void InputApartment()
        {
            XElement doc = XElement.Load("apartment.xml");
            Console.WriteLine("Adding apartment:");
            string enter = Input(doc, "apartmentId");
            Console.WriteLine("Enter the flat, area and price:");
            string flat = EnteringDigit();
            string area = EnteringDigit();
            string price = EnteringDigit();
            ReturnAddress();
            string addressId = Console.ReadLine();
            EditXML.AddNewNodeApartment(enter, addressId, area, price, flat);
        }


        public static void InputRealtor()
        {
            XElement doc = XElement.Load("realtor.xml");
            Console.WriteLine("Adding realtor:");
            string enter = Input(doc, "realtorId");
            Console.WriteLine("Enter first, middle and last name:");
            string first = EnterName();
            string middle = EnterName();
            string last = EnterName();
            string phonenumber = "380" + EnterPhoneNumber();
            Console.WriteLine("Enter the key of the agency");
            ReturnAgency();
            string agencyId = Console.ReadLine();
            EditXML.AddNewNodeRealtor(enter, first, middle, last, phonenumber, agencyId);
        }
    }
}
