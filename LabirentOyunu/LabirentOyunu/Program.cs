using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace LabirentOyunu
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ben bu kodda camel case kullandım.
            int i, j = 0, i1 = 0, j1 = 0, i2 = 0, j2 = 0, j3 = 0, j4 = 0, k = 0, l = 0, m = 1, bomba = 0, tur = 1, gBasma = 0, sayı2 = 0, puan = 0;
            char basılanHarf;
            string basılanHarf2;
            bool labirentOldu = false, labirentOldu2 = false, oyunBitti = false;
            Random Sayı = new Random();
            char[,] labirent1 = new char[11, 10];
            char[,] labirent2 = new char[11, 10];
            while (labirentOldu == false)
            {
                for (i = 0; i < 10; i++)
                {
                    for (j = 0; j < 10; j++)
                    {
                        if (i >= 0 && j == 0)
                        {
                            labirent1[i, j] = '0';
                        }
                        else if (i >= 0 && j == 9)
                        {
                            labirent1[i, j] = '0';
                        }
                    }
                }
                while (k != 3)
                {
                    sayı2 = Sayı.Next(1, 9);
                    j = sayı2;
                    if (labirent1[9, j] != '1')
                    {
                        labirent1[9, j] = '1';
                        k++;
                    }
                }
                for (j = 1; j < 9; j++)
                {
                    if (labirent1[9, j] != '1')
                    {
                        labirent1[9, j] = '0';
                    }
                }
                j = 1;
                while (labirentOldu2 == false)
                {
                    while (j < 9)
                    {
                        if (labirent1[9, j] == '1')
                        {
                            i1 = 9;
                            j1 = j;
                            labirent1[i1, j1] = '3';
                            j = 9;
                        }
                        else
                        {
                            j++;
                        }
                    }
                    while (i1 != 0)
                    {
                        sayı2 = Sayı.Next(1, 4);
                        if (sayı2 == 1)
                        {
                            i1--;
                            labirent1[i1, j1] = '1';
                        }
                        else if (sayı2 == 2 && labirent1[i1, j1 - 1] != '0')
                        {
                            j1--;
                            labirent1[i1, j1] = '1';
                        }
                        else if (sayı2 == 3 && labirent1[i1, j1 + 1] != '0')
                        {
                            j1++;
                            labirent1[i1, j1] = '1';
                        }
                        if (i1 == 0)
                        {
                            j = 1;
                            l++;
                        }
                    }
                    if (l == 3)
                    {
                        labirentOldu2 = true;
                    }
                }
                for (i = 0; i < 10; i++)
                {
                    for (j = 1; j < 9; j++)
                    {
                        if (labirent1[i, j] != '1' && labirent1[i, j] != '3')
                        {
                            labirent1[i, j] = '0';
                        }
                    }
                }
                for (j = 1; j < 9; j++)
                {
                    if (labirent1[9, j] == '3')
                    {
                        labirent1[9, j] = '1';
                    }
                }
                labirentOldu = true;
            }
            for (i = 0; i < 10; i++)
            {
                for (j = 0; j < 10; j++)
                {
                    labirent2[i, j] = labirent1[i, j];
                }
            }
            while (bomba < 2)
            {
                i = Sayı.Next(1, 9);
                j = Sayı.Next(1, 9);
                if (labirent2[i, j] == '1')
                {
                    labirent2[i, j] = '2';
                    bomba++;
                }
            }
            for (j = 0; j < 9; j++)
            {
                if (labirent1[9, j] == '1')
                {
                    if (m == 1)
                    {
                        j1 = j;
                        m++;
                    }
                    else if (m == 2)
                    {
                        j3 = j;
                        m++;
                    }
                    else if (m == 3)
                    {
                        j4 = j;
                        m = 0;
                    }
                }
            }
            while (oyunBitti == false)
            {
                if (tur == 1)
                {
                    for (i = 0; i < 10; i++)
                    {
                        Console.WriteLine();
                        for (j = 0; j < 10; j++)
                        {
                            Console.Write(labirent1[i, j]);
                        }
                    }
                    labirent1[i2, j2] = '1';
                    labirent2[i2, j2] = '1';
                    Console.WriteLine();
                    Console.WriteLine("hangi yolu tercih ediyorsunuz:");
                    basılanHarf2 = Console.ReadLine();
                    basılanHarf = Convert.ToChar(basılanHarf2);
                    puan = 0;
                    if (basılanHarf == '1')
                    {
                        labirent1[9, j1] = 'k';
                        labirent2[9, j1] = 'k';
                        i2 = 9;
                        j2 = j1;
                        tur++;
                    }
                    else if (basılanHarf == '2')
                    {
                        labirent1[9, j3] = 'k';
                        labirent2[9, j3] = 'k';
                        i2 = 9;
                        j2 = j3;
                        tur++;
                    }
                    else if (basılanHarf == '3')
                    {
                        labirent1[9, j4] = 'k';
                        labirent2[9, j4] = 'k';
                        i2 = 9;
                        j2 = j4;
                        tur++;
                    }
                    else
                    {
                        Console.WriteLine("yanlış rakam bastınız tekrar deneyin ");
                    }
                }
                if (tur > 1)
                {
                    for (i = 0; i < 10; i++)
                    {
                        Console.WriteLine();
                        for (j = 0; j < 10; j++)
                        {
                            Console.Write(labirent1[i, j]);
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine("harf basınız w ileri a sağ s geri d sol g bomba görme");
                    basılanHarf2 = Console.ReadLine();
                    basılanHarf = Convert.ToChar(basılanHarf2);
                    if (basılanHarf == 'g' || basılanHarf == 'G')
                    {
                        gBasma++;
                        while (gBasma != 2)
                        {
                            for (i = 0; i < 10; i++)
                            {
                                Console.WriteLine();
                                for (j = 0; j < 10; j++)
                                {
                                    Console.Write(labirent2[i, j]);
                                }
                            }
                            Console.WriteLine();
                            Console.WriteLine("geriye dönmek için g ye basınız");
                            basılanHarf2 = Console.ReadLine();
                            basılanHarf = Convert.ToChar(basılanHarf2);
                            if (basılanHarf == 'g' || basılanHarf == 'G')
                            {
                                gBasma++;
                            }
                            else
                            {
                                Console.WriteLine("yanlış harfe bastınız lütfen tekrar deneyiniz");
                            }
                        }
                        gBasma = 0;
                    }
                    else if (basılanHarf == 'w' || basılanHarf == 'W')
                    {
                        if (labirent2[i2 - 1, j2] == '2')
                        {
                            Console.WriteLine("bombaya denk geldiniz oyununuz bitti");
                            oyunBitti = true;
                        }
                        else if (labirent1[i2 - 1, j2] == '1')
                        {
                            labirent1[i2, j2] = '1';
                            labirent1[i2 - 1, j2] = 'k';
                            labirent2[i2, j2] = '1';
                            labirent2[i2 - 1, j2] = 'k';
                            i2--;
                            puan++;
                        }
                        else if (labirent1[i2, j2 + 1] == '0' || labirent1[i2, j2 - 1] == '0' || labirent1[i2 - 1, j2] == '0')
                        {
                            Console.WriteLine("duvara çarptınız!");
                            puan--;
                        }
                    }
                    else if (basılanHarf == 's' || basılanHarf == 'S')
                    {
                        if (labirent2[i2 + 1, j2] == '2')
                        {
                            Console.WriteLine("bombaya denk geldiniz oyununuz bitti");
                            oyunBitti = true;
                        }
                        if (labirent1[i2 + 1, j2] == '1')
                        {
                            labirent1[i2 + 1, j2] = 'k';
                            labirent1[i2, j2] = '1';
                            labirent2[i2 + 1, j2] = 'k';
                            labirent2[i2, j2] = '1';
                            i2++;
                            puan++;
                        }
                        else if (labirent1[i2, j2 + 1] == '0' || labirent1[i2, j2 - 1] == '0' || labirent1[i2 - 1, j2] == '0')
                        {
                            Console.WriteLine("duvara çarptınız!");
                            puan--;
                        }
                    }
                    else if (basılanHarf == 'a' || basılanHarf == 'A')
                    {
                        if (labirent2[i2, j2 - 1] == '2')
                        {
                            Console.WriteLine("bombaya denk geldiniz oyununuz bitti");
                            oyunBitti = true;
                        }
                        if (labirent1[i2, j2 - 1] == '1')
                        {
                            labirent1[i2, j2 - 1] = 'k';
                            labirent1[i2, j2] = '1';
                            labirent2[i2, j2 - 1] = 'k';
                            labirent2[i2, j2] = '1';
                            j2--;
                            puan++;
                        }
                        else if (labirent1[i2, j2 + 1] == '0' || labirent1[i2, j2 - 1] == '0' || labirent1[i2 - 1, j2] == '0')
                        {
                            Console.WriteLine("duvara çarptınız!");
                            puan--;
                        }
                    }
                    else if (basılanHarf == 'd' || basılanHarf == 'D')
                    {
                        if (labirent2[i2, j2 + 1] == '2')
                        {
                            Console.WriteLine("bombaya denk geldiniz oyununuz bitti");
                            oyunBitti = true;
                        }
                        if (labirent1[i2, j2 + 1] == '1')
                        {
                            labirent1[i2, j2 + 1] = 'k';
                            labirent1[i2, j2] = '1';
                            labirent2[i2, j2 + 1] = 'k';
                            labirent2[i2, j2] = '1';
                            j2++;
                            puan++;
                        }
                        else if (labirent1[i2, j2 + 1] == '0' || labirent1[i2, j2 - 1] == '0' || labirent1[i2 - 1, j2] == '0')
                        {
                            Console.WriteLine("duvara çarptınız!");
                            puan--;
                        }
                    }
                    else
                    {
                        Console.WriteLine("yanlış harf tekrar deneyin");
                    }
                }
                if (i2 == 0 && tur > 1)
                {
                    Console.WriteLine("tebrikler kazandınız puanınız {0}", puan);
                    oyunBitti = true;
                }
                else if (i2 == 9)
                {
                    tur = 1;
                }
            }
            Console.ReadKey();
        }
    }
}