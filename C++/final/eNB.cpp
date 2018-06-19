#include <math.h>

#include <iostream>
using namespace std;

#include "eNB.h"

eNB::eNB() {}

eNB::eNB(int id) {
	_id = id;
	_x = (100 + (_id / 3) * 200) * 10 / 10;
	_y = (100 + (_id % 3) * 200) * 10 / 10;
}

void eNB::print() {
	cout << "Base[" << _id << "] = (" << _x << ", " << _y << ")" << endl;
}

float eNB::distance(float x, float y) {
	float a = abs(x - _x);
	float b = abs(y - _y);
	return sqrt(a * a + b * b);
}