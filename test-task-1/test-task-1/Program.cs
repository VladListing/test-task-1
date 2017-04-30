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
    #region описание структура trade

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
        string path = @"D:\\_LISTING_\B-files\StructTrade_Line_110.dat";  //путь и имя бинарного файла со структурами
        static void Main(string[] args) // тестовое задание 1:
        {

            // подзадача 1.конвертация бинарных файлов в формат " .*CSV "========================================================================================================================

            int schetchik = 0;//счетчик количеста проходов цикла

            //======================= создаем экземпляры (обьекты) структур и инициализируем их поля ============= start ==============================|
            #region creation struct trade
            TradeRecord[] trade = new TradeRecord[110]; // создание экземпяра структуры "TradeRecord" на Х строк
            #endregion
            //============= создаем экземпляры (обьекты) структур и инициализируем их поля ======================= end ==========================|

            try//'''''''''  try '''''''' оператор выполнение которого может привести к ошибке ''''''''''''начало ''''|
            #region
            {
                //================== создаем объект BinaryReader (чтение  из бинарного файла)=================================start=========================|
                #region BinaryReader loading struct trade from *.dat file
                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    #region Read trade

                    reader.BaseStream.Position = 0;// устанавливаем "курсор" на 0-вую позицию в читаемом бинарном файле
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


                //-----------------------------  через цыклы выгружаем значения полей структур в файл  *.CSV  -------------------------------
                #region unloading struct trade in *.CSV file
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"D:\\_LISTING_\B-files\StructTrade_Line_110.CSV"))
                {

                    //    foreach (Header t in header)
                    //    {
                    //        file.Write(t.version);
                    //        file.Write(";");
                    //        file.Write(t.type);
                    //        file.Write(";");

                    //        file.WriteLine(";");
                    //    }


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

                        //Console.WriteLine("id: {0}      счет: {1}     уровень: {2}       комментарий: {3} ", t.id, t.account, t.volume, t.comment);
                    }

                }
                #endregion
                //---------------------------------------------------------------------------------------------------------------------------

                #endregion
            }//'''''''''  try '''''''' оператор выполнение которого может привести к ошибке ''''''''''''конец ''''|

            //======================================   конец подзадачи 1  ================================================================================================================

            //-----вывод сообщения о возникшем исключении--------
            #region исключения
            catch (Exception m)
            {
                Console.WriteLine(m.Message);
            }
            Console.ReadLine();
            #endregion
            //---------------------------------------------------
        }
    }
}
