using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recodme.Dxs.DesafioDXS.BusinessLayer.BOs;
using Recodme.Dxs.DesafioDXS.DataAccessLayer.Seeders;
using Recodme.Dxs.DesafioDXS.DataLayer;

namespace PyramidTests
{
    [TestClass]
    public class PyramidTest
    {
        [TestMethod]
        public void TestCreateAndList()
        {
            PyramidSeeder.Seed();
            var bo = new PyramidBusinessObject();
            var dr = new Pyramid("Head", "Metal", 200.00, 800.00);
            var resCreate = bo.Create(dr);
            var resGet = bo.Read(dr.Id);
            Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);
        }

        [TestMethod]
        public void TestCreateAndListAsync()
        {
            PyramidSeeder.Seed();
            var bo = new PyramidBusinessObject();
            var dr = new Pyramid("Head", "Metal", 200.00, 800.00);
            var resCreate = bo.CreateAsync(dr).Result;
            var resGet = bo.ReadAsync(dr.Id).Result;
            Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);
        }

        //[TestMethod]
        //public void TestListDietaryRestriction()
        //{
        //    RestaurantSeeder.Seed();
        //    var bo = new DietaryRestrictionBusinessObject();
        //    var resList = bo.List();
        //    Assert.IsTrue(resList.Success && resList.Result.Count > 0);
        //}

        //[TestMethod]
        //public void TestListDietaryRestrictionAsync()
        //{
        //    RestaurantSeeder.Seed();
        //    var bo = new DietaryRestrictionBusinessObject();
        //    var resList = bo.ListAsync().Result;
        //    Assert.IsTrue(resList.Success && resList.Result.Count > 0);
        //}

        //[TestMethod]
        //public void TestUpdateDietaryRestriction()
        //{
        //    RestaurantSeeder.Seed();
        //    var bo = new DietaryRestrictionBusinessObject();
        //    var resList = bo.List();
        //    var item = resList.Result.FirstOrDefault();
        //    item.Name = "another";
        //    var resUpdate = bo.Update(item);
        //    resList = bo.ListNonDeleted();
        //    Assert.IsTrue(resList.Success && resUpdate.Success && resList.Result.First().Name == "another");
        //}

        //[TestMethod]
        //public void TestUpdateDietaryRestrictionAsync()
        //{
        //    RestaurantSeeder.Seed();
        //    var bo = new DietaryRestrictionBusinessObject();
        //    var resList = bo.ListAsync().Result;
        //    var item = resList.Result.FirstOrDefault();
        //    item.Name = "another";
        //    var resUpdate = bo.UpdateAsync(item).Result;
        //    resList = bo.ListNonDeletedAsync().Result;
        //    Assert.IsTrue(resList.Success && resUpdate.Success && resList.Result.First().Name == "another");
        //}

        //[TestMethod]
        //public void TestDeleteDietaryRestriction()
        //{
        //    RestaurantSeeder.Seed();
        //    var bo = new DietaryRestrictionBusinessObject();
        //    var resList = bo.List();
        //    var total = resList.Result.Count;
        //    var resDelete = bo.Delete(resList.Result.First().Id);
        //    resList = bo.ListNonDeleted();
        //    Assert.IsTrue(resDelete.Success && resList.Success && resList.Result.Count == total - 1);
        //}

        //[TestMethod]
        //public void TestDeleteDietaryRestrictionAsync()
        //{
        //    RestaurantSeeder.Seed();
        //    var bo = new DietaryRestrictionBusinessObject();
        //    var resList = bo.ListAsync().Result;
        //    var total = resList.Result.Count;
        //    var resDelete = bo.DeleteAsync(resList.Result.First().Id).Result;
        //    resList = bo.ListNonDeletedAsync().Result;
        //    Assert.IsTrue(resDelete.Success && resList.Success && resList.Result.Count == total - 1);
        //}
    }
}
