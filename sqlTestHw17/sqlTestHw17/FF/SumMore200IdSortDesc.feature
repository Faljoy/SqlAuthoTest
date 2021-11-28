Feature: ShowOrdersWhereSumMoreThan200SortedByDESC
As a employee 
i want to see order where summ more than 200
in order to send order first priority

@sumOrders @tableOrders @id
Scenario: ChoseSummMoreThan200SortDesc
	When I chose summ more than 200 sort by DESC id in tables "Orders"
	Then I see first Id more than last and sum more than 200