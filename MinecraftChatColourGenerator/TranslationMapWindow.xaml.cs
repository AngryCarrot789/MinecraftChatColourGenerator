using System.ComponentModel;
using System.Windows;

namespace MinecraftChatColourGenerator {
    /// <summary>
    /// Interaction logic for TranslationMapWindow.xaml
    /// </summary>
    public partial class TranslationMapWindow : Window {
        public TranslationMapViewModel TranslationMap {
            get => (TranslationMapViewModel) this.DataContext;
        }

        public TranslationMapWindow() {
            InitializeComponent();
            this.DataContext = new TranslationMapViewModel();
        }

        protected override void OnClosing(CancelEventArgs e) {
            e.Cancel = true;
            this.Hide();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            ColourTranslationModel model = IoC.OpenDialogCreateTranslation();
            if (model == null) {
                return;
            }

            TranslationMap.AddColourModel(model);
        }
    }
}
