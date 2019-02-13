using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SA.Utils.Data;
using SA.Common.Models;
using SA.Common.Helpers;
using SA.Common;

namespace SA.Tests
{
    [TestClass]
    public class TestConstantValues : TestBase
    {
        [TestMethod]
        [TestCategory(TestCategories.ConstantValues)]
        public void Can_Calculate_ConstantData()
        {
            // Setup SA input
            List<Measurement> packetList = SetupMeasurementPackets(true);
            FileHelper.SerializeInput(SAInputFile, packetList);

            // Run calculate SA
            SAQueryRunner.Run(SAInputFile, SAOutputPath, SARunner, SAProject);
            List<TemperatureAnalysis> temperatureAnalysisList = FileHelper.DeserializeOutput<List<TemperatureAnalysis>>(SAOutputFile);

            // Asserts
            AssertPacketNumber(temperatureAnalysisList);
            AssertConstantValues(temperatureAnalysisList);
        }

        protected void AssertConstantValues(List<TemperatureAnalysis> TemperatureAnalysisList)
        {
            foreach (TemperatureAnalysis TemperatureAnalysis in TemperatureAnalysisList)
                Assert.IsTrue(MathHelper.DoubleAreEqual(TemperatureAnalysis.Difference, TemperatureAnalysisConstants.Difference));
        }
    }
}