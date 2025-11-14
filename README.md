# Proyecto Final: SOFT-740 Automatización de Pruebas en .NET


## Integrantes
- María Alejandra Fonseca Arguedas
- Yeison Rojas Sancho


## Descripción
Este proyecto se basa en el sistema **SauceDemo**, un sitio de e-commerce ficticio diseñado para pruebas automatizadas. El repositorio contiene un framework de automatización en **.NET**, que incluye pruebas unitarias, funcionales y de aceptación basadas en **BDD (SpecFlow)**.


El propósito del proyecto es demostrar la aplicación de buenas prácticas de automatización, patrones de diseño, Page Object Model, integración con Selenium WebDriver y ejecución de pruebas en un entorno estructurado.

## Arquitectura del Framework
El framework de automatización está desarrollado en **.NET 9** con **Selenium WebDriver**, **NUnit** y **SpecFlow**, siguiendo una arquitectura modular basada en el **patrón Page Object Model (POM)**.  
Esta estructura facilita la mantenibilidad, escalabilidad y reutilización del código, separando claramente las responsabilidades entre lógica de negocio, interfaz, utilidades y pruebas.

### Estructura general del proyecto

ProyectoFinal_ECommerceAutomationFramework/
•	ECommerceCore/ # Capa de lógica base y modelos de negocio
o	Models/ # Clases que representan estructuras de datos
o	Services/ # Servicios generales e interfaces reutilizables
o	Interfaces/
•	ECommercePages/ # Capa que implementa el patrón Page Object Model
o	ECommerceLogin/ # Páginas, acciones y waits para el login
o	ECommerceProductosCarrito/ # Páginas, acciones y waits del carrito
o	ECommerceCheckOutCarrito/ # Páginas, acciones y waits del checkout
•	ECommerceUtils/ # Capa de utilidades y soporte
o	Helper/
	Driver/ # Inicialización y control del WebDriver
	Hook/ # Configuración de hooks globales
	JsonReader/ # Lectura de datos desde archivos JSON 
	Screenshot/ # Captura de evidencias visuales
	Wait/ # Métodos de espera explícita e implícita
•	ECommerceTests/ # Capa de pruebas automatizadas
•	ECommerceUI/ # Pruebas funcionales y de aceptación
o	ECommerceLogin/ # Escenarios BDD para login
o	ECommerceProductosCarrito/ # Escenarios BDD para agregar/eliminar productos
o	ECommerceCheckOutCarrito/ # Escenarios BDD para checkout
•	ECommerceUnitTest/ # (Opcional) Pruebas unitarias aisladas
•	allureconfig.json
ProyectoFinal_ECommerceAutomationFramework.sln # Solución principal


### Componentes clave

- **Page Objects:** encapsulan los elementos y acciones de cada página web.  
- **Steps:** conectan los pasos definidos en los archivos `.feature` con las acciones del framework.  
- **Features:** describen los escenarios BDD en lenguaje natural (Gherkin).  
- **Data:** provee datos de entrada en formato JSON para escenarios parametrizados.  
- **Reports:** Allure.  
- **Hooks:** controlan la inicialización y finalización del navegador y de los escenarios.

## Instalación
Para clonar y ejecutar el proyecto, utilice los siguientes comandos:


```bash
git clone https://github.com/yeye1990/ProyectoFinalAuto
cd ProyectoFinal_ECommerceAutomationFramework
dotnet restore
dotnet build
dotnet test 
allure serve .\bin\Debug\net9.0\allure-results
