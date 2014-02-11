/*Program to display the remainders for specified modulus operations
Brian Willis
02/10/2012
*/

#include <stdio.h>

main()
{
	int mod1, mod2, mod3, mod4, mod5, mod6;
	
	mod1=2%2;
	mod2=3%2;
	mod3=5%2;
	mod4=7%3;
	mod5=100%33;
	mod6=100%7;
	
	printf ("The remainder of 2/2 is %d.", mod1);
	printf ("\nThe remainder of 3/2 is %d.", mod2);
	printf ("\nThe remainder of 5/2 is %d.", mod3);
	printf ("\nThe remainder of 7/3 is %d.", mod4);
	printf ("\nThe remainder of 100/33 is %d.", mod5);
	printf ("\nThe remainder of 100/7 is %d.", mod6);
	
	getchar();
}