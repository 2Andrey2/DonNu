#include <string>
#include <iostream>
#include "ExpressionEvaluator.h"
#include "CustomExpressionEvaluator.h"
#include "Subtractor.h"
#include "Summator.h"

int main()
{
    setlocale(LC_CTYPE, "rus");
    double massCustomExpressionEvaluator[5] = { 15,10,-3,12,-6.5 };
    double massSummator[7] = { 15,-3.5,10.5,-2.1,3.3,4,6.3 };
    double massSubtractor[3] = { 1.5,4,-2.5 };
    double massrez[3];
    //ЗАДАНИЕ 1
    ExpressionEvaluator* evaluators[3];
    // Смешанное выражение
    evaluators[0] = new CustomExpressionEvaluator(5);
    evaluators[0]->setOperand(0, 15);
    evaluators[0]->setOperand(1, 10);
    evaluators[0]->setOperand(2, -3);
    evaluators[0]->setOperand(3, 12);
    evaluators[0]->setOperand(4, -6.5);
    massrez[0] = evaluators[0]->calculate();
    //Суммирует
    evaluators[1] = new Summator(7);
    double sum_operands[7];
    for (int i = 0; i < 7; i++)
    {
        sum_operands[i] = massSummator[i];
    }
    evaluators[1]->setOperands(sum_operands, 7);
    massrez[1] = evaluators[1]->calculate();
    //Вычитает
    evaluators[2] = new Subtractor(3);
    double sum_operands1[3];
    for (int i = 0; i < 3; i++)
    {
        sum_operands1[i] = massSubtractor[i];
    }
    evaluators[2]->setOperands(sum_operands1, 3);
    massrez[2] = evaluators[2]->calculate();// должно вычисляться 0.25 * 8 * 3.5 = 7
    // демонстрация полиморфизма
    for (int i = 0; i < 3; ++i)
    {
        evaluators[i]->logToFile("Lab3.txt");
        evaluators[i]->logToScreen();
        std::cout << evaluators[i]->calculate() << std::endl;
    }

    for (int i = 0; i < 3; ++i)
    {
        if (typeid(evaluators[i]) == typeid(Subtractor))
        {
            dynamic_cast<Subtractor*>(evaluators[i])->shuffle();
            dynamic_cast<Subtractor*>(evaluators[i])->calculate();
            dynamic_cast<Subtractor*>(evaluators[i])->logToScreen();
        }
        if (typeid(evaluators[i]) == typeid(Summator))
        {
            dynamic_cast<Summator*>(evaluators[i])->shuffle();
            dynamic_cast<Summator*>(evaluators[i])->calculate();
            dynamic_cast<Summator*>(evaluators[i])->logToScreen();
        }
        if (typeid(evaluators[i]) == typeid(CustomExpressionEvaluator))
        {
            dynamic_cast<CustomExpressionEvaluator*>(evaluators[i])->shuffle();
            dynamic_cast<CustomExpressionEvaluator*>(evaluators[i])->calculate();
            dynamic_cast<CustomExpressionEvaluator*>(evaluators[i])->logToScreen();
        }
    }
    // ... здесь организовать еще цикл по указателям evaluators, в теле которого
    // ... проверить тип текущего объекта, и если он реализует интерфейс IShuffle,
    // ... то вызвать метод shuffle() этого объекта, после чего метод calculate()
    // ... и затем отобразить на экране результат перемешивания и вычисления выражения
    // ... освобождение памяти
    // ...

}