// Fourier.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "iostream"
#include "math.h"
#include "windows.h"
#include "fstream"
#include "Complex.h"

using namespace std;

#define pi 3.14159265358979323846

void DiscrFourierTrans(char* InFileName);
void FastFourierTrans(char* InFileName);

int main()
{
	


	DiscrFourierTrans("LongImpulse.txt");
	system("pause");
    return 0;
}

void FastFourierTrans(char* InFileName)
{
	ifstream fin(InFileName);

	ofstream TxtWriteFi;
	TxtWriteFi.open("FastFourFi.txt");

	ofstream TxtWriteAmp;
	TxtWriteAmp.open("FastFourFi.txt");

	double g_aValueDoubl[10000];  //значения из файла
	double FourierValue;		  
	double FourierReValue;        // Мнимая часть
	double AmpValue;             // Амплитуда	
	double FiValue;              // Фаза
	int NumLast;				// номер последнего значения в файле
	int ValueCount = 1000;		//количество строк в файле	
	int M = 999;        //количество временных рядов
	double MaxAmp = 0;
	double MinAmp = 0;
	double En;


	for (int i = 0; i<ValueCount; i++)   //Считываем значения из файла
	{
		NumLast = 0;		//Нам нужен только последний номер
		fin >> NumLast;	//номер
		fin >> g_aValueDoubl[i];	//значение	
		if (g_aValueDoubl[i] > MaxAmp)
			MaxAmp = g_aValueDoubl[i];
		if (g_aValueDoubl[i] < MinAmp)
			MinAmp = g_aValueDoubl[i];
	}
	En = 0.1 * pow((MaxAmp - MinAmp), 2);

	for (int k = 0; k < 500; k++)       //Xn
	{
		FourierReValue = FourierValue = 0;   //зануляем старые значения
		for (int i = 0; i < M; i++)      //Суммирование реальной и суммирование мнимой
		{
		//	FourierValue += g_aValueDoubl[i] * exp();
		}
	}


	TxtWriteAmp.close();  //Закрываем потоки работы с файлами
	TxtWriteFi.close();
	fin.close();
}



void DiscrFourierTrans(char* InFileName)
{
	ifstream fin(InFileName);   //Создаем потоки для работы с файлами

	ofstream TxtWriteFi;
	TxtWriteFi.open("fourFi.txt");

	ofstream TxtWriteAmp;
	TxtWriteAmp.open("fourAmp.txt");

	double g_aValueDoubl[10000];  //значения из файла
	double FourierImValue;		  // реальная часть
	double FourierReValue;        // Мнимая часть
	double AmpValue;             // Амплитуда	
	double FiValue;              // Фаза
	int NumLast;				// номер последнего значения в файле
	int ValueCount = 1000;		//количество строк в файле	
	int M = 999;        //количество временных рядов
	double MaxAmp = 0;
	double MinAmp = 0;
	double En;

	for (int i = 0; i<ValueCount; i++)   //Считываем значения из файла
	{
		NumLast = 0;		//Нам нужен только последний номер
		fin >> NumLast;	//номер
		fin >> g_aValueDoubl[i];	//значение	
		if (g_aValueDoubl[i] > MaxAmp)
			MaxAmp = g_aValueDoubl[i];
		if (g_aValueDoubl[i] < MinAmp)
			MinAmp = g_aValueDoubl[i];
	}
	En = 0.1 * pow((MaxAmp - MinAmp), 2);

	for (int k = 0; k < 500; k++)       //Xn
	{
		FourierReValue = FourierImValue = 0;   //зануляем старые значения
		for (int i = 0; i < M; i++)      //Суммирование реальной и суммирование мнимой
		{
			FourierReValue += g_aValueDoubl[i] * cos(2 * pi / M * k*i);
			FourierImValue -= g_aValueDoubl[i] * sin(2 * pi / M * k*i);
		}
		AmpValue = sqrt(FourierReValue*FourierReValue + FourierImValue*FourierImValue);			//Расчет амплитуды
		if (AmpValue < En) //убираем "заворот" вблизи оси Х
			AmpValue = FourierReValue = FourierImValue = 0;

		FiValue = atan2(FourierImValue, FourierReValue);			//Фазы

		TxtWriteAmp << k << '\t' << AmpValue << endl;			//запись в файл
		TxtWriteFi << k << '\t' << FiValue << endl;
	}
	TxtWriteAmp.close();  //Закрываем потоки работы с файлами
	TxtWriteFi.close();
	fin.close();
}


