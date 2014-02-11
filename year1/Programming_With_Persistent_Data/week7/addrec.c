/*Program to add records to the library file
Brian Willis
13/3/2013
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
	typedef struct book addition;
	addition current;
	FILE *books;
	books=fopen("books.dat", "ab");
	char choice='y';
	
	if (books==NULL)
	{
		printf ("Error: Could not open file.");
	}
	else
	{
		while (choice=='y'||choice=='Y')
		{
			printf ("Enter the ISBN.\n");
			scanf ("%d", &current.isbn);
			printf ("Enter the title.\n");
			scanf ("%s", &current.title);
			flushall();
			printf ("Enter the author.\n");
			scanf ("%s", &current.auth);
			flushall();
			printf ("Enter the number of copies.\n");
			scanf ("%d", &current.copies);
			printf ("Enter the price.\n");
			scanf ("%f", &current.price);
			
			fwrite (&current, sizeof(current), 1, books);
			
			printf ("\nAdd another record? (y/n): ");
			scanf ("%1s", &choice);
		}//end while
	}//end if
	
	fclose(books);
}//end main()