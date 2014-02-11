/*Program to calculate the average of input numbers using a function
Brian Willis
19/2/2013
*/

#include <stdio.h>

#define SIZE 5

float average(float[]);

main()
{
	int i;
	float ar[SIZE];
	float ave;
	
	for (i=0;i<SIZE;i++)
	{
		printf ("Please input a value for element %d.\n", i);
		scanf ("%f", &ar[i]);
	}
	
	ave=average(ar);
	
	printf ("\nThe average is %f.", ave);
	
	flushall();
	getchar();
}//end main()

float average(float rec[SIZE])
{
	float total=0;
	int i;
	
	for (i=0;i<SIZE;i++)
	{
		total=total+rec[i];
	}
	
	return(total/SIZE);
}//end average()