/*Program to display input numbers
Brian WIllis
13/11/2012
*/

#include <stdio.h>
#define SIZE 15

main()
{
	int ar[SIZE];
	int i;
	
	for (i=0;i<SIZE;i++)
	{
		printf ("Please enter a number.\n");
		scanf ("%d", &ar[i]);
		printf ("\n");
	}
	
	for (i=0;i<SIZE;i++)
	{
		printf ("\n%d", ar[i]);
	}
	
	printf ("\n\n");
	
	for (i=0;i<SIZE;i++)
	{
		printf ("%d, ", ar[i]);
	}
	
	printf ("\n\n");
	
	for (i=SIZE-1;i>=0;i=i-1)
	{
		printf ("%d, ", ar[i]);
	}
	
	flushall();
	getchar();
}