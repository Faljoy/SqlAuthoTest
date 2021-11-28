Feature: ChosePairedIdAndLimit5Rows
As a user
I want to sort a paired id and limit 5 rows 
in order to see a paired first 5 customers id users

@id @tablePersons @Limit @pairedId
Scenario: LimitRowsAndPairedIdInPersonsTables
	When I chose paired id, limit output 5 rows in table "Persons"
	Then I see paired Id and Limit 5 rows