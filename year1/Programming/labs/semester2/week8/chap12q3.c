/*Program to read and write to a structure variable
Brian Willis
19/3/2013
*/

#include <stdio.h>
#include <string.h>

struct stock_record
{
	int no;
	char description[21];
	float price;
	int quantity;
};

struct stock_record stock_item;

main()
{
	//Assigning a value to the members
	stock_item.no=1;
	strcpy(stock_item.description, "An item");
	stock_item.price=23.45;
	stock_item.quantity=678;
	
	//Allowing input of new values
	printf ("Input the number.\n");
	scanf ("%d", &stock_item.no);
	flushall();
	printf ("Input the description.\n");
	gets(stock_item.description);
	printf ("Input the price.\n");
	scanf ("%f", &stock_item.price);
	printf ("Input the quantity.\n");
	scanf ("%d", &stock_item.quantity);
	
	//Displaying the values
	printf ("\nNo is %d", stock_item.no);
	printf ("\nDescription is %s", stock_item.description);
	printf ("\nPrice is %f", stock_item.price);
	printf ("\nQuantity is %d", stock_item.quantity);
	
	flushall();
	getchar();
}//end main