#include "eNB.h"
#include "UE.h"

UE::UE(){}

UE::UE(int id, float x, float y): eNB(id) {
	_x = x;
	_y = y;
	_baseId = -1;
}

void UE::print() {
	cout << "User[" << _id << "] = (" << _x << ", " << _y << "), Base[" << _baseId << "]" << endl;
}