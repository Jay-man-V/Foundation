////-----------------------------------------------------------------------
//// <copyright file="WebApiProcessTests.cs" company="JDV Software Ltd">
////     Copyright (c) JDV Software Ltd. All rights reserved.
//// </copyright>
////-----------------------------------------------------------------------

//using System;
//using System.Text;
//using System.Threading.Tasks;

//using NUnit.Framework;

//using Newtonsoft.Json;

//using NSubstitute;

//using Foundation.BusinessProcess;
//using Foundation.Common;
//using Foundation.Interfaces;

//using Foundation.Tests.Unit.Support;

//namespace Foundation.Tests.Unit.Foundation.BusinessProcess.CoreTests
//{
//    /// <summary>
//    /// Summary description for WebApiProcessTests
//    /// </summary>
//    [TestFixture]
//    public class WebApiProcessTests : UnitTestBase
//    {
//        [TestCase]
//        public void Test_DownloadString()
//        {
//            String expectedResponse = LocationUtils.GetFunctionName();
//            IWebApi webApi = Substitute.For<IWebApi>();
//            webApi.DownloadString(Arg.Any<IFileTransferSettings>()).Returns(expectedResponse);
//            webApi.DownloadStringAsync(Arg.Any<IFileTransferSettings>()).Returns(expectedResponse);

//            WebApiProcess webApiProcess = new WebApiProcess(webApi);

//            String actualResponse = webApiProcess.DownloadData("https://tempuri.org");

//            Assert.That(actualResponse, Is.EqualTo(expectedResponse));
//        }

//        [TestCase]
//        [DeploymentItem(@".Support\SampleDocuments\WebResponse.json", @".Support\SampleDocuments\")]
//        public void Test_DownloadString_JsonData()
//        {
//            Encoding encoding = Encoding.UTF8;
//            IFileService fileService = CoreInstance.IoC.Get<IFileService>();
//            String expectedResponse = fileApi.GetFileContentsAsText(@".Support\SampleDocuments\WebResponse.json", encoding);
//            IWebApi webApi = Substitute.For<IWebApi>();
//            webApi.DownloadString(Arg.Any<IFileTransferSettings>()).Returns(expectedResponse);
//            webApi.DownloadStringAsync(Arg.Any<IFileTransferSettings>()).Returns(expectedResponse);

//            RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(expectedResponse);

//            WebApiProcess webApiProcess = new WebApiProcess(webApi);

//            RootObject actualResponse = webApiProcess.DownloadJsonData<RootObject>("https://tempuri.org");

//            Assert.That(actualResponse.EnglandAndWales.Events.Count, Is.EqualTo(rootObject.EnglandAndWales.Events.Count));
//            Assert.That(actualResponse.NorthernIreland.Events.Count, Is.EqualTo(rootObject.NorthernIreland.Events.Count));
//            Assert.That(actualResponse.Scotland.Events.Count, Is.EqualTo(rootObject.Scotland.Events.Count));
//        }

//        [TestCase]
//        public void Test_DownloadStringAsync()
//        {
//            String expectedResponse = LocationUtils.GetFunctionName();
//            IWebApi webApi = Substitute.For<IWebApi>();
//            webApi.DownloadString(Arg.Any<IFileTransferSettings>()).Returns(expectedResponse);
//            webApi.DownloadStringAsync(Arg.Any<IFileTransferSettings>()).Returns(expectedResponse);

//            WebApiProcess webApiProcess = new WebApiProcess(webApi);

//            Task<String> t = webApiProcess.DownloadDataAsync("https://tempuri.org");
//            t.Wait();
//            String actualResponse = t.Result;

//            Assert.That(actualResponse, Is.EqualTo(expectedResponse));
//        }

//        [TestCase]
//        [DeploymentItem(@".Support\SampleDocuments\WebResponse.json", @".Support\SampleDocuments\")]
//        public void Test_DownloadStringAsync_JsonData()
//        {
//            Encoding encoding = Encoding.UTF8;
//            IFileService fileService = CoreInstance.IoC.Get<IFileService>();
//            String expectedResponse = fileApi.GetFileContentsAsText(@".Support\SampleDocuments\WebResponse.json", encoding);
//            IWebApi webApi = Substitute.For<IWebApi>();
//            webApi.DownloadString(Arg.Any<IFileTransferSettings>()).Returns(expectedResponse);
//            webApi.DownloadStringAsync(Arg.Any<IFileTransferSettings>()).Returns(expectedResponse);

//            RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(expectedResponse);

//            WebApiProcess webApiProcess = new WebApiProcess(webApi);

//            Task<RootObject> t = webApiProcess.DownloadJsonDataAsync<RootObject>("https://tempuri.org");
//            t.Wait();
//            RootObject actualResponse = t.Result;

//            Assert.That(actualResponse.EnglandAndWales.Events.Count, Is.EqualTo(rootObject.EnglandAndWales.Events.Count));
//            Assert.That(actualResponse.NorthernIreland.Events.Count, Is.EqualTo(rootObject.NorthernIreland.Events.Count));
//            Assert.That(actualResponse.Scotland.Events.Count, Is.EqualTo(rootObject.Scotland.Events.Count));
//        }
//    }
//}
