using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai02
{
    class SoNguyenTo
    {
        static public bool KiemTraSoNguyenTo(int a)
        {
            a = Math.Abs(a);
            if (a < 2)
                return false;
            for (int i = 2; i <= Math.Sqrt(a); i++)
                if (a % i == 0)
                    return false;
            return a >= 2;
        }

        static public int TongNguyenTo(uint n)
        {
            int tong = 0;
            for (int i = 2; i < n; i++)
                if (KiemTraSoNguyenTo(i))
                    tong += i;
            return tong;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap so nguyen duong n: ");
            uint n = Convert.ToUInt32(Console.ReadLine());
            int tongSnt = SoNguyenTo.TongNguyenTo(n);
            Console.WriteLine("Tong cac so nguyen to < n: " + tongSnt);
        }
    }
}
