using System;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace HtmlAcademyChecker.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var dao = new Mock<IHtmlAcademyDAO>();
            dao.Setup((x) => x.Load()).Returns(new Collection<HtmlAcademyProfile>() { new HtmlAcademyProfile(18446) });
            IProfileUpdater updater = new ProfileUpdater(dao.Object, new HtmlAcademyProfileReader(), new HtmlAcademyProfileDownloader());
            updater.UpdateAllProfiles();
        }
    }
}
