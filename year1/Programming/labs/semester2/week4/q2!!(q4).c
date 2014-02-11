/*Program to double input numbers using a function and pass by reference
Brian Willis
19/2/2013
*/

#include <stdio.h>

#define SIZE 5

void highest(int*);

main()
{
	int i;
	int ar[SIZE];
	
	for (i=0;i<SIZE;i++)
	{	
		printf ("Please input a value for element %d.\n", i);
		scanf ("%d", &ar[i]);
	}//end for
	
	highest(&ar[0]);
	
	for (i=0;i<SIZE;i++)
	{
		printf ("\n%d", ar[i]);
	}
	
	flushall();
	getchar();
}//end main()

void highest(int *rec)
{
	int i;
	
	for (i=0;i<SIZE;i++)
	{
		*(rec+i)=(*(rec+i)*2);
	}//end outer for
}//end highest()