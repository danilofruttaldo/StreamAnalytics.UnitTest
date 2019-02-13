using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SA.Common.Models;
using SA.Utils.Data;
using System.IO;

namespace SA.Tests
{
    [TestClass]
    public class TestBase
    {
        public string SARunner { get; set; }
        public string SAProject { get; set; }
        public string SAInputFile { get; set; }
        public string SAOutputPath { get; set; }
        public string SAOutputFile { get; set; }

        [TestInitialize]
        public void InizializeProperties()
        {
            string solutionPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.ToString();
            SARunner = Path.Combine(Path.Combine(Path.Combine(Path.Combine(Path.Combine(solutionPath, @"packages"), @"microsoft.azure.streamanalytics.cicd"), @"1.4.0"), @"tools"), @"SA.exe");

            string saProjectPath = Path.Combine(solutionPath, @"SA.StreamAnalytics");
            SAProject = Path.Combine(saProjectPath, @"SA.StreamAnalytics.asaproj");

            string localRunsPath = Path.Combine(solutionPath, @"SALocalRuns");
            SAInputFile = Path.Combine(localRunsPath, @"input.json");
            SAOutputPath = localRunsPath;
            SAOutputFile = Path.Combine(localRunsPath, @"output.json");
        }

        protected List<Measurement> SetupMeasurementPackets(bool hasConstantValues = false, bool hasNullValues = false)
        {
            List<Measurement> measurements = new List<Measurement>();
            double outdoorVariation = 0;

            for (int i = 0; i < GenericConstants.PacketsNumber; i++)
            {
                if (hasNullValues)
                {
                    measurements.Add(new Measurement { Indoor = null, Outdoor = null });
                }
                else
                {
                    if (!hasConstantValues)
                        outdoorVariation += TemperatureConstants.Increment;

                    measurements.Add(new Measurement
                    {
                        Indoor = TemperatureConstants.Indoor,
                        Outdoor = TemperatureConstants.Outdoor + outdoorVariation
                    });
                }
            }

            return measurements;
        }

        protected void AssertPacketNumber(List<TemperatureAnalysis> TemperatureAnalysisList)
        {
            Assert.AreEqual(TemperatureAnalysisList.Count, GenericConstants.PacketsNumber);
        }
    }
}