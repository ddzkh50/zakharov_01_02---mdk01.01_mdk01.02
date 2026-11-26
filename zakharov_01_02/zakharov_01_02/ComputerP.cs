using System;
using System.Collections.Generic;
using System.Text;

namespace zakharov_01_02
{
    public class ComputerP : Computer
    {
        //Поле класса-наследника: объем винчестера
        private double P = 0;

        //Конструктор класса с проверкой входных данных
        public ComputerP(double p ,string processorName, double clockSpeed, double ram) : base(processorName, clockSpeed, ram)
        {
            if (p <= 0)
            {
                throw new ArgumentException("Объем винчестера должен быть больше 0");
            }
            P = p;
        }

        //Функция переопределяющая такую же функцию из класса-родителя
        override public double Q()
        {
             if (P > 1500)
                return base.Q() - 0.5 * P;
            else
                return base.Q() + 0.8 * P;
        }
    }
}
