/*Program to calculate and display the area of a circle with radius 4.8
Brian Willis
02/10/2012
*/

#include <stdio.h>

main()
{
	float radius;
	float pi;
	float area;
	
	pi=3.14;
	radius=4.8;
	
	area=pi*(radius*radius);
	
	printf ("The area of the circle with radius 4.8 is %f.", area);
	
	getchar();
}