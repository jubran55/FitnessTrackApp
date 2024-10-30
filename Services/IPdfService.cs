using System.IO;
using System.Threading.Tasks;
using FitnessTrackApp.ViewModels;
using DinkToPdf;
using DinkToPdf.Contracts;

public interface IPdfService
{
    Task<Stream> GeneratePdfAsync(FoodViewModel model);
}

public class PdfService : IPdfService
{
    private readonly IConverter _converter;

    public PdfService(IConverter converter)
    {
        _converter = converter;
    }

    public async Task<Stream> GeneratePdfAsync(FoodViewModel model)
    {
        var htmlContent = GenerateHtmlContent(model);

        var doc = new HtmlToPdfDocument()
        {
            GlobalSettings = {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
            },
            Objects = {
                new ObjectSettings() {
                    PagesCount = true,
                    HtmlContent = htmlContent,
                    WebSettings = { DefaultEncoding = "utf-8" },
                    HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                    FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Footer" }
                }
            }
        };

        byte[] pdf = _converter.Convert(doc);
        MemoryStream stream = new MemoryStream(pdf);
        stream.Position = 0;

        return await Task.FromResult(stream);
    }

    private string GenerateHtmlContent(FoodViewModel model)
    {
        // Generate HTML content based on the FoodViewModel
        // This is a simple example, you can customize it as needed
        string html = @"
        <html>
        <head>
            <title>Food Report</title>
            <style>
                body { font-family: Arial, sans-serif; }
                h1 { text-align: center; }
                table { width: 100%; border-collapse: collapse; margin: 20px 0; }
                th, td { border: 1px solid #ddd; padding: 8px; text-align: left; }
                th { background-color: #f2f2f2; }
                tr:nth-child(even) { background-color: #f9f9f9; }
            </style>
        </head>
        <body>
            <h1>Food Report</h1>";

        foreach (var foodType in model.FoodTypeList)
        {
            html += $"<h2>{foodType.TypeNameEnglish}</h2>";
            html += @"
            <table>
                <thead>
                    <tr>
                        <th>Food Name</th>
                        <th>Calories</th>
                        <th>Protein</th>
                        <th>Carbohydrates</th>
                        <th>Fats</th>
                        <th>Dietary Fiber</th>
                    </tr>
                </thead>
                <tbody>";

            foreach (var nutrition in model.FoodNutritionsList)
            {
                if (nutrition.FoodTypeId == foodType.FoodTypeId)
                {
                    html += $@"
                    <tr>
                        <td>{nutrition.FoodNameEnglish}</td>
                        <td>{nutrition.Calories}</td>
                        <td>{nutrition.Protein}</td>
                        <td>{nutrition.Carbohydrates}</td>
                        <td>{nutrition.Fats}</td>
                        <td>{nutrition.DietaryFiber}</td>
                    </tr>";
                }
            }

            html += @"
                </tbody>
            </table>";
        }

        html += @"
        </body>
        </html>";

        return html;
    }
}
