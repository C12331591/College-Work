/*Program to mark a record in a file for deletion
Brian Willis
20/3/2013
*/

#include <stdio.h>
#include <stdlib.h>

struct book
{
	int isbn[13];
	char title[30];
	char auth[25];
	int copies;
	float price;
};

main()
{
	typedef struct book finder;
	finder current;
	FILE *books;
	books=fopen("books.dat", "ab");
	char choice='y';
	int del=0;
	int isbndel[13];
	int match;
	int i;
	
	if (books==NULL)
	{
		printf ("Error: Could not open file.");
	}
	else
	{
		while (choice=='y'||choice=='Y')
		{
			printf ("Please enter the ISBN of the record you wish to delete.\n");
			for (i=0;i<13;i++)
			{
				printf ("Digit %d\n", i);
				scanf ("%d", &isbndel[i]);
				if (isbndel[i]>9)
				{
					isbndel[i]=9;
				}
				else if (isbndel[i]<0)
				{
					isbndel[i]=0;
				}
			}
			
			while (books!=NULL&&del==0)
			{
				match=1;
				
				for (i=0;i<13;i++)
				{
					if (current.isbn[i]!=isbndel[i])
					{
						match=0;
					}
				}
				
				if (match==1)
				{
					current.isbn[0]='*';
					printf ("\nRecord was marked for deletion.");
					del=1;
				}
				
				fseek (books, sizeof(current), SEEK_CUR);
			}
			
			if (del==0)
			{
				printf ("\nRecord could not be deleted.");
			}
			
			printf ("\nDelete another record? (y/n): ");
			scanf ("%1s", &choice);
		}//end while
	}//end if
	
	fclose(books);
}//end main()