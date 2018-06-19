#include "Point3D.h"
#include "Point2D.h"
using namespace std;

Point3D::Point3D() {}

Point3D::Point3D(string name, int X, int Y, int Z): Point2D(name, X, Y) {
	setZ(Z);
}

void Point3D::setZ(int Z) {
	_z = Z;
}

int Point3D::getZ() {
	return _z;
}

void Point3D::printAll() {
	Point2D::printAll();  // <-- Call parent protected function
	//cout << "Name: " << getName() <<  ", X: " << getX() << ", Y: " << getY() << ", Z: " << _z << endl;
}
