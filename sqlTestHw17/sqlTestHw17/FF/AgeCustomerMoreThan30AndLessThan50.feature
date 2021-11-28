Feature: ChosePersonsAgeMoreThan30LessThan50
As a employee
i want to sort Customer age more than 30 and less than 50
in order to see a age statistics

@Age @tablePersons
Scenario: SortAgeMoreThan30AndLessThan50
	When I chose in table "Persons" all resultat, where age less than 50 and more than 30
	Then I see customers whose age more than 30 and less than 50