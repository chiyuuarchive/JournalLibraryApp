using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace JLWPF.MVVM.Auxiliaries
{
    internal class InputFieldHandler
    {
        public const string firstNamePlaceholderMsg = "First Name (e.g. John)";
        public const string lastNamePlaceholderMsg = "Last Name (e.g. Doe)";
        public const string EmailPlaceholderMsg = "Email (e.g. john_doe@gmail.com)";
        public const string PasswordPlaceholderMsg = "Password (e.g. Abc123)";

        public enum PlaceholderMsgType
        {
            FirstName,
            LastName,
            Email,
            Password
        }

        public static void SetPlaceholderFontstyle(TextBox textBox)
        {
            textBox.FontStyle = FontStyles.Italic;
            textBox.Foreground = Brushes.Gray;
        }

        public static void SetDefaultFontstyle(TextBox textBox)
        {
            textBox.FontStyle = FontStyles.Normal;
            textBox.Foreground = Brushes.Black;
        }
    }
}