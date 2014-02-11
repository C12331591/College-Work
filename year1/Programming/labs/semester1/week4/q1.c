/*Program to accept input of three numbers and display them.
Brian Willis
09/10/2012
*/

#include <stdio.h>

main()
{
	int num1;
	int num2;
	int num3;
	
	printf ("Please enter a number.\n");
	scanf ("%d", &num1);
	printf ("\nNow enter another number.\n");
	scanf ("%d", &num2);
	printf ("\nAnd finally, a third number.\n");
	scanf ("%d", &num3);
	
	printf ("\nThe first number you entered was %d.", num1);
	printf ("\nThe second number you entered was %d.", num2);
	printf ("\nThe third number you entered was %d.", num3);
	
	getchar();
	getchar();
}