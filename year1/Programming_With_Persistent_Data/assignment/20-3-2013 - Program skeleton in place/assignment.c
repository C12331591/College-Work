/*Program to manage a database of employee records
Due 26 April 2013
Brian Willis
*/

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

//define constants here

//define structures here

void add(void);
void del(void);
void list(void);
void compact(void);
//don't forget to change parameters as necessary

main()
{
	//Add check to see if file already exists
	
	int decision=0;
	int exit=0;
	
	while (exit==0)
	{
		printf 	(	"Please select an operation from 1 to 5:\n"
					"1. Add Employee\n"
					"2. Delete Employee\n"
					"3. List Employees\n"
					"4. Compact Records\n"
					"5. Exit\n"
				);
		
		scanf ("%d", &decision);
		flushall();
		
		switch (decision)
		{
			case 1:
			{
				add();
				break;
			}
			case 2:
			{
				del();
				break;
			}
			case 3:
			{
				list();
				break;
			}
			case 4:
			{
				compact();
				break;
			}
			case 5:
			{
				exit=1;
				break;
			}
			default:
			{
				printf ("\nInvalid input. Please enter a number between 1 and 5 to select an operation.\n\n");
				break;
			}
		}//end switch
	}//end while
}//end main()

void add()
{
	printf ("\nAdd function not yet implemented.\n\n");
}//end add()

void del()
{
	printf ("\nDelete function not yet implemented.\n\n");
}//end del()

void list()
{
	printf ("\nList function not yet implemented.\n\n");
}//end list()

void compact()
{
	printf ("\nCompact function not yet implemented.\n\n");
}//end compact()