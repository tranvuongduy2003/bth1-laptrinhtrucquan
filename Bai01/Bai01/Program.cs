using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai01
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
    }

    class SoChinhPhuong
    {
        static public bool KiemTraSoChinhPhuong(int a)
        {
            int t = (int)Math.Sqrt(a);
            return a == t * t;
        }
    }

    class MangSoNguyen {
        private int[] mang = new int[10001];
        private int length;

        public void TaoMangNgauNhien()
        {
            Console.Write("Nhap n: ");
            length = Convert.ToInt32(Console.ReadLine());

            Random rnd = new Random();
            for (int i = 0; i < length; i++)
                mang[i] = 100 - rnd.Next(200);

            for (int i = 0; i < length; i++)
                Console.Write(mang[i] + " ");
            Console.WriteLine();
        }

        public int TongSoLe()
        {
            int tong = 0;
            for (int i = 0; i < length; i++)
                if (mang[i] % 2 == 1 || mang[i] % 2 == -1)
                    tong += mang[i];
            return tong;
        }

        public int DemSoNguyenTo()
        {
            int dem = 0;
            for (int i = 0; i < length; i++)
                if (SoNguyenTo.KiemTraSoNguyenTo(mang[i]))
                    dem++;
            return dem;
        }

        public int SoChinhPhuongNhoNhat()
        {
            if (length <= 0)
                return -1;

            int min, i = 0;
            while (!SoChinhPhuong.KiemTraSoChinhPhuong(mang[i]) && i < length) i++;

            if (i >= length)
                return -1;
            else
                min = mang[i];

            while (i < length)
            {
                if (SoChinhPhuong.KiemTraSoChinhPhuong(mang[i]))
                    min = Math.Min(min, mang[i]);
                i++;
            }

            return min;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            MangSoNguyen mang = new MangSoNguyen();
            mang.TaoMangNgauNhien();
            int sl = mang.TongSoLe();
            int snt = mang.DemSoNguyenTo();
            int scp = mang.SoChinhPhuongNhoNhat();
            Console.WriteLine("Tong cac so le trong mang: " + sl);
            Console.WriteLine("Dem so nguyen to trong mang: " + snt);
            Console.WriteLine($"So chinh phuong nho nhat: {(scp == -1 ? "Khong co" : Convert.ToString(scp))}");
        }
    }
}
