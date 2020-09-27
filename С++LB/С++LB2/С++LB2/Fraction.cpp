#include "Fraction.h"
#include <stdio.h>  
#include <stdlib.h>
#include <iostream>

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

Fraction Fraction::add(Fraction other) {
    Fraction fract;
    int lcd = lcm(den, other.den);
    int quot1 = lcd / den;
    int quot2 = lcd / other.den;
    fract.set(num * quot1 + other.num * quot2, lcd);
    fract.normalize();
    return fract;
}

Fraction Fraction::mult(Fraction other) {
    Fraction fract;
    fract.set(num * other.num, den * other.den);
    fract.normalize();
    return fract;
}