using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using instakill.Model;

namespace instakill.Tests
{
    [TestClass]
    public class DataLayerSqlTests
    {
        private const string ConnectionString = "Data Source=sql-dv2017-1;Initial Catalog=margatsni;Integrated Security=True";
        [TestMethod]
        public void ShouldAddUser()
        {
            //arrange
            var user = new Users
            {
                Nickname = Guid.NewGuid().ToString().Substring(10)
            };
            var dataLayer = new DataLayer.Sql.DataLayer(ConnectionString);
            //act
            user = dataLayer.AddUser(user);
            //asserts
            var resultUser = dataLayer.GetUser(user.Id);
            Assert.AreEqual(user.Nickname, resultUser.Nickname);
        }
    }
}
