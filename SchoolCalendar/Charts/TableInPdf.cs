using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace SchoolCalendar.Charts
{
    public class TableInPdf
    {
        private string path = @"C:\Users\jacek\Pulpit";

        public void MyTable()
        {
            var doc = new Document(iTextSharp.text.PageSize.A4);
            PdfWriter.GetInstance(doc, new FileStream(path + @"\Doc.pdf", FileMode.Create));

            doc.Open();
            doc.Add(new Paragraph("mój pierwszy pdf"));
            doc.Close();
        }
    }
}