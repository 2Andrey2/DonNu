#pragma once

#include <string>
#include <iostream>
#include <ctime>
#include <iomanip>
#include <cstring>
#include <fstream>

class Plane
{
private:
	std::string filename;
	std::string model;
	std::string airline;
	std::string yearManufacture;
	int capacity;
	int numberPassengers;
public:
	Plane();
	Plane(std::string, std::string, std::string, int, int);
	void print(Plane*);
	void setModel(std::string model){this->model = model;}
	void setairline(std::string airline) { this->airline = airline; }
	void setyearManufacture(std::string yearManufacture) { this->yearManufacture = yearManufacture; }
	void setcapacity(int capacity) { this->capacity = capacity; }
	void setnumberPassengers(int numberPassengers) { this->numberPassengers = numberPassengers; }
	std::string getModel() { return this->model; }
	std::string getairline() { return this->airline; }
	std::string getyearManufacture() { return this->yearManufacture; }
	int getcapacity() { return this->capacity; }
	int getnumberPassengers() { return this->numberPassengers; }
	void serialize(Plane*);
	void deserialize(Plane*);
	void serialize(std::string&);
	void deserialize(std::string&);
	void sorting(int Occupancy[]);
};

Plane::Plane()
{
	this->filename = "file.txt";
}

Plane::Plane(std::string model1, std::string airline1, std::string yearManufacture1, int capacity1, int numberPassengers1)
{
	this->model = model1;
	this->airline = airline1;
	this->yearManufacture = yearManufacture1;
	this->capacity = capacity1;
	this->numberPassengers = numberPassengers1;
	this->filename = "file.txt";
}

inline void Plane::print(Plane*)
{
	std::cout << this->getModel() << " ";
	std::cout << this->getairline() << " ";
	std::cout << this->getyearManufacture() << " ";
	std::cout << this->getcapacity() << " ";
	std::cout << this->getnumberPassengers() << " " << std::endl;
}

void Plane::serialize(Plane* a) {
	std::ofstream fout;
	fout.open(filename);
	if (!fout.is_open()) { std::cout << "Ошибка" << std::endl; }
	else
	{
		fout.write((char*)a, sizeof(Plane));
	}
	fout.close();
}

void Plane::deserialize(Plane* a) {
	std::ifstream fout;
	fout.open(filename, std::ofstream::app);
	if (!fout.is_open()) { std::cout << "Ошибка" << std::endl; }
	else
	{
		fout.read((char*)a, sizeof(Plane));
	}
	fout.close();
}

void Plane::serialize(std::string& filename1) {
	filename = filename1;
}

void Plane::deserialize(std::string& filename1) {
	filename = filename1;
}

void Plane::sorting(int Occupancy[]) {
	double temp;
	for (int i = 0; i < 3 - 1; i++) {
		for (int j = 0; j < 3 - i - 1; j++) {
			if (Occupancy[j] > Occupancy[j + 1]) {
				// меняем элементы местами
				temp = Occupancy[j];
				Occupancy[j] = Occupancy[j + 1];
				Occupancy[j + 1] = temp;
			}
		}
	}
}
