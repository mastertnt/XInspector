using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using XInspector.Converters;
using XInspector.SampleModels;
using XInspector.ViewModels;

namespace XInspector.NUnit
{
    [TestFixture]
    public class ConverterTests
    {
        [SetUp]
        public void SetUp()
        {
            ConverterViewModelRegistry.Instance.FindAllConverters();
        }


        [Test]
        public void PersonTest()
        {
            List<IPropertyViewModel> lResult = new InstanceViewModelConverter().Convert(new Simple());

            // Assert
            Assert.That(lResult.Count, Is.EqualTo(3));
        }
    }
}
