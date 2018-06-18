#ifndef _POINT_3D_H
#define _POINT_3D_H

#include "Point2D.h"
#include <string>
using namespace std;

class Point3D: public Point2D {
	
	public:
		Point3D();
		Point3D(string, int, int, int);
		void setZ(int);
		int getZ();
		
	//protected:
		void printAll();
	
	private:
		int _z;
};
#endif