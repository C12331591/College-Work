/*Program to use pointers with input
Brian WIllis
27/11/2012
*/

#include <stdio.h>

main()
{
	float input1,input2;
	
	float *ptr1;
	float *ptr2;
	
	ptr1=&input1;
	ptr2=&input2;
	
	printf ("Please enter a value for input1.\n");
	scanf ("%f", &input1);
	printf ("\nPlease enter a value for input2.\n");
	scanf ("%f", &input2);
	
	printf ("\n\ninput1 is stored at %p.", ptr1);
	printf ("\ninput2 is stored at %p.", ptr2);
	
	printf ("\n\nptr1 is stored at %p.", &ptr1);
	printf ("\nptr2 is stored at %p.", &ptr2);
	
	printf ("\n\nptr1 contains %p.", ptr1);
	printf ("\nptr2 contains %p.", ptr2);
	
	printf ("\n\nThe address in ptr1 contains %f.", *ptr1);
	printf ("\nThe address in ptr2 contains %f.", *ptr2);
	
	flushall();
	getchar();
}