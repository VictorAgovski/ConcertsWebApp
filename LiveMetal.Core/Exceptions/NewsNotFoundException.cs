using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMetal.Core.Exceptions
{
    public class NewsNotFoundException : Exception
    {
        public NewsNotFoundException() { }

        public NewsNotFoundException(int newsId)
            : base($"News item not found with ID: {newsId}")
        {
        }
    }
}
