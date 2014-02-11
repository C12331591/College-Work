/*Searching the merged list
Brian Willis
*/

#include <stdio.h>
#include <string.h>

#define SIZE 15
#define RECS 5

struct student
{
	char surname[SIZE];
	char firstname[SIZE];
	char stu_num[SIZE];
	char college;
};

#define RECSIZE sizeof(student)

void binarysearch(struct student[], char[], char[], int, int);
int compare(struct student, struct student);

struct student sortedlist[RECS];
FILE *open;
open=fopen("records.dat", "rb");

main()
{
	char first[SIZE];
	char sur[SIZE];
	
	printf ("First name to search: ");
	gets(first);
	printf("Surname to search: ");
	gets(sur);
	
	binarysearch(sortedlist, sur, first, 0, RECS*3);
}//end main

void binarysearch(struct student A[], char searchsur[], char searchfir[], int min, int max)
{
	int mid=(min+max)/2;
	struct student searchterms;
	int i;
	strcpy(searchterms.surname, searchsur);
	strcpy(searchterms.surname, searchsur);
	
	if (strcmp(A[mid].surname, searchsur)==0)
	{
		i=mid;
		/*Cannot implement linear search section within time limit
		*/
		
		while (strcmp(A[i].firstname, searchfir)==0)
		{
			printf ("Student Number: %\n", A[i].stu_num);
			printf ("First Name: %s\n", A[i].firstname);
			printf ("Surname: %s\n", A[i].surname);
			printf ("College: %c", A[i].college);
			if (strcmp(A[i].firstname, A[i+1].firstname)==0 && A[i].college!=A[i+1].college)
			{
				printf ("Warning: Potential duplicate student records\n");
			}
			i++;
		}//end while
	}
	else if (compare(A[mid], searchterms)==1)
	{
		binarysearch(A, searchsur, searchfir, min, mid);
	}
	else
	{
		binarysearch(A, searchsur, searchfir, mid, max);
	}
}//end binarysearch()

int compare (struct student reca, struct student recb)
{
	int count=0;
	
	while(reca.surname[count]!='\0' && recb.surname[count]!='\0')
	{
		if (reca.surname[count]>recb.surname[count])
		{
			return(1);
		}
		else if (reca.surname[count]<recb.surname[count])
		{
			return(0);
		}//end if
		
		count++;
	}
	
	count=0;
	
	while(reca.firstname[count]!='\0' && recb.firstname[count]!='\0')
	{
		if (reca.firstname[count]>recb.firstname[count])
		{
			return(1);
		}
		else if (reca.firstname[count]<recb.firstname[count])
		{
			return(0);
		}//end if
		
		count++;
	}
	
	count=0;
	
	while(reca.stu_num[count]!='\0' && recb.stu_num[count]!='\0')
	{
		if (reca.stu_num[count]>recb.stu_num[count])
		{
			return(1);
		}
		else if (reca.stu_num[count]<recb.stu_num[count])
		{
			return(0);
		}//end if
		
		count++;
	}
	
	return(0);//this line ideally won't be reached
}//end compare()