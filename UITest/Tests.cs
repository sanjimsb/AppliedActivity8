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

        [Test]
        [Category("UI")]
        public void RollButtonsAreDisplayed()
        {
            AppResult[] results = app.Query(c => c.Property("text").Like("Display * result*"));
            Assert.IsTrue(results.Length == 2);
        }

        [Test]
        [Category("UI")]
        public void ButtonsCanBeClickedAndResultsAreDisplayed()
        {
            app.Tap(c => c.Marked("d4"));
            app.Tap(c => c.Marked("Display one result"));

            AppResult[] result1 = app.Query(c => c.Property("text").Like("*"));
            Assert.IsTrue(result1.Length == 1);

            app.Tap(c => c.Marked("d4"));
            app.Tap(c => c.Marked("Display two results"));

            AppResult[] results2 = app.Query(c => c.Property("text").Like("*"));
            Assert.IsTrue(results2.Length == 2);
        }
    }
}
