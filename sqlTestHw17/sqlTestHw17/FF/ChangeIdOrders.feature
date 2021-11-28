Feature: UpdateIdOrdersInOrdersTable
As a employee
I want to change idOrders
In order to i can update id on new

@id @tableOrders @sum
Scenario: ChangeIdOrders
	When I change idOrders in table "Orders" on random amount where id 13 and sum 523.10  
	Then I see idOrders with new value, where id 13 and sum 523.10 