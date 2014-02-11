/*Program to initialise elements in a 2d array and determine the most common element
Brian Willis
11/12/2012
*/

#include <stdio.h>
#define ROW 5
#define COL 5

main()
{
	int ar[ROW][COL];
	int i;
	int j;
	int midrow;
	int midcol;
	int zero, one, two, five;
	int highest;
	
	//initialising elements to 5
	for (i=0;i<ROW;i++)
	{
		for (j=0;j<COL;j++)
		{
			ar[i][j]=5;
		}//end inner for
	}//end outer for
	
	//setting diagonals to 0
	for (i=0;i<ROW;i++)
	{
		ar[i][i]=0;
	}//end for
	
	for (i=0;i<ROW;i++)
	{
		ar[i][COL-1-i]=0;
	}//end for
	
	/*Determining the middle row and column
	If the row or column is even, the middle variable will contain one of the two middles.
	*/
	if (ROW%2!=0)
	{
		midrow=(ROW/2)+1;
	}
	else
	{
		midrow=ROW/2;
	}//end if
	
	if (COL%2!=0)
	{
		midcol=(COL/2)+1;
	}
	else
	{
		midcol=COL/2;
	}//end if
	
	/*Setting the elements in middle row and column to 1
	If there are two middle rows or columns, this sets them both to 1
	*/
	for (i=0;i<COL;i++)
	{
		if (ROW%2!=0)
		{
			ar[midrow][i]=1;
		}
		else
		{
			ar[midrow][i]=1;
			ar[midrow+1][i]=1;
		}//end if
	}//end for
	
	for (i=0;i<ROW;i++)
	{
		if (COL%2!=0)
		{
			ar[midcol][i]=1;
		}
		else
		{
			ar[midcol][i]=1;
			ar[midcol+1][i]=1;
		}//end if
	}//end for
	
	//setting the corners to 2
	ar[0][0]=2;
	ar[0][COL-1]=2;
	ar[ROW-1][0]=2;
	ar[ROW-1][COL-1]=2;
	
	//Determining the most common value
	zero=0;
	one=0;
	two=0;
	five=0;
	
	for (i=0;i<ROW;i++)
	{
		for (j=0;j<COL;j++)
		{
			if (ar[i][j]==0)
			{
				zero=zero+1;
			}
			else if (ar[i][j]==1)
			{
				one=one+1;
			}
			else if (ar[i][j]==2)
			{
				two=two+1;
			}
			else if (ar[i][j]==5)
			{
				five=five+1;
			}//end if
		}//end inner for
	}//end outer for
	
	highest=6;
	
	if (zero>one&&zero>two&&zero>five)
	{
		highest=0;
	}
	else if (one>zero&&one>two&&one>five)
	{
		highest=1;
	}
	else if (two>zero&&two>one&&two>five)
	{
		highest=2;
	}
	else if (five>zero&&five>one&&five>two)
	{
		highest=5;
	}//end if
	
	if (highest==6)
	{
		printf ("There is no most common value.");
	}
	else
	{
		printf ("The most common value is %d.", highest);
	}//end if
	
	getchar();
}//end main