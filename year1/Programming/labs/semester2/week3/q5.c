/*Program to demonstrate Pass by Value
Brian Willis
12/2/2013
*/

#include <stdio.h>

void func(int);

main()
{
	int num=1;
	
	printf ("The number in main is currently %d.\n", num);
	
	func(num);
	
	printf ("The function has now executed. The number in main is still %d.", num);
	
	getchar();
}//end main()

void func(int received)
{
	received=received+2;
	printf ("The function is currently executing. The number in the function is currently %d.\n", received);
}//end func()