#pragma once
class Fraction
{
private:
    int num, den;
    void normalize();
    int gcf(int a, int b);
    int lcm(int a, int b);
public:
    void set(int n, int d) { num = n; den = d; normalize(); }
    int get_num() { return num; }
    int get_den() { return den; }
    Fraction add(Fraction other);
    Fraction mult(Fraction other);
};

