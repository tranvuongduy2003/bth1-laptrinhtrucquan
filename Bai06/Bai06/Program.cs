using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai06
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

    class MaTran
    {
        private int[,] m = new int[1001, 1001];
        private int dong, cot;

        public MaTran(int dong, int cot)
        {
            this.dong = dong;
            this.cot = cot;
            Random r = new Random();
            for (int i = 0; i < dong; i++)
                for (int j = 0; j < cot; j++)
                    m[i, j] = 100 - r.Next(200);
        }

        public void Xuat()
        {
            for (int i = 0; i < dong; i++)
            {
                for (int j = 0; j < cot; j++)
                    Console.Write(m[i, j] + " ");
                Console.WriteLine();
            }
        }

        public int PhanTuLonNhat()
        {
            int max = m[0, 0];
            for (int i = 0; i < dong; i++)
                for (int j = 0; j < cot; j++)
                    max = Math.Max(m[i, j], max);
            return max;
        }

        public int PhanTuNhoNhat()
        {
            int min = m[0, 0];
            for (int i = 0; i < dong; i++)
                for (int j = 0; j < cot; j++)
                    min = Math.Min(m[i, j], min);
            return min;
        }

        public int DongTongLonNhat()
        {
            int tongMax = 0, dongMax = 0;
            for (int i = 0; i < dong; i++)
            {
                int tongDong = 0;
                for (int j = 0; j < cot; j++)
                    tongDong += m[i, j];    
                if (tongDong > tongMax)
                {
                    tongMax = tongDong;
                    dongMax = i;
                }
            }
            return dongMax + 1;
        }

        public int TongKhongNguyenTo()
        {
            int tong = 0;
            for (int i = 0; i < dong; i++)
                for (int j = 0; j < cot; j++)
                    if (!SoNguyenTo.KiemTraSoNguyenTo(m[i, j]))
                        tong += m[i, j];
            return tong;
        }

        public void XoaDong(int k)
        {
            for (int i = k - 1; i < dong - 1; i++)
                for (int j = 0; j < cot; j++)
                    m[i, j] = m[i + 1, j];
            dong--;
        }

        public void XoaCot(int k)
        {
            for (int j = k - 1; j < cot - 1; j++)
                for (int i = 0; i < dong; i++)
                    m[i, j] = m[i, j + 1];
            cot--;
        }

        public int CotChuaMax()
        {
            int max = m[0, 0];
            int cotMax = 0;
            for (int i = 0; i < dong; i++)
            {
                for (int j = 0; j < cot; j++)
                {
                    if (m[i, j] > max)
                    {
                        max = m[i, j];
                        cotMax = j;
                    }
                }
            }
            return cotMax;
        }

        public void XoaCotChuaMax()
        {
            int cotMax = CotChuaMax();
            XoaCot(cotMax);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            MaTran mt = new MaTran(4, 4);
            mt.Xuat();
            int max = mt.PhanTuLonNhat();
            int min = mt.PhanTuNhoNhat();
            int dongMax = mt.DongTongLonNhat();
            int tongKhongNguyenTo = mt.TongKhongNguyenTo();
            Console.WriteLine("Phan tu lon nhat: " + max);
            Console.WriteLine("Phan tu nho nhat: " + min);
            Console.WriteLine("Dong co tong lon nhat: " + dongMax);
            Console.WriteLine("Tong cac phan tu khong phai la so nguyen to: " + tongKhongNguyenTo);
            Console.WriteLine("Xoa dong thu 2: ");
            mt.XoaDong(2);
            mt.Xuat();
            Console.WriteLine("Xoa cot chua phan tu lon nhat: ");
            mt.XoaCotChuaMax();
            mt.Xuat();
        }
    }
}
