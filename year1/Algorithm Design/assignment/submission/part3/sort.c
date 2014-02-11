/*Sorting and merging the three lists
Brian Willis
*/

#include <stdio.h>

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

void mergesort(struct student[], int, int);
void merge2(struct student[], int, int, int);
void merge3(struct student[], int, struct student[], int, struct student[], int);
int compare(struct student, struct student);

struct student dit[RECS];
struct student itt[RECS];
struct student itb[RECS];

main()
{
	int i;
	
	printf ("DIT students:\n");
	for (i=0;i<RECS;i++)
	{
		printf ("Student %d surname: ", i);
		gets(dit[i].surname);
		printf ("\nStudent %d first name: ", i);
		gets(dit[i].firstname);
		printf ("\nStudent %d number: ", i);
		gets(dit[i].stu_num);
		dit[i].college='d';
	}
	
	printf ("ITT students:\n");
	for (i=0;i<RECS;i++)
	{
		printf ("Student %d surname: ", i);
		gets(itt[i].surname);
		printf ("\nStudent %d first name: ", i);
		gets(itt[i].firstname);
		printf ("\nStudent %d number: ", i);
		gets(itt[i].stu_num);
		itt[i].college='t';
	}
	
	printf ("ITB students:\n");
	for (i=0;i<RECS;i++)
	{
		printf ("Student %d surname: ", i);
		gets(itb[i].surname);
		printf ("\nStudent %d first name: ", i);
		gets(itb[i].firstname);
		printf ("\nStudent %d number: ", i);
		gets(itb[i].stu_num);
		itb[i].college='b';
	}
	
	mergesort(dit, 0, RECS-1);
	mergesort(itt, 0, RECS-1);
	mergesort(itb, 0, RECS-1);
	
	merge3(dit, RECS, itt, RECS, itb, RECS);
}//end main()

void mergesort(struct student A[], int low, int high)
{
	int mid;
	if (low==high)
	{
		return;
	}
	else
	{
		mid=(low+high)/2;
		mergesort(A, low, mid);
		mergesort(A, mid+1, high);
		merge2(A, low, mid, high);
	}//end if
}//end mergesort()

void merge2(struct student A[], int low, int mid, int high)
{
	int p1=low;
	int p2=mid+1;
	int count=0;
	struct student newa[SIZE];
	
	while(p1<(mid+1) || p2<(high+1))
	{
		if (compare(A[p1], A[p2])==0 && p1<mid+1 && p2<high+1)
		{
			newa[count]=A[p1];
			count++;
			p1++;
		}
		else if (p1<mid+1&&p2==high+1)
		{
			newa[count]=A[p1];
			count++;
			p1++;
		}
		else if (compare(A[p2], A[p1])==0 && p1<mid+1 && p2<high+1)
		{
			newa[count]=A[p2];
			count++;
			p2++;
		}
		else if (p1==mid+1&&p2<high+1)
		{
			newa[count]=A[p2];
			count++;
			p2++;
		}
	}//end while
}//end merge2()

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

void merge3(struct student A[], int sizea, struct student B[], int sizeb, struct student C[], int sizec)
{
	int ia=0, ib=0, ic=0;
	int count=0;
	struct student merged[RECS*3];
	FILE *write;
	write=fopen("records.dat", "wb");
	
	while (ia<sizea || ib<sizeb ||ic<sizec)
	{
		if (compare(A[ia], B[ib])==0 && ia<sizea && ib<sizeb)
		{
			if (compare(A[ia], C[ic])==0 && ic<sizec)
			{
				merged[count]=A[ia];
				count++;
				ia++;
			}
			else if (ia<sizea && ic==sizec)
			{
				merged[count]=A[ia];
				count++;
				ia++;
			}//end if
		}
		else if (ia<sizea && ib==sizeb)
		{
			if (compare(A[ia], C[ic])==0 && ic<sizec)
			{
				merged[count]=A[ia];
				count++;
				ia++;
			}
			else if (ia<sizea && ic==sizec)
			{
				merged[count]=A[ia];
				count++;
				ia++;
			}//end if
		}
		else if (compare(B[ib], C[ic])==0 && ib<sizeb && ic<sizec)
		{
			merged[count]=B[ib];
			count++;
			ib++;
		}
		else if(ib<sizeb && ic==sizec)
		{
			merged[count]=B[ib];
			count++;
			ib++;
		}
		else
		{
			merged[count]=C[ic];
			count++;
			ic++;
		}
	}//end while
	
	fwrite(&merged, (RECSIZE*(RECS*3)), 1, write);
	
	fclose(write);
}//end merge3()