/*Program to multiply input numbers
Brian Willis
13/11/2012
*/

#include <stdio.h>
#define SIZE 5

main()
{
	int ar1[SIZE];
	int ar2[SIZE];
	int i;
	int product;
	
	for (i=0;i<SIZE;i++)
	{
		printf ("Please input a value for ar1[%d].\n", i);
		scanf ("%d", &ar1[i]);
	}
	
	for (i=0;i<SIZE;i++)
	{
		printf ("Please input a value for ar2[%d].\n", i);
		scanf ("%d", &ar2[i]);
	}
	
	for (i=0;i<SIZE;i++)
	{
		product=ar1[i]*ar2[i];
		printf ("\nar1[%d]*ar2[%d]=%d", i, i, product);
	}
	
	flushall();
	getchar();
}