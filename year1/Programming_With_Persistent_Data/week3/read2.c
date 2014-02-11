/*Program to read characters from a file and write them to the terminal screen
From instructions
Brian Willis
13/2/2013
*/

#include <stdio.h>

main()
{
	char c;
	FILE *fp_in;
	char filename[100];
	
	printf ("Enter the name of the file: ");
	gets(filename);
	
	fp_in=fopen(filename, "r");
	
	if (fp_in==NULL)//This checks if the opening was successful
	{
		printf ("Unable to open file.");//This error message will display if it failed
	}
	else
	{
		while (fread(&c, 1, 1, fp_in)!=NULL)
		{
			printf ("%c", c);
		}
	}
	
	int close=fclose(fp_in);//The close variable stores the value returned by fclose
	
	if (close!=0)//0 is returned upon successful closing. Anything else indicates failure.
	{
		printf ("Unable to close file.");//This error message will display if it failed
	}
}