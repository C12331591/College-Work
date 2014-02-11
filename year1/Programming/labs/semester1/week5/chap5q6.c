/*Program to display a single numeral as a word
Brian Willis
16/10/2012
*/

#include <stdio.h>

main()
{
	int num1;
	
	printf ("Please enter a single numeral\n");
	scanf ("%d", &num1);
	
	switch (num1)
	{
		case 0:
		{
			printf ("\n\nzero");
			break;
		}
		case 1:
		{
			printf ("\n\none");
			break;
		}
		case 2:
		{
			printf ("\n\ntwo");
			break;
		}
		case 3:
		{
			printf ("\n\nthree");
			break;
		}
		case 4:
		{
			printf ("\n\nfour");
			break;
		}
		case 5:
		{
			printf ("\n\nfive");
			break;
		}
		case 6:
		{
			printf ("\n\nsix");
			break;
		}
		case 7:
		{
			printf ("\n\nseven");
			break;
		}
		case 8:
		{
			printf ("\n\neight");
			break;
		}
		case 9:
		{
			printf ("\n\nnine");
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