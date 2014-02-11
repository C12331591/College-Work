/*Program to display all numbers evenly divisible by the input
Brian Willis
23/10/2012
*/

#include <stdio.h>

main()
{
	int input;
	int current;
	
	do
	{
		printf ("Please enter a number between 1 and 5, inclusive.\n");
		scanf ("%d", &input);
		if (input<1||input>5)
		{
			printf ("Error: Number entered was not valid.\n");
		}//end if
	}
	while (input<1||input>5);// end do while
	
	printf ("The numbers between 1 and 20 which are divisble by this number are:\n");
	
	for (current=1;current<21;current++)
	{
		if (current%input==0)
		{
			printf ("%d\n", current);
		}//end if
	}//end for
	
	flushall();
	getchar();
}//end main