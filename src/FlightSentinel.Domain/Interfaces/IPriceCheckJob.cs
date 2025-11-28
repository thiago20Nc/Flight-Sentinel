using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSentinel.Domain.Interfaces
{
    public interface IPriceCheckJob
    {
        Task ExecuteAsync();
    }
}
