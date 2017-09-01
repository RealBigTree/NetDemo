using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unity.IO {
    public static class ExStream {
        public static string ToString2(this Stream src){
            byte[] bts  = new byte[src.Length];
            src.Read(bts, 0, bts.Length);
            return Encoding.UTF8.GetString(bts);
        }
    }
}
