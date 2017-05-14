using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using test_task_1;
using System.Collections;
using System.Text;

namespace test_tesk_1_Testing
{
        //тестируем класс 'ReadToCSV' (модульный тест)

      //Unit test 2: создаем 'заглушку' тестовую  коллекцию содержащую 1000000 'миллион' строк структуры 'tread'
     //тестируем класс 'ReadToCSV',его метод 'toCSV' с его помощью вычитываем данные из тестовой  коллекции и выгружаем их в файл 'Trade-test-2.csv'
    //после чего сверяем количество строк в 'заглушке' тестовой  коллекции и количество  строк выгруженных в файл 'Trade-test-2.csv', если они равны,  тест пройден.  


    [TestClass]
    public class ReadToCSV_Test
    {

        //# 1. Создаем заглушку для тестируемого класса 'ReadToCSV', в виде тестовой  коллекции содержащей 1000000 'миллион' строк структуры 'tread'


        private const string path_CSV_ = @"D:\\Trade-test-2.csv";  //путь и имя бедующего  файла с разделителями содержащего  структуры 'tread'


        [TestMethod(), Timeout(20000)]//максимально возможное время работы теста (20 секунд)
        public void Created_Collection_and_UpLoad_to_CSV_files()
        {
            int lines = 1000000;//на скольких строках коллекции протестировать?
            int result1_; //количество строк сгенерированных в тестовую коллекцию
            int result2_; //количество строк выгруженных в файл 'Trade-test.csv'
            int schet = 0;//счетчик

            //подстраиваем кодировку поля "comment"
            Encoding asciiEncoding = Encoding.Default;
            string comment_ = "   comment Unit-test 2";
            byte[] utf8Bytes = Encoding.Default.GetBytes(comment_);
            string comment__ = asciiEncoding.GetString(utf8Bytes);

            //создаем экземпляр коллекции
            List<TradeRecord> trade_ = new List<TradeRecord>();
            for (int i = 0; i < lines; i++)
            {
                //заполняем коллекцию тестовыми данными
                trade_.Add(new TradeRecord() { id = i, account = 7777, volume = 88888, comment = comment__ });

                schet++;
            }
            result1_ = schet;
            schet = 0;




            //# 2.выполняем действие над тестируем классом:'ReadToCSV'

            ReadToCSV readToCSV = new ReadToCSV(path_CSV_);//создаем экземпляр класса

            result2_ = readToCSV.toCSV(trade_, path_CSV_);//вызов метода класса

            Assert.AreEqual(result1_, result2_);     //сравнение ожидаемого и полученного, если равны то тест пройден


        }
    }
}
