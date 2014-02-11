/*Program to print the contents of a text file
From notes
Brian Willis
20/2/2013
*/

#include <stdio.h>
#include <stdlib.h>

int main()
{
	FILE *fp;//creates the pointer for the file
	char ch;//creates the char variable ch
	ch='a';//assigns ch a value of 'a'
	
	//'a'-'z' 97-122 'A'-'Z' 65-90
	printf ("%i\n", ch);//prints the numerical value of ch
	
	fp=fopen("myfile.txt", "r");//opens the file for reading
	
	if (fp==NULL)//checks that the opening was successful
	{
		printf ("Error: Could not open file!\n");//error message for unsuccessful opening
	}
	
	while ((ch=fgetc(fp))!=EOF)//repeat until it reaches the end of the file
	{
		printf ("%c", ch);//prints the current character
	}
	
	fclose(fp);//closes the file
	return 0;//main() return a value of 0
}//end main()