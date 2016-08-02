using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Reflection;
using System.Collections;
using System;
using System.Collections;

//namespace 迭代器Demo
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Friends friendcollection = new Friends();
//            foreach (Friend f in friendcollection)
//            {
//                Console.WriteLine(f.Name);
//            }

//            Console.Read();
//        }
//    }

//    /// <summary>
//    ///  朋友类
//    /// </summary>
//    public class Friend
//    {
//        private string name;
//        public string Name
//        {
//            get { return name; }
//            set { name = value; }
//        }
//        public Friend(string name)
//        {
//            this.name = name;
//        }
//    }

//    /// <summary>
//    ///   朋友集合
//    /// </summary>
//    public class Friends : IEnumerable
//    {
//        private Friend[] friendarray;

//        public Friends()
//        {
//            friendarray = new Friend[]
//            {
//                new Friend("张三"),
//                new Friend("李四"),
//                new Friend("王五")
//            };
//        }

//        // 索引器
//        public Friend this[int index]
//        {
//            get { return friendarray[index]; }
//        }

//        public int Count
//        {
//            get { return friendarray.Length; }
//        }

//        // 实现IEnumerable<T>接口方法
//        public IEnumerator GetEnumerator()
//        {
//            return new FriendIterator(this);
//        }
//    }

//    /// <summary>
//    ///  自定义迭代器，必须实现 IEnumerator接口
//    /// </summary>
//    public class FriendIterator : IEnumerator
//    {
//        private readonly Friends friends;
//        private int index;
//        private Friend current;
//        internal FriendIterator(Friends friendcollection)
//        {
//            this.friends = friendcollection;
//            index = 0;
//        }

//        #region 实现IEnumerator接口中的方法
//        public object Current
//        {
//            get
//            {
//                return this.current;
//            }
//        }

//        public bool MoveNext()
//        {
//            if (index + 1 > friends.Count)
//            {
//                return false;
//            }
//            else
//            {
//                this.current = friends[index];
//                index++;
//                return true;
//            }
//        }

//        public void Reset()
//        {
//            index = 0;
//        }

//        #endregion
//    }
//}
//namespace BugFixApplication
//{
//    // 一个自定义属性 BugFix 被赋给类及其成员
//    [AttributeUsage(AttributeTargets.Class |
//    AttributeTargets.Constructor |
//    AttributeTargets.Field |
//    AttributeTargets.Method |
//    AttributeTargets.Property,
//    AllowMultiple = true)]
//    public class DeBugInfo : System.Attribute
//    {
//        private int bugNo;
//        private string developer;
//        private string lastReview;
//        public string message;
//        public ArrayList mylist = new ArrayList();

//        public DeBugInfo(int bg, string dev, string d)
//        {
//            this.bugNo = bg;
//            this.developer = dev;
//            this.lastReview = d;
//        }

//        public int BugNo
//        {
//            get
//            {
//                return bugNo;
//            }
//        }
//        public string Developer
//        {
//            get
//            {
//                return developer;
//            }
//        }
//        public string LastReview
//        {
//            get
//            {
//                return lastReview;
//            }
//        }
//        public string Message
//        {
//            get
//            {
//                return message;
//            }
//            set
//            {
//                message = value;
//            }
//        }
//    }
//    [DeBugInfo(45, "Zara Ali", "12/8/2012",
//     Message = "Return type mismatch")]
//    [DeBugInfo(49, "Nuha Ali", "10/10/2012",
//     Message = "Unused variable")]
//    class Rectangle
//    {
//        // 成员变量
//        protected double length;
//        protected double width;
//        public Rectangle(double l, double w)
//        {
//            length = l;
//            width = w;
//        }
//        [DeBugInfo(55, "Zara Ali", "19/10/2012",
//         Message = "Return type mismatch")]
//        public double GetArea()
//        {
//            return length * width;
//        }
//        [DeBugInfo(56, "Zara Ali", "19/10/2012")]
//        public void Display()
//        {
//            Console.WriteLine("Length: {0}", length);
//            Console.WriteLine("Width: {0}", width);
//            Console.WriteLine("Area: {0}", GetArea());
//        }
//    }//end class Rectangle  

//    class ExecuteRectangle
//    {
//        static void Main(string[] args)
//        {
//            Rectangle r = new Rectangle(4.5, 7.5);
//            r.Display();
//            Type type = typeof(Rectangle);
//            // 遍历 Rectangle 类的属性
//            foreach (Object attributes in type.GetCustomAttributes(false))
//            {
//                DeBugInfo dbi = (DeBugInfo)attributes;
//                if (null != dbi)
//                {
//                    Console.WriteLine("Bug no: {0}", dbi.BugNo);
//                    Console.WriteLine("Developer: {0}", dbi.Developer);
//                    Console.WriteLine("Last Reviewed: {0}",
//                         dbi.LastReview);
//                    Console.WriteLine("Remarks: {0}", dbi.Message);
//                }
//            }

//            // 遍历方法属性
//            foreach (MethodInfo m in type.GetMethods())
//            {
//                foreach (Attribute a in m.GetCustomAttributes(true))
//                {
//                    DeBugInfo dbi = (DeBugInfo)a;
//                    if (null != dbi)
//                    {
//                        Console.WriteLine("Bug no: {0}, for Method: {1}",
//                              dbi.BugNo, m.Name);
//                        Console.WriteLine("Developer: {0}", dbi.Developer);
//                        Console.WriteLine("Last Reviewed: {0}",
//                              dbi.LastReview);
//                        Console.WriteLine("Remarks: {0}", dbi.Message);
//                    }
//                }
//            }
//            Console.ReadLine();
//        }
//    }
//    public interface myinterface
//    {
//        void f();
//        void f1();
//        void f2();
//    }
//    public class myclass : myinterface
//    {
//        void f() { }
//        void f1() { }
//        void f2() { }
//    }
//    public abstract class myabstractclass
//    {
//        public abstract void f();
//        public void f1(){}
//    }
//    public class tt : myabstractclass
//    {
//        public override void f()
//        {
            
//        }
//        public new void f1() { }
//    }
//    public class testinterface
//    {
//        public void f(myinterface mi)
//        { }
//        public void g()
//        {
//            myclass mc = new myclass();
//            f(mc);
//        }
//    }
//}
namespace WebApplication2.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }


        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
    //MovieDBContext类代表Entity Framework的电影数据库类，
    //这个类负责在数据库中获取，存储，更新，处理 Movie 类的实例。
    //MovieDBContext继承自Entity Framework的 DbContext基类。
    //MovieDBContext类负责处理连接到数据库，并将Movie对象映射到数据库记录的任务中
    //如何指定它将连接到数据库？在Web.config文件中，添加应用程序的连接字符串(connection string)。
    public class MovieDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        //string mystring;
        //int[] arr = new int[5];
        //int this[int index]
        //{
        //    get { return arr[index]; }
        //    set { arr[index] = value; ; }
        //}
    }
    //public class EventPublisher 
    //{
    //    public delegate void mydelegate(object sender, EventArgs e);
    //    public event mydelegate myevent;
    //    public void process()
    //    {
    //        EventArgs e = new EventArgs();
    //        OnEvent(e);
    //    }
    //    public void OnEvent(EventArgs e)
    //    {
    //        if (myevent != null)
    //        {
    //            myevent(this,e);
    //        }
    //    }
    //}
    //public class EventSubscriber1
    //{
    //    static public void HandleEvent1(object sender,EventArgs e)
    //    { 
    //    }
    //}
    //public class EventSubscriber2
    //{
    //    static public void HandleEvent2(object sender, EventArgs e)
    //    {
    //    }
    //}
    //public class programme1
    //{
    //    static void Main1()
    //    {
    //        EventPublisher ep = new EventPublisher();
    //        ep.myevent += EventSubscriber1.HandleEvent1;
    //        ep.myevent += EventSubscriber2.HandleEvent2;
    //        ep.process();
    //    }
    //}
}