using System.Net.WebSockets;

namespace LINQ
{
    internal class Program
    {
        public delegate void MyDelegate(string msg);//создание делегата
        public static void ShowMsg(string msg) { Console.WriteLine(msg); }

        public event MyDelegate onMsg;

        static void Main(string[] args)
        {
            MyDelegate del = delegate (string msg) { Console.WriteLine(msg); };
            del("Hello");

            List<Person> list = new List<Person>();

            //qwery syntax         
            var result = from x in list 
                         select x.Name;

            var result2 = from x in list
                          where x.Age>18 || x.Age<38
                          select x;

            var result3 = from x in list
                          group x by x.Name;

             //method syntax
             var result4 = list.Where(x=>x.Age>18).ToList();
             var result5 = list.Select(x=>x.Age*2).ToList();

            //OrderBy/OrderByDescending:сортирует элементы в последовательности данных
            //по возрастанию/убыванию
            //GroupBy: группирует элементы по определенному ключу
            //Distinct: удаляет дублирующие элементы изпоследовтельности данных
            //Reverce: разворачивает порядок элементов в последовательности
            //First/FirstOfDefault: возвращает первый элемент из последовательности
            //First выбросит исключение если последовательность пуста
            //FirstOfDefault вернет значение по умолчанию

           /* List<Student> students = new List<Student> 
            { new Student(){Name = "Alice",Grades=new List<int>{5,3,4}},
              new Student(){Name = "Bob",Grades=new List<int>{4,5,3}},
              new Student(){Name = "Vasily",Grades=new List<int>{2,2,5}}

            };

            var sortedList = students.OrderByDescending(student => student.Grades.Average());
            Console.WriteLine("Отсортированный список");
            foreach (var student in sortedList) Console.WriteLine($"{student.Name}:{student.Grades.Average()}");*/

            List<Order> orders = new List<Order> 
            { new Order{OrderID=1,NameClient="Vasya", products  = new List<OrderProduct>
            {
                new OrderProduct{ProductName = "Laptop",Price = 16000},
                new OrderProduct{ProductName = "Telephone",Price = 20000}
            }
            },
            new Order{OrderID=1,NameClient="Petya", products  = new List<OrderProduct>
            {
                new OrderProduct{ProductName = "Laptop",Price = 12000},
                new OrderProduct{ProductName = "Telephone",Price = 10000}
            }
            },
            new Order{OrderID=1,NameClient="Kolya", products  = new List<OrderProduct>
            {
                new OrderProduct{ProductName = "Laptop",Price = 40000},
                new OrderProduct{ProductName = "Telephone",Price = 50000}
            }
            }
            };

            var SumOrders = orders.Select(o => new { 
                OrderId = o.OrderID,
                TotalSum = o.products.Sum(p=>p.Price),
            });



            var TotalSumm = orders.SelectMany(o => o.products).Sum(p=>p.Price);

            
            var dupOrder = orders.SelectMany(o=>o.products)
                                            .GroupBy(p => p.ProductName)
                                            .Where(g=>g.Count()>1)
                                            .Select(g=>g.Key)
                                            .ToList();

            //var topSpender = orders.GroupBy(o => o.NameClient)
                                          //.Select


            var overageOrderSum = orders.Select(o => o.products.Sum(p=>p.Price)).Average();




            
            
            
            

        }
    }
}
