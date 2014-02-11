/*Program to display input characters from an array
Brian Willis
30/10/2012
*/

#include <stdio.h>
#define SIZE 5

main()
{
	char input[SIZE];
	int i;
	
	printf ("Please input %d characters.\n", SIZE);
	
	for (i=0;i<SIZE;i++)
	{
		scanf ("%1s", &input[i]);
	}//end for
	
	printf ("\nYou entered:");
	
	for (i=0;i<SIZE;i++)
	{
		printf (" %c", input[i]);
	}//end for
	
	flushall();
	getchar();
}//end main