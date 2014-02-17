using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples
{
    class Coalescing
    {
        public Coalescing()
        {
            object evaluator = null;

            // Shorthand coalsce operator
            object result = evaluator ?? new object();

            // Expands to //
            result = evaluator == null ? new object() : evaluator;
            
            // Expands to //
            if (evaluator == null)
                result = new object();
            else
                result = evaluator;

        }
    }
}
