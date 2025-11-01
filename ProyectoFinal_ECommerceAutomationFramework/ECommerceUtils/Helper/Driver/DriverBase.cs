using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace ProyectoFinal_ECommerceAutomationFramework.ECommerceUtils.Helper.Driver
{
    public class DriverBase
    {
        protected IWebDriver Driver;
        private readonly string navegador = "chrome";
        private readonly string URL = "https://www.saucedemo.com/";

        [SetUp]
        public void Setup()
        {
            // --- Selección de navegador ---
            if (navegador.ToLower() == "firefox")
            {
                var firefoxOptions = new FirefoxOptions();
                firefoxOptions.AddArgument("--start-maximized");
                Driver = new FirefoxDriver(firefoxOptions);
            }
            else if (navegador.ToLower() == "edge")
            {
                var edgeOptions = new EdgeOptions();
                edgeOptions.AddArgument("--start-maximized");
                Driver = new EdgeDriver(edgeOptions);
            }
            else // Chrome por defecto
            {
                var chromeOptions = new ChromeOptions();
                chromeOptions.AddArgument("--start-maximized");
                Driver = new ChromeDriver(chromeOptions);
            }

            // --- Configuración inicial ---
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(URL);
        }

        [TearDown]
            public void TearDown()
            {
                if (Driver != null)
                {
                    System.Threading.Thread.Sleep(5000);
                    Driver.Quit();
                    Driver.Dispose();
                }
            }
        }
    } 
