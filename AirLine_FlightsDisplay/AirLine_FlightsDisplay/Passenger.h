#pragma once
# include"pch.h"
#include<iostream>
#include<vector>
#include<string>
#include"AirLine.h"
#include"Database.h"
namespace AirLine_FlightsDisplay {
	class Passenger {
	public:
		Passenger() = default;
		Passenger(const std::string& firstName, const std::string& lastName, int passengerContact);
		void displayPassenger()const;

		void setFirstName(const std::string& firstName);
		const std::string& getFirstName() const;

		void setLastName(const std::string& firstName);
		const std::string& getLastName() const;

		void setPassengerContact(int passengerContact);
		int getPassengerContact()const;

		void setPassengerId(int passengerId);
		int getPassengerId()const;

		void setSeatNumber(int seatNumber);
		int getSeatNumber()const;

	private:
		std::string mFirstName;
		std::string mLastName;
		int mPassengerContact=-1;
		int mPassengerId = -1;
		int mSeatNumber = -1;
	};
}
