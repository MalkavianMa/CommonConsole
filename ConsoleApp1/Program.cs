using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {

        private delegate string DelLambda();//没有参数
        private delegate void DelLambdaOne(string Param);//一个参数
        private delegate int DelLambdaTwo(int Param1, int param2);//两个参数表达多个
        static void Main(string[] args)
        {

            //PropertyInfo[] peroperties = typeof(TEST).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            //foreach (PropertyInfo property in peroperties)
            //{
            //    object[] objs = property.GetCustomAttributes(typeof(DescriptionAttribute), true);
            //    if (objs.Length > 0)
            //    {
            //        Console.WriteLine("{0}: {1}", property.Name, ((DescriptionAttribute)objs[0]).Description);
            //    }
            //}
            NoParam();
            OneParam();
            TwoParam();
            LambdaFunc();
            Console.WriteLine(LambdaAndEach());
            LambdaAndWhere();

            ParameterExpression a = Expression.Parameter(typeof(int), "a");//创建一个表达式树中的参数，作为一个节点（就是图中的a）
            ParameterExpression b = Expression.Parameter(typeof(int), "b");
            BinaryExpression ab = Expression.Multiply(a, b);//这就是图中的ab由a和b相乘得到的ab节点

            ParameterExpression c = Expression.Parameter(typeof(int), "c");
            ParameterExpression d = Expression.Parameter(typeof(int), "d");
            BinaryExpression cd = Expression.Multiply(c, d);

            BinaryExpression abcd = Expression.Multiply(ab, cd);//这是由ab和cd相乘得到目前程序中的终节点
                                                                // LambndaFc();
            Func<int, int, int, int, int> func = (p1,p2,p3,p4) => { return 0; };
            Console.WriteLine(func(1,2,2,3));
              //abcd表示操作的程序，后面的表示参数
              Expression <Func<int, int, int, int, int>> lambda = Expression.Lambda<Func<int, int, int, int, int>>(abcd, a, b, c, d);
            Console.WriteLine(lambda + "");
            //编译，生成委托
            Func<int, int, int, int, int> result = lambda.Compile();
            Console.WriteLine(result(3, 2, 2, 1));
            Console.ReadKey();
        }

        private static void LambndaFc()
        {
           
        }

        public static  void LambdaAndWhere()
        {
            List<User> Users = GetList();
            List<int> retList = CreateIisList();
            List<int> aaList = new List<int>();
            //获取所有的用户ID
            List<string> gidList = Users.Select(p => p.Gid).ToList();
            //获取所有大于6的集合
            aaList = retList.Where(p => p > 6).ToList();
            Console.WriteLine("获取所有用户ID集合{0}", string.Join(" ", gidList.ToArray()));
            Console.WriteLine("获取所有大于6的集合{0}", string.Join(" ", aaList.ToArray()));
        }

        public static List<User> GetList()
        {
            User User1 = new User() { Gid = Guid.NewGuid().ToString(), UserName = "admin", Pwd = "123456" };
            User User2 = new User() { Gid = Guid.NewGuid().ToString(), UserName = "zhangsan", Pwd = "zhangsan" };
            User User3 = new User() { Gid = Guid.NewGuid().ToString(), UserName = "lisi", Pwd = "lisi" };
            User User4 = new User() { Gid = Guid.NewGuid().ToString(), UserName = "wangwu", Pwd = "wangwu" };
            List<User> users = new List<User>();
            users.Add(User1);
            users.Add(User2);
            users.Add(User3);
            users.Add(User4);
            return users;
        }

        public static void LambdaFunc()
        {
            Func<string, string, string> getFunc = (p1, p2) =>
            {
                return p1 + "    " + p2;
            };
            Console.WriteLine(getFunc("我是第一个参数", "我是第二个参数"));
        }
        public static void TwoParam() { DelLambdaTwo delLambdaTwo = (p1, p2) => { return p1 * p2; }; Console.WriteLine("{0}",  delLambdaTwo(3, 2)); }
        public static void NoParam()
        {
            DelLambda delLambda = () =>
            {
                return "1";
            };
            Console.WriteLine("我没有参数 返回值：{0}", delLambda());

        }


        public static void OneParam()
        {
            DelLambdaOne delLambdaOne = p =>
            {
                Console.WriteLine(p);
            };
            delLambdaOne("哈哈我只有一个参数");
        }


        public static string LambdaAndEach()
        {
            List<int> retList = CreateIisList();
            StringBuilder sbBuilder = new StringBuilder();
            retList.ForEach(p =>
            {
                if (p == retList[retList.Count - 1])
                {
                    sbBuilder.Append("'" + p+"'");
                }
                else
                {
                    sbBuilder.Append("'" + p + "',");
                }
            });
            return sbBuilder.ToString();
        }

        private static List<int> CreateIisList()
        {
            List<int> r = new List<int>();
            for (int i = 0; i < 15; i++)
            {
                r.Add(i);
            }
            return r;
        }
    }

    public class User
    {
        public string Gid { get; internal set; }
        public string UserName { get; internal set; }
        public string Pwd { get; internal set; }
    }

    class TEST
    {
        [Description("代码注释")]
        public string X
        {
            get { return null; }
        }

        [Description("1")]
        public string Xy
        {
            get { return null; }
        }
    }
}
