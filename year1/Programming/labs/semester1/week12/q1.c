/*Program to calculate values of a circle using pointers
Brian Willis
4/12/2012
*/

#include <stdio.h>
#define PI 3.14

main()
{
	float radius;
	float diameter;
	float area;
	
	float *ptrrad;
	float *ptrdia;
	float *ptrar;
	
	ptrrad=&radius;
	ptrdia=&diameter;
	ptrar=&area;
	
	printf ("Please input a value for the radius.\n");
	scanf ("%f", &*(ptrrad));
	
	*ptrdia=(*ptrrad)*2;
	*ptrar=(PI)*((*ptrrad)*(*ptrrad));
	
	printf ("\n\nThe diameter of the circle is %f.", *(ptrdia));
	printf ("\nThe area of the circle is %f.", *(ptrar));
	
	flushall();
	getchar();
}//end main