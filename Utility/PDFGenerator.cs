using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TuesPechkin;

namespace Utility
{
    public class PDFGenerator
    {
        public static void Generate(string strHtmlTemplate, string strTitle, object[] parameters, string strStorageDirectory, string strFileName)
        {
            Thread t = new Thread(() => PeformGeneratePDF(strHtmlTemplate, strTitle, parameters, strStorageDirectory, strFileName));
            t.Start();
        }
        private static void PeformGeneratePDF(string strHtmlTemplate, string strTitle, object[] parameters, string strStorageDirectory, string strFileName)
        {
            HtmlToPdfDocument document = new HtmlToPdfDocument
            {
                GlobalSettings = new GlobalSettings
                {
                    Margins = new MarginSettings
                    {
                        Left = 0,
                        Right = 0,
                        Top = 5,
                        Bottom = 0
                    },
                    ImageQuality = 100,
                    ImageDPI = 96,
                    PaperSize = PaperKind.A4,
                    DocumentTitle = strTitle
                },
                Objects =
                {
                    new ObjectSettings
                    {
                        WebSettings = new WebSettings
                        {
                            EnableJavascript = true,
                            PrintBackground = true,
                            EnableIntelligentShrinking = false
                        },
                        HtmlText  = string.Format(strHtmlTemplate, parameters)
                    }
                }
            };

            RemotingToolset<PdfToolset> remotingToolset = new RemotingToolset<PdfToolset>(new WinAnyCPUEmbeddedDeployment(new TempFolderDeployment()));

            byte[] result = (new ThreadSafeConverter(remotingToolset)).Convert(document);
            remotingToolset.Unload();

            if (!Directory.Exists(strStorageDirectory))
                Directory.CreateDirectory(strStorageDirectory);

            string strFullyNormalisedPath = Path.Combine(strStorageDirectory, new string(strFileName.Where(x => !Path.GetInvalidFileNameChars().Contains(x)).ToArray()));

            while (File.Exists(strFullyNormalisedPath))
                strFullyNormalisedPath += "_Copy";

            FileStream fsFile = new FileStream(strFullyNormalisedPath, FileMode.Create, FileAccess.Write);

            fsFile.Write(result, 0, result.Length);
            fsFile.Close();
        }
    }
}
