using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project;

namespace UnitTest_Hotel
{

    [TestClass]
    public class UnitTest1
    {


        [TestMethod]
        public void TestKonstruktorClient()
        {
            Client client = new Client("Jan", "Kowalski", "546-653-765", Sex.Man, "janekmajeranek@gmail.com", "RSE 654332");
            Assert.AreEqual("Jan", client.Name);
            Assert.AreEqual("Kowalski", client.Surname);
            Assert.AreEqual("546-653-765", client.Phone);
            Assert.AreEqual(Sex.Man, client.Sex);
            Assert.AreEqual("janekmajeranek@gmail.com", client.Email);
            Assert.AreEqual("RSE 654332", client.IDNumer);
        }
        [TestMethod]
        public void TestKonstruktorEmployee()
        {
            Employee employee = new Employee("Karolina", "Grzanka", "879-987-987", Sex.Woman, "Administrator");
            Assert.AreEqual("Karolina", employee.Name);
            Assert.AreEqual("Grzanka", employee.Surname);
            Assert.AreEqual("879-987-987", employee.Phone);
            Assert.AreEqual(Sex.Woman, employee.Sex);
            Assert.AreEqual("Administrator", employee.Function);
        }
        [TestMethod]
        public void TestKonstruktorHotelRoom()
        {

            Hotel hotel = new Hotel("NAJLEPSZY HOTEL NA ŚWIACIE");
            Employee employee = new Employee("Karolina", "Grzanka", "879-987-987", Sex.Woman, "Administrator");
            Room room = hotel.CreateRoom(01, 0, 1, false, employee);
            Client client = new Client("Jan", "Kowalski", "546-653-765", Sex.Man, "janekmajeranek@gmail.com", "RSE 654332");
            Reservation reservation = new Reservation("Reservation room 1 28/09/2019 - 30/09/2019", client, "2019/09/28", "2019/09/30", 2, 0, 0, true, false, false);


            Assert.AreEqual("NAJLEPSZY HOTEL NA ŚWIACIE", hotel.Name);
            Assert.AreEqual(01, room.RoomNumber);
            Assert.AreEqual(0, room.NumberOfSingleBeds);
            Assert.AreEqual(1, room.NumberOfMarriageBeds);
            Assert.AreEqual(false, room.IsBalcony);
            Assert.IsInstanceOfType(employee, typeof(Employee));

            Assert.IsInstanceOfType(reservation, typeof(Reservation));
        }
        [TestMethod]
        public void TestKonstruktorSinglepayment()
        {
            SinglePayment singlePayment = new SinglePayment("Kawa late", 10.50, 2);
            Assert.AreEqual("Kawa late", singlePayment.Title);
            Assert.AreEqual(10.50, singlePayment.Price);
            Assert.AreEqual(2, singlePayment.Quantity);
        }

        [TestMethod]
        [ExpectedException(typeof(WrongEmailException))]
        public void TestWyjatkuEmail()
        {
            Client client = new Client("", "", "546-653-765", Sex.Man, "Zlymail", "RSE 654332");
            Assert.IsInstanceOfType(client.Email, typeof(string));
        }
        [TestMethod]
        [ExpectedException(typeof(WrongPhoneException))]
        public void TestWyjatkuPhone()
        {
            Client client = new Client("", "", "Zlynumer", Sex.Man, "janekmajeranek@gmail.com", "RSE 654332");
            Assert.IsInstanceOfType(client.Phone, typeof(string));
        }
        [TestMethod]
        [ExpectedException(typeof(WrongIDNumberException))]
        public void TestWyjatkuIDNumer()
        {
            Client client = new Client("", "", "546-653-765", Sex.Man, "janekmajeranek@gmail.com", "ZlyNumerID");
            Assert.IsInstanceOfType(client.IDNumer, typeof(string));
        }
        [TestMethod]
        [ExpectedException(typeof(WrongCheckInException))]
        public void TestWyjatkuCheckIn()
        {
            Client client = new Client("", "", "546-653-765", Sex.Man, "janekmajeranek@gmail.com", "RSE 654332");
            Reservation reservation = new Reservation("Reservation room 1 28/09/2019 - 30/09/2019", client, "2019/09/28", "2019/09/30", 2, 0, 0, false, false, false);
            reservation.CheckIn();

            foreach (Room room in reservation.Rooms)
            {
                Assert.AreEqual(room.IsFree, false);
            }
        }
        [TestMethod]
        public void TestlicznikaClient()
        {
            Hotel hotel = new Hotel("NAJLEPSZY HOTEL NA ŚWIACIE");
            Employee employee = new Employee("Karolina", "Grzanka", "879-987-987", Sex.Woman, "Administrator");
            hotel.CreateClient("Jan", "Kowalski", "546-653-765", Sex.Man, "janekmajeranek@gmail.com", "RSE 654332", employee);
            Assert.AreEqual(1, hotel.Clients.Count);
        }
        [TestMethod]
        public void TestlicznikaEmployee()
        {
            Hotel hotel = new Hotel("NAJLEPSZY HOTEL NA ŚWIACIE");            
            hotel.CreateEmplyee("Karolina", "Grzanka", "879-987-987", Sex.Woman, "Administrator");
            Assert.AreEqual(1, hotel.Employees.Count);
            
        }
        [TestMethod]
        public void TestlicznikaAccounts()
        {
            Hotel hotel = new Hotel("NAJLEPSZY HOTEL NA ŚWIACIE");
            Employee employee = new Employee("Karolina", "Grzanka", "879-987-987", Sex.Woman, "Administrator");
            Client client = new Client("Jan", "Kowalski", "546-653-765", Sex.Man, "janekmajeranek@gmail.com", "RSE 654332");            
            hotel.CreateAccount(client);
            Assert.AreEqual(1, hotel.Accounts.Count);
        }


    }


}

