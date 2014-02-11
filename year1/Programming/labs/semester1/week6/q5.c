/*Program to display all even numbers from 1 to 100
Brian Willis
23/10/2012
*/

#include <stdio.h>

main()
{
	int current;
	
	printf ("The even numbers between 1 and 100 are:\n");
	
	for (current=1;current<101;current++)
	{
		if (current%2==0)
		{
			printf ("%d,", current);
		}//end if
	}//end for
	
	getchar();
}//end main