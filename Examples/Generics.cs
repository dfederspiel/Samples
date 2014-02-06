using System;
using System.Linq;

namespace Examples
{
    public class Generics<T>
    {
        protected T Context { get; set; }
        public Generics(T context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            Context = context;
        }

    }

    public class Test : Generics<Kennel>
    {
        public Test(Kennel context) : base(context)
        {
            context.AsPet(new Pet { Name = "Fido" });
        }

        public void Destroy()
        {
            Test t = new Test(Context);
        }
    }
}
