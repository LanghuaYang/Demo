using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class CheckAccount:Account
    {
        public CheckAccount() { }
        public override bool withdraw(double amt)
        {
            if (amt <= base.Balance)
                return base.withdraw(amt);
            else
                return false;
        }
    }
}
