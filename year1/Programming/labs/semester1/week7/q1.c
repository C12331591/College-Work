/*Program to put input numbers into two arrays
Brian Willis
30/10/2012
*/

#include <stdio.h>
#define SIZE 5

main()
{
	int input[SIZE];
	int transfer[SIZE];
	int i;
	
	printf ("Please input %d numbers.\n", SIZE);
	
	for (i=0;i<SIZE;i++)
	{
		scanf ("%d", &input[i]);
	}//end for
	
	for (i=0;i<SIZE;i++)
	{
		transfer[i]=input[i];
	}//end for
	
	printf ("\nThe contents of the first array are:");
	
	for (i=0;i<SIZE;i++)
	{
		printf (" %d", input[i]);
	}//end for
	
	printf ("\nThe contents of the second array are:");
	
	for (i=0;i<SIZE;i++)
	{
		printf (" %d", transfer[i]);
	}//end for
	
	flushall();
	getchar();
}//end main