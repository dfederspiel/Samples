using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples
{
    public class TestBase<T>
    {
        protected T Context { get; set; }
        public TestBase(T context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            Context = context;
        }

    }

    public class Test : TestBase<Kennel>
    {
        public Test(Kennel context)
            : base(context)
        {
            context.AsPet(new Pet { Name = "Fido" });
        }

        public void Destroy()
        {
            Test t = new Test(Context);
        }
    }
}
