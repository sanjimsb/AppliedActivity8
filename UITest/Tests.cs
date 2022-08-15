using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITest
{
    [TestFixture(Platform.Android)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void WelcomeTextIsDisplayed()
        {
            AppResult[] results = app.WaitForElement(c => c.Marked("Welcome to Xamarin.Forms!"));
            Assert.IsTrue(results.Any());
        }

        [Test]
        [Category("UI")]
        public void PromptLabelIsDisplayed()
        {
            AppResult[] results = app.WaitForElement(c => c.Marked("Select a Die:"  ));
            Assert.IsTrue(results.Any());
        }

        [Test]
        [Category("UI")]
        public void OptionsAreDisplayed()
        {
            Assert.IsTrue(app.Query(c => c.Marked("d4")).Any());
            Assert.IsTrue(app.Query(c => c.Marked("d6")).Any());
            Assert.IsTrue(app.Query(c => c.Marked("d8")).Any());
            Assert.IsTrue(app.Query(c => c.Marked("d10")).Any());
            Assert.IsTrue(app.Query(c => c.Marked("d12")).Any());
            AppResult[] results = app.Query(c => c.Marked("d20"));
            Assert.IsTrue(results.Any());
        }

        [Test]
        [Category("UI")]
        public void OptionsCanBeChecked()
        {
            app.Tap(c => c.Marked("d4"));

            Assert.IsTrue(app.Query(c => c.Marked("d4").Invoke("isChecked")).FirstOrDefault().Equals(true));

            app.Tap(c => c.Marked("d6"));

            Assert.IsTrue(app.Query(c => c.Marked("d6").Invoke("isChecked")).FirstOrDefault().Equals(true));

            Assert.IsTrue(app.Query(c => c.Marked("d4").Invoke("isChecked")).FirstOrDefault().Equals(false));
        }
    }
}
