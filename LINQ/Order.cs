using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class Order
    {   
        public int OrderID { get; set;}
        public string NameClient {  get; set;}
        public List<OrderProduct> products { get; set;}
    }
}
