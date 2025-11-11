using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;


namespace ProyectoFinal_ECommerceAutomationFramework.ECommerceUtils.Helper.Wait
{
    public class WaitBase
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private readonly int time = 10;

        // Constructor: recibe el driver y opcionalmente timeout en segundos
        public WaitBase(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(time));
        }

        public untilTime Until<untilTime>(Func<IWebDriver, untilTime> condition)
        {
            return _wait.Until(condition);
            }
    }
}
