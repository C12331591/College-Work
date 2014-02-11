/*Program to calculate the result of specified arithmetic operations.
Brian Willis
02/10/2012
*/

#include <stdio.h>

main()
{
	int op1, op2, op3, op5;
	float op4;
	//Only the fourth operation can potentially produce a decimal.
	
	op1=15+10;
	op2=15-10;
	op3=15*10;
	op4=15.0/10.0;
	op5=15%3;
	
	printf ("15 + 10 = %d", op1);
	printf ("\n15 - 10 = %d", op2);
	printf ("\n15 * 10 = %d", op3);
	printf ("\n15 / 10 = %f", op4);
	printf ("\nRemainder of 15 / 3 = %d", op5);
	
	getchar();
}