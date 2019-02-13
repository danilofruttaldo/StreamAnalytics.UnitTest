using SA.Common;
using SA.Common.Helpers;
using SA.Common.Models;
using SA.Utils.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace SA.Tests
{
    [TestClass]
    public class TestNullValues : TestBase
    {
        [TestMethod]
        [TestCategory(TestCategories.NullValues)]
        public void Can_Calculate_NullData()
        {
            // Setup SA input
            List<Measurement> packetList = SetupMeasurementPackets(false, true);
            FileHelper.SerializeInput(SAInputFile, packetList);

            // Run calculate SA
            SAQueryRunner.Run(SAInputFile, SAOutputPath, SARunner, SAProject);
            List<TemperatureAnalysis> temperatureAnalysisList = FileHelper.DeserializeOutput<List<TemperatureAnalysis>>(SAOutputFile);

            // Asserts
            AssertPacketNumber(temperatureAnalysisList);
            AssertNullValues(temperatureAnalysisList);
        }

        protected void AssertNullValues(List<TemperatureAnalysis> TemperatureAnalysisList)
        {
            foreach (TemperatureAnalysis TemperatureAnalysis in TemperatureAnalysisList)
                Assert.IsNull(TemperatureAnalysis.Difference);
        }
    }
}
