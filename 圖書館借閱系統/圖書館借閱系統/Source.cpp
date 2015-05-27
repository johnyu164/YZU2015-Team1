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

int main()
{
	/*string BookNumber = "";
	cout<<"請輸入書本編號:";
	cin>>BookNumber;*/

	char line[100];
	int header = 0;

	BookInformation bookinformation[3];

	fstream fin;
	fin.open("Library.txt",ios::in);
	while (fin.getline(line,sizeof(line),'\n'))
	{
		if(header == 0)//欄位名不要儲存
		{
			header++;
		}
		else
		{
			char *token = strtok(line," ");
			int count = 0;
			while(token != NULL)
			{
				if(count == 0)
				{
					string information(token);
					bookinformation[header-1].booknumber = information;
				}
				if(count == 1)
				{
					string information(token);
					bookinformation[header-1].bookname = information;
				}
				if(count == 2)
				{
					string information(token);
					bookinformation[header-1].borrowornot = information;
				}
				count++;
				token = strtok(NULL," ");
			}
			header++;
		}
	}

	system("pause");
	return 0;
}