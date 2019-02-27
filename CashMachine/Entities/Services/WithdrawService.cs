using System.Collections.Generic;
using CashMachine.Entities.Exceptions;
using System.Text;
using System.Globalization;
using System.Linq;

namespace CashMachine.Entities.Services
{
    class WithdrawService
    {
        private List<double> list = new List<double>();
        private static HashSet<double> bills = new HashSet<double>() { 100.0, 50.0, 20.0, 10.0 };

        public WithdrawService()
        {
        }

        public void MakeWithdraw(double amount)
        {
            if ((amount % 10) != 0)
            {
                throw new WithdrawException("Unavaliable bills");
            }
            if (amount <= 0)
            {
                throw new WithdrawException("Invalid value");
            }

            BillsSeparation(amount, bills);
        }

        private void BillsSeparation(double amount, HashSet<double> bills)
        {
            foreach (double billValue in bills)
            {
                if (amount >= billValue)
                {
                    while (amount >= billValue)
                    {
                        list.Add(billValue);
                        amount -= billValue;
                    }
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder($"Bills from withdraw: [{list.First().ToString("F2", CultureInfo.InvariantCulture)}");

            list.Remove(list.First());

            foreach (double bill in list)
            {
                sb.Append($", {bill.ToString("F2", CultureInfo.InvariantCulture)}");  
            }

            sb.Append("]");

            return sb.ToString();
        }
    }
}
