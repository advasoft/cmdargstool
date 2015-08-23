
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Advasoft.CmdArgsTool.Fakes;
using System.Diagnostics;

namespace Advasoft.CmdArgsTool.Tests
{
    [TestClass]
    public class OptionsFactoryUnitTest
    {
        [TestMethod]
        public void CreateOptionsTestMethod()
        {
            IOptionsPolicy creationPolicy = new StubIOptionsPolicy()
            {
                GetSeparateSymbol = () => { return "--"; }
            };
            ILogger logger = new StubILogger()
            {
                LogErrorException = (e) => { Trace.TraceInformation(e.Message); }
            };
            OptionsFactoryBase optionsFactory = new StubOptionsFactoryBase(creationPolicy, logger)
            {
                CreateOptionsByPolicyStringArrayIOptionsPolicy = (a,e) =>
                {
                    OptionsBase options = new StubOptionsBase();
                    return options;
                }
            };

            OptionsBase createdOptions = optionsFactory.CreateOptions(new string[] { "" });

            Assert.IsNotNull(createdOptions);
        }
    }
}
