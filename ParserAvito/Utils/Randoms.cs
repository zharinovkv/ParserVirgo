using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//http://kipor-msk.ru/sluchajnye-chisla-v-c-net

namespace ParserVirgo
{
    public class Randoms
    {
        public int RandomSet()
        {
            var buf = Guid.NewGuid().ToByteArray();
            var randomValue32 = Math.Abs(BitConverter.ToInt32(buf, 7)) / 20000;
            return randomValue32;
        }

    }
}
