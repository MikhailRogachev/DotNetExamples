using AutoMapper;
using common = AutoMapperChainedApp.Pipeline.Common.Profiles;
using commonDto = AutoMapperChainedApp.Pipeline.Common.Dto;
using nz = AutoMapperChainedApp.Pipeline.NZ.Profiles;
using us = AutoMapperChainedApp.Pipeline.US.Profiles;
using AutomapperChainedTest.Extensions;
using FluentAssertions;
using Xunit.Abstractions;
using System.Text.Json.Serialization;
using System.Text.Json;
using AutoMapperChainedApp.Models;

namespace AutomapperChainedTest
{
    public class OrderMapperTests
    {
        private readonly ITestOutputHelper _output;

        public static IMapper Mapper => new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<common.OrderProfile>();
            cfg.AddProfile<nz.NzOrderProfile>();
            cfg.AddProfile<us.UsOrderProfile>();
        }));

        public OrderMapperTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Theory]
        [InlineData("sa_order.json")]
        [InlineData("nz_order.json")]
        public void GetOrderTest(string sourceName)
        {
            var order = TestsHelper.GetOrderSource(sourceName);
            var dto = Mapper.Map<commonDto.ErpRequest>(order);

            dto.Should().NotBeNull();

            // check output
            write_dto_output(dto);
        }

        //[Theory]
        //[InlineData("sa_order.json", "SA")]
        //[InlineData("nz_order.json", "10512220")]
        //public void OrderHeader_Test(string sourceName, string expectedValue)
        //{
        //    var order = TestsHelper.GetOrderSource(sourceName);
        //    Type type = order.GetHeaderType();

        //    var dto = Mapper.Map(order, typeof(OrderHeader), type); 

        //    dto.Should().NotBeNull();
        //    dto.Should().BeAssignableTo(type);

        //    var region = dto.GetObjectValue("Region");
        //    region.Should().NotBeNull();
        //    region.ToString().Should().Be(expectedValue);

        //    var processId = dto.GetObjectValue("ResponderProcessId");
        //    processId.Should().NotBeNull();
        //    processId.ToString().Should().Be("Common " + expectedValue);

        //    // check header
        //    write_dto_output(dto);
        //}


        #region private function and methods

        private void write_dto_output(object dto)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            var json = JsonSerializer.Serialize(dto, options);

            _output.WriteLine(json);
        }

        #endregion
    }
}
