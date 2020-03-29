using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspectCore.Configuration;
using AspectCore.Extensions.Autofac;
using Autofac;
using SumFramework.Cache;

namespace TestConsole
{
    class Program
    {
        private static ContainerBuilder CreateBuilder()
        {
            return new ContainerBuilder().RegisterDynamicProxy(config =>
            {
                config.Interceptors.AddDelegate(next => ctx => next(ctx), Predicates.ForNameSpace("TestConsole"));
            });
        }

        static void Main(string[] args)
        {
            var builder = CreateBuilder();
            //builder.RegisterType<Service>().As<IService>();
            //builder.RegisterType<Controller>().As<IController>();
            builder.RegisterType<Test>().As<ITest>();
            var container = builder.Build();
            var test = container.Resolve<ITest>();

            var r1 = test.Topla(5, 3);
            var r2 = test.Topla(1, 2);
            var r3 = test.Birlestir("Ahmet", "Candan");
            var r4 = test.Topla(5, 3);
            var r5 = test.Topla(Convert.ToDecimal(5), 4);


            string aa = "ahmet";
            var b1 = aa.StartsWith("[a-d]");
            aa = "candan";
            b1 = aa.StartsWith("[a-d]");
            aa = "gdvs";
            b1 = aa.StartsWith("[a-d]");



            Console.ReadLine();
        }
    }

    public interface ITest
    {
        [Cache]
        int Topla(int s1, int s2);
        [Cache]
        decimal Topla(decimal s1, decimal s2);
        [Cache]
        string Birlestir(string t1, string t2);
        [Cache]
        string Birlestir(string t1, string t2, string t3);

    }

    public class Test : ITest
    {
        public int Topla(int s1, int s2)
        {
            return s1 + s2;
        }

        public decimal Topla(decimal s1, decimal s2)
        {
            return s1 + s2;
        }

        public string Birlestir(string t1, string t2)
        {
            return t1 + t2;
        }

        public string Birlestir(string t1, string t2, string t3)
        {
            return t1 + t2 + t3;
        }
    }
}
