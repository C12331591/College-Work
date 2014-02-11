/*Program to attempt to go beyond an array using pointers
Brian Willis
4/12/2012
*/

#include <stdio.h>
#define SIZE 3

main()
{
	float ar[SIZE]={1.1,2.2,3.3};
	int i;
	
	//printf ("The contents of ar[-1] are %f" *(ar-1));
	
	for (i=0;i<SIZE;i++)
	{
		printf ("\nThe contents of ar[%d] are %f", i, *(ar+i));
	}
	
	printf ("\nThe contents of ar[%d] are %f", SIZE, *(ar+SIZE));
	
	getchar();
}//end main