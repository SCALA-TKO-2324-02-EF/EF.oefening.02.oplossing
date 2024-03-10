using Microsoft.Win32;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EF.oefening._02.oplossing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.PreviewKeyDown += new KeyEventHandler(handleEsc);
        }

        private void handleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                if (MessageBox.Show("App afsluiten ?", "App afsluiten ?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    this.Close();
                }
            }
        }

        private void BtnNieuw_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPG-bestanden (*.jpg, *.jpeg)|*.jpg;*.jpeg|PNG-bestanden(*.png)|*.png";
            if (openFileDialog.ShowDialog() == true)
            {
                string pad = openFileDialog.FileName;

                // Uri fileUri = new Uri(openFileDialog.FileName);
                // imgDynamic.Source = new BitmapImage(fileUri);

                Dialoog Dlg = new Dialoog();
                Dlg.AfbPad(pad);
                Dlg.VerbergCbVerwijder();
                if (Dlg.ShowDialog() == true)
                {
                    string bijschrift = Dlg.Bijschrift();
                    Afbeelding afbeelding = null;
                    if (bijschrift.Length == 0)
                    {
                        afbeelding = new Afbeelding(pad);
                    }
                    else
                    {
                        afbeelding = new Afbeelding(pad, bijschrift);
                    }
                    LstAfbeeldingen.Items.Add(afbeelding);
                }
            }
        }

        private void LstAfbeeldingen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Afbeelding afbeelding = (Afbeelding)LstAfbeeldingen.SelectedItem;
            if (afbeelding != null)
            {
                Dialoog Dlg = new Dialoog();
                Dlg.AfbPad(afbeelding.AfbPad());
                Dlg.Bijschrift(afbeelding.TekstBijschrift());
                if (Dlg.ShowDialog() == true)
                {
                    if (Dlg.Verwijderen())
                    {
                        LstAfbeeldingen.Items.Remove(LstAfbeeldingen.SelectedItem);
                    }
                    else
                    {
                        string bijschrift = Dlg.Bijschrift();
                        afbeelding.Bijschrift(bijschrift);
                        LstAfbeeldingen.Items.Refresh();
                    }
                    LstAfbeeldingen.SelectedIndex = -1;
                }
            }
        }
    }
}