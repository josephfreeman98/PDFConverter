using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Microsoft.Win32;

//To work with word docu
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocToPDFConverter;

//to read convert and work with PDF files
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;

//for our theme
using Syncfusion.SfSkinManager;
using Syncfusion.Themes.FluentLight.WPF;

// to start a process we need the diagnostics name-space
using System.Diagnostics;

//to work with images
using System.Drawing;

//to save and read files
using System.IO;
using System.Windows;
using System.Reflection.Metadata.Ecma335;
using Syncfusion.Compression.Zip;

namespace PDFConverterSyncfusion {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {

            FluentTheme fluentTheme = new FluentTheme() {
                ThemeName = "FluentLight",
                HoverEffectMode = HoverEffect.None,
                PressedEffectMode = PressedEffect.Glow,
                ShowAcrylicBackground = false
            };

            FluentLightThemeSettings themeSettings = new FluentLightThemeSettings();
            themeSettings.BodyFontSize = 16;
            themeSettings.FontFamily = new System.Windows.Media.FontFamily("Barlow");
            SfSkinManager.RegisterThemeSettings("FluentLight", themeSettings);

            SfSkinManager.SetTheme(this, fluentTheme);



            InitializeComponent();
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e) {

            if (pathTextBox.Text == String.Empty) {
                MessageBox.Show("Please Select a File");
                return;
            }

            switch (conversionDropDown.SelectedIndex) {

                case 0:
                    //Doc to PDF
                    ConvertDocToPDF(pathTextBox.Text);
                    break;
                case 1:
                    //Pdf to doc
                    ConvertPDFToDoc(pathTextBox.Text);

                    break;
                case 2:
                    //PNG to PDF
                    ConvertPNGToPDF(pathTextBox.Text);
                    break;
                default:
                    MessageBox.Show("Please Select an option");
                    return;

            }


            OpenFolder(pathTextBox.Text);
        }

        private void ConvertDocToPDF(string docPath) {
            WordDocument wordDocument = new WordDocument(docPath, FormatType.Automatic);
            DocToPDFConverter converter = new DocToPDFConverter();
            PdfDocument pdfDocument = converter.ConvertToPDF(wordDocument);

            string newPDFPath = docPath.Split('.')[0] + ".pdf";

            pdfDocument.Save(newPDFPath);
            pdfDocument.Close(true);

            wordDocument.Close();

        }


        private void ConvertPDFToDoc(string pdfPath) {

            WordDocument wordDocument = new WordDocument();
            IWSection section = wordDocument.AddSection();

            section.PageSetup.Margins.All = 0;
            IWParagraph firsParagraph = section.AddParagraph();

            SizeF defaultPageSize = new SizeF(wordDocument.LastSection.PageSetup.PageSize.Width,
            wordDocument.LastSection.PageSetup.PageSize.Height);



            using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(pdfPath)) {

                for (int i = 0; i < loadedDocument.Pages.Count; i++) {
                    using (var image = loadedDocument.ExportAsImage(i, defaultPageSize, false)) {

                        IWPicture picture = firsParagraph.AppendPicture(image);
                        picture.Width = image.Width;
                        picture.Height = image.Height;
                    }
                }
            };

            string newPDFPath = pdfPath.Split('.')[0] + ".docx";
            wordDocument.Save(newPDFPath);
            wordDocument.Dispose();

        }



        private void ConvertPNGToPDF(string pngPath) {
            PdfDocument pdfDocument = new PdfDocument();
            PdfImage pdfImage = PdfImage.FromStream(new FileStream(pngPath, FileMode.Open));

            PdfPage pdfPage = new PdfPage();
            PdfSection pdfSection = pdfDocument.Sections.Add();

            pdfSection.Pages.Insert(0, pdfPage);

            pdfPage.Graphics.DrawImage(pdfImage, 0, 0);

            string newPngPath = pngPath.Split('.')[0] + ".pdf";

            pdfDocument.Save(newPngPath);
            pdfDocument.Close(true);


        }






        private void SelectFile_Click(object sender, RoutedEventArgs e) {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            bool? result = openFileDialog.ShowDialog();

            if (result.HasValue && result.Value) {
                pathTextBox.Text = openFileDialog.FileName;

            }

        }

        private void OpenFolder(string folderPath) {
            ProcessStartInfo startInfo = new ProcessStartInfo() {
                Arguments = folderPath.Substring(0, folderPath.LastIndexOf('\\')),
                FileName = "explorer.exe"
            };
            Process.Start(startInfo);

        }

        private void myMainWindow_SizeChanged(object sender, SizeChangedEventArgs e) {




            {
                myMainWindow.Width = e.NewSize.Width;
                myMainWindow.Height = e.NewSize.Height;

                double xChange = 1, yChange = 1;

                if (e.PreviousSize.Width != 0)
                    xChange = (e.NewSize.Width / e.PreviousSize.Width);

                if (e.PreviousSize.Height != 0)
                    yChange = (e.NewSize.Height / e.PreviousSize.Height);

                foreach (FrameworkElement fe in myGrid.Children) {
                    if (fe is Grid == false) {
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
