/*Program to display 2 user defined characters using getchar() and putchar()
Brian Willis
09/10/2012
*/

#include <stdio.h>

main()
{
	char c1;
	char c2;
	
	printf ("Please enter a character.\n");
	c1=getchar();
	getchar();
	printf ("Now enter another character.\n");
	c2=getchar();
	
	printf ("The first character was ");
	putchar(c1);
	printf (".\nThe second character was ");
	putchar(c2);
	
	getchar();
	getchar();
}