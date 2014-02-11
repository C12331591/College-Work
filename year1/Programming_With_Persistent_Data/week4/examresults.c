/*Program to analyse information from a text file
From notes
Brian Willis
20/2/2013
*/

#include <stdio.h>
#include <stdlib.h>

int main()
{
	FILE *fp;//creates the file pointer
	char student[20];//creates an array for students
	int mark;//creates an int variable to store the current mark
	
	fp=fopen("result.txt", "r");//opens the file for reading
	
	if (fp==NULL)//checks if the opening was successful
	{
		printf ("Cannot open file.\n");//error message for unsuccessful opening
	}
	
	while (fscanf(fp, "%s" "%i", student,  &mark)!=EOF)//repeat until it reaches the end of the file
	{
		if (mark>=40)//criteria for passing
		{
			printf ("%s passed the exam!\n", student);//displays if criteria is met
		}
	}
	
	fclose(fp);//closes the file
	return 0;//main() returns 0
}//end main()