#include "stdafx.h"
#include "Circle.h"

using namespace std;

const double PI_VALUE = 3.1416; // Do not use a magic number in source code

Circle::Circle(double radius/* = 1.0*/, string color/* = "red"*/)
{
	m_radius = radius;
	m_color = color;
}

Circle::~Circle()
{
}

double Circle::getRadius() // Member function (Getter)
{
	return m_radius;
}

string Circle::getColor() // Member function (Getter)
{   
	return m_color;
}

double Circle::getArea() // Member function
{
	return m_radius*m_radius*PI_VALUE;
}