/*Program to use a function to determine the most commonly entered character by the user
Brian Willis
12/2/2013
*/

#include <stdio.h>

#define CHARS 5

char common(char[]);

main()
{
	int i;
	char input[CHARS];
	char ans;
	
	for (i=0;i<CHARS;i++)
	{
		printf ("Please input a character for element %d.\n", i);
		scanf ("%1s", &input[i]);
	}//end for
	
	ans=common(input);
	
	if (ans==NULL)
	{
		printf ("\nThere is no most common character.");
	}
	else
	{
		printf ("\nThe most common character is %c.", ans);
	}
	
	flushall();
	getchar();
}//end main()

char common(char received[CHARS])
{
	int i, j;
	char answer;
	int instances;
	int highestinstances=0;
	
	for (i=0;i<CHARS;i++)
	{
		instances=0;
		
		for (j=0;j<CHARS;j++)
		{
			if (received[i]==received[j])
			{
				instances++;
			}//end if
		}//end inner for
		
		if (instances>highestinstances)
		{
			answer=received[i];
			highestinstances=instances;
		}
	}//end outer for
	
	if (highestinstances==1)
	{
		return(NULL);
	}
	else
	{
		return(answer);
	}//end if
}//end common()