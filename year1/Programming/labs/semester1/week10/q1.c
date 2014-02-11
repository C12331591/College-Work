/*Program to multiply elements in arrays
Brian Willis
20/11/2012
*/

#include <stdio.h>
#define ROW 3
#define COL 4

main()
{
	int ar1[ROW][COL]=	{{63,75,9,40},
						{6,82,754,3},
						{53,39,0,17}
						};
	
	int ar2[ROW][COL]=	{{42,8,19,81},
						{63,69,14,76},
						{7,90,13,818}
						};
	
	int ar3[ROW][COL];
	int i;
	int j;
	
	for (i=0;i<ROW;i++)
	{
		for (j=0;j<COL;j++)
		{
			ar3[i][j]=ar1[i][j]*ar2[i][j];
			
			printf ("ar1[%d][%d]*ar2[%d][%d]=%d\n", i, j, i, j, ar3[i][j]);
		}//end inner for
	}//end outer for
	
	getchar();
}//end main