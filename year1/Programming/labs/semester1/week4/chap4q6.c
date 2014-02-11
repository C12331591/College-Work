/*Program to convert Celcius to Fahrenheit
Brian Willis
09/10/2012
*/

#include <stdio.h>

main()
{
	float fah;
	float cel;
	
	printf ("Input the temperature in degrees Fahrenheit.\n");
	scanf ("%f", &fah);
	
	cel=(fah-32.0)*(5.0/9.0);
	
	printf ("\n\nThe temperature in Celcius is %f.", cel);
	
	flushall();
	getchar();
}