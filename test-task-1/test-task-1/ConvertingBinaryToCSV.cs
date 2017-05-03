using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace test_task_1
{
    public class ConvertingBinaryToCSV: IConvertingBinaryToCSV
    {
        

        //коструктоp пользовательский
        #region 
        public ConvertingBinaryToCSV(string patch_dat_, string patch_CSV_)
        {
            string patch_dat = patch_dat_;
            string patch_CSV = patch_CSV_;
            
        }

        public void fromBinaryFile()
        {
            
        }
        #endregion



        //метод 'fromBinaryFile' , вычитывает данные из бинарного потока и возвращает коллекцию структурированных данных  
        #region 'fromBinaryFile'
        public List<TradeRecord> fromBinaryFile(string patch_dat)
        {


            //создаем экземпляр коллекции , содержащую набор элементов типа структуры TradeRecod
            List<TradeRecord> trade = new List<TradeRecord>();

            int i = 0;//переменная счетчика

            //инициация потока
            using (BinaryReader reader = new BinaryReader(File.Open(patch_dat, FileMode.Open), Encoding.ASCII))
            {

                Console.WriteLine("выполняется чтение из бинарного файла: 'D:\\Trade.dat' ");
                reader.BaseStream.Position = 0;// устанавливаем "курсор" на 0-вую позицию в читаемом бинарном файле


                // считываем через цикл каждое значение полей строк структуры "TradeRecord" из бинарного файла
                while (reader.PeekChar() > -1)// пока не достигнут конец файла
                {
                    int id_ = reader.ReadInt32();
                    int account_ = reader.ReadInt32();
                    double volume_ = reader.ReadDouble();
                    string comment_ = reader.ReadString();


                    //вывод в консоль вычитаных полей (значительно увеличивает время обработки)
                    //Console.WriteLine("id: {0}      счет: {1}     уровень: {2}       комментарий: {3} ", id, account, volume, comment);

                    // инециализируем поля структуры находящейся в коллекции
                    trade.Add(new TradeRecord() { id = id_, account = account_, volume = volume_, comment = comment_ });

                    i++;
                    //Console.WriteLine("вычитанно строк: {0} ", i);
                }
                Console.WriteLine();
                Console.WriteLine("вычитано строк: {0}", i);
                i = 0;

            }

            return trade;//возвращаем коллекцию 
        }

        public void toCSV()
        {
            throw new NotImplementedException();
        }
        #endregion




        //метод 'toCSV' получает коллекцию структурированных данных  и генерирует из нее конечный файл *.CSV 
        #region 'toCSV'
        public void toCSV(List<TradeRecord> trade, string patch_CSV)
        {
            int i = 0;//переменая счетчика

            //секция критичная в части исключений
            try
            #region
            {

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(patch_CSV))
                {

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

                        i++;
                        //Console.WriteLine("id: {0}      счет: {1}     уровень: {2}       комментарий: {3} ", t.id, t.account, t.volume, t.comment);
                    }

                    Console.WriteLine();
                    Console.WriteLine("cконвертировано в файл:'D:\\Trade.csv'  : {0} строк ", i);
                    i = 0;

                }

            }
            #endregion

            //сообщение о возникшем исключении
            #region исключения
            catch (Exception m)
            {
                Console.WriteLine(m.Message);
            }
            Console.ReadLine();
            #endregion

        }
        #endregion

    }
}
        
    
