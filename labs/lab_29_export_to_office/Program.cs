using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed;
using Xceed.Words.NET;
using System.Diagnostics;

namespace lab_29_export_to_office
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = @"\RabbitReport.docx";
            string fileNameDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + fileName;
            //string fileNameDocument = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + fileName;
            //string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\RabbitReport.docx";

            var doc = DocX.Create(fileNameDesktop);

            doc.InsertParagraph("Rabbit Report");

            doc.InsertParagraph("Number of rabbits created : 1000");

            doc.InsertParagraph("Time taken :  with one loop");

            doc.Save();



            // Run word

            Process.Start("WINWORD.EXE", Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + fileName);
            
        }
    }
}
