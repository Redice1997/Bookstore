using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Contractors
{
    public interface IPaymentService
    {
        string UniqueCode { get; }
        string Title { get; }
        Form CreateForm(Order order);
        Form MoveNextForm(int orderId, int step, IReadOnlyDictionary<string, string> values);
        OrderPayment GetPayment(Form form);

    }
}
