@allure.epic:Login
@allure.parentSuite:UI
@allure.suite:LoginInvalido
Feature: Login

@critical
@allure.story:LoginInvalido
Scenario: Unsuccessful login with invalid credentials
  Given The user is on the login page
  When The user enters invalid username and password from testdata "InvalidCredentials"
  And The user clicks the login button
  Then An error message "Epic sadface: Username and password do not match any user in this service" should be displayed