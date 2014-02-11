/*Program to display three float numbers with different decimal places.
Brian WIllis
09/10/2012
*/

#include <stdio.h>

main()
{
	float num1;
	float num2;
	float num3;
	
	printf ("Please enter any number (Decimals are permitted.).\n");
	scanf ("%f", &num1);
	printf ("\nPlease enter another number.\n");
	scanf ("%f", &num2);
	printf ("\nPlease enter a final number.\n");
	scanf ("%f", &num3);
	
	printf ("\nThe first number was %3.4f.", num1);
	printf ("\nThe second number was %3.3f.", num2);
	printf ("\nThe third number was %3.0f.", num3);
	
	getchar();
	getchar();
}