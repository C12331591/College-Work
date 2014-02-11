/*Program to demonstrate Pass by Reference
Brian Willis
12/2/2013
*/

#include <stdio.h>

void func(int*);

main()
{
	int num=1;
	
	printf ("The value in main is currently %d.\n", num);
	
	func(&num);
	
	printf ("The function has finished executing. The value in main is now %d.", num);
	
	getchar();
}//end main()

void func(int *ptr)
{
	*ptr=*ptr+2;
	printf ("The function is executing. The value in the function is %d.\n", *ptr);
}//end func()