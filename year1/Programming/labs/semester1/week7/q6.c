/*Program to sort input numbers by size
Brian Willis
30/10/2012
*/

#include <stdio.h>
#define SIZE 3

main()
{
	int input[SIZE];
	int order[SIZE];
	int i;
	int o;
	
	for (o=0;o<SIZE;o++)
	{
		order[o]=-9999;
	}
	
	printf ("Please input %d different numbers.\n", SIZE);
	
	for (i=0;i<SIZE;i++)
	{
		scanf ("%d", &input[i]);
	}
	
	for (o=0;o<SIZE;o++)
	{
		for (i=0;i<SIZE;i++)
		{
			if (input[i]>order[SIZE-(o+1)])
			{
				order[SIZE-(o+1)]=input[i];
			}
		}
		
		for (i=0;i<SIZE;i++)
		{
			if (input[i]==order[o])
			{
				input[i]=-10000;
			}
		}
	}
	
	printf ("Ordered from smallest to largest, they are:");
	
	for (i=0;i<SIZE;i++)
	{
		printf (" %d", order[i]);
	}
	
	flushall();
	getchar();
}