/*Program to find the sum of the elements in an array
Brian Willis
20/11/2012
*/

#include <stdio.h>
#define ROW 4
#define COL 6

main()
{
	int data[ROW][COL] = { {3, 2, 5, 7, 4, 2},
							{1, 4, 4, 8, 13, 1},
							{9, 1, 0, 2, 0, 0},
							{0, 2, 6, 3, -1, -8}
							};
	
	int total=0;
	int i, j;
	
	// compute the sum
	for ( i=0; i < ROW; i++)
	{
		for ( j=0; j < COL; j++)
		{
			total=total+data[i][j];
		}
	}
	
	// display the sum
	printf("The sum of the elements is %d.", total);
	
	getchar();
}