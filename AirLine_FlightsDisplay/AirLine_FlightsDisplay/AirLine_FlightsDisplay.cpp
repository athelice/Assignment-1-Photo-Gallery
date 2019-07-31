// AirLine_FlightsDisplay.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include "pch.h"
#include <iostream>
#include"AirLine.h"
#include"Database.h"
#include"Passenger.h"
using namespace std;
using namespace AirLine_FlightsDisplay;


int main()
{
	Database flightDB;
    std::cout << "Hello World!\n"; 

	flightDB.addFlight("Seattle", "Anchorage", 100, 20);
	flightDB.addFlight("Las Vegas", "Seattle", 101, 30);
	flightDB.addFlight("Seattle", "Las Vegas", 102, 40);
	cout << "------------Flight Schedule ------------- " << endl;
	flightDB.displayAll();
}

