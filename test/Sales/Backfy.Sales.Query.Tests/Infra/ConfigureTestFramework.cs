using Autofac;
using Xunit;
using Xunit.Abstractions;
using Xunit.Frameworks.Autofac;

[assembly: TestFramework("Backfy.Sales.Query.Tests.Infra.ConfigureTestFramework", "Backfy.Sales.Query.Tests")]
namespace Backfy.Sales.Query.Tests.Infra
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
