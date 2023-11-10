using AutoMapper;
using HospitalMS.BLL.DTOs;
using HospitalMS.DAL;
using HospitalMS.DAL.Models;
using iText.Html2pdf;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using RazorEngine;
using RazorEngine.Templating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMS.BLL.Services
{
    public class RenderTestService
    {
        private readonly DataAccessFactory _dataAccessFactory;
        public RenderTestService(ApplicationDbContext db)
        {
            _dataAccessFactory = new DataAccessFactory(db);
        }
        public  string RenderViewToString(string viewName, RenderTestDTO obj)
        {
            obj = new RenderTestDTO()
            {
                Name = "Saikat",
                Age = 22,
                Gender = "Male"
            };
            var razorEngineService = Engine.Razor;
            string filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\BLL\\Views\\" + viewName + ".cshtml");
            var viewContent = File.ReadAllText(filePath);

            var result = razorEngineService.RunCompile(viewContent, filePath, null, obj);

            return result;
        }
        public  byte[] GetPDF(string title)
        {
            {
                var obj = new RenderTestDTO();
                // Render the view to a string
                var html = RenderViewToString("TestView", obj).ToString();

                // Create a PDF document
                //using (var pdfStream = new MemoryStream())
                //{
                //    var writer = new PdfWriter(pdfStream);
                //    var pdf = new PdfDocument(writer);

                //    // Convert HTML to PDF using pdfHTML
                //    ConverterProperties converterProperties = new ConverterProperties();
                //    HtmlConverter.ConvertToPdf(html, pdf, converterProperties);

                //    pdf.Close();
                //    writer.Close();
                //    return pdfStream;
                //    // Return the PDF as a file download
                //    //return File(pdfStream.ToArray(), "application/pdf", "MyPDF.pdf");
                //}

                MemoryStream ms = new MemoryStream();
                //PdfWriter writer = new PdfWriter(ms);
                PdfDocument pdfDocument = new PdfDocument(new PdfWriter(ms));
                pdfDocument.SetDefaultPageSize(PageSize.A4);
                pdfDocument.GetDocumentInfo().SetTitle(title);

                //PageSize pageSize = PageSize.A4;
                ConverterProperties converterProperties = new ConverterProperties();
                HtmlConverter.ConvertToPdf(html, pdfDocument, converterProperties);

                // Create a new PdfWriter object, passing the MemoryStream as a parameter
                //  PdfWriter writer = new PdfWriter(ms, new WriterProperties().SetMediaSize(pageSize));
                // PdfDocument pdf = new PdfDocument(writer).SetDefaultPageSize(pageSize);
                //  PdfDocument pdfDocument = new PdfDocument(new PdfWriter(ms));
                // pdfDocument.SetDefaultPageSize(PageSize.A3);
                // Create a new HtmlConverter object and call its ConvertToPdf method, passing in the HTML string and the PdfWriter object

                // Close the PdfWriter object
                pdfDocument.Close();

                // Get the bytes from the MemoryStream
                byte[] pdfBytes = ms.ToArray();
                return pdfBytes;


            }
        }
    }


}
//MemoryStream ms = new MemoryStream();
//PdfWriter writer = new PdfWriter(ms);
//HtmlConverter.ConvertToPdf(html, writer);
//writer.Close();
