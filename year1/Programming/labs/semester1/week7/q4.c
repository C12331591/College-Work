/*Program to put input numbers into two arrays forwards and backwards
Brian Willis
30/10/2012
*/

#include <stdio.h>
#define SIZE 5

main()
{
	int input[SIZE];
	int rev[SIZE];
	int i;
	
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
	
	for (i=0;i<SIZE;i++)
	{
		rev[SIZE-(i+1)]=input[i];
	}//end for
	
	printf ("\nThe reverse is:");
	
	for (i=0;i<SIZE;i++)
	{
		printf (" %d", rev[i]);
	}//end for
	
	flushall();
	getchar();
}//end main