/*Program to use a function to count odd input numbers
Brian Willis
19/2/2013
*/

#include <stdio.h>

#define SIZE 5

int oddeven(int[]);

main()
{
	int i;
	int ar[SIZE];
	int numodd;
	
	for (i=0;i<SIZE;i++)
	{
		printf ("Please input a value for element %d.\n", i);
		scanf ("%d", &ar[i]);
	}
	
	numodd=oddeven(ar);
	
	printf ("\n\nThere are %d odd numbers.", numodd);
	
	flushall();
	getchar();
}//end main()

int oddeven(int rec[SIZE])
{
	int i;
	int oddcount=0;
	
	for (i=0;i<SIZE;i++)
	{
		printf ("\n%d", rec[i]);
		
		if (rec[i]%2==0)
		{
			printf ("	even");
		}
		else
		{
			printf ("	odd");
			oddcount=oddcount+1;
		}//end if
	}//end for
	
	return(oddcount);
}//end oddeven()