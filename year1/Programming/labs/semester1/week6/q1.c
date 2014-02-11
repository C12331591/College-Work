/*Program to display numbers 1 to 10 in descending order
Brian Willis
23/10/2012
*/

#include <stdio.h>

main()
{
	int num1=10;
	
	while (num1!=0)
	{
		printf ("%d,", num1);
		num1=num1-1;
	}//end while
	
	getchar();
}//end main