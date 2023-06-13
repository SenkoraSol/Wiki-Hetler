using System;
using System.Collections.Generic;
using System.Text;

namespace Wiki_Hitler
{
    interface IDataWorker
    {
        public string GetData();

        public void SafeData(string Data);

    }
}
