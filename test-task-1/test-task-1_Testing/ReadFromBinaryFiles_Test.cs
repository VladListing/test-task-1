using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using test_task_1;

namespace test_task_1_Unit_Testing_1
{

        //тестируем класс 'ReaderFromBinaryFiles' (модульный тест)

      //Unit test 1: создаем 'заглушку' тестовый бинарный файл 'Tread-test-1.dat' содержащий 1000000 'миллион'строк структуры 'tread'
     //тестируем класс 'ReaderFromBinaryFiles',его метод 'fromBinaryFile' с его помощью вычитываем данные из тестового бинарного файла и размещаем их в коллекцию
    //после чего сверяем количество строк в 'заглушке' тестовом бинарном файле и количество  строк вычитанных из него в коллекцию, если они равны то тест пройден.  



    [TestClass]
    public class ReadFromBinaryFile_Test
    {



        //# 1. Создаем заглушку для тестируемого класса 'ReaderFromBinaryFiles', в виде тестового бинарного файла 'Tread-test-1.dat'

        [TestMethod(), Timeout(20000)]//максимально возможное время работы теста (20 секунд)
        #region

        public void fromBinaryFile_Created_and_Read__Lines()
        {

            string path = @"D:\\Trade-test-1.dat";  //путь и имя бедующего бинарного файла содержащего  структуры
            int schetchik = 0;//счетчик
            int result1 = 0;//счетчик
            int lines = 1000000;//на скольких строках протестировать?



            //создаем массив структур и присваиваем  значения полям каждой структуры 
            #region 

            TradeRecord[] trade = new TradeRecord[lines]; // создание экземпляра структуры "TradeRecord" на X строк

            for (int i = 0; i < lines; i++)
            {
                trade[i] = new TradeRecord(0 + i, lines, 640 + i, "   comment Unit-test 1");
            }
            #endregion


            //создание экземпляра BinaryWriter (запись  в бинарный файл)
            #region BinaryWriter
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))// открывает поток для записи структур в файл
            {
                #region
                foreach (TradeRecord t in trade)
                {
                    writer.Write(t.id);
                    writer.Write(t.account);
                    writer.Write(t.volume);
                    writer.Write(t.comment);

                    schetchik++;
                }
                Console.WriteLine("");
                Console.WriteLine("в бинарный файл 'D:\\Trade-test-1.dat' записано   {0}  строк(и) структуры 'trade'", schetchik);
                result1 = schetchik;
                schetchik = 0;
                #endregion
            }
            #endregion

            #endregion


            //# 2.выполняем действие над тестируемым классом:'ReaderFromBinaryFiles'

            ReaderFromBinaryFiles readerFromBinaryFiles = new ReaderFromBinaryFiles(path);
            int result2;//количество строк вычитанных из бинарного файла в коллекцию 
            readerFromBinaryFiles.fromBinaryFile(path, out result2);

            Assert.AreEqual(result1, result2);//сравнение ожидаемого и полученного, если равны то тест пройден

        }
    }
}
