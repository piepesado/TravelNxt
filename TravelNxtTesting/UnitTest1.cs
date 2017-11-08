using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System.Threading;

namespace TravelNxtTesting
{
    [TestFixture]
    public class UnitTest1
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://managedemo.travelnxt.com/login?cid=20033");
        }

        [Test]
        public void LogIn()
        {
            IWebElement userName = driver.FindElement(By.Id("ucPWP_ctl07_2524_ctl00_2597_txtUserName"));
            userName.SendKeys("dnan@travelleaders.com ");

            IWebElement password = driver.FindElement(By.Id("ucPWP_ctl07_2524_ctl00_2597_txtPassword"));
            password.SendKeys("P@ss123");
            /*
            int i = 0;
            do
            {
                password.SendKeys(Keys.Tab);
                i++;
            } while (i < 3);
            */            

            IWebElement captchaField = driver.FindElement(By.Id("recaptcha_response_field"));
            captchaField.Click();

            //IWebElement cid = driver.FindElement(By.Id("ucPWP_ctl07_2524_ctl00_2597_txtContextId"));
            //cid.SendKeys("20033");

            //Allows 10 seconds to complete captha
            Thread.Sleep(15000);

            driver.FindElement(By.Id("ucPWP_ctl07_2524_ctl00_2597_lnkBtnSignIn")).Click();

            Thread.Sleep(3000);
        }

        [Test]
        public void EnterFrontOffice()
        {
            driver.FindElement(By.Id("ucPWP_ctl07_2517_lnkFO")).Click();

        }

        [Test]
        public void SelectFlightModule()
        {
            driver.FindElement(By.Id("liflightTab")).Click();
        }

        [Test]
        public void BookFlightRountTrip()
        {
            //Complete Fields
            IWebElement fromField = driver.FindElement(By.Id("ucPWP_ctl14_12066_txtFlightDepartLoc"));
            fromField.SendKeys("Montevideo");
            fromField.SendKeys(Keys.Tab);

            IWebElement toField = driver.FindElement(By.Id("ucPWP_ctl14_12066_txtFlightArriveLoc"));
            toField.SendKeys("Melbourne");
            toField.SendKeys(Keys.Tab);

            //Date pickers
            IWebElement leaveDatePicker = driver.FindElement(By.Id("ucPWP_ctl14_12066_txtFlightDepartDate"));
            leaveDatePicker.Click();
            leaveDatePicker.SendKeys("03/03/2018");

            IWebElement returnDatePicker = driver.FindElement(By.Id("ucPWP_ctl14_12066_txtFlightArriveDate"));
            returnDatePicker.Click();
            returnDatePicker.SendKeys("20/03/2018");

            //Dropdowns
            IWebElement leaveTimeCombo = driver.FindElement(By.Id("ucPWP_ctl14_12066_ddlFlightDepartTime"));
            SelectElement oLeaveTime = new SelectElement(leaveTimeCombo);
            oLeaveTime.SelectByValue("3:00 PM");

            IWebElement returnTime = driver.FindElement(By.Id("ucPWP_ctl14_12066_ddlFlightArriveTime"));
            SelectElement oReturnTime = new SelectElement(returnTime);
            oReturnTime.SelectByIndex(5);

            //Checkbox

        }


        [TearDown]
        public void Quit()
        {
            driver.Quit();
        }
    }
}
