using Autofac;
using Backfy.Albums.Repository.Interfaces;
using Xunit;
using Xunit.Abstractions;
using Xunit.Frameworks.Autofac;

[assembly: TestFramework("Backfy.Albums.Repository.Tests.Infra.ConfigureTestFramework", "Backfy.Albums.Repository.Tests")]
namespace Backfy.Albums.Repository.Tests.Infra
{
    public class ConfigureTestFramework : AutofacTestFramework
    {
        public ConfigureTestFramework(IMessageSink diagnosticMessageSink)
            : base(diagnosticMessageSink)
        {
        }

        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<GenreRepository>().As<IGenreRepository>().InstancePerTest();
        }
    }
}
