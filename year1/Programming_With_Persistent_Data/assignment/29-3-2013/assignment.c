/*Program to manage a database of employee records
Due 23 April 2013
Brian Willis
*/

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

struct employee
{
	char emp_num[6];
	char firstname[16];
	char surname[16];
	char address[26];
	char dep_code[10];
	char duration[2];
};

struct header
{
	int totalrecs;
	int delrecs;
	char filler[16];
};

#define RECSIZE sizeof(struct employee)
#define HEADERSIZE sizeof(struct header)

void add(void);
void del(void);
void list(void);
void compact(void);
int create(void);
void update(int, int);

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
	struct record addition;
	struct record check;
	FILE *add;
	FILE *search;
	add=fopen("employees.dat", "ab");
	search=fopen("employees.dat", "rb");
	int found=0;
	int valid=0;
	char answer;
	
	printf ("\nPlease enter the number of the employee to be added.\n");
	scanf ("%5s", &addition.emp_num);
	
	while(fread(&check, RECSIZE, 1, search)!=NULL && found==0)
	{
		if(strcmp(check.emp_num, addition.emp_num)==0)
		{
			found=1;
		}
	}
	
	if (found==1)
	{
		printf ("\nThe specified employee number is already listed in the file. Do you wish to overwrite the record? (y/n)\n");
		
		do
		{
			scanf ("%1s", &answer)
			if (answer=='y'||answer=='Y')
			{
				valid=1;
			}
			else if (answer=='n'||answer=='N')
			{
				valid=1;
			}
			else
			{
				printf ("\nInvalid input.\n");
			}
		}
		while (valid==0);
	}
	
}//end add()


void del()
{
	struct employee current;
	FILE *search;
	FILE *mark;
	search=fopen("employees.dat", "rb");
	mark=fopen("employees.dat", "ab");
	int found=0;
	char input[6];
	
	printf ("\nPlease enter the number of the employee to be deleted.\n");
	scanf ("%5s", &input);
	flushall();
	
	fseek(search, HEADERSIZE, SEEK_SET);
	
	while(fread(&current, RECSIZE, 1, search)!=NULL && found==0)
	{
		if(strcmp(current.emp_num, input)==0)
		{
			found=1;
			mark=search;
		}
	}//end while
	
	if (found==0)
	{
		printf ("\nThe specified employee number does exist in the file.\n\n");
	}
	else
	{
		current.emp_num[0]='*';
		fwrite(&current, RECSIZE, 1, mark);
		update(0, 1);
	}
	
	fclose(search);
	fclose(mark);
}//end del()


void list()
{
	struct employee current;
	struct header readheader;
	FILE *records;
	records=fopen("employees.dat", "rb");
	fseek(records, HEADERSIZE, SEEK_SET);
	
	if (records==NULL)
	{
		printf ("\nError: File could not be opened.");
	}
	else
	{
		while (fread(&current, RECSIZE, 1, records)!=NULL)
		{
			if (current.emp_num[0]!='*')
			{
				printf ("\nEmployee Number:	%s", current.emp_num);
				printf ("\nFirst Name:	%s", current.firstname);
				printf ("\nSurname:	%s", current.surname);
				printf ("\nAddress:	%s", current.address);
				printf ("\nDepartment Code:	%s", current.dep_code);
				printf ("\nDuration Employed:	%s", current.duration);
			}
		}
		
		rewind(records);
		fread(&readheader, HEADERSIZE, 1, records);
		
		if (readheader.totalrecs==0)
		{
			printf ("\nNo records were found in the file.\n");
		}
		else
		{
			printf ("\nActive employees:	%d", (readheader.totalrecs)-(readheader.delrecs));
			printf ("\nTotal records:	%d", readheader.totalrecs);
			printf ("\nRecords marked for deletion:	%d", readheader.delrecs);
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
	int created=1;
	
	if (check==NULL)
	{
		FILE *create;
		create=fopen("employees.dat", "wb");
		struct header addheader;
		
		addheader.totalrecs=0;
		addheader.delrecs=0;
		strcpy(addheader.filler, "\0");
		
		fwrite(&addheader, HEADERSIZE, 1, create);
	}
	else
	{
		created=0;
	}
	
	fclose(check);
	return(created);
}//end create()

void update(int added, int marked)
{
	struct header updated;
	FILE *fileaccess;
	fileaccess=fopen("employees.dat", "ab")
	rewind(fileaccess);
	fread (&updated, HEADERSIZE, 1, fileaccess);
	
	updated.totalrecs=updated.totalrecs+added;
	updated.delrecs=updated.delrecs+marked;
	
	fwrite(&updated, HEADERSIZE, 1, fileaccess);
	
	fclose(fileaccess);
}//end update()