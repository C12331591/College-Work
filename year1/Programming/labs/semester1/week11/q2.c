/*Program to use pointers
 Brian Willis
 27/11/2012
 */
 
 #include <stdio.h>
 
 main()
 {
	int num1=6;
	char char1='y';
	
	int *ptr1;
	char *ptr2;
	int *ptr3;
	
	ptr1=&num1;
	ptr2=&char1;
	ptr3=(int*)&char1;
	
	printf ("num1 contains %d.", num1);
	printf ("\nnum1 is stored at %p.", ptr1);
	printf ("\nchar1 contains %c.", char1);
	printf ("\nchar1 is stored at %p.", ptr2);
	
	printf ("\n\nptr1 contains %p.", ptr1);
	printf ("\nptr2 contains %p.", ptr2);
	
	printf ("\n\nThe address in ptr1 contains %d.", *ptr1);
	printf ("\nThe address in ptr2 contains %c.", *ptr2);
	
	printf ("\n\nThe address of ptr1 is %p.", &ptr1);
	printf ("\nThe address of ptr2 is %p.", &ptr2);
	
	printf ("\n\nThe address in ptr3 contains %d.", *ptr3);
	printf ("\nThe address in ptr3 contains %c.", *ptr3);
	
	/*When displaying it as an integer, a very large number is displayed.
	When displaying it as a character, it correctly displays the contents of char1.
	*/
	
	getchar();
}