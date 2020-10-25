using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Interpolation
{
    public static class TextBoxes
    {
        public static TextBox CreateTextBox()
        {
            var textBox = new TextBox
            {
                Width = 70,
                Height = 40,
                VerticalContentAlignment = VerticalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center,
            };
            textBox.GotFocus += (obj, eventArgs) => textBox.SelectAll();
            return textBox;
        }

        public static TextBox CreateReadOnlyTextBox()
        {
            var textBox = CreateTextBox();
            textBox.IsReadOnly = true;
            return textBox;
        }

        public static TextBox CreateDisabledTextBox()
        {
            var textBox = CreateTextBox();
            textBox.IsEnabled = false;
            textBox.Background = Brushes.Gray;
            return textBox;
        }
    }
}