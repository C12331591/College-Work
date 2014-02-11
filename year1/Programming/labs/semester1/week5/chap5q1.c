/*Program to perform a function using a switch statement
Brian Willis
16/10/2012
*/

#include <stdio.h>

main()
{
	char marstat;
	
	printf ("Please input marital status.\ns - single\nm - married\nw - widowed\ne - separated\nd- divorced\n");
	scanf ("%1s", &marstat);
	
	switch (marstat)
	{
		case 's':
		{
			printf ("\n\nsingle");
			break;
		}
		case 'm':
		{
			printf ("\n\nmarried");
			break;
		}
		case 'w':
		{
			printf ("\n\nwidowed");
			break;
		}
		case 'e':
		{
			printf ("\n\nseparated");
			break;
		}
		case 'd':
		{
			printf ("\n\ndivorced");
			break;
		}
		default:
		{
			printf ("\n\nerror:invalid code");
		}
	}/*end switch()*/
	
	flushall();
	getchar();
}/*end main()*/