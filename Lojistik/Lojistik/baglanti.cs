using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojistik
{
    public class baglanti
    {
        public static string baglantiAdresi { get; set; } = File.ReadAllText("connection.txt");
    }
}
