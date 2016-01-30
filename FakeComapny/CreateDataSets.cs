﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace FakeCompany
{
    public static class CreateDataSets
    {
        public static List<Company> createCompanies()
        {
            List<Company> list = new List<Company>();
            Address address = new Address("1000 Big Bucks Avenue", "Redmond", "WA", 98052);
            list.Add(new Company("Microsoft", address, Product.Word, "unnecessary bloatware designed to make your digital life miserable",
                "Jon SellumUp", "Katie Killer"));
            address = new Address("1.12 WordPerfect Still Matters Lane", "Ottowa", "Ontario, Canada", 11111); //pretend zip code
            list.Add(new Company("Corel", address, Product.WordPerfect, "Microsoft products",
                "Bill Gates", "Steve Jobs"));
            return list;
        }

        public static List<Customer> createCustomers()
        {
            List<Customer> list = new List<Customer>();
            
            Customer customer = new Customer();
            customer.firstName = "George";
            customer.lastName = "Clooney";
            customer.gender = Gender.male;
            customer.product = Product.WordPerfect.ToString();
            customer.dateOfPurchase = new DateTime(2014, 10, 31);
            customer.address = new Address("P.O. Box 222", "Santa Fe", "NM", 87501);
            customer.getGeneratedProperties();
            list.Add(customer);

            customer = new Customer();
            customer.firstName = "Carly";
            customer.lastName = "Fiorina";
            customer.gender = Gender.female;
            customer.product = Product.Word.ToString();
            customer.dateOfPurchase = new DateTime(2015, 12, 25);
            customer.address = new Address("35 Hewlett-Packard Rd", "Mendocino", "CA", 21345);
            customer.getGeneratedProperties();
            list.Add(customer);

            customer = new Customer();
            customer.firstName = "Jeff";
            customer.lastName = "Bezos";
            customer.gender = Gender.male;
            customer.product = Product.WordPerfect.ToString();
            customer.dateOfPurchase = DateTime.Now.AddDays(-2); // set up customer as buying product 2 days ago
            customer.address = new Address("1200 World Domination Blvd", "Seattle", "WA", 91834);
            customer.getGeneratedProperties();
            list.Add(customer);
            return list;
        }


        //example of how to use enums to create corresponding text
        public static Dictionary<Gender, string> salutation = new Dictionary<Gender, string>
        {
            {Gender.female, "Ms."},
            {Gender.male,"Mr."},
            {Gender.ambiguous, "M."} //???
        };


    }
    public enum Product
    {
        Word,
        WordPerfect
    }

    public enum Gender
    {
        female,
        male,
        ambiguous
    }
}
