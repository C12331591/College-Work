/*Program to use nested functions to calculate the average of input numbers
Brian Willis
5/2/2013
*/

#include <stdio.h>

#define NUMBERS 3

void sum(int[]);
void average(int);

main()
{
	int i;
	int mainar[NUMBERS];
	
	for (i=0;i<NUMBERS;i++)
	{
		printf ("Please input a value for number %d.\n", i+1);
		scanf ("%d", &mainar[i]);
	}
	
	sum(mainar);
	
	flushall();
	getchar();
}//end main()

void sum(int sumar[NUMBERS])
{
	int i;
	int total=0;
	
	for (i=0;i<NUMBERS;i++)
	{
		total=total+sumar[i];
	}
	
	average(total);
}//end sum()

void average(int receivedsum)
{
	int ave;
	
	ave=receivedsum/NUMBERS;
	
	printf ("\nThe average is %d.", ave);
}//end average()