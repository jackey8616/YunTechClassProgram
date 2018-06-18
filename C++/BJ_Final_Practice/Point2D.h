#ifndef _POINT_2D_H
#define _POINT_2D_H

#include <iostream>
#include <string>
using namespace std;

class Point2D {

	public:
		Point2D();
		Point2D(string, int, int);
		void setName(string);
		string getName();
		void setX(int);
		int getX();
		void setY(int);
		int getY();
		void setXY(int, int);
	
	protected:
		void printAll();

	private:
		string _name;
		int _x, _y;
		
};

#endif