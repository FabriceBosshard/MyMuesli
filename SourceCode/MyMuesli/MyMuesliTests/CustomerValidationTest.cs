using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyMuesli.Helpers;
using MyMuesli.Model;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace MyMuesliTests
{
    [TestFixture]
    public class CustomerValidationTest
    {
        [Test]
        public void WrongName()
        {
            var customer = new CustomerDetails()
            {
                Name = "pe",
                Address = "Something",
                City = "Zurich",
                Country = new Country()
                {
                    Name = "Swiss"
                },
                Zip = "3434",
                Phone = "079 620 00 35",
                Email = "fab.bos@bos.com",
            };
            Assert.IsFalse(CustomerValidation.ValidateCustomer(customer));
        }
        [Test]
        public void WrongAddress()
        {
            var customer = new CustomerDetails()
            {
                Name = "person",
                Address = "se",
                City = "Zurich",
                Country = new Country()
                {
                    Name = "Swiss"
                },
                Zip = "3434",
                Phone = "079 620 00 35",
                Email = "fab.bos@bos.com",
            };
            Assert.IsFalse(CustomerValidation.ValidateCustomer(customer));
        }
        [Test]
        public void WrongZip()
        {
            var customer = new CustomerDetails()
            {
                Name = "person",
                Address = "Something",
                City = "Zurich",
                Country = new Country()
                {
                    Name = "Swiss"
                },
                Zip = "dsfsd",
                Phone = "079 620 00 35",
                Email = "fab.bos@bos.com",
            };
            Assert.IsFalse(CustomerValidation.ValidateCustomer(customer));
        }
        [Test]
        public void WrongCity()
        {
            var customer = new CustomerDetails()
            {
                Name = "person",
                Address = "Something",
                City = "s",
                Country = new Country()
                {
                    Name = "Swiss"
                },
                Zip = "3434",
                Phone = "079 620 00 35",
                Email = "fab.bos@bos.com",
            };
            Assert.IsFalse(CustomerValidation.ValidateCustomer(customer));
        }
        [Test]
        public void WrongPhone()
        {
            var customer = new CustomerDetails()
            {
                Name = "person",
                Address = "Something",
                City = "Zurich",
                Country = new Country()
                {
                    Name = "Swiss"
                },
                Zip = "3434",
                Phone = "079",
                Email = "fab.bos@bos.com",
            };
            Assert.IsFalse(CustomerValidation.ValidateCustomer(customer));
        }
        [Test]
        public void WrongMail()
        {
            var customer = new CustomerDetails()
            {
                Name = "person",
                Address = "Something",
                City = "Zurich",
                Country = new Country()
                {
                    Name = "Swiss"
                },
                Zip = "3434",
                Phone = "079 620 00 35",
                Email = "fab.bos@bo",
            };
            Assert.IsFalse(CustomerValidation.ValidateCustomer(customer));
        }
        [Test]
        public void CorrectCustomer()
        {
            var customer = new CustomerDetails()
            {
                Name = "person",
                Address = "Something",
                City = "Zurich",
                Country = new Country()
                {
                    Name = "Swiss"
                },
                Zip = "3434",
                Phone = "079 620 00 35",
                Email = "fab.bos@bos.com",
            };
            Assert.IsTrue(CustomerValidation.ValidateCustomer(customer));
        }
    }
}
