#pragma once
#include"pch.h"
#include <iostream>
#include <vector>
#include<string>
#include "AirLine.h"

namespace AirLine_FlightsDisplay 
{

	class Database
	{
		public:
			AirLine& addFlight(const std::string& departureCity, const std::string& arrivalCity, int flightNumber, int seatsAvailable);
				AirLine& getFlight(int flightNumber);
				void displayAll() const;
		
		private:
				std::vector<AirLine> mAirline;
	};
}