using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace MinecraftChatColourGenerator {
    /// <summary>
    /// Interaction logic for AddColourTranslationWindow.xaml
    /// </summary>
    public partial class AddColourTranslationWindow : Window {
        private static readonly Color DEFAULT_COLOR = Colors.White;

        private Color colour;

        private int tabIndex = 0;

        private ColourTranslationModel colourModel;
        public ColourTranslationModel ColourModel {
            get => colourModel;
            set {
                this.colourModel = value;
                if (value != null) {
                    this.ColourName.Text = value.ColourName;
                    this.ColourChar.Text = value.Character.ToString();
                    SetColourPreviewBox(value.Colour);
                }
            }
        }

        public AddColourTranslationWindow() {
            InitializeComponent();
        }

        public void SetColourPreviewBox(Color colour) {
            SolidColorBrush brush = new SolidColorBrush(colour == null ? DEFAULT_COLOR : colour);
            this.ColourPreview1.Fill = brush;
            this.ColourPreview2.Fill = brush;
            this.colour = colour;
        }

        private void ColourPreview1_MouseDown(object sender, MouseButtonEventArgs e) {
            ShowColourPickerDialog();
        }

        private void ColourPreview2_MouseDown(object sender, MouseButtonEventArgs e) {
            ShowColourPickerDialog();
        }

        public void ShowColourPickerDialog() {
            Color? colour = IoC.GetColourFromDialog();
            if (colour != null) {
                SetColourPreviewBox((Color) colour);
            }
        }

        private void OK_Click(object sender, RoutedEventArgs e) {
            Confirm();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e) {
            Cancel();
        }

        private void Confirm() {
            string charText = this.ColourChar.Text;
            this.colourModel = new ColourTranslationModel(this.ColourName.Text, (charText == null || charText == string.Empty) ? '?' : charText[0], this.colour);
            this.DialogResult = true;
            this.Close();
        }

        private void Cancel() {
            this.colourModel = null;
            this.DialogResult = false;
            this.Close();
        }

        protected override void OnPreviewKeyDown(KeyEventArgs e) {
            if (e.Key == Key.Enter) {
                e.Handled = true;
                Confirm();
            }
            else if (e.Key == Key.Escape) {
                e.Handled = true;
                Cancel();
            }
            else if (e.Key == Key.Tab) {
                if (tabIndex == 0) {
                    this.ColourChar.Focus();
                    this.ColourChar.SelectAll();
                    this.tabIndex = 1;
                }
                else if (tabIndex == 1) {
                    this.ColourName.Focus();
                    this.ColourName.SelectAll();
                    this.tabIndex = 0;
                }
                else {
                    return;
                    // throw new System.Exception("What.....");
                }
            }
            else {
                base.OnPreviewKeyDown(e);
            }
        }
    }
}