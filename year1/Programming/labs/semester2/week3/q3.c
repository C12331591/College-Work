/*Program to use a function to find the highest of input numbers
Brian Willis
12/2/2013
*/

#include <stdio.h>

#define NUMBERS 3

int highest(int[]);

main()
{
	int i;
	int input[NUMBERS];
	int ans;
	
	for (i=0;i<NUMBERS;i++)
	{
		printf ("Please enter element %d.\n", i);
		scanf ("%d", &input[i]);
	}//end for
	
	ans=highest(input);
	
	printf ("\nThe highest is %d.", ans);
	
	flushall();
	getchar();
}//end main()

int highest(int received[NUMBERS])
{
	int answer=received[0];
	int i;
	
	for (i=1;i<NUMBERS;i++)
	{
		if (received[i]>answer)
		{
			answer=received[i];
		}//end if
	}//end for
	
	return(answer);
}//end highest()