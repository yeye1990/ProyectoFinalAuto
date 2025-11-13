@allure.epic:CheckoutCarrito
@allure.parentSuite:UI
@allure.suite:CheckoutCarrito
Feature: Validate the Checkout process of the shopping cart in the E-Commerce application

Background:
  Given The user logs into the system with valid credential
  And The user adds products to the cart in order to make a purchase

@critical
@allure.story:CheckoutCompleto
Scenario: Successfully completing the shopping cart checkout
  Given The user has selected the products and clicks the "Checkout" button
  Then The user should see the screen with the title "Checkout: Your Information"
  When The user enters their required personal information for the checkout
  And The user clicks the "Continue" button
  Then The user should see the screen with the title "Checkout: Overview"
  And The user should verify the total sum of the products
  And The user should verify the total amount including tax
  When The user clicks the "Finish" button
  Then The user should see the screen with the message "Thank you for your order!"

