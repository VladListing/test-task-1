using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace test_task_1
{

    //====================================================== обьявляем структуры ================ start  ==================================|
    #region описание структура header
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Header //обьявление структуры "Header "
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
    #endregion

    #region описание структура trade
    [Serializable]
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
    #endregion
    //====================================================== обьявляем структуры ================ end  =================================|



    class Program
    {
        public const
        string path = @"D:\\_LISTING_\B-files\StructTrade_Line_1200.dat";  //путь и имя бинарного файла со структурами
        static void Main(string[] args) // тестовое задание 1:
        {


            //BinaryFormatter formatter = new BinaryFormatter();



            // подзадача 1.конвертация бинарных файлов в формат " .*CSV "========================================================================================================================

            int schetchik = 0;//счетчик количеста проходов цикла
            Header[] header = new Header[1]; // создание экземпяра структуры "TradeRecord" на 1-ну строку
            TradeRecord[] trade = new TradeRecord[110]; // создание экземпяра структуры "TradeRecord" на Х строк
            TradeRecord[] newtrade = new TradeRecord[10000]; // создание экземпяра структуры "TradeRecord" на X строк

            try//'''''''''  try '''''''' оператор выполнение которого может привести к ошибке ''''''''''''начало ''''|
            #region
            {
                //================== создаем объект BinaryReader (чтение  из бинарного файла)=================================start=========================|
                #region BinaryReader
                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    reader.BaseStream.Position = 0;// устанавливаем "курсор" на 0-вую позицию в читаемом бинарном файле

                    // считываем через цикл каждое значение полей строк структуры "Header" из файла "treding.dat" и выводим на экран , а так же через конструктор заполняем поля структуры
                    #region  Read header
                    while (reader.BaseStream.Position < 12)//пока позиция курсора не превышает 12-тую в бинарном файле
                    {
                        //var poz = reader.Current;
                        int version = reader.ReadInt32();
                        string type = reader.ReadString();

                        Console.WriteLine("версия: {0}      тип: {1} ", version, type);

                        header[0] = new Header(version, type);// инециализируем поля , присваиваем им значения через конструктор
                        schetchik = schetchik + 1;
                    }

                    Console.WriteLine("Счетчик вычитанных из бинарного файла строк структуры header: {0}  ", schetchik);
                    schetchik = 0;
                    #endregion
                    Console.WriteLine();//пустая строка

                    #region Read trade
                    reader.BaseStream.Position = 12;// устанавливаем "курсор" на 12-вую позицию в бинарном файле

                    // пока не достигнут конец файла
                    // считываем через цикл каждое значение полей строк структуры "TradeRecord" из файла "treding.dat" и выводим на экран
                    while (reader.PeekChar() > -1)// пока не достигнут конец файла
                    {
                        int id = reader.ReadInt32();
                        int account = reader.ReadInt32();
                        double volume = reader.ReadDouble();
                        string comment = reader.ReadString();

                        //Console.WriteLine("id: {0}      счет: {1}     уровень: {2}       комментарий: {3} ", id, account, volume, comment);

                        trade[schetchik] = new TradeRecord(id, account, volume, comment);// инециализируем поля структуры, присваиваем им значения через конструктор
                        schetchik = schetchik + 1;
                    }

                    Console.WriteLine("Счетчик вычитанных из бинарного файла строк структуры trade: {0}  ", schetchik);
                    schetchik = 0;
                    #endregion

                }
                #endregion
                //================== создаем объект BinaryReader (чтение  из бинарного файла)=================================end=====================|


                #region Deserialize
                //using (FileStream f = new FileStream(path, FileMode.OpenOrCreate))
                //{
                //    newtrade = (TradeRecord[])formatter.Deserialize(f);
                //    //Console.WriteLine("Объект десериализован");
                //    // Console.WriteLine("Имя: {0} --- Возраст: {1}", newPerson.Name, newPerson.Age);
                //    Console.WriteLine("Объект десериализован");
                //    foreach (TradeRecord z in newtrade)
                //    {
                //        //Console.WriteLine("id: {0}      счет: {1}     уровень: {2}       комментарий: {3} ", z.id, z.account, z.volume, z.comment);
                //    }
                //}
                #endregion


                //-----------------------------  через цыклы выгружаем значения полей структур в файл  *.CSV  -------------------------------
                #region unloading in .*CSV file
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"D:\\_LISTING_\B-files\StructTrade_Line_1200.CSV"))
                {

                    //    foreach (Header t in header)
                    //    {
                    //        file.Write(t.version);
                    //        file.Write(";");
                    //        file.Write(t.type);
                    //        file.Write(";");

                    //        file.WriteLine(";");
                    //    }


                    foreach (TradeRecord t in newtrade)
                    {
                        file.Write(t.id);
                        file.Write(";");
                        file.Write(t.account);
                        file.Write(";");
                        file.Write(t.volume);
                        file.Write(";");
                        file.Write(t.comment);

                        file.WriteLine(";");

                        //Console.WriteLine("id: {0}      счет: {1}     уровень: {2}       комментарий: {3} ", t.id, t.account, t.volume, t.comment);
                    }

                }
                #endregion
                //---------------------------------------------------------------------------------------------------------------------------

                #endregion
            }//'''''''''  try '''''''' оператор выполнение которого может привести к ошибке ''''''''''''конец ''''|



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
