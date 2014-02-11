/*Program to merge two files
Brian Willis
27/2/2013
*/

#include <stdio.h>

main()
{
	FILE *read1;
	FILE *read2;
	FILE *write1;
	int num_r1, num_r2, num_w;
	
	read1=fopen("odd.txt", "rb");
	read2=fopen("even.txt", "rb");
	write1=fopen("poem.txt", "wb");
	
	if (read1==NULL)
	{
		printf ("Unable to open odd.txt\n");
	}//end if
	
	if (read2==NULL)
	{
		printf ("Unable to open even.txt\n");
	}//end if
	
	if (write1==NULL)
	{
		printf ("Unable to open poem.txt\n");
	}//end if
	
	while ((num_r1=fgetc(read1)!=EOF)||(num_r2=fgetc(read2)!=EOF))
	{
		if (num_r1==num_r2)
		{
			num_w=fputc(num_r1, write1);
			
			if (num_w!=num_r1)
			{
				printf ("Unable to write data\n");
			}//end inner if
		}
		else if (num_r1!=' ')
		{
			num_w=fputc(num_r1, write1);
			
			if (num_w!=num_r1)
			{
				printf ("Unable to write data\n");
			}//end inner if
		}
		else
		{
			num_w=fputc(num_r2, write1);
			
			if (num_w!=num_r2)
			{
				printf ("Unable to write data\n");
			}//end inner if
		}//end outer if
	}//end while
	
	fclose(read1);
	fclose(read2);
	fclose(write1);
}//end main()