using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ClassLibrary;
using System.Collections.Generic;


namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            TaskList taskList = new TaskList(new List<Task>(), "ABC");
            Assert.AreEqual(taskList.GetName(), "ABC");
        }
    }
}
