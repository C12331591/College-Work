/*Program to manipulate arrays with pointers
Brian Willis
27/11/2012
*/

#include <stdio.h>
#define SIZE 3

main()
{
	float ar1[SIZE];
	float ar2[SIZE];
	int i;
	
	float *ptr1;
	float *ptr2;
	int *ptr3;
	
	ptr1=&ar1[0];
	ptr2=&ar2[0];
	ptr3=&i;
	
	for ((*ptr3)=0;(*ptr3)<SIZE;(*ptr3)++)
	{
		printf ("Please enter a value for ar1[%d].\n", (*ptr3));
		scanf ("%f", (ptr1+(*ptr3)));
		printf ("\n");
	}//end for
	
	for ((*ptr3)=0;(*ptr3)<SIZE;(*ptr3)++)
	{
		*(ptr2+(*ptr3))=*(ptr1+(*ptr3));
	}//end for
	
	for ((*ptr3)=0;(*ptr3)<SIZE;(*ptr3)++)
	{
		printf ("\nar1[%d] contains %f.", ptr1+(*ptr3));
	}//end for
	
	printf ("\n");
	
	for ((*ptr3)=0;(*ptr3)<SIZE;(*ptr3)++)
	{
		printf ("\nar2[%d] contains %f.", ptr2+(*ptr3));
	}//end for
	
	flushall();
	getchar();
}//end main