using Autofac;
using Xunit;
using Xunit.Abstractions;
using Xunit.Frameworks.Autofac;

[assembly: TestFramework("Backfy.Sales.Repository.Tests.Infra.ConfigureTestFramework", "Backfy.Sales.Repository.Tests")]
namespace Backfy.Sales.Repository.Tests.Infra
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
