#include"pch.h"
#include<iostream>
#include<string>
#include"Passenger.h"

using namespace std;

namespace AirLine_FlightsDisplay 
{
	Passenger::Passenger(const std::string& firstName, const std::string& lastName, 
		int passengerContact)
		:mFirstName(firstName), mLastName(lastName),
		mPassengerContact(passengerContact)
	{
	}

	void Passenger::setFirstName(const string& firstName)
	{
		mFirstName = firstName;
	}

	const string& Passenger::getFirstName()const 
	{
		return mFirstName;
	}

	void Passenger::setLastName(const string& lastName)
	{
		mLastName = lastName;
	}
	const string& Passenger::getLastName() const
	{
		return mLastName;
	}
	void Passenger::setPassengerContact(int passengerContact)
	{
		mPassengerContact = passengerContact;
	}
	int Passenger::getPassengerContact() const
	{
		return mPassengerContact;
	}
	void Passenger::setPassengerId(int passengerId)
	{
		mPassengerId = passengerId;
	}
	int Passenger::getPassengerId() const
	{
		return mPassengerId;
	}
	void Passenger::setSeatNumber(int seatNumber)
	{
		mSeatNumber = seatNumber;
	}
	int Passenger::getSeatNumber() const
	{
		return mSeatNumber;
	}
	void Passenger::displayPassenger() const {
		cout << "Passenger:" << getLastName() << ", " << getFirstName() <<
			"Contact: " << getPassengerContact() << endl;
		cout << endl;
		cout << "Passenger Id: " << getPassengerId() << endl;

	}
}

