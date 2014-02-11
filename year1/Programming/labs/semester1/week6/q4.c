/*Program to count from 1 to 10 and note when the number is 3 or 7
Brian Willis
23/10/2012
*/

#include <stdio.h>

main()
{
	int count;
	
	for (count=1;count<11;count++)
	{
		printf ("%d\n", count);
		switch (count)
		{
			case 3:
			{
				printf ("The number is three.\n");
				break;
			}
			case 7:
			{
				printf ("The number is seven.\n");
			}
		}//end switch
	}//end for
	
	getchar();
}//end main