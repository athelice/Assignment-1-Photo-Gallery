#include"pch.h"
#include<iostream>
#include<algorithm>
#include<vector>
#include"AirLine.h"

using namespace std;

namespace AirLine_FlightsDisplay {
	AirLine::AirLine(const std::string& departureCity, const std::string& arrivalCity,
					 int flightNumber, int noOfSeats)
					: mDepartureCity(departureCity),
					mArrivalCity(arrivalCity), 
					mFlightNumber(flightNumber)
	{
		for (int i = 1; i <= noOfSeats; i++) 
		{

			mAvailableSeats.push_back(i);

		}

	}

	const std::string& AirLine::getArrivalCity() const
	{
		return mArrivalCity;
	}
	void AirLine::setArrivalCity(const std::string& arrivalCity)
	{
		mArrivalCity = arrivalCity;
	}

	const std::string& AirLine::getDepartureCity() const
	{
		return mDepartureCity;
	}
	void AirLine::setDepartureCity(const std::string& departureCity)
	{
		mDepartureCity = departureCity;
	}
	int AirLine::getFlightNumber() const
	{
		return mFlightNumber;
	}
	void AirLine::setFlightNumber(int flightNumber)
	{
		mFlightNumber = flightNumber;
	}
	void AirLine::setAvailableSeats(std::vector<int> availableSeats)
	{
		mAvailableSeats = availableSeats;
	}
	std::vector<int>  AirLine::getAvailableSeats() const {
		return mAvailableSeats;
	}

	/*void AirLine::bookSeats(Passenger &passenger)
	{
		mPassenger.push_back(passenger);
		int seatNumber = passenger.getSeatNumber();
		//mAvailableSeats.erase(std::remove(mAvailableSeats.begin(), 
			//mAvailableSeats.end(), seatNumber), mAvailableSeats.end());
		/*for (auto& availableSeats : mAvailableSeats)
		{

			auto result = std::find(mAvailableSeats.begin(),
				mAvailableSeats.end(), seatNumber);

			if (result != mAvailableSeats.end())
			{
				auto index = std::distance(mAvailableSeats.begin(), result);


				break;

			}


		}*}*/

	void AirLine::display() const
	{
		cout << "Departure City: " << getDepartureCity() << " " << "Arrival City: " << getArrivalCity() << " " << "Flight Number: " << getFlightNumber() << " " << endl;
	}
}


