/*Program to read and write strings
Brian Willis
5/3/2013
*/

#include <stdio.h>

#define SIZE 20

main()
{
	char inputstr[SIZE];
	int i;
	char *ptr1;
	char *ptr2;
	
	printf ("Type in something: ");
	gets(inputstr);
	
	printf ("You wrote: ");
	puts (inputstr);
	
	ptr1=inputstr;
	ptr2=ptr1;
	
	printf ("\n\nString up to null character:");
	
	while (*ptr2!='\0')
	{
		printf (" %c,", *ptr2);
		ptr2++;
	}
	
	ptr2=ptr1;
	
	printf ("\n\nFull array:");
	
	for (i=0;i<SIZE;i++)
	{
		printf (" %c,", *ptr2);
		ptr2++;
	}
	
	getchar();
}//end main()