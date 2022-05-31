using AnalizerDashboard.Models;
using Bogus;

namespace AnalizerDashboard._Util
{
    public class SamplesFake
    {
        public static IEnumerable<Sample> ListOfSamples(int generateCount, Guid analistId)
        {
            var fakeSample = new Faker<Sample>("pt_PT")
                .RuleFor(c => c.Id, new Guid())
                .RuleFor(c => c.Name, f => f.Commerce.Color())
                .RuleFor(c => c.AnalistId, analistId)
                .RuleFor(c => c.Description, "New sample added")
                .RuleFor(c => c.Result, f => f.Random.Double(0, 99));

            return fakeSample.Generate(generateCount).AsEnumerable();
        }
    }
}
