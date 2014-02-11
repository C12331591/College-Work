/*struct1.c
from notes
Brian Willis
13/3/2013
*/

#include <stdio.h>

main()
{
	struct
	{
		char initial;
		int age;
		int grade;
	}kids[12];
	
	int i;
	
	for (i=0;i<12;i++)
	{
		kids[i].initial='A'+i;
		kids[i].age=16;
		kids[i].grade=84;
	}//end for
	
	kids[3].age=kids[5].age=17;
	kids[2].grade=kids[6].grade=92;
	kids[4].grade=57;
	kids[10]=kids[4];
	
	for (i=0;i<12;i++)
	{
		printf ("%c is %d years old and got a grade of %d\n", kids[i].initial, kids[i].age, kids[i].grade);
	}
	
	getchar();
}//end main()