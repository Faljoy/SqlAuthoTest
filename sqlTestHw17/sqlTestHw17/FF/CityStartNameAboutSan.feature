Feature: CheckCityWhereNameLikeSan...
As a customer
i want to see customer who live in San..
in order to i can send them their order

@city @tablePersons @cityLikeSan
Scenario:ScenarioAboutSearchCityWhereNameLikeSan
	When i chose in table "Persons" all results, where name of city like "San"
	Then i see city which start with "San"