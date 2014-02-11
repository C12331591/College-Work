/*Program to use a 2-dimensional array
Brian Willis
13/11/2012
*/

#include <stdio.h>
#define ROW 3
#define COL 2

main()
{
	int ar[ROW][COL]=	{ {45,860},
						{6,9},
						{87,90}
						};
	int i;
	int j;
	int moving;
	int counter=0;
	int total;
	int average;
	
	for (i=0;i<ROW;i++)
	{
		for (j=0;j<COL;j++)
		{
			printf ("ar[%d][%d]=%d\n", i, j, ar[i][j]);
		}
	}
	
	printf ("\n");
	
	do
	{
		for (i=0;i<ROW;i++)
		{
			for (j=0;j<COL-1;j++)
			{
				if (ar[i][j]<ar[i][j+1])
				{
					moving=ar[i][j];
					ar[i][j]=ar[i][j+1];
					ar[i][j+1]=moving;
				}
			}
		}
		
		for (i=0;i<ROW-1;i++)
		{
			if (ar[i][COL-1]<ar[i+1][0])
			{
				moving=ar[i][COL-1];
				ar[i][COL-1]=ar[i+1][0];
				ar[i+1][0]=moving;
			}
		}
		
		counter++;
	}
	while (counter<3);
	
	for (i=0;i<ROW;i++)
	{
		for (j=0;j<COL;j++)
		{
			printf ("ar[%d][%d]=%d\n", i, j, ar[i][j]);
		}
	}
	
	printf ("\nHighest value=%d\nLowest value=%d", ar[0][0], ar[ROW-1][COL-1]);
	
	total=0;
	counter=0;
	
	for (i=0;i<ROW;i++)
	{
		for (j=0;j<COL;j++)
		{
			total=total+ar[i][j];
			counter++;
		}
	}
	
	average=total/counter;
	
	printf ("\n\nAverage is %d.", average);
	
	getchar();
}