using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace test_task_1
{
    public interface IConvertingBinaryToCSV: IReaderFromBinaryFiles,IReadToCSV
    {

        new void fromBinaryFile();
        new void toCSV();
    }

}