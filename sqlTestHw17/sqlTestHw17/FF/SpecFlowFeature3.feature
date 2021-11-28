Feature: DataBaseWorksAboutDi_database3

@mytag
Scenario Outline: It is scenario 3
	When я меняю idOrders в таблице "Orders" на рандомное значение, там где id 13 а сумма 523.10  
	Then я вижу idOrders c новым значением, там где id 13 а сумма 523.10 
