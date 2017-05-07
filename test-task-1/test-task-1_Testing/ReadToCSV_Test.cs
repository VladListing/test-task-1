using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using test_task_1;
using System.Collections;


namespace test_tesk_1_Testing_2
{

    //описание структуры 'TradeRecord' 
    #region 'TradeRecord'

    //[StructLayout(LayoutKind.Sequential, Pack = 1)]// размещение в неуправляемый код
    //public struct TradeRecord
    //{
    //    public int id;
    //    public int account;
    //    public double volume;
    //    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)] //маршалинг в неуправляемый код
    //    public string comment;

    //    //конструктор "TradeRecord"
    //    public TradeRecord(int a, int b, double c, string d)
    //    {
    //        id = a;
    //        account = b;
    //        volume = c;
    //        comment = d;
    //    }
    //}
    #endregion





    [TestClass]
    public class ReadToCSV_Test
    {

        private const string path_CSV_ = @"D:\\Trade-test.csv";  //путь и имя будующего бинарного файла содержащего  структуры
        //static List<TradeRecord> collektion_ = Created_Collection();
        //static List<TradeRecord> trade_;




        [TestMethod]
        public void Created_Collection_and_UpLoad_to_CSV_files()
        {
            int lines = 100;//на скольких строках коллекции протестировать?
            int result1_; //количество строк сгенерированых в тестовую коллекцию
            int result2_;//количество строк выгруженых в файл CSV
            int schet = 0;


            List<TradeRecord> trade_ = new List<TradeRecord>();

            for (int i = 0; i < lines; i++)

            {
                //заполняем  коллекцию  тестовыми данными
                trade_.Add(new TradeRecord() { id = i, account = 7778, volume = 78888, comment = "Коллекция, строка Unit теста 2" });

                schet++;
            }
            Console.WriteLine(" в коллекцию записанно :{0} строк ", schet);
            result1_ = schet;
            schet = 0;



            //2.выполнить действие над той системой которую мы тестируем  

            ReadToCSV readToCSV = new ReadToCSV(trade_, path_CSV_);//создаем экземпляр класса
            result2_ = readToCSV.toCSV(trade_, path_CSV_);//вызов метода класса 


            Assert.AreEqual(result1_, result2_);//сравнение ожидаемого и полученого


        }
    }
}
