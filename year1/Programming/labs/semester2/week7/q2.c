/*Program to analyse an input string
Brian Willis
12/3/2013
*/

#include <stdio.h>
#include <string.h>

#define SIZE 20

void is(char[]);

main()
{
	char input[SIZE];
	char addinput[SIZE+18]="My sentence is : ";
	
	printf ("Write a sentence here:\n");
	gets(input);
	
	if (input[SIZE-1]!='\0')//Adding a '\0' if the sentence is too long
	{
		input[SIZE-1]='\0';
	}
	
	is(input);
	strcat(addinput, input);
	
	printf ("\nThe sentence is %d characters in length (including spaces).\n", strlen(input));
	printf ("%s", addinput);//I first tried puts here, but it was was producing unusual results
	
	flushall();
	getchar();
}//end main

void is(char recar[])
{
	int i;
	int iscount=0;
	
	for (i=0;i<SIZE||recar[i]=='\0';i++)
	{
		if ((recar[i]=='i'&&recar[i+1]=='s')||(recar[i]=='I'&&recar[i+1]=='s'))//detecting is
		{
			if ((recar[i+2]==' '&&i==0)||(recar[i+2]==' '&&recar[i-1]==' ')||(recar[i-1]==' '&&recar[i+2]=='\0')||(i==0&&recar[i+2]=='\0'))//making sure it isn't part of another word
			{
				iscount++;
			}//end inner if
		}//end outer if
	}//end for
	
	if (iscount==0)
	{
		printf ("\n'is' is not present.");
	}
	else
	{
		printf ("\n'is' is present %d time(s).", iscount);
	}
}//end is()