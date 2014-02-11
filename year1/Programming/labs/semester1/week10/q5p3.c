/*Program to experiment with pointers
Brian Willis
20/11/2012
*/

#include <stdio.h>

main()
{
	int *ptr;
	
	ptr=(int*)0xfb6546;
	*ptr=10;
	
	printf ("The address %p contains the value %d.", ptr, *ptr);
	
	getchar();
}