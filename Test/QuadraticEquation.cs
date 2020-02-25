using System;

namespace quadratic
{
    class QuadraticEquation
    {
        /// <summary>
        /// Вычисляет корни уравнения
        /// </summary>
        /// <param name="a">Первый параметр</param>
        /// <param name="b">Второй параметр</param>
        /// <param name="c">Третий параметр</param>
        /// <returns>Возвращает корни уравнения в виде строки</returns>
        public string CalculateResult(double a, double b, double c)
        {
            return (a, b, c) switch
            {
                (_, 0, 0) => "0",
                (0, _, 0) => "0",
                (0, 0, _) => "Нет корней",
                (0, _, _) => b != 0 ? (-c / b).ToString("0.00") : "0",
                (_, 0, _) => $"{Math.Sqrt(-c):0.00}; -{Math.Sqrt(-c):0.00}",
                (_, _, 0) => $"0; {-b / a:0.00}",
                (_, _, _) => b * b - 4 * a * c > 0
                            ? $"{ (-b + Math.Sqrt(b * b - 4 * a * c)) / (2 * a):0.00}; {(-b - Math.Sqrt(b * b - 4 * a * c)) / (2 * a):0.00}"
                            : $"{-b / (2 * a):0.00} + {Math.Sqrt(-(b * b - 4 * a * c)) / (2 * a):0.00}i; " +
                                $"{-b / (2 * a):0.00} - {(Math.Sqrt(-(b * b - 4 * a * c)) / (2 * a)):0.00}i"
            };
        }

        static void Main()
        {
            double a, b, c;
            bool repeat;
            do
            {
                Console.WriteLine("Введите a, b, c через пробел: ");
                string inputString = Console.ReadLine();

                //  Разбор строки на три параметра
                try
                {
                    double.TryParse(inputString.Substring(0, inputString.IndexOf(' ')), out a);
                    inputString = inputString.Substring(inputString.IndexOf(' ') + 1);

                    double.TryParse(inputString.Substring(0, inputString.IndexOf(' ')), out b);
                    inputString = inputString.Substring(inputString.IndexOf(' ') + 1);

                    double.TryParse(inputString, out c);
                }
                catch
                {
                    Console.WriteLine("Некорректный ввод.");
                    return;
                }

                QuadraticEquation equation = new QuadraticEquation();

                Console.WriteLine(equation.CalculateResult(a, b, c));

                Console.WriteLine("Повторить?" + Environment.NewLine + "Введите Y или N: ");
                repeat = Console.ReadLine().ToString() == "Y" ? true : false;
            } while (repeat);
        }
    }
}
