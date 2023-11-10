using HospitalMS.BLL.DTOs;
using iText.Html2pdf;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using RazorEngine;
using RazorEngine.Templating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMS.BLL
{
    internal class GeneratePDF
    {
        public static string RenderToString(string viewName, AppointmentDTO obj)
        {
            var razorEngineService = Engine.Razor;
            string filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\HospitalMS.BLL\\Views\\" + viewName + ".cshtml");
            var viewContent = File.ReadAllText(filePath);
            var result = razorEngineService.RunCompile(viewContent, filePath, null, obj);
            return result;
        }
        public static string RenderToString(string viewName, OPDBillAllDetailsDTO obj)
        {
            var razorEngineService = Engine.Razor;
            string filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\HospitalMS.BLL\\Views\\" + viewName + ".cshtml");
            var viewContent = File.ReadAllText(filePath);
            var result = razorEngineService.RunCompile(viewContent, filePath, null, obj);
            var showRes = result;
            if (showRes != null)
            {

            }
            return result;
        }

        public static byte[] GetPDF(string viewName, AppointmentDTO obj)
        {
            {
                var html = RenderToString(viewName, obj).ToString();
                MemoryStream ms = new MemoryStream();
                PdfDocument pdfDocument = new PdfDocument(new PdfWriter(ms));
                pdfDocument.SetDefaultPageSize(PageSize.A4);
                pdfDocument.GetDocumentInfo().SetTitle("appointment_" + obj.Id);

                ConverterProperties converterProperties = new ConverterProperties();
                HtmlConverter.ConvertToPdf(html, pdfDocument, converterProperties);

                pdfDocument.Close();
                byte[] pdfBytes = ms.ToArray();
                return pdfBytes;
            }
        }
        public static byte[] GetPDF(string viewName, OPDBillAllDetailsDTO obj)
        {
            {
                var html = RenderToString(viewName, obj).ToString();
                MemoryStream ms = new MemoryStream();
                PdfDocument pdfDocument = new PdfDocument(new PdfWriter(ms));
                pdfDocument.SetDefaultPageSize(PageSize.A4);
                pdfDocument.GetDocumentInfo().SetTitle("OPD_Bill_" + obj.OPDBillId);

                ConverterProperties converterProperties = new ConverterProperties();
                HtmlConverter.ConvertToPdf(html, pdfDocument, converterProperties);

                pdfDocument.Close();
                byte[] pdfBytes = ms.ToArray();
                return pdfBytes;
            }
        }
    }
}
