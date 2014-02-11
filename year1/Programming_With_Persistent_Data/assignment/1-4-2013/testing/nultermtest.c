/*testing nulterm function
*/

#include <stdio.h>

void nulterm(int, char[]);

main()
{
	char str[6];
	
	printf ("Type in a string.\n");
	gets(str);
	
	nulterm(6, str);
	
	if(str[5]=='\0')
	{
		printf ("\nstr is null terminated");
	}
	else
	{
		printf ("\nstr is not null terminated");
	}
	
	flushall();
	getchar();
}

void nulterm(int varsize, char recar[])
{
	int els;
	els=varsize/sizeof(char);
	
	recar[els-1]='\0';
	
	printf("varsize is %d\n", sizeof(varsize));
}