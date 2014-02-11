/*Program to copy contents of one file into another
From notes
Brian Willis
20/2/2013
*/

#include <stdio.h>
#include <stdlib.h>

int main()
{
	FILE *file_r;//creates the pointer for reading the file
	FILE *file_w1;//creates the pointer for writing the file
	FILE *file_w2;
	FILE *file_w3;
	
	int num_r, num_w;//creates int variables for use during the operation
	char buffer[100];//creates a variable for data to be moved through
	
	if ((file_r=fopen("rugby.bmp", "rb"))==NULL)//opens the file for reading and checks that the operation was successful
	{
		printf ("Error: Cannot open read file!\n");//error message for unsuccessful opening
	}
	
	if ((file_w1=fopen("rugby_copy1.bmp", "wb"))==NULL)//opens the file for writing and checks that the operation was successful
	{
		printf ("Error: Cannot open write file!");//error message for unsuccessful opening
	}
	
	if ((file_w2=fopen("rugby_copy2.bmp", "wb"))==NULL)//opens the file for writing and checks that the operation was successful
	{
		printf ("Error: Cannot open write file!");//error message for unsuccessful opening
	}
	
	if ((file_w3=fopen("rugby_copy3.bmp", "wb"))==NULL)//opens the file for writing and checks that the operation was successful
	{
		printf ("Error: Cannot open write file!");//error message for unsuccessful opening
	}
	
	while (feof(file_r)==0)//repeats until it reaches the end of the file
	{
		num_r=fread(buffer, 1, 100, file_r);//reads data from the source file
		num_w=fwrite(buffer, 1, num_r, file_w1);//writes the data to the other file
		
		if (num_w!=num_r)//checks that the writing was successful
		{
			fprintf(stderr, "Error: Cannot write file!\n");//error message for unsuccessful writing
		}
	}
	
	num_r=0;
	num_w=0;
	
	while (feof(file_r)==0)//repeats until it reaches the end of the file
	{
		num_r=fread(buffer, 1, 100, file_r);//reads data from the source file
		num_w=fwrite(buffer, 1, num_r, file_w2);//writes the data to the other file
		
		if (num_w!=num_r)//checks that the writing was successful
		{
			fprintf(stderr, "Error: Cannot write file!\n");//error message for unsuccessful writing
		}
	}
	
	while (feof(file_r)==0)//repeats until it reaches the end of the file
	{
		num_r=fread(buffer, 1, 100, file_r);//reads data from the source file
		num_w=fwrite(buffer, 1, num_r, file_w3);//writes the data to the other file
		
		if (num_w!=num_r)//checks that the writing was successful
		{
			fprintf(stderr, "Error: Cannot write file!\n");//error message for unsuccessful writing
		}
	}
	
	fclose(file_r);//closes the source file 
	fclose(file_w1);//closes the writing file
	fclose(file_w2);//closes the writing file
	fclose(file_w3);//closes the writing file
	return 0;//main() returns a value of 0
}//end main()