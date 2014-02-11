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
	FILE *people;
	people=fopen("employee.dat", "rb");
	
	if (people==NULL)
	{
		printf ("ERROR: Failed to open file!");
	}
	else
	{
		while (fread(&employee, sizeof(employee), 1, people)!=EOF)
		{
			printf ("%s\n", employee.last_name);
			printf ("%s\n", employee.first_name);
			printf ("%d\n", &employee.age);
			printf ("%f\n", &employee.salary);
		}//end while
	}//end if
	
	fclose(people);
	
	getchar();
}//end main