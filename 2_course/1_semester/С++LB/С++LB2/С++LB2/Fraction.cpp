#include "Fraction.h"
#include <stdio.h>  
#include <stdlib.h>
#include <iostream>
// Анализ дроби и сокращение до минимума
void Fraction::normalize() {

    if (num == 0 || den == 0) {
        num = 0;
        den = 1;
    }

    if (den < 0) {
        num *= -1;
        den *= -1;
    }

    int n = gcf(num, den);
    num = num / n;
    den = den / n;
}

int Fraction::gcf(int a, int b) {
    if (a % b == 0)
        return abs(b);
    else
        return gcf(b, a % b);
}

int Fraction::lcm(int a, int b) {
    return (a / gcf(a, b)) * b;
}

Fraction Fraction::Drobb1(Fraction other) {
    Fraction fract;
    int lcd = lcm(den, other.den);
    int quot1 = lcd / den;
    int quot2 = lcd / other.den;
    fract.set(num * quot1 + other.num * quot2, lcd);
    fract.normalize();
    return fract;
}

Fraction Fraction::Drobb2(Fraction other) {
    Fraction fract;
    fract.set(num * other.num, den * other.den);
    fract.normalize();
    return fract;
}
// Вывод дробей
void Fraction::printAsFraction(Fraction drob, int i)
{
    std::cout << "Дробь " << drob.getNum() << "/" << drob.getDen() << std::endl;
}

void Fraction::printAsFraction(Fraction drob1, size_t i)
{
    std::cout << drob1.getNum() << "/" << drob1.getDen() << std::endl << std::endl;
}
// Ниже все оперриции перегрузки
Fraction Fraction::operator*(Fraction drob)
{
    Fraction rez;
    rez.num = this->num * drob.num;
    rez.den = this->den * drob.den;
    return rez;
}
Fraction Fraction::operator/(Fraction drob)
{
    Fraction rez;
    rez.den = this->num * drob.den;
    rez.num = this->den * drob.num;
    return rez;
}
Fraction Fraction::operator-(Fraction drob)
{
    Fraction rez;
    rez.num = this->num - drob.num;
    rez.den = this->den * drob.den;
    return rez;
}
Fraction Fraction::operator+(Fraction drob)
{
    Fraction rez;
    rez.num = this->num + drob.num;
    rez.den = this->den * drob.den;
    return rez;
}