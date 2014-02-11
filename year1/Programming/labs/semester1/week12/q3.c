/*Program to access arrays using pointers
Brian Willis
4/12/2012
*/

#include <stdio.h>
#define SIZE 3

main()
{
	int ar1[SIZE];
	int ar2[SIZE];
	int i;
	
	for (i=0;i<SIZE;i++)
	{
		printf ("Please input a value for the first element.\n");
		scanf ("%d", &*(ar1+i));
		printf ("\n");
	}//end for
	
	for (i=0;i<SIZE;i++)
	{
		*(ar2+i)=*(ar1+i);
	}//end for
	
	for (i=0;i<SIZE;i++)
	{
		printf ("\nar1[%d]=%d	ar2[%d]=%d", i, *(ar1+i), i, *(ar2+i));
	}//end for
	
	flushall();
	getchar();
}//end main