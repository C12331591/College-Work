/*Program to print 10 stars
Brian Willis
5/2/2013
*/

#include <stdio.h>

#define NUMSTARS 10

void stars(int);

main()
{
	stars(NUMSTARS);
	
	getchar();
}//end main()

void stars(int num)
{
	int i;
	
	for (i=0;i<num;i++)
	{
		printf ("*");
	}
}//end stars()