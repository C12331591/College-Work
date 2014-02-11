/*Program to view the output of a given code sample
Brian WIllis
4/12/2012
*/

#include <stdio.h>

main()
{
	int count = 10, *temp, sum = 0;
	
	temp = &count;
	*temp = 20;
	temp = &sum;
	*temp = count;
	
	printf("count = %d, *temp = %d, sum = %d\n", count, *temp, sum );
	
	getchar();
}