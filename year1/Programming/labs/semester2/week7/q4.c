/*Program to compare two input words
Brian Willis
12/3/2013
*/

#include <stdio.h>
#include <string.h>

#define SIZE 10

void charcount(char[]);

main()
{
	char input1[SIZE];
	char input2[SIZE];
	char addinput1[23+SIZE]="First word entered is : ";
	
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
	
	strcat(addinput1, input1);
	printf ("\n\n%s", addinput1);
	
	charcount(addinput1);
	
	flushall();
	getchar();
}//end main()

void charcount(char recstr[])
{
	int i;
	int spacecount=0;
	
	printf ("\nThe length of the above string is %d.", strlen(recstr));
	
	for (i=0;recstr[i]!='\0';i++)
	{
		if (recstr[i]==' ')
		{
			spacecount++;
		}
	}//end for
	
	printf ("\nThe number of characters used, excluding spaces, is %d.", strlen(recstr)-spacecount);
}//end charcount()