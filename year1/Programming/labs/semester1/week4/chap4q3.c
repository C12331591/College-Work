/*Program to input four numbers and display them in the opposite order.
Brian Willis
09/10/2012
*/

#include <stdio.h>

main()
{
	float num1, num2, num3, num4;
	
	printf ("Enter the first number.\n");
	scanf ("%f", &num1);
	printf ("\nEnter the second number.\n");
	scanf ("%f", &num2);
	printf ("\nEnter the third number.\n");
	scanf ("%f", &num3);
	printf ("\nEnter the fourth number.\n");
	scanf ("%f", &num4);
	
	printf ("\n%f, %f, %f, %f", num4, num3, num2, num1);
	
	getchar();
	getchar();
}