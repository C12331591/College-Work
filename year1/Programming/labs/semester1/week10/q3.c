/*Program to total rows in an array and find the highest number
Brian Willis
20/11/2012
*/

#include <stdio.h>
#define ROW 3
#define COL 2

main()
{
	int ar[ROW][COL];
	int rowtotals[ROW]={0,0,0};
	int coltotals[COL]={0,0};
	int highest=0;
	int i;
	int j;
	
	for (i=0;i<ROW;i++)
	{
		for (j=0;j<COL;j++)
		{
			printf ("Please enter a value for ar[%d][%d]\n", i, j);
			scanf ("%d", &ar[i][j]);
		}
	}
	
	for (i=0;i<ROW;i++)
	{
		for (j=0;j<COL;j++)
		{	
			rowtotals[i]=rowtotals[i]+ar[i][j];
		}
	}
	
	for (i=0;i<COL;i++)
	{
		for (j=0;j<ROW;j++)
		{	
			coltotals[i]=coltotals[i]+ar[j][i];
		}
	}
	
	for (i=0;i<ROW;i++)
	{
		for (j=0;j<COL;j++)
		{
			if (highest<ar[i][j])
			{
				highest=ar[i][j];
			}//end if
		}//end inner for
	}//end outer for
	
	for (i=0;i<ROW;i++)
	{
		printf ("The total of the elements in row %d is %d.\n", i+1, rowtotals[i]);
	}
	
	for (i=0;i<COL;i++)
	{
		printf ("The total of the elements in column %d is %d.\n", i+1, coltotals[i]);
	}
	
	printf ("The highest number in the array is %d.", highest);
	
	flushall();
	getchar();
}//end main