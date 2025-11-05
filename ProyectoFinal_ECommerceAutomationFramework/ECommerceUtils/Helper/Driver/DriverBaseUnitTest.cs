using Moq;
using ProyectoFinal_ECommerceAutomationFramework.ECommerceCore.Services.Interfaces;
using ProyectoFinal_ECommerceAutomationFramework.ECommerceCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_ECommerceAutomationFramework.ECommerceUtils.Helper.Driver
{
    public class DriverBaseUnitTest
    {
        // Dependencias simuladas (mock)
        protected Mock<IPaymentService> _paymentServiceMock;
        protected Mock<INotificationService> _notificationServiceMock;

        // Instancia del sistema bajo prueba (SUT)
        protected OrderCalculator _calculator;


        /// <summary>
        /// Método que se ejecuta antes de cada prueba.
        /// Inicializa los mocks y crea una nueva instancia del OrderCalculator.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _paymentServiceMock = new Mock<IPaymentService>();
            _notificationServiceMock = new Mock<INotificationService>();

            // Se inyectan las dependencias simuladas en el constructor
            _calculator = new OrderCalculator(_paymentServiceMock.Object, _notificationServiceMock.Object);
        }
    }
}
