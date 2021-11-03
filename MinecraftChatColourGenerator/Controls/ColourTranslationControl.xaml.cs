using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MinecraftChatColourGenerator.Controls {
    /// <summary>
    /// Interaction logic for ColourTranslationControl.xaml
    /// </summary>
    public partial class ColourTranslationControl : UserControl {
        private static readonly Color DEFAULT_COLOUR = Colors.White;

        public static readonly DependencyProperty ColourNameProperty;

        public static readonly DependencyProperty CharacterProperty;

        public static readonly DependencyProperty ColourProperty;

        public static readonly DependencyProperty IsEditableProperty;

        static ColourTranslationControl() {
            ColourNameProperty = DependencyProperty.Register(
                nameof(ColourName),
                typeof(string),
                typeof(ColourTranslationControl),
                new FrameworkPropertyMetadata(
                    "Colour Name",
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    (o, e) => {
                        ((ColourTranslationControl) o).PreviewBlock.Text = (e.NewValue == null ? string.Empty : e.NewValue.ToString());
                    },
                    (o, v) => {
                        return v == null ? string.Empty : v.ToString();
                    }));

            CharacterProperty = DependencyProperty.Register(
                nameof(Character),
                typeof(string),
                typeof(ColourTranslationControl),
                new FrameworkPropertyMetadata(
                    "?",
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    (o, e) => {
                        ((ColourTranslationControl) o).ValueBox.Text = (e.NewValue == null ? "" : e.NewValue.ToString());
                    },
                    (o, v) => {
                        if (v == null) {
                            return string.Empty;
                        }

                        string value = v.ToString();
                        if (value.Length > 1) {
                            return value[0];
                        }

                        return value;
                    }));

            ColourProperty = DependencyProperty.Register(
                nameof(Colour),
                typeof(Color),
                typeof(ColourTranslationControl),
                new FrameworkPropertyMetadata(
                    Colors.White,
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | FrameworkPropertyMetadataOptions.AffectsRender,
                    (o, e) => {
                        ((ColourTranslationControl) o).ColourPreview.Fill = new SolidColorBrush((Color) (e.NewValue == null ? DEFAULT_COLOUR : e.NewValue));
                    },
                    (o, v) => {
                        return v == null ? DEFAULT_COLOUR : v;
                    }));

            IsEditableProperty = DependencyProperty.Register(
                nameof(IsEditable),
                typeof(bool),
                typeof(ColourTranslationControl),
                new FrameworkPropertyMetadata(
                    true,
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | FrameworkPropertyMetadataOptions.AffectsRender,
                    (o, e) => {
                        bool enabled = (bool) e.NewValue;
                        ((ColourTranslationControl) o).PreviewBlock.IsEnabled = enabled;
                        ((ColourTranslationControl) o).ValueBox.IsEnabled = enabled;
                        ((ColourTranslationControl) o).ColourPreview.IsEnabled = enabled;
                    }));
        }

        public string ColourName {
            get => (string) GetValue(ColourNameProperty);
            set {
                if (IsEditable) {
                    SetValue(ColourNameProperty, value);
                }
            }
        }

        public string Character {
            get => (string) GetValue(CharacterProperty);
            set {
                if (IsEditable) {
                    SetValue(CharacterProperty, value);
                }
            }
        }

        public Color Colour {
            get => (Color) GetValue(ColourProperty);
            set {
                if (IsEditable) {
                    SetValue(ColourProperty, value);
                }
            }
        }

        public bool IsEditable {
            get => (bool) GetValue(IsEditableProperty);
            set => SetValue(IsEditableProperty, value);
        }

        public ColourTranslationControl() {
            InitializeComponent();
        }

        public void ShowColourPicker() {
            System.Windows.Forms.ColorDialog dialog = new System.Windows.Forms.ColorDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                System.Drawing.Color newColour = dialog.Color;
                this.Colour = Color.FromArgb(newColour.A, newColour.R, newColour.G, newColour.B);
            }
        }

        private void ColourPreview_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e) {
            ShowColourPicker();
        }
    }
}