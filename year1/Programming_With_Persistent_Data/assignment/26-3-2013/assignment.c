/*Program to manage a database of employee records
Due 26 April 2013
Brian Willis
*/

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

//define constants here

//define structures here
struct employee
{
	char emp_num[6];
	char firstname[16];
	char surname[16];
	char address[26];
	char dep_code[10];
	char duration[2];
};

void add(void);
void del(void);
void list(void);
void compact(void);
int create(void);
//don't forget to change parameters as necessary

main()
{
	if (create()==1)
	{
		printf ("employees.dat was created.");
	}
	else
	{
		printf ("employees.dat was found.");
	}
	
	int decision=0;
	int exit=0;
	
	while (exit==0)
	{
		printf 	(	"\n\nPlease select an operation from 1 to 5:\n"
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
	struct employee current;
	FILE *records;
	records=fopen("employees.dat", "rb");
	int active=0;
	int deleted=0;
	
	if (records==NULL)
	{
		printf ("\nError: File could not be opened.");
	}
	else
	{
		while (fread(&current, sizeof(current), 1, records)!=NULL)
		{
			if (current.emp_num[0]=='*')
			{
				deleted++;
			}
			else
			{
				active++;
				printf ("\nEmployee Number:	%6s", current.emp_num);
				printf ("\nFirst Name:	%s", current.firstname);
				printf ("\nSurname:	%s", current.surname);
				printf ("\nAddress:	%s", current.address);
				printf ("\nDepartment Code:	%s", current.dep_code);
				printf ("\nDuration Employed:	%s", current.duration);
			}
		}
		
		if (active==0&&deleted==0)
		{
			printf ("\nNo records were found in the file.\n");
		}
		else
		{
			printf ("\nActive employees:	%d", active);
			printf ("\nTotal records:	%d", active+deleted);
			printf ("\nRecords marked for deletion:	%d", deleted);
		}
	}
	
	fclose(records);
}//end list()

void compact()
{
	printf ("\nCompact function not yet implemented.\n\n");
}//end compact()

int create()
{
	FILE *check;
	check=fopen("employees.dat", "rb");
	
	if (check==NULL)
	{
		FILE *create;
		create=fopen("employees.dat", "wb");
		return(1);
	}
	else
	{
		return(0);
	}
	
	fclose(check);
}//end create()