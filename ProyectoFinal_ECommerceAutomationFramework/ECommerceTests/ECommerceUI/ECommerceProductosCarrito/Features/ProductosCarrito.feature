Feature: Product cart functionality
Background: 
	Given The user is logged in
	And The user has added products to the cart
	And The user clicks on the cart icon
  Scenario: Remove a product from the cart
	When The user removes a product from the cart
	Then the product should no longer appear in the cart