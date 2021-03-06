// Gauss Transform.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "iostream"
#include "math.h"

#include "windows.h"
#include "fstream"
using namespace std;

double g_aGaussValue[1000];


void GaussTransCalc(int count, char* Name);
void GaussTransRefer(int Ncount, char* InFileName, int Kcount, char* OutFileName);
void GaussTransReferSecond(int Ncount, char* InFileName, int Kcount, char* OutFileName);
int PosResCheck(int Value);
int PosResCheck2(int Value);

int main()
{
 	GaussTransCalc(1000, "Gauss.txt");
	GaussTransRefer(1000, "Gauss.txt", 20, "GaussRefer.txt");
	GaussTransReferSecond(1000, "Gauss.txt", 20, "GaussRefer2.txt");

	system("pause");
    return 0;
}

void GaussTransCalc(int count, char* Name)
{
	double Mu = 500;
	double Sig = 400;
	double pi = 3.14;
	double Fx = 0;

	ofstream TxtWrite;
	TxtWrite.open(Name);

	for (int n = 0; n < count; n++)
	{		
		Fx = (   (1 / (Sig*sqrt(2 * pi)))     *   exp(-1*(((n-Mu) *(n-Mu)) / (2 *(Sig*Sig))))    ) * 10e7;
		
		 TxtWrite << n << "\t" << Fx << "\n";
		 g_aGaussValue[n] = Fx;
	}
	TxtWrite.close();
}

void GaussTransRefer(int Ncount, char* InFileName, int Kcount, char* OutFileName)
{
	double Sn = 0;;	
	double aGaussValue[10000] = { 0 };

	ofstream TxtWrite;
	TxtWrite.open(OutFileName);

	for(int n = 0; n < Ncount; n++)
	{
		Sn = 0;
		for (int k = 1; k < Kcount; k++)
		{
			Sn += (g_aGaussValue[k*(Ncount / Kcount)] - g_aGaussValue[(k - 1)*(Ncount / Kcount)]) * PosResCheck(n - k*(Ncount / Kcount));
		}
		TxtWrite << n << "\t" << Sn << "\n";
	}
	TxtWrite.close();
}

void GaussTransReferSecond(int Ncount, char* InFileName, int Kcount, char* OutFileName)
{
	double Sn = 0;;
	double aGaussValue[10000] = { 0 };

	ofstream TxtWrite;
	TxtWrite.open(OutFileName);

	for (int n = 0; n < Ncount; n++)
	{
		Sn = 0;
		for (int k = 1; k < Kcount; k++)
		{
			Sn += g_aGaussValue[k*(Ncount / Kcount)]  * PosResCheck2(n - k*(Ncount / Kcount));
		}
		TxtWrite << n << "\t" << Sn << "\n";
	}
	TxtWrite.close();
}

int PosResCheck2(int Value)
{
	if (Value != 0)
		return 0;
	else
		return 1;
}

int PosResCheck(int Value)
{
	if (Value < 0)
		return 0;
	else
		return 1;
}