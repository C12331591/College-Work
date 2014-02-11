/*Program to take and display two characters
Brian Willis
09/10/2012
*/

#include <stdio.h>

main()
{
	char c1;
	char c2;
	
	printf ("Please enter any character.\n");
	scanf ("%1s", &c1);
	printf ("Please enter another character.\n");
	scanf ("%1s", &c2);
	
	printf ("\nThe first character you entered was %c.", c1);
	printf ("\nThe second character you entered was %c.", c2);
	
	getchar();
	getchar();
}