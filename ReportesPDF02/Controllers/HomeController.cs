using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Layout.Properties;
using iText.Layout.Borders;
using iText.Kernel.Colors;
using ReportesPDF02.Models;
using ReportesPDF02;

namespace ReportesPDF.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Peru2()
        {
            PeruCrea("C:/temp/peru.pdf");
            return File("C:/temp/peru.pdf", "application/pdf");
        }

        public virtual void PeruCrea(string ruta)
        {
            //DaoPeru daoPeru = new DaoPeru();
            //List<departamentos> list = daoPeru.peruDepaProv();

            //PdfWriter writer = new PdfWriter(ruta);
            //PdfDocument pdf = new PdfDocument(writer);
            //Document document = new Document(pdf);
            //// ----------------------------------------------------


            //Table table2 = new Table(new float[] { 50f, 70f });
            //table2.SetWidth(UnitValue.CreatePercentValue(100));

            //table2.AddHeaderCell(new Cell()
            //    .SetBackgroundColor(new DeviceRgb(0, 140, 0))
            //    .Add(new Paragraph("Departamento").SetFontColor(new DeviceRgb(255, 255, 255))));
            //table2.AddHeaderCell(new Cell()
            //    .SetBackgroundColor(new DeviceRgb(0, 140, 0))
            //    .Add(new Paragraph("Provincia").SetFontColor(new DeviceRgb(255, 255, 255))));

            //foreach (departamentos depa in list)
            //{
            //    string d = depa.departamento;

            //    foreach (provincias prov in depa.provincias)
            //    {
            //        table2.AddCell(new Cell()
            //            .SetBorderBottom(new SolidBorder(ColorConstants.LIGHT_GRAY, 0.5F))
            //            .SetBorderRight(new SolidBorder(ColorConstants.LIGHT_GRAY, 0.5F))
            //            .Add(new Paragraph(new Text(d).SetFontSize(8))));

            //        table2.AddCell(new Cell()
            //            .SetBorderBottom(new SolidBorder(ColorConstants.LIGHT_GRAY, 0.5F))
            //            .Add(new Paragraph(new Text(prov.provincia).SetFontSize(8))));

            //        d = "";
            //    }
            //}

            DaoPeru daoPeru = new DaoPeru();
            List<departamentos> list = daoPeru.peruDepaProvDist();

            PdfWriter writer = new PdfWriter(ruta);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);
            // ----------------------------------------------------


            Table table2 = new Table(new float[] { 30f, 30f, 40f });
            table2.SetWidth(UnitValue.CreatePercentValue(100));

            table2.AddHeaderCell(new Cell()
                .SetBackgroundColor(new DeviceRgb(0, 140, 0))
                .Add(new Paragraph("Departamento").SetFontColor(new DeviceRgb(255, 255, 255))));
            table2.AddHeaderCell(new Cell()
                .SetBackgroundColor(new DeviceRgb(0, 140, 0))
                .Add(new Paragraph("Provincia").SetFontColor(new DeviceRgb(255, 255, 255))));
            table2.AddHeaderCell(new Cell()
                .SetBackgroundColor(new DeviceRgb(0, 140, 0))
                .Add(new Paragraph("Distrito").SetFontColor(new DeviceRgb(255, 255, 255))));

            foreach (departamentos depa in list)
            {
                string d = depa.departamento;

                foreach (provincias prov in depa.provincias)
                {
                    string p = prov.provincia;
                    
                    foreach(distritos dist in prov.distritos)
                    {
                        table2.AddCell(new Cell()
                        .SetBorderBottom(new SolidBorder(ColorConstants.LIGHT_GRAY, 0.5F))
                        .SetBorderRight(new SolidBorder(ColorConstants.LIGHT_GRAY, 0.5F))
                        .Add(new Paragraph(new Text(d).SetFontSize(8))));

                        table2.AddCell(new Cell()
                            .SetBorderBottom(new SolidBorder(ColorConstants.LIGHT_GRAY, 0.5F))
                            .Add(new Paragraph(new Text(p).SetFontSize(8))));

                        table2.AddCell(new Cell()
                            .SetBorderBottom(new SolidBorder(ColorConstants.LIGHT_GRAY, 0.5F))
                            .Add(new Paragraph(new Text(dist.distrito).SetFontSize(8))));

                        d = "";
                        p = "";
                    }
                }
            }

            document.Add(table2);


            // ----------------------------------------------------
            document.Close();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}