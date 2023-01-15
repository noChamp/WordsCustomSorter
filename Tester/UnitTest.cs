
using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordsProcessor;

namespace Tester
{
    [TestClass]
    public class UnitTest
    {
        IWordsHandler _worker = null;
        ILifetimeScope _scope = null;

        [TestInitialize]
        public void Init()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<WordsSanitizer>().As<IWordsSanitizer>();
            builder.RegisterType<HebrewSortedWordsProcessor>().As<IWordsProcessor>();
            builder.RegisterType<WordsHandler>().As<IWordsHandler>();

            var container = builder.Build();

            _scope = container.BeginLifetimeScope();
            _worker = _scope.Resolve<IWordsHandler>();
        }

        [TestMethod]
        public void TestMethod1()
        {
            string input = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";
            string expected = "adipiscing aliqua amet do dolor dolore tempor labore Lorem magna sit sed incididunt ipsum ut consectetur et elit eiusmod";

            string output = _worker.Handle(input);

            Assert.AreEqual(expected, output);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _scope.Dispose();
        }
    }
}