/*Program to display 3 temperatures in Celcius and Fahrenheit
Brian Willis
30/10/2012
*/

#include <stdio.h>
#define SIZE 3

main()
{
	float fah[SIZE];
	float cel[SIZE];
	int i;
	
	printf ("Please input %d temperatures in Fahrenheit.\n", SIZE);
	
	for (i=0;i<SIZE;i++)
	{
		scanf ("%f", &fah[i]);
	}//end for
	
	for (i=0;i<SIZE;i++)
	{
		cel[i]=(fah[i]-32.0)*(5.0/9.0);
	}//end for
	
	for (i=0;i<SIZE;i++)
	{
		printf ("\n%f degrees Fahrenheit is %f degrees Celcius.", fah[i], cel[i]);
	}//end for
	
	flushall();
	getchar();
}//end main