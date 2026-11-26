using System;
using System.Collections.Generic;
using System.Text;

namespace zakharov_01_02
{
    public class Computer
    {
        //Поля класса: имя процессора, тактовая частота и ОЗУ
        private string ProcessorName = "";
        private double ClockSpeed = 0;
        private double RAM = 0;

        //Конструктор класса с проверкой на правильность входных данных
        public Computer(string processorName, double clockSpeed, double ram)
        {
            if (string.IsNullOrWhiteSpace(processorName))
            {
                throw new ArgumentException("Название процессора не может быть пустым");
            }
            if (clockSpeed <= 0)
            {
                throw new ArgumentException("Тактовая частота процессора должна быть больше 0");
            }
            if (ram <= 0)
            {
                throw new ArgumentException("Объем оперативной памяти должен быть больше 0");
            }

            ProcessorName = processorName;
            ClockSpeed = clockSpeed;
            RAM = ram;
        }

        //Функция вычесления качества объекта
        virtual public double Q()
        {
            return (0.5 * ClockSpeed) + RAM;
        }

        //Функция возврата информации об объекте
        //Является виртуальной в пользу дальнейшего переопределения
        public string GetInfo()
        {
            return $"Процессор: {ProcessorName}\nТактовая частота: {ClockSpeed} ГГц\nОбъем оперативной памяти: {RAM} ГБ\nQ = {Q()}";
        }
    }
}
