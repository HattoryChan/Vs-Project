// SinCos.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "iostream"
#include "math.h"

#include "windows.h"
#include "fstream"
using namespace std;

void SinToTxt();
void RandSignaltoTxt();
void LongImpToTxt();
void RadioSignalToTxt();
void CosToTxt();

int main()
{
	
	SinToTxt();	
	CosToTxt();
	RandSignaltoTxt();
	LongImpToTxt();
	RadioSignalToTxt();

	system("pause");
	return 0;
}

//Create Radio signal and write to TXT
void RadioSignalToTxt()
{
	cout << "Radio Signal Write to txt..... \n";

	double a, s;
	int count = 0;

	ofstream TxtWrite;
	TxtWrite.open("RadioSignal.txt");
	
	for (int i=0; i < 5; i++)
	{
		for (a = 0; a <= 360; a += 40)
		{
			s = sin(a*3.14 / 180);
			TxtWrite << count << " " << s << endl;
			count++;
		}
	}
	for (int i = 50; i < 101; i++)
	{
		TxtWrite << i << " 0\n";		
	}

	TxtWrite.close();
	cout << "Radio Signal Write to txt complited\n\n";

}


//Create long impulse and write to TXT
void LongImpToTxt()
{
	cout << "Long Impulse write to TXT ..... \n";
	ofstream TxtWrite;
	TxtWrite.open("LongImpulse.txt");

	for (int i = 0; i < 101; i++)
	{
		if (i <= 25)
		{
			TxtWrite << i << " 1\n";
		}
		if (i > 25 && i <= 50)
		{
			TxtWrite << i << " 0\n";
		}
		if (i > 50 && i <= 75)
		{
			TxtWrite << i << " 1\n";
		}
		if (i > 75 && i <= 100)
		{
			TxtWrite << i << " 0\n";
		}

	}
	TxtWrite.close();
	cout << "Long Impulse write to TXT complited\n\n";
}

//Create random signal and write to txt
void RandSignaltoTxt()
{
	int DotCount;

	cout << "Random Signal write to TXT ......\n";
	cout << "Random Signal dot value: ";
	cin >> DotCount;

	ofstream TxtWrite;
	TxtWrite.open("RandomSignal.txt");
	
	TxtWrite << "Random Singal value:\n";
	for (double i = 0; i < DotCount + 1; i++)
	{

		TxtWrite <<  i / DotCount << " " << rand() << "\n";
	}
	TxtWrite.close();
	cout << "Random Singal write complited\n\n";
}

// Create sin value and write on TXT file
void SinToTxt()
{
	double a, s;
	int DotCount;

	cout << "Enter dot number for SIN: ";
	cin >> DotCount;
	cout << "Sin Write to txt..... \n";

	ofstream TxtWrite;
	TxtWrite.open("sin.txt");		
		for (a = 0; a <= DotCount; a++)
		{
			s = sin(a*2*3.14 / DotCount);			
			TxtWrite << a << '\t' << s << endl;
		}	
	TxtWrite.close();
	cout << "Sin Write to txt complited\n\n";
}

// Create cos value and write on TXT file
void CosToTxt()
{
	int DotCount;
	double a, s;

	cout << "Enter dot number for COS: ";
	cin >> DotCount;
	cout << "Cos Write to txt..... \n";

	ofstream TxtWrite;
	TxtWrite.open("cos.txt");
	
	for (a = 0; a <= DotCount; a++)
	{
		s = cos(a*2*3.14 / DotCount);
		TxtWrite << a << " " << s << endl;
	}
	TxtWrite.close();
	cout << "Cos Write to txt complited\n\n";
}

