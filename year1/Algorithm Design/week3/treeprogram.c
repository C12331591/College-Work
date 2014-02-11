/*Program to implement the algorithm to draw a tree
Brian Willis
11/2/2013
*/

#include <stdio.h>

main()
{
	int numlines;
	int i, j;
	
	printf ("Please enter the number of lines to use.\n");
	scanf ("%d", &numlines);
	printf ("\n");
	
	if (numlines<1)
	{
		printf ("Unable to draw a tree using that number of lines.");
	}
	else if (numlines==1)
	{
		printf ("*");
	}
	else
	{
		for (i=1;i<numlines;i++)
		{
			for (j=0;j<(numlines-i);j++)
			{
				printf (" ");
			}//end for
			
			for (j=0;j<((2*i)-1);j++)
			{
				printf ("*");
			}//end for
			
			for (j=0;j<(numlines-i);j++)
			{
				printf (" ");
			}//end for
			
			printf ("\n");
		}//end for
		
		for (i=0;i<(numlines-1);i++)
		{
			printf (" ");
		}//end for
		
		printf ("*");
		
		for (i=0;i<(numlines-1);i++)
		{
			printf (" ");
		}//end for
	}//end if
	
	flushall();
	getchar();
}//end main