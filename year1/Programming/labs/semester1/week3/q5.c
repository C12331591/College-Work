/*Program to calculate the volume of a cube.
Brian Willis
02/10/2012
*/

#include <stdio.h>

main()
{
	float side;
	float volume;
	
	side=2.8;
	volume=side*side*side;
	
	printf ("The volume of the cube with sides %f metres is %f metres cubed.", side, volume);
	
	getchar();
}