using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai04
{
    class Date
    {
        private int ngay, thang, nam;

        public bool KiemTraNamNhuan()
        {
            if ((nam % 4 == 0 && nam % 100 != 0) || nam % 400 == 0)
                return true;
            return false;
        }

        public void NhapThangNam()
        {
            Console.Write("Nhap thang: ");
            thang = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nhap nam: ");
            nam = Convert.ToInt32(Console.ReadLine());
        }

        public void InNgay()
        {
            switch (thang)
            {
                case 1: case 3: case 5: case 7: case 8: case 10: case 12:
                    ngay = 31;
                    break;
                case 4: case 6: case 9: case 11:
                    ngay = 30;
                    break;
                case 2:
                    ngay = KiemTraNamNhuan() ? 29 : 28;
                    break;
            }
            Console.WriteLine("So ngay cua thang: " + ngay);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Date date = new Date();
            date.NhapThangNam();
            date.InNgay();
        }
    }
}
