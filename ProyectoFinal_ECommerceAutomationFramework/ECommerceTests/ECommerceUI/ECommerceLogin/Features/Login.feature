@allure.epic:Login
@allure.parentSuite:UI
@allure.suite:Login
Feature: Validate login scenario in the E-Commerce application

@critical
@allure.story:LoginValido
Scenario Outline: Login to the application with valid credentials
  Given That when the page loads the user should see the title "Swag Labs"
  When The user enters valid credentials
  And The user clicks the login button
  Then The user should see the products page with the title "Products"