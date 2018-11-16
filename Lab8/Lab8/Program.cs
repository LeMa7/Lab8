using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab4
{
    interface IOperations<T>
    {
        void Add(T obj);
        void Delete(int num);
        void View();
    }

    class Owner
    {

        public static int id;
        public int ID;
        public string name;
        public string organization;

        public Owner()
        {
            id++;
            ID = id;
        }

        public Owner(string name, string organization) : this()
        {
            this.name = name;
            this.organization = organization;
        }

        public void OwnerInfo()
        {
            Console.WriteLine(ID);
            Console.WriteLine(name);
            Console.WriteLine(organization);
        }
    }
    public class Matrix<T> : IOperations<T> where T : struct
    {
        List<T> list = new List<T>();

        public void View()
        {
            foreach (T s in list)
            {
                Console.WriteLine(s);
            }
        }

        public void Add(T obj)
        {
            list.Add(obj);
        }

        public void Delete(int num)
        {
            list.RemoveAt(num - 1);
        }

        Owner me = new Owner("Lenya", "Lenya corp.");

        class Date
        {
            public DateTime date = new DateTime();

            public Date()
            {
                date = DateTime.Now;
            }
        }

        Date date = new Date();

        public int[,] myArr = new int[3, 3];

        public static Matrix<T> operator +(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            Matrix<T> plusResult = new Matrix<T>();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    plusResult.myArr[i, j] = matrix1.myArr[i, j] + matrix2.myArr[i, j];
                }
            }
            return plusResult;
        }

        public static Matrix<T> operator -(Matrix<T> matrix, int q)
        {
            q--;
            int i = q;
            for (int j = 0; j < 3; j++)
            {
                matrix.myArr[i, j] = 0;
            }
            return matrix;
        }

        public static bool operator <(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            bool boolResult = true;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Math.Abs(matrix1.myArr[i, j]) > Math.Abs(matrix2.myArr[i, j]))
                    {
                        boolResult = false;
                        break;
                    }

                }
            }
            return boolResult;
        }

        public static bool operator >(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            bool boolResult = true;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Math.Abs(matrix1.myArr[i, j]) < Math.Abs(matrix2.myArr[i, j]))
                    {
                        boolResult = false;
                        break;
                    }

                }
            }
            return boolResult;
        }

        public static Matrix<T> operator *(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    matrix1.myArr[i, j] = matrix2.myArr[i, j];
                }
            }
            return matrix2;
        }

        public void matrixCreation()
        {
            Random rand = new Random();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    myArr[i, j] = rand.Next(100);
                }
            }
        }

        public void info()
        {
            Console.WriteLine(date.date);
            me.OwnerInfo();
        }

        public void show()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("{0}\t", myArr[i, j]);
                }
                Console.WriteLine("\n");
            }
            Console.WriteLine("\n");
        }

        public void Save()
        {
            string str = me.name + "\t" + me.organization;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    str += "\t" + myArr[i, j];
                }
                str += "\n";
            }

            str += "\n";

            foreach (T s in list)
            {
                str += s + "\t";
            }

            File.AppendAllText(@"d:\Labs\OOP\Lab4\Lab4\file.txt", str);

        }

    }



    public static class MathOperation
    {
        public static int Max(this Matrix<int> matrix)
        {
            int maxElem = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (maxElem < matrix.myArr[i, j])
                    {
                        maxElem = matrix.myArr[i, j];
                    }
                }
                Console.WriteLine("\n");
            }
            return maxElem;
        }

        public static int Min(this Matrix<int> matrix)
        {
            int minElem = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (minElem > matrix.myArr[i, j])
                    {
                        minElem = matrix.myArr[i, j];
                    }
                }
                Console.WriteLine("\n");
            }
            return minElem;
        }

        public static int NumberOfElements(this Matrix<int> matrix)
        {
            int numberOfElements = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    numberOfElements++;
                }
                Console.WriteLine("\n");
            }
            return numberOfElements;
        }

        public static int Sum(this Matrix<int> matrix)
        {
            int sum = 0;
            for (int i = 0; i < 3; i++)
            {
                sum += matrix.myArr[i, i];
                Console.WriteLine("\n");
            }
            return sum;
        }

        public static string FindNum(this string s, string num)
        {
            if (s.IndexOf(num) > -1)
            {
                return "Такой номер есть";
            }
            else
            {
                return "Такого номера нет";
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Matrix<int> matr1 = new Matrix<int>();
            Matrix<int> matr2 = new Matrix<int>();
            Matrix<int> result = new Matrix<int>();

            matr1.info();

            matr1.matrixCreation();
            matr2.matrixCreation();

            matr1.show();
            matr2.show();

            result = matr1 + matr2;
            Console.WriteLine("Сложение матриц : ");
            result.show();

            Console.WriteLine("Убираем 1 строку");
            result = matr1 - 1;

            result.show();

            Console.WriteLine("Максимальное число : " + result.Max());
            Console.WriteLine("Минимальное число : " + result.Min());
            Console.WriteLine("Сумма главной диагонали : " + result.Sum());
            Console.WriteLine("Количество элементов : " + result.NumberOfElements());
            Console.WriteLine("\n");

            Matrix<double> matr11 = new Matrix<double>();
            Matrix<double> matr21 = new Matrix<double>();
            Matrix<double> result2 = new Matrix<double>();

            matr11.matrixCreation();
            matr21.matrixCreation();

            result2 = matr11 + matr21;
            Console.WriteLine("Сложение типов double");
            result2.show();
            Console.WriteLine();

            int k = 0;
            do
            {

                Console.WriteLine("\n\n1. Добавить элемент");
                Console.WriteLine("2. Вывести элемент");
                Console.WriteLine("3. Удалить элемент");
                Console.WriteLine("4. Сохранить объект");
                Console.Write("Выберите действие: ");
                k = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (k)
                {
                    case 1:
                        try
                        {

                            Console.Write("Введите число: ");
                            int x = int.Parse(Console.ReadLine());
                            matr1.Add(x);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        finally
                        {
                            Console.WriteLine("Операция завершена");
                        }
                        break;
                    case 2:
                        matr1.View();
                        break;
                    case 3:
                        try
                        {
                            Console.Write("Введите номер элемента который хотите удалить: ");
                            int i = int.Parse(Console.ReadLine());
                            matr1.Delete(i);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        finally
                        {
                            Console.WriteLine("Операция завершена");
                        }
                        break;
                    case 4:
                        matr1.Save();
                        break;
                }
            } while (k != 0);


        }


    }

}


