using System.Linq;
using System.Threading.Tasks;
using App.Metrics.Facts.Fixtures;
using App.Metrics.Filtering;
using App.Metrics.Internal;
using FluentAssertions;
using Xunit;

namespace App.Metrics.Facts.Core
{
    public class MetricsContextFilteringTests : IClassFixture<MetricsWithMultipleContextsSamplesFixture>
    {
        private readonly IMetrics _metrics;

        public MetricsContextFilteringTests(MetricsWithMultipleContextsSamplesFixture fixture)
        {
            _metrics = fixture.Metrics;
        }

        [Fact]
        public void can_filter_metrics_by_context()
        {
            var filter = new DefaultMetricsFilter().WhereContext("test_context1");
            var currentData = _metrics.Snapshot.Get(filter);
            var context = currentData.Contexts.Single();

            var counterValue = context.Counters.Single();
            counterValue.Name.Should().Be("test_counter");
            counterValue.Value.Count.Should().Be(1);

            Assert.Null(context.Meters.FirstOrDefault());
            Assert.Null(context.Gauges.FirstOrDefault());
            Assert.Null(context.Histograms.FirstOrDefault());
            Assert.Null(context.Timers.FirstOrDefault());
        }

        [Fact]
        public void can_filter_metrics_by_context_via_data_provider()
        {
            var currentData = _metrics.Snapshot.GetForContext("test_context1");

            var counterValue = currentData.Counters.Single();
            counterValue.Name.Should().Be("test_counter");
            counterValue.Value.Count.Should().Be(1);

            Assert.Null(currentData.Meters.FirstOrDefault());
            Assert.Null(currentData.Gauges.FirstOrDefault());
            Assert.Null(currentData.Histograms.FirstOrDefault());
            Assert.Null(currentData.Timers.FirstOrDefault());
        }
    }
}