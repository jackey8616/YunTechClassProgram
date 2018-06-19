#ifndef _UE_H
#define _UE_H

#include <iostream>
using namespace std;

#include "eNB.h"

class UE: public eNB {
	
	public:
		int _baseId;
		UE();
		UE(int, float, float);
		void print();
};

#endif