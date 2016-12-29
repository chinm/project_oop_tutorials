// FirstConsoleApplication.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

#include "Circle.h"
#include <iostream>	// using IO functions

using namespace std;

int main()
{
	// Construct a Circle instance
	Circle c1(1.2, "blue");
	cout << "Radius=" << c1.getRadius() << " Area=" << c1.getArea()
		<< " Color=" << c1.getColor() << endl;

	// Construct another Circle instance
	Circle c2(3.4); // default color
	cout << "Radius=" << c2.getRadius() << " Area=" << c2.getArea()
		<< " Color=" << c2.getColor() << endl;

	// Construct a Circle instance using default no-arg constructor
	Circle c3;      // default radius and color
	cout << "Radius=" << c3.getRadius() << " Area=" << c3.getArea()
		<< " Color=" << c3.getColor() << endl;
	return 0;
}