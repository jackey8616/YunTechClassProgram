#include <iostream>
#include <string>
#include <stdlib.h>
#include <time.h>

#include "Point2D.h"
#include "Point3D.h"
using namespace std;

int main(void) {
	
	srand((unsigned int)time(NULL));
	/*
	Point2D points2D[5];
	for(int i = 0; i < 5; ++i) {
		points2D[i] = Point2D(to_string(i), rand() % 100, rand() % 100);
		points2D[i].printAll();
	}
	*/
	Point3D points3D[5];
	for(int i = 0; i < 5; ++i) {
		points3D[i] = Point3D(to_string(i), rand() % 100, rand() % 100, rand() % 100);
		//points3D[i].Point2D::printAll();
		points3D[i].printAll();  // <-- Child override function.
	}
	
	cout << "TEST" << endl;
	system("PAUSE");
	return 0;
	}