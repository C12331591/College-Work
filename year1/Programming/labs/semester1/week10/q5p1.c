/*Program to test compiler's tolerance for pointers
Brian Willis
20/11/2012
*/

#include <stdio.h>

main()
{
	int *ptr;
	
	ptr=(int*)0xf176ba2;
	
	printf ("ptr contains the address %p.\n", ptr);
	printf ("The address contained in ptr contains the value %d.", *ptr);
	
	getchar();
}