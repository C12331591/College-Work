/*Program to convert 5 input values in Euro to Dollars
Brian Willis
11/12/2012
*/

#include <stdio.h>
#define SIZE 5
#define CONV 1.3

main()
{
	float euro[SIZE];
	float dollar[SIZE];
	int i;
	
	for (i=0;i<SIZE;i++)
	{
		printf ("Please enter a value in Euro.\n");
		scanf ("%f", &euro[i]);
	}//end for
	
	for (i=0;i<SIZE;i++)
	{
		dollar[i]=euro[i];
	}//end for
	
	for (i=0;i<SIZE;i++)
	{
		dollar[i]=dollar[i]*CONV;
	}//end for
	
	for (i=0;i<SIZE;i++)
	{
		printf ("\n%f Euro = %f Dollars\n", euro[i], dollar[i]);
	}//end for
	
	flushall();
	getchar();
}// end main()