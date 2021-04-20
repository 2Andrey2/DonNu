#pragma once
class Fraction
{
private:
    static int counter; // По заданию статический счетчик
    int num, den;
    void normalize();
    int gcf(int a, int b);
    int lcm(int a, int b);
public:
    Fraction() { }
    void counter1(int i) { counter = i; } // Счетчик созданных дробей
    void set(int n, int d) { num = n; den = d; normalize(); }
    int getNum() { return num; } //num
    int getDen() { return den; } //den
    Fraction Drobb1(Fraction other);
    Fraction Drobb2(Fraction other);
    void printAsFraction(Fraction, int); // Вывод сокращенных дробей, две вариации
    void printAsFraction(Fraction, size_t);
    Fraction operator* (Fraction); // Перегрузил все опереции в .cpp внизу реализация.
    Fraction operator-(Fraction);
    Fraction operator+(Fraction);
    Fraction operator/(Fraction);
};

