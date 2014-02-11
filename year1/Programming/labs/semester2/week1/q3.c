/*Program to work with numbers stored using DMA
Brian Willis
29/1/2013
*/

#include <stdio.h>
#include <stdlib.h>

#define NO_ELS 5

main()
{
	float *ptr;
	float *ptrave;
	int i;
	
	ptr=(float*)calloc(NO_ELS,sizeof(float));
	
	if (ptr==NULL)
	{
		printf ("Memory could not be allocated.");
	}
	else
	{
		for (i=0;i<NO_ELS;i++)
		{
			printf ("Enter the value for element %d.\n", i);
			scanf ("%f", &*(ptr+i));
		}
		
		ptrave=(float*)calloc(1,sizeof(float));
		*(ptrave)=0;
		
		for (i=0;i<NO_ELS;i++)
		{
			*(ptrave)=*(ptrave)+*(ptr+i);
		}
		
		*(ptrave)=*(ptrave)/NO_ELS;
		
		for (i=0;i<NO_ELS;i++)
		{
			printf ("\nElement %d:	%f", i, *(ptr+i));
		}
		
		printf ("\nAverage:	%f", *(ptrave));
		
		free (ptr);
		free (ptrave);
	}//end else
	
	flushall();
	getchar();
}//end main