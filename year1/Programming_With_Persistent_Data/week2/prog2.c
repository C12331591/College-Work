/*Program which uses open and close commands
From lab instructions
Brian Willis
6/2/2013
*/

#include <stdio.h>

main()
{
	FILE *fp;
	
	fp=fopen("prog1.c", "r");
	//The fclose command is removed here
	
	if (fp==NULL)//this will detect if the opening was successful
	{
		printf ("ERROR: File is not found for opening.\n\n");
		//This will display if the file could not be opened
	}
	else
	{
		printf ("File was successfully opened.\n\n");//this will indicate that the file was opened
		fclose(fp);//fp is closed
		printf ("File has now been closed.");//this shows that the file was closed
	}//end if
	
	getchar();
}//end main()