/*Program to display records in the library file
Brian Willis
13/3/2013
*/

#include <stdio.h>
#include <stdlib.h>

struct book
{
	int isbn[13];
	char title[30];
	char auth[25];
	int copies;
	float price;
};

main()
{
	typedef struct book entry;
	entry current;