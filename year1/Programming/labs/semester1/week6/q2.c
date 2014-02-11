/*Program to perform calculations until the answer is 1
Brian Willis
23/10/2012
*/

#include <stdio.h>

main()
{
	int input;
	int counter;
	
	do
	{
		printf ("Please enter a number.\n");
		scanf ("%d", &input);
		if (input<1)
		{
			printf ("Error: Input is less than 1.\n");
		}//end if
	}
	while (input<1);//end while
	
	for (counter=0;input!=1;counter++)
	{
		if (input%2==0)
		{
			input=input/2;
		}
		else
		{
			input=(input*3)+1;
		}//end if
		printf ("Value is %d,\n", input);
	}//end for
	
	printf ("\nTotal number of steps was %d.", counter);
	
	flushall();
	getchar();
}//end main