using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai03
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

        public bool KiemTraHopLe()
        {
            if (thang < 1 || thang > 12)
                return false;
            switch(thang)
            {
                case 1: case 3: case 5: case 7: case 8: case 10: case 12:
                    if (ngay < 1 || ngay > 31) 
                        return false;
                    break;
                case 4: case 6: case 9: case 11:
                    if (ngay < 1 || ngay > 30) 
                        return false;
                    break;
                case 2:
                    if (KiemTraNamNhuan() && (ngay < 1 || ngay > 29))
                        return false;
                    if (!KiemTraNamNhuan() && ngay > 28)
                        return false;
                    break;
            }
            return true;
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
            Console.WriteLine(date.KiemTraHopLe() ? "Hop le" : "Khong hop le");
        }
    }
}
