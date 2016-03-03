using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewsEffectProj;
using System.Collections.Generic;
using Moq;

namespace NewsEffectTests
{
    [TestClass]
    public class RegisteringCompaniesTests
    {
        [TestMethod]
        public void Test_RegcompMethodWhenCalled_AddsTheCompanyToTheCompanyListAndCanBeFound()
        {
            //Arrange
            Mock<DatabaseReader> mockDBreader = new Mock<DatabaseReader>();
            Mock<List<Companies>> emptymockCoList = new Mock<List<Companies>>();
            mockDBreader.Setup(r => r.ReadDatabase()).Returns(emptymockCoList.Object);
            Register registration = new Register("Barnes & Noble", mockDBreader.Object);
            List<Companies> newlist = registration.regcomp();
            //Act
            Companies theaddedcomp = newlist.Find(i =>i.name == "Barnes & Noble");
            //Assert
            Assert.AreEqual("Barnes & Noble", theaddedcomp.name);
        }

        [TestMethod]
        public void Test_RegcompMethodWhenCalledToAddOneCompany_CompanyListWillEqualOne()
        {
            //Arrange
            Mock<DatabaseReader> mockDBreader = new Mock<DatabaseReader>();
            Mock<List<Companies>> emptymockCoList = new Mock<List<Companies>>();
            mockDBreader.Setup(r => r.ReadDatabase()).Returns(emptymockCoList.Object);
            Register registration = new Register("Barnes & Noble", mockDBreader.Object);
            //Act
            List<Companies> newlist = registration.regcomp();
            //Assert
            Assert.AreEqual(1, newlist.Count);
        }

        [TestMethod]
        public void Test_RegcompMethodWhenCalledToAddTwoCompanies_CompanyListWillEqualTwo()
        {
            //Arrange
            Mock<DatabaseReader> mockDBreader = new Mock<DatabaseReader>();
            Mock<List<Companies>> emptymockCoList = new Mock<List<Companies>>();
            mockDBreader.Setup(r => r.ReadDatabase()).Returns(emptymockCoList.Object);
            Register registration = new Register("Barnes & Noble", mockDBreader.Object);
            Register registration1 = new Register("Waterstones", mockDBreader.Object);
            //Act
            List<Companies> newlist = registration1.regcomp();
            //Assert
            Assert.AreEqual(2, newlist.Count);
        }

        [TestMethod]
        public void Test_RegcompMethodWhenCalled_WillNotAddToTheCompanyListACompanyWithTheSameName()
        {
            //Arrange
            Mock<DatabaseReader> mockDBreader = new Mock<DatabaseReader>();
            Mock<List<Companies>> emptymockCoList = new Mock<List<Companies>>();
            mockDBreader.Setup(r => r.ReadDatabase()).Returns(emptymockCoList.Object);
            Register registration = new Register("Barnes & Noble", mockDBreader.Object);
            Register registration1 = new Register("Barnes & Noble", mockDBreader.Object);
            List<Companies> newlist = registration1.regcomp();
            //Act

            //Assert
            Assert.AreEqual(1, newlist.Count);
        }


    }
}
