/* ИВТ7 Васильянов Андрей


Написать классы Vector и Matrix для хранения и обработки одномерных и
двумерных массивов, соответственно.Реализовать задание 2 лабораторной работы №1
с помощью созданных классов.Все функции оформить в виде методов классов.
В коде отразить следующее :
 Выделение и освобождение динамической памяти производить в конструкторах и
деструкторах классов, соответственно.
 В классе Vector перегрузить оператор индексации[].В классе Matrix добавить
методы T at(int i, int j) const и setAt(int i, int j, T val), которые
позволяют получить и установить значение элемента массива с индексом[i][j], T –
это тип элементов массива по варианту(int или double).
 Перегрузить операторы инкремента и декремента(как префиксного, так и
    постфиксного).Смысл инкремента / декремента всего массива заключается в
    инкременте / декременте каждого элемента массива.


2. Написать класс Fraction для представления обыкновенных дробей(как отношения
        двух целых чисел x / y).Перегрузить операторы + , -, *, / для дробей.Реализовать метод
    void reduce() для сокращения дроби, а также статические методы :
 int gcd(int n, int m)
функция для нахождения наибольшего общего делителя чисел n и m;
  void printAsFraction(double decimal_fraction)
 void printAsFraction(char* decimal_fraction)
перегруженные методы вывода десятичной дроби в виде обыкновенной
(например, при значении decimal_fraction = 0.43 на экране должно
    вывестись 43 / 100, при 0.25 – 1 / 4 и т.д.).
    Также реализовать в виде статического члена класса счетчик всех созданных на
данный момент в программе экземпляров дробей.
Продемонстрировать работу созданного класса. Создать несколько объектов дробей.
Произвести операции сложения, вычитания, умножения и деления дробей. Вывести
на экран результаты. Показать также результаты работы статических методов класса.



3. Написать собственный класс, в соответствии с вариантом. Продемонстрировать в коде
инкапсуляцию данных, применение конструкторов без параметров и с параметрами
для инициализации данных. Класс должен содержать метод serialize() для
сохранения данных класса в файл и метод deserialize() для чтения данных класса
из файла по умолчанию в текущей директории, а также перегруженные методы
serialize(const std::string& filename) и deserialize(const std::string&
filename) для работы с файлом с указанным в параметре именем.
*/


#include <string>
#include <iostream>
#include "Plane.h"
#include "Matrix.h"
#include "Vector.h"
#include "Fraction.h"
#include <math.h>

int Fraction::counter;
int main()
{
    setlocale(LC_CTYPE, "rus");
    // Задание 1
    int str, stolb, longg, flag;
    std::cout << "Введите кол-во строк и столбцов" << std::endl;
    std::cin >> str >> stolb;
    Matrix* m = new Matrix(str,stolb);
    m->initializeArray();
    m->printArray2D();
    std::cout << "Хотите изменить элемент. 'Да' введите 1, 'Нет' введите 2" << std::endl;
    std::cin >> flag;
    if (flag == 1)
    {
        std::cout << "Ведите столбец,строку,значение" << std::endl;
        int i, j;
        double zn;
        std::cin >> i;
        std::cin >> j;
        std::cin >> zn;
        m->setAt(i, j, zn);
        m->printArray2D();

    }
    m->makeArray1D();
    m->printArray1D();
    delete m;
    std::cout << "Введите кол-во элеметов массива и желаемое кол-во строк и столбцов" << std::endl;
    std::cin >> longg >> str >> stolb;
    Vector* v = new Vector(str, stolb, longg);
    v->initializeArray();
    v->printArray1D();
    v->makeArray2D();
    v->printArray2D();
    delete v;
    // Задание 2
    std::cout << "Сколько дробей хотите ввести?";
    std::cin >> flag;
    Fraction* drob = new Fraction[flag]; // Сами дроби
    Fraction* drob1 = new Fraction[flag]; // Темповский массив для вывода произведенных опереций, да можно подругому, но я так)
    int X1, Y1;
    for (size_t i = 0; i < flag; i++)
    {
        // Стандартное сокращение для каждой из дробей
        std::cout << " Введите первое число: ";
        std::cin >> X1;
        std::cout << " Введите второе число: ";
        std::cin >> Y1;
        drob[i].set(X1, Y1);
        drob[i].printAsFraction(drob[i],i);
        drob[i].counter1(i);
        if(i==1||i==3||i==5)
        {
            // Все операции которые есть, вычисляется с каждой парой дробей
            drob1[i] = drob[i-1].Drobb2(drob[i]);
            drob1->printAsFraction(drob1[i],i);
            drob1[i] = drob[i] * drob[i-1];
            drob1->printAsFraction(drob1[i],i);
            drob1[i] = drob[i] / drob[i - 1];
            drob1->printAsFraction(drob1[i], i);
            drob1[i] = drob[i] + drob[i - 1];
            drob1->printAsFraction(drob1[i], i);
            drob1[i] = drob[i] - drob[i - 1];
            drob1->printAsFraction(drob1[i], i);
        }
    }
    // Задание 3
    std::string model[4] = { "Boeing","Airbus","ATR","Суперджет" };
    std::string airline[4] = { "Air China","Ryanair","FlyDubai","Airlines" };
    std::string yearManufacture[4] = { "21.05.2015","03.10.2013","30.08.2018","15.05.2016" };
    int capacity[4] = {500,500,500,500};

    Plane* mass = new Plane[3];
    std::cout << "В какой файл записывать? 1 по умолчанию 2 введите имя" << std::endl;
    std::cin >> flag;
    if (flag == 2)
    {
        std::string a;
        std::cin >> a;
        Plane* h = new Plane();
        h->deserialize(a);
    }
    for (size_t i = 0; i < 3; i++)
    {
        mass[i].setModel(model[rand() % 4]);
        mass[i].setairline(airline[rand() % 4]);
        mass[i].setyearManufacture(yearManufacture[rand() % 4]);
        mass[i].setcapacity(rand() % 4);
        mass[i].setnumberPassengers(rand() % 500);
        mass[i].serialize(&mass[i]);
    }
    Plane* construkt = new Plane(model[rand() % 4], airline[rand() % 4], yearManufacture[rand() % 4], capacity[rand() % 4], rand() % 500);

    Plane** mass1 = new Plane*[3];
    for (size_t i = 0; i < 3; i++)
    {
        mass1[i] = new Plane(model[rand() % 4], airline[rand() % 4], yearManufacture[rand() % 4], capacity[rand() % 4], rand() % 500);
        mass[i].serialize(&mass[i]);
    }
    int Occupancy[3];
    for (size_t i = 0; i < 3; i++)
    {
        Occupancy[i] = (mass1[i]->getnumberPassengers() * 100) / mass1[i]->getcapacity();
        mass1[i]->print(&mass[i]);
        std::cout << std::endl;
    }
    for (size_t i = 0; i < 3; i++)
    {
        std:: cout << Occupancy[i] << " ";
    }
    std::cout << std::endl;
    mass1[0]->sorting(Occupancy); // Сортировку убрал в класс
    for (size_t i = 0; i < 3; i++)
    {
        std::cout << Occupancy[i] << " ";
    }
    std::cout << std::endl <<  "Вывести данные из файла 1 да 2 нет" << std::endl;
    std::cin >> flag;
    if (flag)
    {
        Plane* r = new Plane();
        r->deserialize(r);
        r->print(r);
    }
    std::cout << std::endl;
    system("pause");
}
