#pragma once
#include <string>      // using string

class Circle {
private:
	double m_radius;		// Data member (Variable)
	std::string m_color;	// Data member (Variable)

public:
	// Constructor with default values for data members
	Circle(double radius = 1.0, std::string color = "red");

	// Destructor
	~Circle();

	// Member function (Getter)
	double getRadius();

	// Member function (Getter)
	std::string getColor();

	// Member function
	double getArea();

};	// need to end the class declaration with a semi-colon

