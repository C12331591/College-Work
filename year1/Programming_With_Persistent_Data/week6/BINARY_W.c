/*Program to process data using a struct
From notes
Brian Willis
6/3/2013
*/

#include <stdio.h>
#include <stdlib.h>

struct record 
{
	char last_name[20];
	char first_name[15];
	int age;
	float salary;
};

void main()
{
	typedef struct record person;
	person employee;
	char choice='y';
	FILE *people;
	people=fopen("employee.dat", "ab");
	
	if (people==NULL)
	{
		printf ("ERROR: Failed to open file!");
	}
	else
	{
		while (choice=='y'||choice=='Y')
		{
			printf ("\nEnter surname: ");
			scanf ("%s", employee.last_name);
			flushall();
			printf ("\nEnter first name: ");
			scanf ("%s", employee.first_name);
			flushall();
			printf ("\nEnter age: ");
			scanf ("%d", &employee.age);
			flushall();
			printf ("\nEnter salary: ");
			scanf ("%f", &employee.salary);
			
			fwrite (&employee, sizeof(employee), 1, people);
			
			printf ("\nAdd another record? (y/n): ");
			scanf ("%1s", &choice);
		}//end while
	}//end if
	
	fclose(people);
}//end main