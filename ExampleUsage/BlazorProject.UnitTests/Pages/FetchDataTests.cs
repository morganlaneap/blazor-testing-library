using BlazorProject.Pages;
using BlazorProject.UnitTests.TestUtils;
using BlazorTestingLibrary;
using Bunit;
using FluentAssertions;
using RichardSzalay.MockHttp;
using Xunit;

namespace BlazorProject.UnitTests.Pages
{
    public class FetchDataTests
    {
        [Fact]
        public void ShouldRenderDataOnPageWhenReady()
        {
            using var context = new TestContext();
            var httpMock = context.Services.AddMockHttpClient();
            var testWeather = TestData.ValidWeatherForecastData;
            httpMock.When("/sample-data/weather.json").RespondJson(testWeather);
            
            var component = context.RenderComponent<FetchData>();

            component.VerifyTextExists("Loading...");
            component.WaitForElement("table");
            component.VerifyTextExists(testWeather[0].Summary);
        }
    }
}