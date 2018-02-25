using Microsoft.VisualStudio.TestTools.UnitTesting;
using HistoryMap.Shared_Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodaTime;
using NodaTime.Calendars;

namespace HistoryMap.Shared_Classes.Tests
{
    [TestClass()]
    public class HistoryMapWebClientTests
    {
        private const string user = "admin", pass = "ivkh0rAj8v1mDWHJDzaY";
        private const bool Setup = false;
        [TestMethod()]
        public void HistoryMapWebClientTest_FailConnection()
        {
            try
            {
                var client = new HistoryMapWebClient("", "");
                Assert.Fail("Should fail to login");
            }
            catch (Exception e)
            {
                Assert.AreEqual("Incorrect username/password combination, or user doesn't exist", e.Message);
            }

        }

        [TestMethod()]
        public void HistoryMapWebClientTest_SuccessConnection()
        {
            var client = new HistoryMapWebClient(user, pass);
            Assert.IsNotNull(client);
        }
        [TestMethod()]
        public async Task HistoryMapWebClientTest_AllButtons()
        {
            var client = new HistoryMapWebClient(user, pass);
            var btns = await client.GetButtons();
            Assert.AreNotEqual(0, btns.Count);

        }
        [TestMethod()]
        public async Task HistoryMapWebClientTest_AllButtonsFilter()
        {
            const int expectedBtns = 1;
            var startDate = new LocalDate(Era.Common, 1065, 5, 5);
            var endDate = new LocalDate(Era.Common, 1067, 5, 5);
            var client = new HistoryMapWebClient(user, pass);
            var btns = await client.GetButtons(startDate, endDate);
            Assert.AreEqual(expectedBtns, btns.Count);
        }

        [TestMethod()]
        public async Task HistoryMapWebClientTest_AllBorders()
        {
            var client = new HistoryMapWebClient(user, pass);
            var btns = await client.GetBorders();
            Assert.AreNotEqual(0, btns.Count);

            var withPoints = btns.Where(p => p.AllPointsofBorder.Count > 0);

            Assert.AreNotEqual(0, withPoints.Count());
        }

        [TestMethod()]
        public async Task HistoryMapWebClientTest_AllBordersFilter()
        {
            const int expectedBtns = 1;
            var expectedColor = Color.Red.ToArgb();

            var currentTime = new LocalDate(Era.Common, 1066, 5, 5);
            var client = new HistoryMapWebClient(user, pass);
            var borders = await client.GetBorders(currentTime);
            Assert.AreEqual(expectedBtns, borders.Count);
            Assert.AreEqual(expectedColor, borders.First().Colour.ToArgb());
        }

        [TestMethod()]
        public async Task Insert_Button_Test()
        {
            var client = new HistoryMapWebClient(user, pass);
            var a = client.CreateRecord(new GenericLabelForWorldMap(new LocalDate(Era.BeforeCommon, 50, 5, 5),
                new Point(5, 5), "SomeType", new Dictionary<string, string>()
                {
                    {"Key", "Value"}
                }, 50, 50, Guid.NewGuid().ToString()));
            Assert.IsTrue(a.GetAwaiter().GetResult().Success);
        }

        [TestMethod()]
        public async Task Insert_Button_And_Find_And_Delete_Test()
        {

            var client = new HistoryMapWebClient(user, pass);
            var record = new GenericLabelForWorldMap(new LocalDate(Era.BeforeCommon, 50, 5, 5), new Point(5, 5),
                "SomeType", new Dictionary<string, string>()
                {
                    {"Key", "Value"}
                }, 50, 50, Guid.NewGuid().ToString());

            //create record
            var a = await client.CreateRecord(record);
            Assert.IsTrue(a.Success);

            //Find record
            var allRecords = await client.GetButtons();
            var inserted = allRecords.SingleOrDefault(p => p._id == record._id);

            Assert.IsNotNull(inserted);

            //Delete record
            var deleteResult = await client.Delete<GenericLabelForWorldMap>(record._id);

            Assert.IsTrue(deleteResult.Success);

            //Check deletion
            allRecords = await client.GetButtons();
            inserted = allRecords.SingleOrDefault(p => p._id == record._id);

            Assert.IsNull(inserted);

        }
        [TestMethod()]
        public async Task InsertandUpdate_Button_BC()
        {

            var client = new HistoryMapWebClient(user, pass);
            var record = new GenericLabelForWorldMap(new LocalDate(Era.BeforeCommon, 50, 5, 5), new Point(5, 5),
                "SomeType", new Dictionary<string, string>()
                {
                    {"Key", "Value"}
                }, 50, 50, Guid.NewGuid().ToString());

            //create record
            var a = await client.CreateRecord(record);
            Assert.IsTrue(a.Success);

            //Find record
            var allRecords = await client.GetButtons();
            var inserted = allRecords.SingleOrDefault(p => p._id == record._id);

            Assert.IsNotNull(inserted);

            //Update record
            var newDate = new LocalDate(Era.BeforeCommon, 1050, 05, 05);
            record.timeOf = newDate;
            var updateResult = await client.UpdateRecord(record);

            Assert.IsTrue(updateResult.Success);

            //Check update
            allRecords = await client.GetButtons();
            inserted = allRecords.SingleOrDefault(p => p._id == record._id);

            Assert.AreEqual(newDate, inserted.timeOf);

        }
        [TestMethod()]
        public async Task InsertandUpdate_Button_AD()
        {

            var client = new HistoryMapWebClient(user, pass);
            var record = new GenericLabelForWorldMap(new LocalDate(Era.BeforeCommon, 50, 5, 5), new Point(5, 5),
                "SomeType", new Dictionary<string, string>()
                {
                    {"Key", "Value"}
                }, 50, 50, Guid.NewGuid().ToString());

            //create record
            var a = await client.CreateRecord(record);
            Assert.IsTrue(a.Success);

            //Find record
            var allRecords = await client.GetButtons();
            var inserted = allRecords.SingleOrDefault(p => p._id == record._id);

            Assert.IsNotNull(inserted);

            //Update record
            var newDate = new LocalDate(Era.Common, 1050, 05, 05);
            record.timeOf = newDate;
            var updateResult = await client.UpdateRecord(record);

            Assert.IsTrue(updateResult.Success);

            //Check update
            allRecords = await client.GetButtons();
            inserted = allRecords.SingleOrDefault(p => p._id == record._id);

            Assert.AreEqual(newDate, inserted.timeOf);

        }

        [TestMethod()]
        public async Task Insert_Border_Test()
        {
            var client = new HistoryMapWebClient(user, pass);
            var a = await client.CreateRecord(new BorderStorageClass(new LocalDate(Era.BeforeCommon, 50, 5, 5), Color.Black, new List<Point>() { new Point(50, 50) }));
            Assert.IsTrue(a.Success);
        }
        [TestMethod()]
        public async Task Insert_Border_For_Filter_Test()
        {
            //var client = new HistoryMapWebClient(user, pass);
            //var border = new BorderStorageClass(new LocalDate(Era.Common, 1065, 5, 5), Color.Red,
            //    new List<Point>() { new Point(50, 50) });
            //border.ValidTill = new LocalDate(Era.Common, 1067, 5, 5);
            //var a = await client.CreateRecord(border);
        }

    }
}