/*Lab Test 2 attempt - Program to calculate 
Brian Willis
26/2/2013
*/

#include <stdio.h>

#define SIZE 10

void fibonacci(int*);
void display(int[]);

main()
{
	int fibar[SIZE]={0,1,1,2,3};
	
	fibonacci(&fibar[0]);
	display(fibar);
}//end main

void fibonacci(int *rec)
{
	int i;
	
	for (i=5;i<SIZE;i++)
	{
		*(rec+i)=(*(rec+(i-1)))+(*(rec+(i-2)));
	}//end for
}//end fibonacci

void display(int recar[SIZE])
{
	int i;
	
	printf ("The first %d elements in Fibonacci are:\n", SIZE);
	
	for (i=0;i<SIZE;i++)
	{
		printf ("%d\n", recar[i]);
	}//end for
	
	getchar();
}//end display