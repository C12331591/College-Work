/*Program which uses open and close commands
From lab instructions
Brian Willis
6/2/2013
*/

#include <stdio.h>

main()
{
	FILE *fp;//a pointer variable is created for the file
	
	fp=fopen("prog1.c", "r");//the file is opened into fp
	fclose(fp);//fp is closed
}//end main()