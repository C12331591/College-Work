/*Program to use a function to calculate the average of input numbers
Brian Willis
12/2/2013
*/

#include <stdio.h>

#define NUMBERS 3

float average(float[]);

main()
{
	float input[NUMBERS];
	int i;
	float ave;
	
	for (i=0;i<NUMBERS;i++)
	{
		printf ("Please enter element %d.\n", i);
		scanf ("%f", &input[i]);
	}//end for
	
	ave=average(input);
	
	printf ("\nThe average is %f.", ave);
	
	flushall();
	getchar();
}//end main()

float average(float received[NUMBERS])
{
	float total=0;
	int i;
	
	for (i=0;i<NUMBERS;i++)
	{
		total=total+received[i];
	}//end for
	
	return(total/NUMBERS);
}//end average()