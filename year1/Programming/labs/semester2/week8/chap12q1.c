/*Structure prototypes specified in Chapter 12, Q1
Brian Willis
19/3/2013
*/

#define SIZE 15

struct card
{
	char suit[SIZE];
	char value[SIZE];//Can handle names and numbers: eg. "King", "3", "Three"
};

struct stock
{
	int stk_no;
	char desc[20];
	int quant;
};

struct book
{
	char isbn[14];
	char author[25];
	float price;
};

struct customer
{
	unsigned int num;
	char name[25];
	char address[45];
	double outstanding;
};

struct transaction
{
	char type;
	int date[3];
	float amount;
};

struct time
{
	int hours;
	int mins;
	int secs;
	char amorpm[3];
};

struct co-ordinates
{
	int degs;
	int mins;
	char dir;
};

struct team
{
	char name[20];
	int homewdl[3];
	int awaywdl[3];
};