using System.IO;
using Microsoft.AspNetCore.Mvc;
using iText.Html2pdf;
using iText.Kernel.Pdf;
using iText.Signatures;
using Org.BouncyCastle.X509;
using iText.Kernel.Exceptions;

public class HomeController : Controller
{
    [HttpPost]
    public IActionResult ExportToPdf(string htmlContent)
    {
        // Define the file path for the PDF
        string fileName = "NutritionReport.pdf";
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "pdfs", fileName);

        // Ensure the directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(filePath));

        // Convert HTML to PDF
        using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        {
            try
            {
                // Create ConverterProperties for potential signing
                ConverterProperties props = new ConverterProperties();
                // Optionally set up BouncyCastle fonts or additional properties here

                HtmlConverter.ConvertToPdf(htmlContent, fs, props);
            }
            catch (PdfException ex)
            {
                // Handle PDF generation exceptions
                return BadRequest($"PDF Generation Error: {ex.Message}");
            }
        }

        // Return the file URL for downloading
        var fileUrl = Url.Content($"~/pdfs/{fileName}");
        return Json(new { fileUrl = fileUrl });
    }

    // Optional: Add method for signing PDF if needed
    public void SignPdf(string pdfPath)
    {
        // Your signing logic here
        // Load your private key and certificate
        // Use BouncyCastle for signing if necessary
    }
}
