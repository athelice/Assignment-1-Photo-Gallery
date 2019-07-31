#pragma once
# include "pch.h"
#include<iostream>
#include<vector>
#include<algorithm>
#include<string>
#include "Passenger.h"


namespace AirLine_FlightsDisplay 
{
	class AirLine
	{
	public:
			AirLine() = default;
			AirLine(const std::string& departureCity, 
					const std::string& arrivalCity,
					int flightNumber, 
					int seatsAmount);

			const std::string& getArrivalCity() const;
			void setArrivalCity(const std::string& arrivalCity);

			const std::string& getDepartureCity() const;
			void setDepartureCity(const std::string& departureCity);

			int getFlightNumber() const;
			void setFlightNumber(int flightNumber);

			std::vector<int> getAvailableSeats() const;
			void setAvailableSeats(std::vector<int> availableSeats);

			void display() const;
		//	void bookSeats(Passenger& passenger);

	private:
			std::string mDepartureCity;
			std::string mArrivalCity;
			std::vector<Passenger> mPassenger;
			std::vector<int> mAvailableSeats;
			int mFlightNumber = -1;

	};
}