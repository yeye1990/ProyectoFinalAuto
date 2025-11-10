Feature: Validate login scenario in the E-Commerce application

Scenario: Login to the application with valid credentials
   Given That when the page loads the user should see the title "Swag Labs"
   When The user enters valid credentials
   And The user Clicks the login button
   Then The user should see the products page with the title "Products"
