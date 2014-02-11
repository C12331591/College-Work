/*Program to calculate the area of a circle and square using pass by reference
Brian Willis
19/2/2013
*/

#include <stdio.h>

#define PI 3.14

void square(float*, float*);
void circle(float*, float*);

main()
{
	float side, sq_area, rad, cir_area;
	
	printf ("Please enter the length of a side of the square.\n");
	scanf ("%f", &side);
	printf ("Please enter the radius of the circle.\n");
	scanf ("%f", &rad);
	
	square(&side, &sq_area);
	circle(&rad, &cir_area);
	
	printf ("\nThe area of the square is %f.", sq_area);
	printf ("\nThe area of the circle is %f.", cir_area);
	
	flushall();
	getchar();
}//end main()

void square(float *sside, float *sarea)
{
	*sarea=(*sside)*(*sside);
}//end square()

void circle(float *crad, float *carea)
{
	*carea=PI*((*crad)*(*crad));
}//end circle()