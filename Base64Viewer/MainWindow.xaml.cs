using System;
using System.Collections.Generic;
using System.IO;
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

namespace Base64Viewer
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

    bool DecodeAsFloat;

    private void InputBox_TextChanged(object sender, TextChangedEventArgs e)
    {
      Decode();
    }

    private void Window_Activated_1(object sender, EventArgs e)
    {
      InputBox.Text = Clipboard.GetText();
    }

    private void DecodeAsFloatCheckBox_Click_1(object sender, RoutedEventArgs e)
    {
      DecodeAsFloat = DecodeAsFloatCheckBox.IsChecked.Value;
      Decode();
    }

    void Decode()
    {
      try
      {
        var ms = new MemoryStream(Convert.FromBase64String(InputBox.Text.Trim()));
        var br = new BinaryReader(ms);
        var sb = new StringBuilder();
        int i = 0;
        while (ms.Position < ms.Length)
        {
          sb.AppendFormat("[{0}]     {1}\n", i, DecodeAsFloat ? br.ReadSingle() : br.ReadDouble());
          i++;
        }
        OutputBox.Text = sb.ToString();
      }
      catch (Exception)
      {
        OutputBox.Text = "ERROR";
      }
    }
  }
}
