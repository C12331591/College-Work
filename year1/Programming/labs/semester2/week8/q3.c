/*Program to copy data from a structure and modify it
Brian Willis
19/3/2013
*/

#include <stdio.h>
#include <string.h>

#define SIZE 15

struct bio
{
	char firstname[SIZE];
	char surname[SIZE];
	int dob[3];
	float hei;
	float wei;
	char eye[SIZE];
	char country[SIZE];
};

struct bio person1;
struct bio person2;
 
main()
{
	//Allowing input for values in person1
	printf ("Please input first name.\n");
	gets(person1.firstname);
	printf ("Please input surname.\n");
	flushall();
	gets(person1.surname);
	printf ("Please input day of birth.(numerical)\n");
	scanf ("%d", &person1.dob[0]);
	printf ("Please input month of birth.(numerical)\n");
	scanf ("%d", &person1.dob[1]);
	printf ("Please input year of birth.\n");
	scanf ("%d", &person1.dob[2]);
	printf ("Please input height.\n");
	scanf ("%f", &person1.hei);
	printf ("Please input weight.\n");
	scanf ("%f", &person1.wei);
	printf ("Please input eye colour.\n");
	flushall();
	gets(person1.eye);
	printf ("Please input country of citizenship.\n");
	flushall();
	gets(person1.country);
	
	//Displaying the values in person1
	printf ("\nPerson 1:\n");
	printf ("\nFirst Name:	%s\n", person1.firstname);
	printf ("Surname:	%s\n", person1.surname);
	printf ("Date of Birth:	%d.%d.%d\n", person1.dob[0], person1.dob[1], person1.dob[2]);
	printf ("Height:	%f\n", person1.hei);
	printf ("Weight:	%f\n", person1.wei);
	printf ("Eye Colour:	%s\n", person1.eye);
	printf ("Country of Citizenship:	%s\n", person1.country);
	
	//Copying the data into person2
	strcpy(person2.firstname, person1.firstname);
	strcpy(person2.surname, person1.surname);
	person2.dob[0]=person1.dob[0];
	person2.dob[1]=person1.dob[1];
	person2.dob[2]=person1.dob[2];
	person2.hei=person1.hei;
	person2.wei=person1.wei;
	strcpy(person2.eye, person1.eye);
	strcpy(person2.country, person1.country);
	
	//Modifying the data in person2
	strcpy(person2.firstname, "Bob");
	strcpy(person2.surname, "Bobbington");
	person2.dob[0]=31;
	person2.dob[1]=1;
	person2.dob[2]=808;
	person2.hei=808;
	person2.wei=180.8;
	strcpy(person2.eye, "Burnt Sienna");
	strcpy(person2.country, "Bobland");
	
	//Displaying the values in person2
	printf ("\nPerson 2:\n");
	printf ("\nFirst Name:	%s\n", person2.firstname);
	printf ("Surname:	%s\n", person2.surname);
	printf ("Date of Birth:	%d.%d.%d\n", person2.dob[0], person2.dob[1], person2.dob[2]);
	printf ("Height:	%f\n", person2.hei);
	printf ("Weight:	%f\n", person2.wei);
	printf ("Eye Colour:	%s\n", person2.eye);
	printf ("Country of Citizenship:	%s\n", person2.country);
	
	flushall();
	getchar();
}//end main()