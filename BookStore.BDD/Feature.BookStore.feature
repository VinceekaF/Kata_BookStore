Feature: Feature
	In order to order a book
	As a customer
	I want to buy a book and have it confirmed

Scenario Outline: Show books when a visitor arrive
	When I open the web site
	Then The page must show me the correct books <number>
	Examples: 
	| number |
	| 5      |

Scenario Outline: Each time a customer add a book, it must be added in the cart
	Given I have a book <title>:
	When I add it
	Then in my cart I must see the book <title>
	Examples:
	| title									     |
	| 3. Harry Potter et le prisonnier d'Azkaban |
	

