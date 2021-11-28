Feature: DataBaseWorksAboutDi_database2

@mytag
Scenario Outline: It is scenario 2
	When я выбираю сумму больше 200, сортирую по спаданию айди в таблице "Orders"
	Then я вижу первый ади больше последнего и сумма больше 200
