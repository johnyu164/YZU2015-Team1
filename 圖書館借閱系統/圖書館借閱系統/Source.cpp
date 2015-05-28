#include <iostream>
#include <fstream>
#include <string>

using namespace std;

struct BookInformation
{
	string booknumber;
	string bookname;
	string borrowornot;
};
BookInformation bookinformation[3];

void ReadBookInformation(int count , int dataCount , char* token)
{
	if(count == 0)
	{
		string information(token);
		bookinformation[dataCount-1].booknumber = information;
	}
	if(count == 1)
	{
		string information(token);
		bookinformation[dataCount-1].bookname = information;
	}
	if(count == 2)
	{
		string information(token);
		bookinformation[dataCount-1].borrowornot = information;
	}
}

void FindBook(int count,string BookNumber)
{
	if(strcmp(bookinformation[count].booknumber.c_str(),BookNumber.c_str()) == 0)
	{
		if(atoi(bookinformation[count].borrowornot.c_str()) == 0)
			cout<<"�ѥ��s��:"<<bookinformation[count].booknumber<<" �ѥ��W��:"<<bookinformation[count].bookname<<" �ɾ\���A:���ɥX"<<endl;
		else
			cout<<"�ѥ��s��:"<<bookinformation[count].booknumber<<" �ѥ��W��:"<<bookinformation[count].bookname<<" �ɾ\���A:�w�ɥX"<<endl;
	}
}

int main()
{
	char line[100];
	int dataCount = 0;

	fstream fin;
	fin.open("Library.txt",ios::in);
	while (fin.getline(line,sizeof(line),'\n'))
	{
		if(dataCount == 0)//���W���n�x�s
		{
			dataCount++;
		}
		else
		{
			char *token = strtok(line," ");
			int count = 0;
			while(token != NULL)
			{
				ReadBookInformation(count,dataCount,token);
				count++;
				token = strtok(NULL," ");
			}
			dataCount++;
		}
	}

	string BookNumber = "";
	cout<<"�п�J�ѥ��s��:";
	cin>>BookNumber;

	for(int i = 0 ; i < dataCount-1 ; i++)
	{
		FindBook(i,BookNumber);
	}

	system("pause");
	return 0;
}