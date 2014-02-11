/*Program to compare two input words
Brian Willis
12/3/2013
*/

#include <stdio.h>
#include <string.h>

#define SIZE 10

main()
{
	char input1[SIZE];
	char input2[SIZE];
	
	printf ("Please input a word.\n");
	gets(input1);
	printf ("\nPlease input another word.\n");
	gets(input2);
	
	if (input1[SIZE-1]!='\0')
	{
		input1[SIZE-1]='\0';
	}//end if
	
	if (input2[SIZE-1]!='\0')
	{
		input2[SIZE-1]='\0';
	}//end if
	
	if (strcmp(input1, input2)==0)
	{
		printf ("\nThe two words are identical.");
	}
	else
	{
		printf ("\nThe two words are not identical.");
	}//end if
	
	flushall();
	getchar();
}//end main()