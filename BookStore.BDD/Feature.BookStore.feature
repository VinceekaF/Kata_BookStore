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
	When I add a book by its <title>
	Then in my cart I must see the book
	Examples:
	| title                                      |
	| 3. Harry Potter et le prisonnier d'Azkaban |
	| 5. Harry Potter et le prince de sang-mêlé  |
	
Scenario Outline: Computing the cart total price with discount
	When I add <book1>, <book2>, <book3>, <book4>, <book5>
	Then I have to see the total <price> with discount applied
	Examples: 
	| book1 | book2 | book3 | book4 | book5 | price |
	| 5		| 3		| 4		| 2		| 1		| 100.4 |
	| 2		| 0		| 2		| 0		| 1		| 36.8  |
	| 0		| 5		| 5		| 3		| 1		| 99.2  |
