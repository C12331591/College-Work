/*Program to calculate the volume and surface area of a box 10cm x 11.5cm x 2.5cm.
Brian Willis
02/10/2012
*/

#include <stdio.h>

main()
{
	//I decided to define the dimensions so they would only need to be entered once.
	
	float hei;
	float len;
	float wid;
	
	hei=10.0;
	len=11.5;
	wid=2.5;
	
	float vol;
	float sur;
	
	vol=hei*len*wid;
	sur=2*(hei*len)+2*(hei*wid)+2*(len*wid);
	
	printf ("The volume of the box is %f.", vol);
	printf ("\nThe surface area of the box is %f.", sur);
	
	getchar();
}