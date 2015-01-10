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
using System.Globalization;

namespace TimesTables
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private int baseNumber = 2;

		public MainWindow()
		{
			InitializeComponent();
		}

		public static bool IsKeyADigit( Key key )
		{
			return ( key >= Key.D0 && key <= Key.D9 ) || ( key >= Key.NumPad0 && key <= Key.NumPad9 );
		}
		
		private void Answer_KeyDown( object sender, KeyEventArgs e )
		{
			if ( IsKeyADigit( e.Key ) )
			{
				int keyValue;

				if ( ( e.Key == Key.D1 ) || ( e.Key == Key.NumPad1 ) )
					keyValue = 1;
				else if ( ( e.Key == Key.D2 ) || ( e.Key == Key.NumPad2 ) )
					keyValue = 2;
				else if ( ( e.Key == Key.D3 ) || ( e.Key == Key.NumPad3 ) )
					keyValue = 3;
				else if ( ( e.Key == Key.D4 ) || ( e.Key == Key.NumPad4 ) )
					keyValue = 4;
				else if ( ( e.Key == Key.D5 ) || ( e.Key == Key.NumPad5 ) )
					keyValue = 5;
				else if ( ( e.Key == Key.D6 ) || ( e.Key == Key.NumPad6 ) )
					keyValue = 6;
				else if ( ( e.Key == Key.D7 ) || ( e.Key == Key.NumPad7 ) )
					keyValue = 7;
				else if ( ( e.Key == Key.D8 ) || ( e.Key == Key.NumPad8 ) )
					keyValue = 8;
				else if ( ( e.Key == Key.D9 ) || ( e.Key == Key.NumPad9 ) )
					keyValue = 9;
				else
					keyValue = 0;

				this.Answer.Content = string.Format("{0} x {1} = {2}", keyValue, baseNumber, keyValue * baseNumber);
			}
			else if ( e.Key == Key.Return )
			{
				var dlg = new BaseNumber();
				dlg.BaseNumberBox.Text = baseNumber.ToString(CultureInfo.InvariantCulture);

				dlg.ShowDialog();

				try
				{
					var newValue = int.Parse( dlg.BaseNumberBox.Text, CultureInfo.InvariantCulture );
					if ( ( newValue >= 0 ) && ( newValue <= 10 ) )
					{
						baseNumber = newValue;
					}
				}
				catch
				{
				}
			}
		}

		private void Window_KeyDown( object sender, KeyEventArgs e )
		{
			Answer_KeyDown( sender, e );
		}
	}
}
