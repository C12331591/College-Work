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
	
	while (fread(&c, 1, 1, fp_in)!=NULL)
	{
		printf ("%c", c);
	}
	
	fclose(fp_in);
}