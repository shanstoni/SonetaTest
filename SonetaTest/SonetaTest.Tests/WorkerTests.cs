using NUnit.Framework;
using Soneta.Business;
using Soneta.CRM;
using Soneta.Test;
using Soneta.Zadania;
using System.Linq;

namespace SonetaTest.Tests
{
    internal class WorkerTests : DbTransactionTestBase
    {
        [SetUp]
        public void Setup()
        {
            var zad = new Zadanie
            {
                Definicja = Session.GetZadania().DefZadan.WgSymbolu["ZAD"]
            };

            using (ITransaction t = Context.Session.Logout(true))
            {
                
                Session.GetZadania().Zadania.AddRow(zad);
                zad.Nazwa = "TestZadanie";                
                t.Commit();
            }
        }

        [Test]
        public void Task_Should_NotBeNull() {
            var zad = Session.GetZadania().Zadania.WgNazwy["TestZadanie"];
            Assert.IsNotNull(zad);
        }

        [Test]
        public void TaskName_Should_Be_TestZadanie()
        {
            Zadanie zad = Session.GetZadania().Zadania.WgNazwy["TestZadanie"].Single();
            Assert.AreEqual(zad.Nazwa, "TestZadanie");
        }

        

        [Test]
        public void Task_Should_have_ConnectionWithContractor()
        {
            var zm = Session.GetZadania();
            Zadanie zad = zm.Zadania.WgNazwy["TestZadanie"].Single();

            InUITransaction(() => { zad.Kontrahent = Session.GetCRM().Kontrahenci.WgKodu["Abc"]; });            

            Assert.That(zad.Kontrahent, Is.EqualTo(Session.GetCRM().Kontrahenci.WgKodu["Abc"]));
        }
    }
}
