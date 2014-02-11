/*Program to use a function check if a number is even or odd
Brian Willis
12/2/2013
*/

#include <stdio.h>

int evencheck(int);

main()
{
	int input;
	int even;
	
	printf ("Please enter a number.\n");
	scanf ("%d", &input);
	
	even=evencheck(input);
	
	if (even==1)
	{
		printf ("\nIt's even.");
	}
	else
	{
		printf ("\nIt's odd.");
	}//end if
	
	flushall();
	getchar();
}//end main()

int evencheck(int received)
{
	if (received%2==0)
	{
		return(1);
	}
	else
	{
		return(0);
	}//end if
}//end evencheck()