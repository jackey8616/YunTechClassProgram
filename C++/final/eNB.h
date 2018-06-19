#ifndef _ENB_H
#define _ENB_H

#include <iostream>
using namespace std;

class eNB {

	public:
		int _id;
		float _x, _y;
		
		eNB();
		eNB(int);
		void print();
		float distance(float, float);
};
#endif