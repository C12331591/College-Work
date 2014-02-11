/*Program to check divisiblity of one integer by another
Brian Willis
16/10/2012
*/

#include <stdio.h>

main()
{
	int num1;
	int num2;
	int mod;
	
	printf ("Please enter two integers, separated by a comma.\n");
	scanf ("%d, %d", &num1, &num2);
	
	mod=num1%num2;
	
	if (mod==0)
	{
		printf ("\n%d is evenly divisible by %d.", num1, num2);
	}
	else
	{
		printf ("\n%d is not divisible by %d.", num1, num2);
	}/*end of if statement*/
	
	flushall();
	getchar();
}/*end main()*/