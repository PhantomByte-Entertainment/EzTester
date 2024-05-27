using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
public interface TestInterface
{
    void TestMethod();
    int TestMethodWithReturn();
    float TestMethodWithReturnFloat();
}
public class TestClass : TestInterface
{
    public void TestMethod()
    {
        Debug.Log("Test Method Called");
    }
    public int TestMethodWithReturn()
    {
        return 1;
    }
    public float TestMethodWithReturnFloat()
    {
        return 1.0f+TestMethodWithReturn();
    }
}
public class TestForTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void TestForTestVoid()
    {
        //Mock testclass
        Moq.Mock<TestInterface> mock = new Moq.Mock<TestInterface>();//create a mock object of TestInterface
        mock.Setup(x => x.TestMethod());//setup the mock object to call TestMethod
        mock.Object.TestMethod();//call the TestMethod
        mock.Verify(x => x.TestMethod(), Moq.Times.Once());//verify that the TestMethod was called once
    
    }
    [Test]
    public void TestForTestWithReturn()
    {
        //Mock testclass
        Moq.Mock<TestInterface> mock = new Moq.Mock<TestInterface>();//create a mock object of TestInterface
        mock.Setup(x => x.TestMethodWithReturn()).Returns(2);//setup the mock object to call TestMethodWithReturn and return 1
        Assert.AreEqual(2, mock.Object.TestMethodWithReturn());//call the TestMethodWithReturn and assert that it returns 1
        mock.Verify(x => x.TestMethodWithReturn(), Moq.Times.Once());//verify that the TestMethodWithReturn was called once
    }

    [Test]
    public void TestForTestWithReturnFloat()
    {
        //Mock testclass
        Moq.Mock<TestInterface> mock = new Moq.Mock<TestInterface>();//create a mock object of TestInterface
        mock.Setup(x => x.TestMethodWithReturnFloat()).Returns(2.0f);//setup the mock object to call TestMethodWithReturnFloat and return 1.0f
        Assert.AreEqual(2.0f, mock.Object.TestMethodWithReturnFloat());//call the TestMethodWithReturnFloat and assert that it returns 1.0f
        mock.Verify(x => x.TestMethodWithReturnFloat(), Moq.Times.Once());//verify that the TestMethodWithReturnFloat was called once
    }


}
