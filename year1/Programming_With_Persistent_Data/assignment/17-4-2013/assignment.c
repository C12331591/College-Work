/*Program to manage a database of employee records
Due 26 April 2013
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
void nulterm(char[]);

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
	
	int decision;
	int exit=0;
	
	while (exit==0)
	{
		decision=0;
		flushall();//flushing anything left over from previous operations
		
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
			}
		}//end switch
	}//end while
}//end main()


void add()
{
	struct employee addition;
	struct employee check;
	FILE *add;
	add=fopen("employees.dat", "rb+");
	fseek(add, HEADERSIZE, SEEK_SET);
	int found=0;
	int overwrite=0;
	char answer;
	
	printf ("\nPlease enter the number of the employee to be added.\n");
	scanf ("%5s", &addition.emp_num);
	
	while(found==0)
	{
		if(fread(&check, RECSIZE, 1, add)!=NULL)
		{
			if(strcmp(check.emp_num, addition.emp_num)==0)
			{
				found=1;
			}//end inner if
		}
		else
		{
			found=2;
		}//end if
	}//end while
	
	if (found==1)
	{
		fseek(add, -RECSIZE, SEEK_CUR);
		printf ("\nThe specified employee number is already listed in the file. Do you wish to overwrite the record? (y/n)\n");
		
		do
		{
			scanf ("%1s", &answer);
			if (answer=='y'||answer=='Y')
			{
				overwrite=1;
			}
			else if (answer=='n'||answer=='N')
			{
				return;
			}
			else
			{
				printf ("\nInvalid input.\n");
			}//end if
		}
		while (overwrite==0);
	}//end if
	
	flushall();
	printf ("\nPlease enter the first name of the employee.\n");
	gets(addition.firstname);
	
	flushall();
	printf ("\nPlease enter the surname of the employee.\n");
	gets(addition.surname);
	
	flushall();
	printf ("\nPlease enter the address of the employee.\n");
	gets(addition.address);
	
	flushall();
	printf ("\nPlease enter the department code of the employee.\n");
	gets(addition.dep_code);
	
	flushall();
	printf ("\nPlease enter the employee's duration (in years) working here.\n");
	gets(addition.duration);
	
	fwrite(&addition, RECSIZE, 1, add);
	fclose(add);
	
	if (overwrite==0)
	{
		update(1, 0);
	}//end if
}//end add()


void del()
{
	struct employee current;
	FILE *mark;
	mark=fopen("employees.dat", "rb+");
	fseek(mark, HEADERSIZE, SEEK_SET);
	int found=0;
	char input[6];
	
	printf ("\nPlease enter the number of the employee to be deleted.\n");
	scanf ("%5s", &input);
	flushall();
	
	while(fread(&current, RECSIZE, 1, mark)!=NULL && found==0)
	{
		if(strcmp(current.emp_num, input)==0)
		{
			fseek(mark, -RECSIZE, SEEK_CUR);
			found=1;
			current.emp_num[0]='*';
			fwrite(&current, RECSIZE, 1, mark);
			update(0, 1);
		}
	}//end while
	
	if (found==0)
	{
		printf ("\nThe specified employee number does exist in the file.\n\n");
	}
	
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
	FILE *oldf;
	FILE *newf;
	oldf=fopen("employees.dat", "rb+");
	newf=fopen("employeescomp.dat", "wb+");
	struct header htransfer;
	struct employee rtransfer;
	
	fread(&htransfer, HEADERSIZE, 1, oldf);
	htransfer.totalrecs=htransfer.totalrecs-htransfer.delrecs;
	htransfer.delrecs=0;
	fwrite(&htransfer, HEADERSIZE, 1, newf);
	
	while (fread(&rtransfer, RECSIZE, 1, oldf))
	{
		if (rtransfer.emp_num[0]!='*')
		{
			fwrite(&rtransfer, RECSIZE, 1, newf);
		}
	}
	
	fclose(oldf);
	fclose(newf);
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
		
		fwrite(&addheader, HEADERSIZE, 1, create);
		fclose(create);
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
	fileaccess=fopen("employees.dat", "rb+");
	fread (&updated, HEADERSIZE, 1, fileaccess);
	rewind(fileaccess);
	
	if (added==1)
	{
		updated.totalrecs++;
	}
	
	if (marked==1)
	{
		updated.delrecs++;
	}
	
	fwrite(&updated, HEADERSIZE, 1, fileaccess);
	
	fclose(fileaccess);
}//end update()