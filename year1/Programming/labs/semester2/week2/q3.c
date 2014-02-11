/*Program to find the highest and lowest of three numbers
Brian Willis
5/2/2013
*/

#include <stdio.h>

#define CYCLES 2

void highlow(int, int, int);

main()
{
	int num1, num2, num3;
	
	printf ("Please input the first number.\n");
	scanf ("%d", &num1);
	printf ("Please input the second number.\n");
	scanf ("%d", &num2);
	printf ("Please input the third number.\n");
	scanf ("%d", &num3);
	printf ("\n");
	
	highlow (num1, num2, num3);
	
	flushall();
	getchar();
}//end main()

void highlow(int sort1, int sort2, int sort3)
{
	int i;
	int temp;
	
	for (i=0;i<CYCLES;i++)
	{
		if (sort1<sort2)
		{
			temp=sort1;
			sort1=sort2;
			sort2=temp;
		}//end if
		
		if (sort2<sort3)
		{
			temp=sort2;
			sort2=sort3;
			sort3=temp;
		}//end if
	}//end for
	
	printf ("The highest number is: %d\n\n", sort1);
	printf ("The lowest number is: %d", sort3);
}//end highlow()