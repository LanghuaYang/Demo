using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public delegate int delegetecompute(int x);//声明一个delegate，它是一个类

namespace WindowsFormsApplication2
{
    public class Money { 
        private double balance;
        private double interest;
        Money(){}
        Money(double bl, double it){balance = bl;interest = it;}
        public Balance{
            get{return balance;}
            set{balance = value;}
        }
        public Interest{
            get{return interest;}
            set{interest = value;}
        }
        public int add(int amt){return balance + amt;}
        public int minus(int amt){return balance - amt;}
        public int multiple(int amt){return balance + (amt*interest);}
    }
    public class Person {
        private string name;
        public Person(){}
        public Person(string n) { name = n; }
        public string Name {
            get { return name; }
            set { name = value; }
        }
    }
    public class Account
    {
        private double balance;
        internal int i;
        private Person[] relatives;
        //property
        public double Balance {
            get { return balance; }
            set { balance = value; }
        }
        //indexer
        public Person this[int index] {
            get { return relatives[index]; }
            set { relatives[index] = value; }
        }
        public Account() { relatives = new Person[100]; }
        public Account(double cal) : this() { }
        //public Account(double bal) :this() { balance = bal; }
        public virtual bool withdraw(double amt)
        {
            balance -= amt;
            return true;
        }

    }
    class test {
        Account ac;
        public test()
        {
            ac = new Account();
            ac.i = 21;
        }

    }
}

namespace testinternal {
    using WindowsFormsApplication2;
    public class teset { 
            Account ac;
            public teset()
        {
            ac = new Account();
            ac.i = 21;
        }
    }
}
