/*Program that uses a function which accepts two parameters
Brian Willis
5/2/2013
*/

#include <stdio.h>

void func1(int, char);

main()
{
	int num;
	char ch;
	
	printf ("Please input a number.\n");
	scanf ("%d", &num);
	printf("Please input a character.\n");
	scanf ("%1s", &ch);
	printf ("\n");
	
	func1(num, ch);
	
	flushall();
	getchar();
}//end main()

void func1(int timesprint, char printthis)
{
	int i;
	
	for (i=0;i<timesprint;i++)
	{
		printf ("%c", printthis);
	}//end for
}//end func1()