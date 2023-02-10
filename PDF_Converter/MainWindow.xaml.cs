using Microsoft.Win32;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Controls;

//to work with word files
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocToPDFConverter;

//to work with PDF files and conversion
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;

//to use downloaded theme
using Syncfusion.SfSkinManager;
using Syncfusion.Themes.FluentLight.WPF;

namespace PDF_Converter
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            FluentTheme ft = new FluentTheme()
            {
                ThemeName = "FluentLight",
                HoverEffectMode = HoverEffect.None,
                PressedEffectMode = PressedEffect.Glow,
                ShowAcrylicBackground = false
            };

            FluentLightThemeSettings themeSettings = new FluentLightThemeSettings();
            themeSettings.BodyAltFontSize = 16;
            themeSettings.FontFamily = new System.Windows.Media.FontFamily("Barlow");
            SfSkinManager.RegisterThemeSettings("FluentLight", themeSettings);
            SfSkinManager.SetTheme(this, ft);

            InitializeComponent();
        }

        private void selectFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            bool? result = ofd.ShowDialog();

            if (result.HasValue && result.Value)
                pathTextBox.Text = ofd.FileName;
        }

        private void OpenFile(string path)
        {
            ProcessStartInfo start = new ProcessStartInfo()
            {
                Arguments = path.Substring(0, path.LastIndexOf('\\')),
                FileName = "explorer.exe"
            };
            Process.Start(start);
        }

        private void convertButton_Click(object sender, RoutedEventArgs e)
        {
            if (pathTextBox.Text == string.Empty)
            {
                MessageBox.Show("Please select a file first");
                return;
            }

            switch (selectConversionComboBox.SelectedIndex)
            {
                case 0:
                    Convert_DOCtoPDF(pathTextBox.Text);
                    break;

                case 1:
                    Convert_PDFtoDOC(pathTextBox.Text);
                    break;

                case 2:
                    Convert_PNGtoPDF(pathTextBox.Text);
                    break;

                default:
                    MessageBox.Show("Please select an option");
                    return;
            }

            OpenFile(pathTextBox.Text);
        }

        private void Convert_DOCtoPDF(string docPath)
        {
            WordDocument wd = new WordDocument(docPath, FormatType.Automatic);
            DocToPDFConverter converter = new DocToPDFConverter();
            PdfDocument pdf = converter.ConvertToPDF(wd);

            string newPDF_path = docPath.Split('.')[0] + ".pdf";
            pdf.Save(newPDF_path);

            pdf.Close(true);
            wd.Close();
        }

        private void Convert_PDFtoDOC(string pdfPath)
        {
            WordDocument wd = new WordDocument();
            IWSection section = wd.AddSection();
            section.PageSetup.Margins.All = 0;
            IWParagraph firstParapraph = section.AddParagraph();

            SizeF defaultPageSize =
                new SizeF(wd.LastSection.PageSetup.PageSize.Width, wd.LastSection.PageSetup.PageSize.Height);

            using (PdfLoadedDocument loadedDOC = new PdfLoadedDocument(pdfPath))
            {
                for (int i = 0; i < loadedDOC.Pages.Count; i++)
                {
                    using (var image = loadedDOC.ExportAsImage(i, defaultPageSize, false))
                    {
                        IWPicture picture = firstParapraph.AppendPicture(image);
                        picture.Width = image.Width;
                        picture.Height = image.Height;
                    }
                }
            };

            string newPDF_path = pdfPath.Split('.')[0] + ".doc";
            wd.Save(newPDF_path);
            wd.Dispose();
        }

        private void Convert_PNGtoPDF(string pngPath)
        {
            PdfDocument pdfDoc = new PdfDocument();
            PdfImage img = PdfImage.FromStream(new FileStream(pngPath, FileMode.Open));
            PdfPage pdfPage = new PdfPage();
            PdfSection pdfSection = pdfDoc.Sections.Add();
            pdfSection.Pages.Insert(0, pdfPage);
            pdfPage.Graphics.DrawImage(img, 0, 0);

            string newPDF_path = pngPath.Split('.')[0] + ".pdf";
            pdfDoc.Save(newPDF_path);
            pdfDoc.Close(true);
        }

        private void MainWindowAutoscaling(object sender, SizeChangedEventArgs e)
        {
            {
                mainWindow.Width = e.NewSize.Width;
                mainWindow.Height = e.NewSize.Height;

                double xChange = 1, yChange = 1;

                if (e.PreviousSize.Width != 0)
                    xChange = (e.NewSize.Width / e.PreviousSize.Width);

                if (e.PreviousSize.Height != 0)
                    yChange = (e.NewSize.Height / e.PreviousSize.Height);

                foreach (FrameworkElement fe in myGrid.Children)
                {
                    if (fe is Grid == false)
                    {
                        fe.Height = fe.ActualHeight * yChange;
                        fe.Width = fe.ActualWidth * xChange;

                        Canvas.SetTop(fe, Canvas.GetTop(fe) * yChange);
                        Canvas.SetLeft(fe, Canvas.GetLeft(fe) * xChange);
                    }
                }
            }
        }
    }
}