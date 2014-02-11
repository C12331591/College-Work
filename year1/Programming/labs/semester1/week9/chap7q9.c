/*Program to detect negative values in a 2-dimensional array
Brian Willis
13/11/2012
*/

#include <stdio.h>
#define ROW 4
#define COL 5

main()
{
	int ar[ROW][COL];
	int i;
	int j;
	
	for (i=0;i<ROW;i++)
	{
		for (j=0;j<COL;j++)
		{
			printf ("Please input a value for ar[%d][%d].", i, j);
			scanf ("%d", &ar[i][j]);
		}
	}
	
	for (i=0;i<ROW;i++)
	{
		for (j=0;j<COL;j++)
		{
			if (ar[i][j]<0)
			{
				printf ("\nar[%d][%d] is negative with a value of %d.", i, j, ar[i][j]);
			}
		}
	}
	
	flushall();
	getchar();
}