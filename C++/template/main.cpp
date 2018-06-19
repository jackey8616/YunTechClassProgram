#include <iostream>
using namespace std;

#include "Printer.h"

int main(void) {

	Printer<float> p = Printer<float>(0.5f);
	p.print();
	
	Printer<char> p2 = Printer<char>('A');
	p2.print();
	/*
	Printer<string> p3 = Printer<string>("A");
	p3.print();
	*/
	Printer<int> p4 = Printer<int>(123);
	p4.print();
	
	system("PAUSE");
	return 0;
}