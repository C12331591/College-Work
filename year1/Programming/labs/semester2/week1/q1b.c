/*Program that uses calloc()
Brian Willis
29/1/2013
*/

#include <stdio.h>
#include <stdlib.h>

main()
{
	float *ptr;
	int no_els, i;
	
	printf ("Enter the number of elements.\n");
	scanf ("%d", &no_els);
	
	/*Allocating the memory
	*/
	ptr=(float*)calloc(no_els,1);//sizeof(float) removed
	
	/*Checking if memory allocation was successful
	*/
	if (ptr==NULL)
	{
		printf ("Memory cannot be allocated");
	}
	else
	{
		//Enter the numbers
		for (i=0;i<no_els;i++)
		{
			printf ("Enter element %d.\n", i);
			scanf ("%f", &*(ptr+i));
		}
		
		for (i=0;i<no_els;i++)
		{
			printf ("%f\n", *(ptr+i));
		}
		
		free(ptr);
	}//end else
	
	flushall();
	getchar();
}//end main