using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai05
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

        public int MaNgay()
        {
            return ngay % 7;
        }

        public int MaThang()
        {
            if (thang % 2 == 0)
                return 12 - thang;
            else if (thang != 9 && thang != 11)
                return 12 - thang - 4;
            return 12 - thang - 4 + 1;
        }

        public int MaNam()
        {
            int t = nam % 100;
            return (t % 7) + (int)(t / 4);
        }

        public int MaTheKy()
        {
            return ((int)(nam / 100)) % 4 * 5;
        }

        public int MaSaiSo()
        {
            if (thang > 2)
                return -2;
            else if (KiemTraNamNhuan())
                return -1;
            return 0;
        }

        public void InThu()
        {
            int thu = (MaNgay() + MaThang() + MaNam() + MaTheKy() + MaSaiSo()) % 7;
            string sThu = "";
            switch (thu)
            {
                case 2:
                    sThu = "Thu Hai";
                    break;
                case 3:
                    sThu = "Thu Ba";
                    break;
                case 4:
                    sThu = "Thu Tu";
                    break;
                case 5:
                    sThu = "Thu Nam";
                    break;
                case 6:
                    sThu = "Thu Sau";
                    break;
                case 0:
                    sThu = "Thu Bay";
                    break;
                case 1:
                    sThu = "Chu Nhat";
                    break;
            }
            Console.WriteLine("Thu trong tuan la " + sThu);
        }

        public void Nhap()
        {
            Console.Write("Nhap ngay: ");
            ngay = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nhap thang: ");
            thang = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nhap nam: ");
            nam = Convert.ToInt32(Console.ReadLine());
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Date date = new Date();
            date.Nhap();
            date.InThu();
        }
    }
}
