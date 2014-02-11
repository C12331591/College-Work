/*Program to take input of a character and determine whether it is a vowel.
Brian Willis
16/10/2012
*/

#include <stdio.h>

main()
{
	char c1;
	
	printf ("Please input a character.\n");
	scanf ("%1s", &c1);
	
	switch (c1)
	{
		case 'a':
		{
			printf ("\nThe character you entered was a vowel.");
			break;
		}
		case 'e':
		{
			printf ("\nThe character you entered was a vowel.");
			break;
		}
		case 'i':
		{
			printf ("\nThe character you entered was a vowel.");
			break;
		}
		case 'o':
		{
			printf ("\nThe character you entered was a vowel.");
			break;
		}
		case 'u':
		{
			printf ("\nThe character you entered was a vowel.");
			break;
		}
		default:
		{
			printf ("\nThe character you entered was not a vowel.");
		}
	}/*end switch*/
	
	flushall();
	getchar();
}/*end main()*/