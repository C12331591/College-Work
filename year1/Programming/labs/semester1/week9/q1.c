/*Program to display the contents of a specific element in an array
Brian Willis
13/11/2012
*/

#include <stdio.h>
#define SIZE 10

main()
{
	int a[SIZE];
	int i;
	
	for (i=0;i<10;i++)
	{
		a[i]=9-i;
	}
	
	for (i=0;i<10;i++)
	{
		a[i]=a[a[i]];
	}
	
	for (i=0;i<SIZE;i++)
	{
		printf ("%d is contained within a[%d].\n", a[i], i);
	}
	
	getchar();
}//end main