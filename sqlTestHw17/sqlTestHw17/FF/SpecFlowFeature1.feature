Feature: DataBaseWorksAboutDi_database

@mytag
Scenario Outline: It is scenario 1
	When я выбираю парные значения aйди, ограничиваю выведение 5 строками в таблице "Persons"
	Then я вижу парные айди и только 5 строк
