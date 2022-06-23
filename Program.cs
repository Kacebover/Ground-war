using System;

namespace WarInUkraine
{
    class Program
    {
        private static int health1 = 100; // прочность 1 танка
        private static int health2 = 100; // прочность 2 танка
        private static int tankX1 = 19; // 1 танк на оси X
        private static int tankY1 = 1; // 1 танк на оси Y
        private static int tankX2 = 1; // 2 танк на оси X
        private static int tankY2 = 10; // 2 танк на оси Y
        private static string tank1; // для модельки танка 1 игрока
        private static string tank2; // для модельки танка 2 игрока
        private static int projectileX1 = tankX1; // ось X 1 снаряда
        private static int projectileY1 = tankY1; // ось Y 1 снаряда
        private static int projectileX2 = tankX2; // ось X 2 снаряда
        private static int projectileY2 = tankY2; // ось Y 2 снаряда
        private static int direction1 = 8; // направление 1 танка
        private static int direction2 = 2; // направление 2 танка
        private static string line1;
        private static string line2;
        private static string line3;
        private static string line4;
        private static string line5;
        private static string line6;
        private static string line7;
        private static string line8;
        private static string line9;
        private static string line10;
        // линии карты
        private static string shot1;
        private static string shot2;
        // управление выстрелом
        private static bool pause = false; // пауза
        private static int time; // отсчёт после паузы
        private static bool ishotting1 = false; // стреляет ли 1 игрок
        private static bool ishotting2 = false; // стреляет ли 2 игрок
        private static bool aifighting1 = false; // включён ли ИИ за 1 игрока против 2 игрока
        private static bool aifighting2 = false; // включён ли ИИ за 2 игрока против 1 игрока
        private static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("                             War");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("In");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Ukraine");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Управление :");
            Console.WriteLine("     Игрок 1: Выстрел - пробел, передвижение - W A S D, поворот башни - I J K L, пауза вкл/выкл Tab, ИИ вкл/выкл - P, завершить игру - Esc");
            Console.WriteLine("     Игрок 2: Выстрел - 1, передвижение - ↑ ← ↓ →, поворот башни - 8 4 5 6, пауза вкл/выкл PageDown, ИИ вкл/выкл - 9, завершить игру - End");
            Console.WriteLine("Правила :");
            Console.WriteLine("     У каждого игрока по 100хп");
            Console.WriteLine("     Один выстрел сносит 20хп");
            Console.WriteLine("     Скорость выстрела - 1 клетка в 60мс");
            Console.WriteLine();
            Timer timer1 = new Timer(shoterX1, null, 0, 60);
            Timer timer2 = new Timer(shoterY1, null, 0, 60);
            Timer timer3 = new Timer(shoterX2, null, 0, 60);
            Timer timer4 = new Timer(shoterY2, null, 0, 60);
            Timer timer5 = new Timer(aifightvstwo, null, 0, 60);
            Timer timer6 = new Timer(aifightvsone, null, 0, 60);
            Timer timer7 = new Timer(deather, null, 0, 1);
            do
            {
                if (ishotting1 == false)
                {
                    projectileX1 = tankX1;
                    projectileY1 = tankY1;
                }
                if (ishotting2 == false)
                {
                    projectileX2 = tankX2;
                    projectileY2 = tankY2;
                }
                if (pause == false)
                    menu();
                while (Console.KeyAvailable)
                    Console.ReadKey(true);
                ConsoleKeyInfo hit = Console.ReadKey(true);
                if (pause == false)
                {
                    switch (hit.Key)
                    {
                        case ConsoleKey.Spacebar:
                            ishotting1 = true;
                            if (direction1 == 8)
                                shot1 = "up";
                            else if (direction1 == 4)
                                shot1 = "left";
                            else if (direction1 == 2)
                                shot1 = "down";
                            else if (direction1 == 6)
                                shot1 = "right";
                            break;
                        case ConsoleKey.W:
                            if (tankY1 != 10)
                                tankY1++;
                            if (tankY1 == tankY2 & tankX1 == tankX2)
                                tankY1--;
                            break;
                        case ConsoleKey.A:
                            if (tankX1 != 1)
                                tankX1 -= 2;
                            if (tankY1 == tankY2 & tankX1 == tankX2)
                                tankX1 += 2;
                            break;
                        case ConsoleKey.S:
                            if (tankY1 != 1)
                                tankY1--;
                            if (tankY1 == tankY2 & tankX1 == tankX2)
                                tankY1++;
                            break;
                        case ConsoleKey.D:
                            if (tankX1 != 19)
                                tankX1 += 2;
                            if (tankY1 == tankY2 & tankX1 == tankX2)
                                tankX1 -= 2;
                            break;
                        case ConsoleKey.NumPad1:
                            ishotting2 = true;
                            if (direction2 == 8)
                                shot2 = "up";
                            else if (direction2 == 4)
                                shot2 = "left";
                            else if (direction2 == 2)
                                shot2 = "down";
                            else if (direction2 == 6)
                                shot2 = "right";
                            break;
                        case ConsoleKey.UpArrow:
                            if (tankY2 != 10)
                                tankY2++;
                            if (tankY1 == tankY2 & tankX1 == tankX2)
                                tankY2--;
                            break;
                        case ConsoleKey.LeftArrow:
                            if (tankX2 != 1)
                                tankX2 -= 2;
                            if (tankY1 == tankY2 & tankX1 == tankX2)
                                tankX2 += 2;
                            break;
                        case ConsoleKey.DownArrow:
                            if (tankY2 != 1)
                                tankY2--;
                            if (tankY1 == tankY2 & tankX1 == tankX2)
                                tankY2++;
                            break;
                        case ConsoleKey.RightArrow:
                            if (tankX2 != 19)
                                tankX2 += 2;
                            if (tankY1 == tankY2 & tankX1 == tankX2)
                                tankX2 -= 2;
                            break;
                        case ConsoleKey.J:
                            if (direction1 != 4)
                                direction1 = 4;
                            if (ishotting1 == true)
                                shot1 = "left";
                            break;
                        case ConsoleKey.I:
                            if (direction1 != 8)
                                direction1 = 8;
                            if (ishotting1 == true)
                                shot1 = "up";
                            break;
                        case ConsoleKey.K:
                            if (direction1 != 2)
                                direction1 = 2;
                            if (ishotting1 == true)
                                shot1 = "down";
                            break;
                        case ConsoleKey.L:
                            if (direction1 != 6)
                                direction1 = 6;
                            if (ishotting1 == true)
                                shot1 = "right";
                            break;
                        case ConsoleKey.NumPad4:
                            if (direction2 != 4)
                                direction2 = 4;
                            if (ishotting2 == true)
                                shot2 = "left";
                            break;
                        case ConsoleKey.NumPad8:
                            if (direction2 != 8)
                                direction2 = 8;
                            if (ishotting2 == true)
                                shot2 = "up";
                            break;
                        case ConsoleKey.NumPad5:
                            if (direction2 != 2)
                                direction2 = 2;
                            if (ishotting2 == true)
                                shot2 = "down";
                            break;
                        case ConsoleKey.NumPad6:
                            if (direction2 != 6)
                                direction2 = 6;
                            if (ishotting2 == true)
                                shot2 = "right";
                            break;
                        case ConsoleKey.Escape:
                            return;
                        case ConsoleKey.End:
                            return;
                        case ConsoleKey.P:
                            if (aifighting2 == false & aifighting1 == false)
                                aifighting2 = true;
                            else
                            {
                                aifighting1 = false;
                                aifighting2 = false;
                            }
                            break;
                        case ConsoleKey.NumPad9:
                            if (aifighting2 == false & aifighting1 == false)
                                aifighting1 = true;
                            else
                            {
                                aifighting1 = false;
                                aifighting2 = false;
                            }
                            break;
                    }
                }
                if (hit.Key == ConsoleKey.PageDown || hit.Key == ConsoleKey.Tab)
                {
                    if (pause == false)
                    {
                        pause = true;
                        Console.WriteLine("Поставлена пауза");
                        Console.WriteLine("Введите PageUp или M (англ), чтобы посмотреть управление и правила");
                        Console.WriteLine("PageDown или Tab - возобновить игру");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("Игра будет возобновлена через: ");
                        time = 4;
                        beeper();
                        Thread.Sleep(1000);
                        beeper();
                        Thread.Sleep(1000);
                        beeper();
                        Thread.Sleep(1000);
                        beeper();
                    }
                }
                if (pause == true)
                {
                    if (hit.Key == ConsoleKey.PageUp || hit.Key == ConsoleKey.M)
                    {
                        Console.WriteLine("Управление :");
                        Console.WriteLine("     Игрок 1: Выстрел - пробел, передвижение - W A S D, поворот башни - I J K L, пауза вкл/выкл Tab, ИИ вкл/выкл - P, завершить игру - Esc");
                        Console.WriteLine("     Игрок 2: Выстрел - 1, передвижение - ↑ ← ↓ →, поворот башни - 8 4 5 6, пауза вкл/выкл PageDown, ИИ вкл/выкл - 9, завершить игру - End");
                        Console.WriteLine("Правила :");
                        Console.WriteLine("     У каждого игрока по 100хп");
                        Console.WriteLine("     Один выстрел сносит 20хп");
                        Console.WriteLine("     Скорость выстрела - 1 клетка в 60мс");
                    }
                }
            } while (true);
        }
        private static void shoterX1(object obj) // перемещение снаряда 1 танка по оси X
        {
            if (shot1 == "right")
            {
                projectileX1 += 2;
                menu();
            }
            else if (shot1 == "left")
            {
                projectileX1 -= 2;
                menu();
            }
            if (projectileX1 == tankX2 & projectileY1 == tankY2)
            {
                health2 -= 20;
                shot1 = "";
                projectileX1 = tankX1;
                projectileY1 = tankY1;
                ishotting1 = false;
            }
            else if (projectileX1 > 19 || projectileX1 < 1)
            {
                shot1 = "";
                projectileX1 = tankX1;
                projectileY1 = tankY1;
                ishotting1 = false;
            }
        }
        private static void shoterY1(object obj) // перемещение снаряда 1 танка по оси Y
        {
            if (shot1 == "up")
            {
                projectileY1++;
                menu();
            }
            else if (shot1 == "down")
            {
                projectileY1--;
                menu();
            }
            if (projectileX1 == tankX2 & projectileY1 == tankY2)
            {
                health2 -= 20;
                shot1 = "";
                projectileX1 = tankX1;
                projectileY1 = tankY1;
                ishotting1 = false;
            }
            else if (projectileY1 > 10 || projectileY1 < 1)
            {
                shot1 = "";
                projectileX1 = tankX1;
                projectileY1 = tankY1;
                ishotting1 = false;
            }
        }
        private static void shoterX2(object obj) // перемещение снаряда 2 танка по оси X
        {
            if (shot2 == "right")
            {
                projectileX2 += 2;
                menu();
            }
            else if (shot2 == "left")
            {
                projectileX2 -= 2;
                menu();
            }
            if (projectileX2 == tankX1 & projectileY2 == tankY1)
            {
                health1 -= 20;
                shot2 = "";
                projectileX2 = tankX2;
                projectileY2 = tankY2;
                ishotting2 = false;
            }
            else if (projectileX2 > 19 || projectileX2 < 1)
            {
                shot2 = "";
                projectileX2 = tankX2;
                projectileY2 = tankY2;
                ishotting2 = false;
            }
        }
        private static void shoterY2(object obj) // перемещение снаряда 2 танка по оси Y
        {
            if (shot2 == "up")
            {
                projectileY2++;
                menu();
            }
            else if (shot2 == "down")
            {
                projectileY2--;
                menu();
            }
            if (projectileX2 == tankX1 & projectileY2 == tankY1)
            {
                health1 -= 20;
                shot2 = "";
                projectileX2 = tankX2;
                projectileY2 = tankY2;
                ishotting2 = false;
            }
            else if (projectileY2 > 10 || projectileY2 < 1)
            {
                shot2 = "";
                projectileX2 = tankX2;
                projectileY2 = tankY2;
                ishotting2 = false;
            }
        }
        private static void menu() // меню (графика)
        {
            line1 = "|_|_|_|_|_|_|_|_|_|_|";
            line2 = "|_|_|_|_|_|_|_|_|_|_|";
            line3 = "|_|_|_|_|_|_|_|_|_|_|";
            line4 = "|_|_|_|_|_|_|_|_|_|_|";
            line5 = "|_|_|_|_|_|_|_|_|_|_|";
            line6 = "|_|_|_|_|_|_|_|_|_|_|";
            line7 = "|_|_|_|_|_|_|_|_|_|_|";
            line8 = "|_|_|_|_|_|_|_|_|_|_|";
            line9 = "|_|_|_|_|_|_|_|_|_|_|";
            line10 = "|_|_|_|_|_|_|_|_|_|_|";
            if (direction1 == 8)
                tank1 = "↑";
            else if (direction1 == 4)
                tank1 = "←";
            else if (direction1 == 2)
                tank1 = "↓";
            else if (direction1 == 6)
                tank1 = "→";
            if (direction2 == 8)
                tank2 = "▲";
            else if (direction2 == 4)
                tank2 = "◄";
            else if (direction2 == 2)
                tank2 = "▼";
            else if (direction2 == 6)
                tank2 = "►";
            try
            {
                if (projectileX1 != tankX1 || projectileY1 != tankY1)
                {
                    switch (projectileY1)
                    {
                        case 1:
                            line10 = line10.Remove(projectileX1, 1);
                            line10 = line10.Insert(projectileX1, "*");
                            break;
                        case 2:
                            line9 = line9.Remove(projectileX1, 1);
                            line9 = line9.Insert(projectileX1, "*");
                            break;
                        case 3:
                            line8 = line8.Remove(projectileX1, 1);
                            line8 = line8.Insert(projectileX1, "*");
                            break;
                        case 4:
                            line7 = line7.Remove(projectileX1, 1);
                            line7 = line7.Insert(projectileX1, "*");
                            break;
                        case 5:
                            line6 = line6.Remove(projectileX1, 1);
                            line6 = line6.Insert(projectileX1, "*");
                            break;
                        case 6:
                            line5 = line5.Remove(projectileX1, 1);
                            line5 = line5.Insert(projectileX1, "*");
                            break;
                        case 7:
                            line4 = line4.Remove(projectileX1, 1);
                            line4 = line4.Insert(projectileX1, "*");
                            break;
                        case 8:
                            line3 = line3.Remove(projectileX1, 1);
                            line3 = line3.Insert(projectileX1, "*");
                            break;
                        case 9:
                            line2 = line2.Remove(projectileX1, 1);
                            line2 = line2.Insert(projectileX1, "*");
                            break;
                        case 10:
                            line1 = line1.Remove(projectileX1, 1);
                            line1 = line1.Insert(projectileX1, "*");
                            break;
                    }
                }
                if (projectileX2 != tankX2 || projectileY2 != tankY2)
                {
                    switch (projectileY2)
                    {
                        case 1:
                            line10 = line10.Remove(projectileX2, 1);
                            line10 = line10.Insert(projectileX2, "*");
                            break;
                        case 2:
                            line9 = line9.Remove(projectileX2, 1);
                            line9 = line9.Insert(projectileX2, "*");
                            break;
                        case 3:
                            line8 = line8.Remove(projectileX2, 1);
                            line8 = line8.Insert(projectileX2, "*");
                            break;
                        case 4:
                            line7 = line7.Remove(projectileX2, 1);
                            line7 = line7.Insert(projectileX2, "*");
                            break;
                        case 5:
                            line6 = line6.Remove(projectileX2, 1);
                            line6 = line6.Insert(projectileX2, "*");
                            break;
                        case 6:
                            line5 = line5.Remove(projectileX2, 1);
                            line5 = line5.Insert(projectileX2, "*");
                            break;
                        case 7:
                            line4 = line4.Remove(projectileX2, 1);
                            line4 = line4.Insert(projectileX2, "*");
                            break;
                        case 8:
                            line3 = line3.Remove(projectileX2, 1);
                            line3 = line3.Insert(projectileX2, "*");
                            break;
                        case 9:
                            line2 = line2.Remove(projectileX2, 1);
                            line2 = line2.Insert(projectileX2, "*");
                            break;
                        case 10:
                            line1 = line1.Remove(projectileX2, 1);
                            line1 = line1.Insert(projectileX2, "*");
                            break;
                    }
                }
            }
            catch
            {

            }
            switch (tankY1)
            {
                case 1:
                    line10 = line10.Remove(tankX1, 1);
                    line10 = line10.Insert(tankX1, tank1);
                    break;
                case 2:
                    line9 = line9.Remove(tankX1, 1);
                    line9 = line9.Insert(tankX1, tank1);
                    break;
                case 3:
                    line8 = line8.Remove(tankX1, 1);
                    line8 = line8.Insert(tankX1, tank1);
                    break;
                case 4:
                    line7 = line7.Remove(tankX1, 1);
                    line7 = line7.Insert(tankX1, tank1);
                    break;
                case 5:
                    line6 = line6.Remove(tankX1, 1);
                    line6 = line6.Insert(tankX1, tank1);
                    break;
                case 6:
                    line5 = line5.Remove(tankX1, 1);
                    line5 = line5.Insert(tankX1, tank1);
                    break;
                case 7:
                    line4 = line4.Remove(tankX1, 1);
                    line4 = line4.Insert(tankX1, tank1);
                    break;
                case 8:
                    line3 = line3.Remove(tankX1, 1);
                    line3 = line3.Insert(tankX1, tank1);
                    break;
                case 9:
                    line2 = line2.Remove(tankX1, 1);
                    line2 = line2.Insert(tankX1, tank1);
                    break;
                case 10:
                    line1 = line1.Remove(tankX1, 1);
                    line1 = line1.Insert(tankX1, tank1);
                    break;
            }
            switch (tankY2)
            {
                case 1:
                    line10 = line10.Remove(tankX2, 1);
                    line10 = line10.Insert(tankX2, tank2);
                    break;
                case 2:
                    line9 = line9.Remove(tankX2, 1);
                    line9 = line9.Insert(tankX2, tank2);
                    break;
                case 3:
                    line8 = line8.Remove(tankX2, 1);
                    line8 = line8.Insert(tankX2, tank2);
                    break;
                case 4:
                    line7 = line7.Remove(tankX2, 1);
                    line7 = line7.Insert(tankX2, tank2);
                    break;
                case 5:
                    line6 = line6.Remove(tankX2, 1);
                    line6 = line6.Insert(tankX2, tank2);
                    break;
                case 6:
                    line5 = line5.Remove(tankX2, 1);
                    line5 = line5.Insert(tankX2, tank2);
                    break;
                case 7:
                    line4 = line4.Remove(tankX2, 1);
                    line4 = line4.Insert(tankX2, tank2);
                    break;
                case 8:
                    line3 = line3.Remove(tankX2, 1);
                    line3 = line3.Insert(tankX2, tank2);
                    break;
                case 9:
                    line2 = line2.Remove(tankX2, 1);
                    line2 = line2.Insert(tankX2, tank2);
                    break;
                case 10:
                    line1 = line1.Remove(tankX2, 1);
                    line1 = line1.Insert(tankX2, tank2);
                    break;
            }
            Thread.Sleep(5); // чтобы хп сразу отнимались
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("1 танк: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(health1 + "хп, ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("второй танк: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(health2 + "хп");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(line1 + "\n" + line2 + "\n" + line3 + "\n" + line4 + "\n" + line5 + "\n" + line6 + "\n" + line7 + "\n" + line8 + "\n" + line9 + "\n" + line10);
            Thread.Sleep(60); // это чтобы всё было более-менее в норме если быстро тыкать
        }
        private static void loser() // если один из танков уничтожен
        {
            Console.ForegroundColor = ConsoleColor.Green;
            health1 = 100;
            health2 = 100;
            tankX1 = 19;
            tankY1 = 1;
            tankX2 = 1;
            tankY2 = 10;
            projectileX1 = tankX1;
            projectileY1 = tankY1;
            projectileX2 = tankX2;
            projectileY2 = tankY2;
            direction1 = 8;
            direction2 = 2;
            Console.WriteLine("Танки отремонтированы, экипажи заменены");
            Console.ForegroundColor = ConsoleColor.White;
        }
        private static void beeper() // отсчёт после паузы
        {
            time--;
            musicer();
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (time == 3)
            {
                Console.Write("3сек, ");
            }
            else if (time == 2)
            {
                Console.Write("2сек, ");
            }
            else if (time == 1)
            {
                Console.Write("1сек");
            }
            else if (time == 0)
            {
                pause = false;
                Console.WriteLine();
                Console.WriteLine("Игра возобновлена");
            }
        }
        private static void musicer() // пики при отсчёте после паузы
        {
            if (time == 3)
            {
                Console.Beep();
            }
            else if (time == 2)
            {
                Console.Beep();
            }
            else if (time == 1)
            {
                Console.Beep();
            }
            else if (time == 0)
            {
                Console.Beep();
            }
        }
        private static void aifightvstwo(object obj) // ИИ против 2 игрока
        {
            if (aifighting1 == true)
            {
                ishotting1 = true;
                if (direction1 == 8)
                    shot1 = "up";
                else if (direction1 == 4)
                    shot1 = "left";
                else if (direction1 == 2)
                    shot1 = "down";
                else if (direction1 == 6)
                    shot1 = "right";
            }

        }
        private static void aifightvsone(object obj) // ИИ против 1 игрока
        {
            if (aifighting2 == true)
            {
                ishotting2 = true;
                if (direction2 == 8)
                    shot2 = "up";
                else if (direction2 == 4)
                    shot2 = "left";
                else if (direction2 == 2)
                    shot2 = "down";
                else if (direction2 == 6)
                    shot2 = "right";
            }
        }
        private static void deather(object obj) // при уничтожении танка
        {
            if (health2 <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Танк 2 уничтожен");
                loser();
                Console.Beep();
                menu();
            }
            if (health1 <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Танк 1 уничтожен");
                loser();
                Console.Beep();
                menu();
            }
        }
    }
}
