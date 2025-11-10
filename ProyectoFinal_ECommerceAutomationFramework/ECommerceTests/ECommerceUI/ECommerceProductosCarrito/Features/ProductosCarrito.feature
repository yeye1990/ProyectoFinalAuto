Feature: Validate adding products to the shopping cart in the E-Commerce application

Background:
  Given The user logs into the system with valid credentials

Scenario: Add products to the shopping cart
  Given The user selects each product they want to purchase from the list
  When The user finishes adding the products and clicks the shopping cart button
  Then The user can verify each product added to the shopping cart
