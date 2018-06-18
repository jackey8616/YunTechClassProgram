#include <string>
#include "Point2D.h"
using namespace std;

Point2D::Point2D() {}

Point2D::Point2D(string name, int X, int Y) {
	setName(name);
	setXY(X, Y);
}

void Point2D::setName(string name) {
	_name = name;
}

string Point2D::getName() {
	return _name;
}

void Point2D::setX(int X) { 
	_x = X;
}

int Point2D::getX() {
	return _x;
}

void Point2D::setY(int Y) {
	_y = Y;
}

int Point2D::getY() {
	return _y;
}

void Point2D::setXY(int X, int Y) {
	setX(X);
	setY(Y);
}

void Point2D::printAll() {
	cout << "Name: " << _name <<  ", X: " << _x << ", Y: " << _y << endl;
}