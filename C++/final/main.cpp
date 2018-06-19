#include <iostream>
#include <stdlib.h>
#include <time.h>
using namespace std;

#include "eNB.h"
#include "UE.h"

int main(void) {

	srand((unsigned int) time(NULL));
	eNB base[9];
	UE user[20];
	cout << "================ [ Print Base ] ================" << endl;
	for(int i = 0; i < 9; ++i) {
		base[i] = eNB(i);
		base[i].print();
	}
	cout << "================ [ Print User ] ================" << endl;
	for(int i = 0; i < 20; ++i) {
		user[i] = UE(i, (rand() % 6001) / 10 , (rand() % 6001) / 10);
		user[i].print();
	}
	cout << "================ [ Find Shortest ] ================" << endl;
	for(int i = 0; i < 20; ++i) {
		float distance = 600.0f;
		for(int j = 0; j < 9; ++j) {
			float cal = user[i].distance(base[j]._x, base[j]._y);
			if(cal < distance && cal <= 140) {
				distance = cal;
				user[i]._baseId = j;
			}
			cout << "Base[" << j << "] distance to User[" << i << "]= " << cal << endl;
		}
	}
	cout << "================ [ Print base neighbor ] ================" << endl;
	for(int i = 0; i < 9; ++i) {
		cout << "Neighbor of Base[" << i << "]= ";
		for(int j = 0; j < 20; ++j) {
			if(user[j]._baseId == i)
				cout << j << " ";
		}
		cout << endl;
	}
	cout << "================ [ Random connection ] ================" << endl;
	int src = rand() % 20, dst = rand() % 20;
	while(dst == src)
		dst = rand() % 20;
	cout << "source: " << src << ", destination: " << dst << endl;
	cout << "connection: " << 
			"User[" << src << "] => Base[" << user[src]._baseId << "] => Base[" << user[dst]._baseId << "] => User[" << dst << "]" << endl;
	system("PAUSE");
	return 0;
	}