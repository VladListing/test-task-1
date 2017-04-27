using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace test_task_1
{

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Header //обьявление структуры "Header"
    {
        public int version;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string type;


        //конструктор "Header"
        public Header(int e, string k)
        {
            version = e;
            type = k;
        }

    }


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TradeRecord //обьявление структуры "TradeRecord"
    {

        public int id;
        public int account;
        public double volume;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string comment;


        //конструктор "TradeRecord"
        public TradeRecord(int a, int b, double c, string d)
        {
            id = a;
            account = b;
            volume = c;
            comment = d;

        }
    }




    class Program
    {
        public const
        string path = @"D:\\_LISTING_\B-files\treding_1.dat";  //путь и имя бинарного файла со структурами
        static void Main(string[] args)
        {
            // тестовое задание 1:





            // подзадача 1.конвертация бинарных файлов в формат " .*CSV "========================================================================================================================

            int schetchik = 0;//счетчик количеста проходов цикла
            Header[] header = new Header[1]; // создание экземпяра структуры "TradeRecord" на 1-ну строку
            TradeRecord[] trade = new TradeRecord[7]; // создание экземпяра структуры "TradeRecord" на 7-мь строк
            
           try
          {
               // создаем объект BinaryReader (поток чтение  из бинарного файла)
               using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
               {

                    reader.BaseStream.Position = 0;// устанавливаем "курсор" на 0-вую позицию в читаемом бинарном файле

                    // считываем через цикл каждое значение полей строк структуры "Header" из файла "treding.dat" и выводим на экран , а так же через конструктор заполняем поля структуры
                    while (reader.BaseStream.Position < 12)//пока позиция курсора не превышает 12-тую в бинарном файле
                    {
                        //var poz = reader.Current;
                        int version = reader.ReadInt32();
                        string type = reader.ReadString();

                        Console.WriteLine("версия: {0}      тип: {1} ", version, type);

                        header[0] = new Header(version, type);// инециализируем поля , присваиваем им значения через конструктор
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

                        trade[schetchik] = new TradeRecord(id, account, volume, comment );// инециализируем поля структуры, присваиваем им значения через конструктор
                        schetchik = schetchik + 1;

                    }
                }

                //-----------------------------  через цыклы выгружаем значения полей структур в файл  *.CSV  -------------------------------

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"D:\\_LISTING_\B-files\treding_1.CSV"))
                {

                    foreach (Header t in header)
                    {
                        file.Write(t.version);
                        file.Write(";");
                        file.Write(t.type);
                        file.Write(";");

                        file.WriteLine(";");
                    }


                    foreach (TradeRecord t in trade)
                    {
                        file.Write(t.id);
                        file.Write(";");
                        file.Write(t.account);
                        file.Write(";");
                        file.Write(t.volume);
                        file.Write(";");
                        file.Write(t.comment);

                        file.WriteLine(";");
                    }

                }
                //-----------------------------  через цыклы выгружаем значения полей структур в файл  *.CSV  -------------------------------
               
              }
             //======================================   конец подзадачи 1  ================================================================================================================

            



            //==================== подзадача 2.конвертация бинарных файлов в формат SQL============================================================================

            //=====================================================================================================================================================



            //================== подзадача 3.получение одной записи по "id" из сконвертированных файлов  в формате:  SQL ==========================================

            //=====================================================================================================================================================



            //================== подзадача 4.удаление сконвертированных файлов файлов в формате:  SQL , " .*CSV " =================================================

            //=====================================================================================================================================================

            
            
            
            // вывод сообщения о возникшем исключении
            catch (Exception m)
            {
                Console.WriteLine(m.Message);
            }
            Console.ReadLine();
        }
    }
}
