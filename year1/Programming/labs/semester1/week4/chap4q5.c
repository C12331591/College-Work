/*Program to calculate the number of hearbeats in a person's life thus far (If bpm=75)
Brian Willis
09/10/2012
*/

#include <stdio.h>

main()
{
	double bpm;
	double age;
	double hour;
	double day;
	double year;
	double total;
	
	bpm=75;
	hour=bpm*60;
	day=hour*24;
	year=day*365;
	
	printf ("What is your age?\n");
	scanf ("%lf", &age);
	
	total=age*year;
	
	printf ("Your heart as made appoximately %3.0lf beats so far.", total);
	
	getchar();
	getchar();
}