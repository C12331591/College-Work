/*Program to use diferent pointer functions
Brian Willis
20/11/2012
*/

#include <stdio.h>

main()
{
	int num=1;
	int *ptr;
	
	ptr=&num;
	
	printf ("The value in the address in ptr is %d.", *ptr);
	
	ptr++;
	
	printf ("\nThe value in the address in ptr+1 is %d.", *ptr);
	
	getchar();
}