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
using System.Windows.Shapes;

namespace EF.oefening._02.oplossing
{
    /// <summary>
    /// Interaction logic for Dialoog.xaml
    /// </summary>
    public partial class Dialoog : Window
    {
        public Dialoog()
        {
            InitializeComponent();
            TxtDlg.Focus();
        }

        public string Bijschrift()
        {
            return TxtDlg.Text.Trim();
        }

        public void AfbPad(string pad)
        {
            ImgDlg.Source = new BitmapImage(new Uri(pad));
        }

        public void VerbergCbVerwijder()
        {
            CbVerwijder.IsEnabled = false;
        }

        public void Bijschrift(string tekst)
        {
            TxtDlg.Text = tekst;
        }

        private void BtnDlg_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        public bool Verwijderen()
        {
            return CbVerwijder.IsChecked.Value;
        }
    }
}
