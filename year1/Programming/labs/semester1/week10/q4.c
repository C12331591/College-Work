/*Program to use pointers
Brian Willis
20/11/2012
*/

#include <stdio.h>

main()
{
	int var1;
	int *ptr;
	var1 = 1;
	ptr = &var1;
	
	printf("the address of var1 is %p\n", &var1);
	printf("ptr contains %p\n", ptr);
	printf("*ptr contains %d", *ptr);
	
	getchar();
}