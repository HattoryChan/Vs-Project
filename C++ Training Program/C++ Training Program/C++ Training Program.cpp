// C++ Training Program.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>

using namespace std;

void DivInCat();
void MathExp();

int main()
{
	
	DivInCat();
	//MathExp();
	system("pause");
    return 0;
}

void DivInCat()
{
	cout << "\t\t\tDivision into categories\n\n";
	int value, CalcVal;
	cout << "Enter  number(9 char): ";
	cin >> value;
	CalcVal = value;

	for (int i = 1; i <= 9; i++)
	{
		cout << "\t\t" << CalcVal % 10 << "\n";
		CalcVal /= 10;
	}
}

void MathExp()
{
	cout << "\t\t\tMathematical expression\n\n";
	int a, b, f;
	cout <<  "(a+b-f/a)+f*a*a-(a+b)\n" << "Input a,b,f:\n";
    cout << "Enter a: ";
	cin >> a;
	cout << "\nEnter b: ";
	cin >> b;
	cout << "\nEnter f: ";
	cin >> f;
	cout << "(a+b-f/a)+f*a*a-(a+b)= " << (a + b - (f / a)) + f*a*a - (a + b) << "\n";
}


