/*Program to find the highest number in an array using a function
Brian Willis
19/2/2013
*/

#include <stdio.h>

#define SIZE 5

int highest(int[]);

main()
{
	int i;
	int ar[SIZE];
	int answer;
	
	for (i=0;i<SIZE;i++)
	{	
		printf ("Please input a value for element %d.\n", i);
		scanf ("%d", &ar[i]);
	}//end for
	
	answer=highest(ar);
	
	printf ("\nThe highest value is %d.", answer);
	
	flushall();
	getchar();
}//end main()

int highest(int rec[SIZE])
{
	int i, j, transfer;
	
	for (i=0;i<SIZE;i++)
	{
		for (j=0;j<SIZE-1;j++)
		{
			if (rec[j]<rec[j+1])
			{	
				transfer=rec[j];
				rec[j]=rec[j+1];
				rec[j+1]=transfer;
			}//end if
		}//end inner for
	}//end outer for
	
	return(rec[0]);
}//end highest()