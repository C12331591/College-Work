/*Program to interpret a number as a day of the week
Brian Willis
16/10/2012
*/

#include <stdio.h>

main()
{
	int num1;
	
	printf ("Please input a number from 1 to 7.\n");
	scanf ("%d", &num1);
	
	switch (num1)
	{
		case 1:
		{
			printf ("\n\nSunday");
			break;
		}
		case 2:
		{
			printf ("\n\nMonday");
			break;
		}
		case 3:
		{
			printf ("\n\nTuesday");
			break;
		}
		case 4:
		{
			printf ("\n\nWednesday");
			break;
		}
		case 5:
		{
			printf ("\n\nThursday");
			break;
		}
		case 6:
		{
			printf ("\n\nFriday");
			break;
		}
		case 7:
		{
			printf ("\n\nSaturday");
			break;
		}
		default:
		{
			printf ("\n\ninvalid entry");
		}
	}/*end switch()*/
	
	flushall();
	getchar();
}/*end main()*/