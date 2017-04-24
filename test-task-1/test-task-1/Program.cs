using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_task_1
{
    class Program
    {
        public const
        string path = @"D:\\_LISTING_\B-files\treding.dat";  //путь и имя бинарного файла со структурами
        static void Main(string[] args)
        {
            // тестовое задание 1

       // подзадача 1.конвертация бинарных файлов в формат " .*CSV "
            // создаем объект BinaryReader (чтение  из бинарного файла)
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                Console.WriteLine();//пустая строка
                reader.BaseStream.Position = 0;// устанавливаем "курсор" на 0-вую позицию в бинарном файле

                // считываем через цикл каждое значение полей строк структуры "Header" из файла "treding.dat" и выводим на экран

                //while (reader.PeekChar() > -1)
                while (reader.BaseStream.Position < 12)//пока позиция курсора не превышает 12-тую в бинарном файле

                {
                    
                    int version = reader.ReadInt32();
                    string type = reader.ReadString();

                    Console.WriteLine("версия: {0}      тип: {1} ", version, type);
                }
                Console.WriteLine();//пустая строка

                reader.BaseStream.Position = 12;// устанавливаем "курсор" на 12-вую позицию в бинарном файле

                // пока не достигнут конец файла
                // считываем через цикл каждое значение полей строк структуры "TradeRecord" из файла "treding.dat" и выводим на экран
                while (reader.PeekChar() > -1)// пока не достигнут конец файла
                {
                    int id = reader.ReadInt32();
                    int account = reader.ReadInt32();
                    double volume = reader.ReadDouble();
                    string comment = reader.ReadString();

                    Console.WriteLine("id: {0}      счет: {1}     уровень: {2}       комментарий: {3} ", id, account, volume, comment);
                }
            }

            
            Console.ReadLine();


            // подзадача 2.конвертация бинарных файлов в формат SQL



            // подзадача 3.получение одной записи по "id" из сконвертированных файлов  в формате:  SQL 



            // подзадача 4.удаление сконвертированных файлов файлов в формате:  SQL , " .*CSV "


        }
    }
}
