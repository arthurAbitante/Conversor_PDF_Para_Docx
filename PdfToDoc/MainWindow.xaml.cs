using System.IO;
using System.Windows;
using System.Windows.Forms;

namespace PdfToDoc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string caminhoArquivo = caminho.Text;

            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();

            f.OpenPdf(caminhoArquivo);
            if (f.PageCount > 0)
            {
                string novoCaminhoArquivo = caminhoArquivo.Replace(".pdf", ".docx");
                int result = f.ToWord(novoCaminhoArquivo);

                if (result == 0)
                {
                    System.Diagnostics.Process.Start(novoCaminhoArquivo);
                    mensagem.Content = "Arquivo convertido com sucesso";
                }
                else
                {
                    mensagem.Content = "Erro ao converter arquivo";
                }
            }
            

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //pega o caminho para converter
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            DialogResult result = openFileDialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    string path = openFileDialog.FileName;
                    caminho.Text = path;
                }
                catch (IOException)
                {
                    mensagem.Content = "Erro ao encontrar caminho";
                }
            }
        }
    }
}
