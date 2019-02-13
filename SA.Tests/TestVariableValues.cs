using SA.Common;
using SA.Common.Helpers;
using SA.Common.Models;
using SA.Utils.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace SA.Tests
{
    [TestClass]
    public class TestVariableValues : TestBase
    {
        [TestMethod]
        [TestCategory(TestCategories.VariableValues)]
        public void Can_Calculate_VariableData()
        {
            // Setup SA input
            List<Measurement> packetList = SetupMeasurementPackets();
            FileHelper.SerializeInput(SAInputFile, packetList);

            // Run calculate SA
            SAQueryRunner.Run(SAInputFile, SAOutputPath, SARunner, SAProject);
            List<TemperatureAnalysis> temperatureAnalysisList = FileHelper.DeserializeOutput<List<TemperatureAnalysis>>(SAOutputFile);

            // Asserts
            AssertPacketNumber(temperatureAnalysisList);
            AssertVariableValues(temperatureAnalysisList);
        }

        protected void AssertVariableValues(List<TemperatureAnalysis> TemperatureAnalysisList)
        {
            double increment = TemperatureConstants.Increment;
            foreach (TemperatureAnalysis TemperatureAnalysis in TemperatureAnalysisList)
            {
                Assert.IsTrue(MathHelper.DoubleAreEqual(TemperatureAnalysis.Difference, TemperatureAnalysisConstants.Difference + increment));
                increment += TemperatureConstants.Increment;
            }
        }
    }
}
