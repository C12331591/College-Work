/*Program to accept input of multiple variables in one line
Brian Willis
09/10/2012
*/

#include <stdio.h>

main()
{
	int first;
	int second, third, fourth;
	float principal, rate, time;
	char keyval1, keyval2;
	long int total1, total2, total3;
	char c;
	int i;
	float f;
	long int l;
	double d;
	
	printf ("Please enter a single number.\n");
	scanf ("%d", &first);
	printf ("\nEnter three more numbers (All on one lin seperated by commas).\n");
	scanf ("%d, %d, %d", &second, &third, &fourth);
	printf ("\nEnter three more numbers, where decimals are accepted.\n");
	scanf ("%f, %f, %f", &principal, &rate, &time);
	printf ("\nEnter two characters.\n");
	scanf ("%1s, %1s", &keyval1, &keyval2);
	printf ("\nPlease enter three whole numbers.\n");
	scanf ("%ld, %ld, %ld", &total1, &total2, &total3);
	printf ("\nFinally, please enter a character, followed by a whole number, followed by any number, followed by any whole number, followed by any number.\n");
	scanf ("%1s, %d, %f, %ld, %lf", &c, &i, &f, &l, &d);
	
	printf ("\n%d", first);
	printf ("\n%d, %d, %d", second, third, fourth);
	printf ("\n%f, %f, %f", principal, rate, time);
	printf ("\n%c, %c", keyval1, keyval2);
	printf ("\n%ld, %ld, %ld", total1, total2, total3);
	printf ("\n%c, %d, %f, %ld, %lf", c, i, f, l, d);
	
	getchar();
	getchar();
}