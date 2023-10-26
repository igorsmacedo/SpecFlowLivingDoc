Feature: Teste

Calcula a soma de dois números

#@DataSource:Calculos.xlsx @DataSet:Soma
#Scenario: Soma de dois números através de arquivo externo
#	Given Que tenho dois numeros, sendo eles o numero "<numero1>" e o número "<numero2>"
#	When somado os dois números
#	Then então a soma deles deve ser "<resultado>"



Scenario: Soma de dois números através de exemplo
	Given Que tenho dois numeros, sendo eles o numero "<numero1>" e o número "<numero2>"
	When somado os dois números
	Then então a soma deles deve ser "<resultado>"

Examples:
	| numero1 | numero2 | resultado |
	| 1       | 1       | 2         |
	| 10      | 10      | 20        |
	| 100     | 100     | 200       |
	| 1000    | 1000    | 2000      |
