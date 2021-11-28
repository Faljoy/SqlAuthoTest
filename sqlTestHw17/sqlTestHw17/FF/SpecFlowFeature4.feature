Feature: DataBaseWorksAboutDi_database4

@mytag
Scenario Outline: It is scenario 4
	When я выбираю в таблице "Persons" все результаты, где возраст покупателей меньше 50 и больше 30
	Then я вижу покупателей с возрастом больше 30
