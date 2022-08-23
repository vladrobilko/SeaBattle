﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeaBattle;

namespace ConsoleSeaBattle
{  
    class Program
    {

        static void Main(string[] args)
        {
            //Console.WriteLine("  |0|1|2|3|4|5|6|7|8|9     |0|1|2|3|4|5|6|7|8|9|");
            //Console.WriteLine("_______________________  _______________________");

            //Расстановка кораблей моих и чужих происходит случайно, корабли противника не видны
            //противник ходит автоматически
            //что должно выводиться
            //Console.WriteLine("a | | | | | | | | | | |   a| | | | | | | | | | |");//а0 соответствует х = 1, у = 4 (для игрока)
            //Console.WriteLine("b | | | | | | | | | | |   b| | | | | | | | | | |");//j9 соответсвует х = 10, у = 22 (для игрока)            
            //Console.WriteLine("c | | | | | | | | | | |   c| | | | | | | | | | |");// для игрока - ( х от 1 до 10(через 1), у от 4 до 22(через2))
            //Console.WriteLine("d | | | | | | | | | | |   d| | | | | | | | | | |");
            //Console.WriteLine("e | | | | | | | | | | |   e| | | | | | | | | | |");//а0 соответствует х = 1, у = 29 (для противника)
            //Console.WriteLine("f | | | | | | | | | | |   f| | | | | | | | | | |");//j9 соответсвует х = 10, у = 47 (для противника)
            //Console.WriteLine("g | | | | | | | | | | |   g| | | | | | | | | | |");// для противника - ( х от 1 до 10(через 1), у от 29 до 47(через2))
            //Console.WriteLine("h | | | | | | | | | | |   h| | | | | | | | | | |");//ввести координату для хода(букву и цифру)
            //Console.WriteLine("i | | | | | | | | | | |   i| | | | | | | | | | |");
            //Console.WriteLine("j | | | | | | | | | | |   j| | | | | | | | | | |");
            /*            
            так как заполнение и ход у противника автоматом
            то эта логика будет происходить внутри, мб сначала ее написать?
            допустим юзер вводит координату a 5 для листа противника это listOpponent, a - значит в listOpponent будет лист под номером 1,
            в котором 5 элемент будет нужная клетка
            */
            //интерфейс заполнения случайными кораблями,
            //интерфейс преобразования квадрата в string, интерфейс выстрела(действия после выстрела х - попал,` - промах) 
            //нужен классИгрока(10х10) методы - преобразование в строку
            //классПротивника(10) методы - преобразование в строку

            var gameField = new PlayArea(10,10);

            gameField.FillShipsRandomly(1, 4);
            gameField.FillShipsRandomly(2, 3);
            gameField.FillShipsRandomly(3, 2);  
           // gameField.FillShipsRandomly(4, 1);




            for (int i = 0; i < gameField.cells.GetLength(0); i++)
            {
                for (int j = 0; j < gameField.cells.GetLength(1); j++)
                {
                    Console.Write(gameField.cells[i,j].Condition + "|");
                }
                Console.WriteLine();
            }
           
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
