#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define SIZE 10

struct employee
{
	char start[SIZE];
	int num;
	char ch;
	char str[6];
	char end[SIZE];
};

struct header
{
	char hello[SIZE];
	int totalrecs;
	int delrecs;
	char goodbye[SIZE];
};

#define RECSIZE sizeof(struct employee)
#define HEADERSIZE sizeof(struct header)

void add(void);
void addnh(void);
void list(void);
void listnh(void);
void update(int, int);
int create(void);
int createnh(void);

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
	
	if (createnh()==1)
	{
		printf ("employeesnh.dat was created.");
	}
	else
	{
		printf ("employeesnh.dat was found.");
	}
	
	int decision;
	int exit=0;
	
	while (exit==0)
	{
		decision=0;
		flushall();//flushing anything left over from previous operations
		
		printf 	(	"\n\nPlease select an operation from 1 to 5:\n"
					"1. Add Employee\n"
					"2. List Employees\n"
					"3. Add no header\n"
					"4. List no header\n"
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
				list();
				break;
			}
			case 3:
			{
				addnh();
				break;
			}
			case 4:
			{
				listnh();
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
		strcpy(addheader.hello, "Hello");
		strcpy(addheader.goodbye, "Goodbye");
		
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

int createnh()
{
	FILE *check;
	check=fopen("employeesnh.dat", "rb");
	int created=1;
	
	if (check==NULL)
	{
		FILE *create;
		create=fopen("employeesnh.dat", "wb");
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
	fileaccess=fopen("employees.dat", "ab");
	rewind(fileaccess);
	fread (&updated, HEADERSIZE, 1, fileaccess);
	
	updated.totalrecs=(updated.totalrecs+added)-marked;
	updated.delrecs=updated.delrecs+marked;
	
	fwrite(&updated, HEADERSIZE, 1, fileaccess);
	
	fclose(fileaccess);
}

void add(void)
{
	struct employee addition;
	FILE *add;
	add=fopen("employees.dat", "ab");
	
	fread(&addition, RECSIZE, 1, add);
	
	strcpy(addition.start, "Start");
	strcpy(addition.end, "End");
	
	printf ("\n\nEnter a number: ");
	scanf ("%d", &addition.num);
	
	printf ("Enter a character: ");
	flushall();
	scanf ("%c", &addition.ch);
	
	printf ("Enter a string 5 characters or less: ");
	flushall();
	gets(addition.str);
	
	fwrite(&addition, RECSIZE, 1, add);
	
	fclose(add);
}//end add()

void addnh(void)
{
	struct employee addition;
	FILE *add;
	add=fopen("employeesnh.dat", "ab");
	
	fread(&addition, RECSIZE, 1, add);
	
	strcpy(addition.start, "Start");
	strcpy(addition.end, "End");
	
	printf ("\n\nEnter a number: ");
	scanf ("%d", &addition.num);
	
	printf ("Enter a character: ");
	flushall();
	scanf ("%c", &addition.ch);
	
	printf ("Enter a string 5 characters or less: ");
	flushall();
	gets(addition.str);
	
	fwrite(&addition, RECSIZE, 1, add);
	
	fclose(add);
}//end addnh()

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
			printf ("\nNumber is %d.", current.num);
			printf ("\nCharacter is %c.", current.ch);
			printf ("\nString is %s", current.str);
		}
		
		rewind(records);
		fread(&readheader, HEADERSIZE, 1, records);
		
		printf ("\nActive employees:	%d", (readheader.totalrecs)-(readheader.delrecs));
		printf ("\nTotal records:	%d", readheader.totalrecs);
		printf ("\nRecords marked for deletion:	%d\n", readheader.delrecs);
		puts(readheader.goodbye);
	}
	
	fclose(records);
}//end list()

void listnh()
{
	struct employee current;
	FILE *records;
	records=fopen("employeesnh.dat", "rb");
	
	if (records==NULL)
	{
		printf ("\nError: File could not be opened.");
	}
	else
	{
		while (fread(&current, RECSIZE, 1, records)!=NULL)
		{
			printf ("\nNumber is %d.", current.num);
			printf ("\nCharacter is %c.", current.ch);
			printf ("\nString is %s", current.str);
		}
	}
	
	fclose(records);
}//end listnh()