/*Program to display entered numbers in different orders
Brian Willis
30/10/2012
*/

#include <stdio.h>
#define SIZE 4

main()
{
	int input[SIZE];
	int i;
	int transfer;
	
	printf ("Please input %d numbers.\n", SIZE);
	
	for (i=0;i<SIZE;i++)
	{
		scanf ("%d", &input[i]);
	}//end for
	
	printf ("\nYou entered:");
	
	for (i=0;i<SIZE;i++)
	{
		printf (" %d", input[i]);
	}//end for
	
	for (i=0;i<SIZE;i=i+2)
	{
		transfer=input[i];
		input[i]=input[i+1];
		input[i+1]=transfer;
	}//end for
	
	printf ("\nThe new order is:");
	
	for (i=0;i<SIZE;i++)
	{
		printf (" %d", input[i]);
	}//end for
	
	flushall();
	getchar();
}//end main