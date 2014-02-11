/*Program which uses open and close commands
From lab instructions
Brian Willis
6/2/2013
*/

#include <stdio.h>

main()
{
	FILE *fp;
	
	char filename[10];//an array is now used for the filename
	
	printf ("Please enter the name of the file you wish to open: ");//the user is prompted to enter the name
	gets(filename);//the filename input is accepted here
	
	fp=fopen(filename, "r");//the filename is no longer hardcoded here
	
	if (fp==NULL)
	{
		printf ("ERROR: File is not found for opening.\n\n");
	}
	else
	{
		printf ("File was successfully opened.\n\n");
		fclose(fp);
		printf ("File has now been closed.");
	}//end if
	
	getchar();
}//end main()