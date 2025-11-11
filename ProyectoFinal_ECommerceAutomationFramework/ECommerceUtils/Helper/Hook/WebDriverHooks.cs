using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Reqnroll;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;

namespace ProyectoFinal_ECommerceAutomationFramework.ECommerceUtils.Helper.Hook
{
    [Binding]
    public class WebDriverHooks
    {
        private readonly ScenarioContext _scenarioContext;
        protected IWebDriver? Driver;
        private readonly string navegador = "firefox";
        private readonly string URL = "https://www.saucedemo.com/";

        public WebDriverHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            // --- Selección de navegador ---
            if (navegador.ToLower() == "firefox")
            {
                var firefoxOptions = new FirefoxOptions();
                firefoxOptions.AddArgument("--start-maximized");
                firefoxOptions.AddArgument("--disable-notifications");
                firefoxOptions.AddArgument("--disable-infobars");

                Driver = new FirefoxDriver(firefoxOptions);
                _scenarioContext.Set<IWebDriver>(Driver);
            }
            else if (navegador.ToLower() == "edge")
            {
                var edgeOptions = new EdgeOptions();
                edgeOptions.AddArgument("--start-maximized");
                edgeOptions.AddArgument("--disable-notifications");
                edgeOptions.AddArgument("--disable-infobars");

                Driver = new EdgeDriver(edgeOptions);
                _scenarioContext.Set<IWebDriver>(Driver);
            }
            else // Chrome por defecto
            {
                var chromeOptions = new ChromeOptions();
                chromeOptions.AddArgument("--start-maximized");
                chromeOptions.AddArgument("--disable-notifications");
                chromeOptions.AddArgument("--disable-infobars");

                Driver = new ChromeDriver(chromeOptions);
                _scenarioContext.Set<IWebDriver>(Driver);
            }

            // --- Configuración inicial ---
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(URL);

        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (_scenarioContext.TryGetValue<IWebDriver>(out var driver))
            {
                driver.Quit();
                driver.Dispose();
            }
        }


    }
}
