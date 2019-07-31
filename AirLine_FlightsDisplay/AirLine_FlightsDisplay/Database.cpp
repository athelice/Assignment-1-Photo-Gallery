#include"pch.h"
#include <iostream>
#include <stdexcept>
#include "Database.h"
#include"AirLine.h"
using namespace std;
namespace AirLine_FlightsDisplay
{
	AirLine& Database::addFlight(const std::string& departureCity,
		const std::string& arrivalCity, int flightNumber, int seatsAvailable)
	{
		AirLine theAirLine(departureCity, arrivalCity, flightNumber, seatsAvailable);
		mAirline.push_back(theAirLine);
		return mAirline[mAirline.size() - 1];
	}
	AirLine& Database::getFlight(int flightNumber) 
	{
		for (auto& airline : mAirline) 
		{
			if (airline.getFlightNumber() == flightNumber) 
			{
				return airline;
			}
		}
		throw logic_error("No Flight found.");
	}

	void Database::displayAll() const
	{
		for (const auto& airline : mAirline) 
		{
			airline.display();
		}
	}
	
}
