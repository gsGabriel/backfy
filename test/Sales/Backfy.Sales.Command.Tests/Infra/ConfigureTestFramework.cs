using Autofac;
using Xunit;
using Xunit.Abstractions;
using Xunit.Frameworks.Autofac;

[assembly: TestFramework("Backfy.Sales.Command.Tests.Infra.ConfigureTestFramework", "Backfy.Sales.Command.Tests")]
namespace Backfy.Sales.Command.Tests.Infra
{
    public class ConfigureTestFramework : AutofacTestFramework
    {
        public ConfigureTestFramework(IMessageSink diagnosticMessageSink)
            : base(diagnosticMessageSink)
        {
        }

        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            
        }
    }
}
