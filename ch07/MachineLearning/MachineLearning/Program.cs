//Load sample data
using MachineLearning;

var sampleData = new SampleML.ModelInput()
{
    Month = @"2-Jan",
};

//Load model and predict output
var result = SampleML.Predict(sampleData);
Console.WriteLine(result.ProductSales);
