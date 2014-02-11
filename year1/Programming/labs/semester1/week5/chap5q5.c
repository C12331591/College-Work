/*Program to determine if three lengths can form a valid triangle
Brian Willis
16/10/2012
*/

#include <stdio.h>

main()
{
	float side1;
	float side2;
	float side3;
	float fps;
	float fpt;
	float spt;
	
	printf ("Please input the length of the first side.\n");
	scanf ("%f", &side1);
	printf ("\nPlease input the length of the second side.\n");
	scanf ("%f", &side2);
	printf ("\nPlease input the length of the third side.\n");
	scanf ("%f", &side3);
	
	fps=side1+side2;
	fpt=side1+side3;
	spt=side2+side3;
	
	if (fps>side3 && fpt>side2 && spt>side1)
	{
		printf ("\n\nThese three lengths will form a valid triangle.");
	}
	else
	{
		printf ("\n\nThese three lengths will not form a valid triangle.");
	}/*end if*/
	
	flushall();
	getchar();
}/*end main()*/