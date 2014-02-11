/*Program to perform calculations wih pointer variables
Brian Willis
27/11/2012
*/

#include <stdio.h>

main()
{
	int num1;
	int num2;
	int sum;
	
	int *ptr1;
	int *ptr2;
	int *ptr3;
	
	printf ("Please enter a value for the first number.\n");
	scanf ("%d", &num1);
	printf ("\nPlease enter a value for the second number.\n");
	scanf ("%d", &num2);
	
	ptr1=&num1;
	ptr2=&num2;
	ptr3=&sum;
	
	*ptr3=*ptr1+*ptr2;
	
	printf ("\n\nThe sum of these two numbers is %d.", *ptr3);
	
	flushall();
	getchar();
}