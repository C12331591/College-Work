/*Program to calculate the sum of the integes 1 to 5 and to calculate the average of the floating point 
numbers 1.0, 1.1, 1.2... 2.0.
Brian Willis
02/10/2012
*/

#include <stdio.h>

main()
{
	int sum;
	
	sum=1+2+3+4+5;
	
	printf ("The sum of the integers 1 to 5 is %d.", sum);
	
	float f1;
	
	//This totals the numbers before dividing the result by the number of numbers
	
	f1=1.0+1.2+1.3+1.4+1.5+1.6+1.7+1.8+1.9+2.0;
	f1=f1/10;
	
	printf ("\nThe average of The floating point numbers 1.0, 1.1... 2.0 is %f.", f1);
	
	getchar();
}