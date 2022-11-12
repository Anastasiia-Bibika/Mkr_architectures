using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
// Варіант 1
//1 Завдання
//Патерни GoF.Паттерн проектування(GoF) - це поширене рішення певної проблеми(не певний код, а якась концепція певного рішення ) при проектуванні архітектури програм.
//Паттерни діляться на такі типи, як: породжуючі,структурні,повендікові.
//Спостерігач. Це є повендіковий шаблон проектування.
//Його основна ознака, що стан деяких об'єктів залежить від стану іншого об’єкта.
//Реалізує принцип відкритості та закритості і зменшує зв'язність коду,але недолік в тому,
//що цей шаблон порушує принцип єдиної відповідальності та можливе протякання пам'яті
//2 Завдання 
//Використати Паттерн Sinleton
namespace ConsoleMkr
{
    internal class Program
    {
        class Payment
        {
            public int id { get; set; }
            public int sumpayment { get; set; }
            public DateTime time { get; set; }

            public Payment(int id, int sumpayment, DateTime time)
            {
                this.id = id;
                this.sumpayment = sumpayment;
                this.time = time;
            }
        }
        class PaymentTracer
        {
            private static PaymentTracer _instance = null;
            private PaymentTracer()
            {
                this.payments = new List<Payment>()
                {
                     new Payment (1, 2000, DateTime.Now),
                    new Payment(2, 3500, DateTime.Now),
                    new Payment(3,6000, DateTime.Now),
                };
            }

            public static PaymentTracer getInstance()
            {
                if (_instance == null)
                {
                    _instance = new PaymentTracer();
                }
                return _instance;
            }
            public List<Payment> payments { get; set; }
            public void AddPayment(Payment payment)
            {
                this.payments.Add(payment);
            }
            public void SavePayment(string path)
            {
                using (StreamWriter stream = new StreamWriter(path))
                {
                    foreach (Payment payment in this.payments)
                    {
                        stream.WriteLine($"{payment.time} - Payment {payment.id}: {payment.sumpayment}");
                    }
                }
            }
            public void PrintPayment()
            {
                foreach (Payment payment in this.payments)
                {
                    Console.WriteLine($"{payment.time} - Payment {payment.id}: {payment.sumpayment}");
                }
                Console.WriteLine();
            }
            public void AllSumPayment()
            {
                int allsum = 0;
                foreach (Payment payment in this.payments)
                {
                    allsum += payment.sumpayment;
                    Console.WriteLine($"Сума платежів: {allsum}");
                }
                Console.WriteLine();
            }

        }
        
        static void Main(string[] args)
        {
            PaymentTracer pay1 = PaymentTracer.getInstance();
            pay1.PrintPayment();
            PaymentTracer pay2 = PaymentTracer.getInstance();
            pay2.PrintPayment();

            pay1.AddPayment(new Payment(4, 7500, DateTime.Now));
            pay1.AddPayment(new Payment(5, 3400, DateTime.Now));

            pay1.PrintPayment();
            pay2.PrintPayment();

        }
    }
}
