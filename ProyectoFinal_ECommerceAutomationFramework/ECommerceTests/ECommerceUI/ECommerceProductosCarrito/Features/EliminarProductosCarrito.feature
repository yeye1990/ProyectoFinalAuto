Feature: Product cart functionality
Background: 
	Given The user logs into the system correctly
	And The user has added products to the cart
	And The user clicks on the cart icon
  Scenario: Remove a product from the cart
	When The user removes a product from the cart
	Then The user verifies that the selected products have been removed from the cart