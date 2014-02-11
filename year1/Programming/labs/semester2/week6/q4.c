/*Program to demonstrate different methods of initialising a string
Brian Willis
5/3/2013
*/

#include <stdio.h>

#define SIZE 5

main()
{
	int i;
	
	char my_word1[SIZE];
	
	my_word1[0]='H';
	my_word1[1]='e';
	my_word1[2]='l';
	my_word1[3]='l';
	my_word1[4]='o';
	
	char my_word2[]="World";
	
	char my_word3[SIZE]="Hello";
	
	char my_word4[SIZE+1];
	
	my_word4[0]='W';
	my_word4[1]='o';
	my_word4[2]='r';
	my_word4[3]='l';
	my_word4[4]='d';
	
	char my_word5[SIZE+1];
	
	my_word5[0]='H';
	my_word5[1]='e';
	my_word5[2]='l';
	my_word5[3]='l';
	my_word5[4]='o';
	my_word5[5]='\0';
	
	char my_word6[SIZE+1]="World";
	
	printf ("my_word1 (no null character): %s", my_word1);
	printf ("\n\nmy_word2 (null character): %s", my_word2);
	printf ("\n\nmy_word3 (no null character): %s", my_word3);
	printf ("\n\nmy_word4 (ends with undefined element): %s", my_word4);
	printf ("\n\nmy_word5 (null character): %s", my_word5);
	printf ("\n\nmy_word6 (null character?): %s", my_word6);
	
	printf ("\n\n\nmy_word1 (no null character):");
	
	for(i=0;my_word1[i]!='\0';i++)
	{
		printf (" %c,", my_word1[i]);
	}//end for
	
	printf ("\n\nmy_word2 (null character):");
	
	for(i=0;my_word2[i]!='\0';i++)
	{
		printf (" %c,", my_word2[i]);
	}//end for
	
	printf ("\n\nmy_word3 (no null character):");
	
	for(i=0;my_word3[i]!='\0';i++)
	{
		printf (" %c,", my_word3[i]);
	}//end for
	
	printf ("\n\nmy_word4 (ends with undefined element):");
	
	for(i=0;my_word4[i]!='\0';i++)
	{
		printf (" %c,", my_word4[i]);
	}//end for
	
	printf ("\n\nmy_word5 (null character):");
	
	for(i=0;my_word5[i]!='\0';i++)
	{
		printf (" %c,", my_word5[i]);
	}//end for
	
	printf ("\n\nmy_word6 (null character?):");
	
	for(i=0;my_word5[i]!='\0';i++)
	{
		printf (" %c,", my_word6[i]);
	}//end for
	
	getchar();
}//end main