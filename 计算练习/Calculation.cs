using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 计算练习
{
    public class Calculation
    {
        public const string 加 = "＋";
        public const string 减 = "－";
        public const string 乘 = "×";
        public const string 除 = "÷";
        public static Random r = new Random();

        public static void 出题<T>(int count, Func<T> fn, List<T> result)
        {
            int i = 0;
            while (i++ < count)
            {
                if (fn != null) result.Add(fn.Invoke());
            }
        }

        public static void 出题<T>(int count, Func<int, T> fn, int arg, List<T> result)
        {
            int i = 0;
            while (i++ < count)
            {
                if (fn != null) result.Add(fn.Invoke(arg));
            }
        }

        public static void 出题<T>(int count, Func<int, bool, T> fn, int arg0, bool arg1, List<T> result)
        {
            int i = 0;
            while (i++ < count)
            {
                if (fn != null) result.Add(fn.Invoke(arg0, arg1));
            }
        }

        public static List<T> RandomSortList<T>(List<T> ListT)
        {
            Random random = new Random();
            List<T> newList = new List<T>();
            foreach (T item in ListT)
            {
                newList.Insert(random.Next(newList.Count + 1), item);
            }
            return newList;
        }

        public static bool IsBorrow(int n1, int n2)
        {
            string s1 = n1.ToString();
            string s2 = n2.ToString();
            while (s1.Length > 0 && s2.Length > 0)
            {
                if (s1[s1.Length - 1] < s2[s2.Length - 1]) return true;
                s1 = s1.Remove(s1.Length - 1, 1);
                s2 = s2.Remove(s2.Length - 1, 1);
            }
            return false;
        }

        public static bool IsCarry(int n1, int n2)
        {
            return IsBorrow(n1 + n2, n1);
        }

        public static string 二十以内加减法()
        {
            int n1, n2;
            if (r.Next(2) == 1)
            {
                do
                {
                    n1 = r.Next(1, 20);
                    n2 = r.Next(2, 20);
                } while (n1 + n2 > 20);
                return n1 + 加 + n2;
            }
            else
            {
                n1 = r.Next(3, 21);
                n2 = r.Next(2, n1);
                return n1 + 减 + n2;
            }
        }

        public static string 两位数加减个位()
        {
            int n1, n2;
            if (r.Next(2) == 1)
            {
                do
                {
                    n1 = r.Next(1, 10);
                    n2 = r.Next(2, 10);
                } while (n1 + n2 >= 10);
                n1 = r.Next(1, 10) * 10 + n1;
                if (r.Next(2) == 1) return n1 + 加 + n2;
                else return n2 + 加 + n1;
            }
            else
            {
                n1 = r.Next(2, 10);
                n2 = r.Next(2, n1 + 1);
                n1 = r.Next(1, 10) * 10 + n1;
                return n1 + 减 + n2;
            }
        }

        public static string 两位数加减整十()
        {
            int n1, n2;
            if (r.Next(2) == 1)
            {
                do
                {
                    n1 = r.Next(1, 10);
                    n2 = r.Next(1, 10);
                } while (n1 + n2 >= 10);
                n1 = n1 * 10 + r.Next(1, 10);
                n2 = n2 * 10;
                if (r.Next(2) == 1) return n1 + 加 + n2;
                else return n2 + 加 + n1;
            }
            else
            {
                n1 = r.Next(2, 10);
                n2 = r.Next(1, n1 + 1);
                n1 = n1 * 10 + r.Next(10);
                n2 = n2 * 10;
                return n1 + 减 + n2;
            }
        }

        public static string X以内乘法(int limit)
        {
            return r.Next(2, limit + 1) + 乘 + r.Next(2, limit + 1);
        }

        public static string X以内除法(int limit)
        {
            int n1 = r.Next(2, limit + 1);
            return n1 * r.Next(2, limit + 1) + 除 + n1;
        }

        public static string X以内加法(int limit, bool uncarry = false)
        {
            int n1 = r.Next(1, limit);
            int n2 = r.Next(1, limit - n1 + 1);
            if (uncarry)
            {
                while (IsCarry(n1, n2))
                {
                    n1 = r.Next(1, limit);
                    n2 = r.Next(1, limit - n1 + 1);
                }
            }
            return n1 + 加 + n2;
        }

        public static string 易混淆加减法(int limit)
        {
            if (r.Next(2) == 0)
                return r.Next(2, limit + 1) + 加 + r.Next(2, limit + 1);
            else
            {
                int n1 = r.Next(2, limit + 1);
                return n1 * r.Next(2, limit + 1) + 减 + n1;
            }
        }

        public static string X以内减法(int limit, bool unborrow = false)
        {
            int n1 = r.Next(2, limit + 1);
            int n2 = r.Next(1, n1);
            if (unborrow)
            {
                while (IsBorrow(n1, n2))
                {
                    n1 = r.Next(2, limit + 1);
                    n2 = r.Next(1, n1);
                }
            }
            return n1 + 减 + n2;
        }

        public static string 二千以内整百加减法()
        {
            int n1, n2;
            if (r.Next(2) == 1)
            {
                do
                {
                    n1 = r.Next(1, 20);
                    n2 = r.Next(2, 20);
                } while (n1 + n2 > 20);
                return n1 * 100 + 加 + n2 * 100;
            }
            else
            {
                n1 = r.Next(3, 21);
                n2 = r.Next(2, n1);
                return n1 * 100 + 减 + n2 * 100;
            }
        }

        public static string 两位数加减法()
        {
            int sum = r.Next(20, 101);
            int n1 = r.Next(10, sum - 10 + 1);
            if (r.Next(2) == 1)
            {
                return $"{n1} + {sum - n1}";
            }
            else
            {
                return $"{sum} - {n1}";
            }
        }

        public static string 两位数乘以一位数()
        {
            return r.Next(10, 100) + 乘 + r.Next(2, 10);
        }

        public static string 两位数除以一位数()
        {
            int n1 = r.Next(2, 10), n2;
            do
            {
                n2 = r.Next(2, 50);
            } while (n1 * n2 >= 100);
            return n1 * n2 + 除 + n1;
        }

        public static string 两位数乘除一位加减两位数()
        {
            if (r.Next(0, 2) > 0)
            {
                //加
                if (r.Next(0, 2) > 0)
                {
                    //乘
                    return 两位数乘以一位数() + 加 + r.Next(10, 100); 
                }
                else
                {
                    //除
                    return 两位数除以一位数() + 加 + r.Next(10, 100);
                }
            }
            else
            {
                //减
                if(r.Next(0, 2) > 0)
                {
                    //乘
                    int n1 = r.Next(10, 100);
                    int n2 = r.Next(2, 10);
                    return n1 + 乘 + n2 + 减 + r.Next(10, Math.Min(n1 * n2,100));
                }
                else
                {
                    //除
                    int n1 = r.Next(11, 50), n2;
                    do
                    {
                        n2 = r.Next(2, 10);
                    } while (n1 * n2 > 100);
                    return n1 * n2 + 除 + n2 + 减 + r.Next(10, n1);
                }
            }
        }

        public static string 两位数加减两位数乘除一位()
        {
            if (r.Next(0, 2) > 0)
            {
                //加
                if (r.Next(0, 2) > 0)
                {
                    //乘
                    return r.Next(10, 100) + 加 + 两位数乘以一位数();
                }
                else
                {
                    //除
                    return r.Next(10, 100) + 加 + 两位数除以一位数();
                }
            }
            else
            {
                //减
                if (r.Next(0, 2) > 0)
                {
                    //乘
                    int n1 = r.Next(2, 10), n2;
                    do n2 = r.Next(10, 50); while (n1 * n2 >= 100);
                    return r.Next(n1 * n2, 100) + 减 +  n1 + 乘 + n2;
                }
                else
                {
                    //除
                    int n1 = r.Next(11, 50), n2;
                    do
                    {
                        n2 = r.Next(2, 10);
                    } while (n1 * n2 > 100);
                    return r.Next(n1, 100) + 减 + n1 * n2 + 除 + n2;
                }
            }
        }
    }
}
