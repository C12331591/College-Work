/*Brian Willis
18/2/2013
*/

#include <stdio.h>

void moveTower(int, int, int, int);

main()
{
	int numdisks;
	
	printf ("Enter the number of disks.\n");
	scanf ("%d", &numdisks);
	numdisks=numdisks-1;
	
	moveTower(numdisks, 1, 3, 2);
	
	flushall();
	getchar();
}//end main()

void moveTower(int disk, int source, int dest, int spare)
{
	if (disk==0)
	{
		printf ("\nMove disk %d from tower %d to tower %d.", disk, source, dest);
	}
	else
	{
		moveTower(disk-1, source, spare, dest);
		printf ("\nMove disk %d from tower %d to tower %d.", disk, source, dest);
		moveTower(disk-1, spare, dest, source);
	}//end if
}//end moveTower()