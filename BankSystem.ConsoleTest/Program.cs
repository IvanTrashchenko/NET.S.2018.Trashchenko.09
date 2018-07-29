using System;

namespace BankSystem.ConsoleTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BankAccount a = new BaseAccount(new AccountNumberGenerator(), new AccountHolder("Vanya", "Trashchenko", "first@email.com"));
            BankAccount b = new SilverAccount(new AccountNumberGenerator(), new AccountHolder("Vova", "Lenin", "second@gmail.com"));
            BankAccount c = new GoldAccount(new AccountNumberGenerator(), new AccountHolder("Sasha", "Pavlov", "third@mail.com"));
            BankAccount d = new PlatinumAccount(new AccountNumberGenerator(), new AccountHolder("Katya", "Ivanova", "forth@mmmmail.com"));

            a.Deposite(100);
            b.Deposite(100);
            c.Deposite(100);
            d.Deposite(100);

            IRepository rep = new Repository(a, b, c);

            rep.Save(d);
            rep.Delete(b);

            IService ser = new Service(rep);

            ser.OpenAccount(new AccountNumberGenerator(), new AccountHolder("Sasha", "Vrashchenko", "gg@email.com"), new GoldAccountFactory());
            ser.OpenAccount(new AccountNumberGenerator(), new AccountHolder("Dasha", "Mrashchenko", "gg@email.com"));

            // ser.Dump();

            foreach (var item in ser.Repository.Accounts)
            {
                Console.WriteLine(item.Id);
            }

            /*
             1427432362
             1292111581
             1369438661
             990816398
             746003708
            */

            ser.Deposite("746003708", 1000);
            // ser.Withdraw("990816398", 200); throws InvalidBalanceException

            ser.Transfer("746003708", "990816398", 1);

            ser.CloseAccount("1427432362");

            foreach (var item in ser.Repository.Accounts)
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadKey();
        }
    }
}