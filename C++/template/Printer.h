#ifndef _PRINTER_H
#define _PRINTER_H

#include <iostream>
using namespace std;

template <class T>
class Printer {
	
	public:
		Printer(T t) {
			_t = t;
		};
		void print() {
			cout << to_string(_t) << endl;
		};
	private:
		T _t;
};

#endif