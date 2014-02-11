/*Program to calculate the sum of all odd integers from 1 to 99
Brian Willis
23/10/2012
*/

#include <stdio.h>

main()
{
	int current;
	int total;
	
	total=0;
	
	for (current=1;current<100;current++)
	{
		if (current%2!=0)
		{
			total=total+current;
		}//end if
	}//end for
	
	printf ("The total of all odd integers from 1 to 99 is %d.", total);
	
	getchar();
}//end main