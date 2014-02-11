/*Program to calculate the desired term of Fibonacci
Brian Willis
18/2/2013
*/

#include <stdio.h>

int fibonacci(int);

main()
{
	int input;
	int answer;
	
	printf ("Please enter which term you want to calculate to.\n");
	scanf ("%d", &input);
	
	answer=fibonacci(input);
	
	printf ("\nTerm %d is %d.", input, answer);
	
	flushall();
	getchar();
}//end maqin()

int fibonacci(int n)
{
	if (n==0|n==1)
	{
		return(n);
	}
	else
	{
		return ((fibonacci(n-1))+(fibonacci(n-2)));
	}
}//end fibonacci