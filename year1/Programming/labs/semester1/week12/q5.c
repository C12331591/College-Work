/*Program to arrange arrays using pointers
Brian Willis
4/12/2012
*/

#include <stdio.h>
#define SIZE 5

main()
{
	float ar1[SIZE];
	float ar2[SIZE];
	
	int i;
	int j;
	float average;
	float transfer;
	
	int *ptri;
	float *ptrav;
	float *ptrtrans;
	ptrav=&average;
	ptrtrans=&transfer;
	ptri=&i;
	
	for (i=0;i<SIZE;i++)
	{
		printf ("Please input a value for ar1[%d].\n", *(ptri));
		scanf ("%f", &*(ar1+i));
		printf ("\n");
	}
	
	for (i=0;i<SIZE;i++)
	{
		for (j=0;j<SIZE-1;j++)
		{
			if (*(ar1+j)<*(ar1+j+1))
			{
				*ptrtrans=*(ar1+j);
				*(ar1+j)=*(ar1+j+1);
				*(ar1+j+1)=*ptrtrans;
			}//end if
		}//end inner for
	}//end outer for
	
	printf ("\nThe highest value is %f.", *ar1);
	printf ("\nThe lowest value is %f.", *(ar1+(SIZE-1)));
	
	*ptrtrans=0;
	
	for (i=0;i<SIZE;i++)
	{
		*ptrtrans=*ptrtrans+*(ar1+i);
	}
	
	*ptrav=*ptrtrans/SIZE;
	
	printf ("\n\nThe average of the numbers is %f.", *ptrav);
	
	for (i=0;i<SIZE;i++)
	{
		*(ar2+i)=*(ar1+SIZE-1-i);
	}
	
	for (i=0;i<SIZE;i++)
	{
		printf ("\n\nar1[%d]=%f	ar2[%d]=%f", *ptri, *(ar1+i), *ptri, *(ar2+i));
	}
	
	flushall();
	getchar();
}//end main