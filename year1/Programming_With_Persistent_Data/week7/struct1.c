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
	}boy, girl;
	
	boy.initial='R';
	boy.age=15;
	boy.grade=75;
	
	girl.age=boy.age-1;
	girl.grade=82;
	girl.initial='H';
	
	printf ("%c is %d years old and got a grade of %d\n", boy.initial, boy.age, boy.grade);
	printf ("%c is %d years old and got a grade of %d\n", girl.initial, girl.age, girl.grade);
	
	getchar();
}//end main()