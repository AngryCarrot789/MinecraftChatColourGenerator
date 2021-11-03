using System.Windows;
using REghZyFramework.Utilities;

namespace MinecraftChatColourGenerator {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public TranslationMapWindow TranslationMap { get; }

        public RCSConfig Config { get; }

        public MainWindow() {
            InitializeComponent();
            this.Config = new RCSConfig("config");
            this.TranslationMap = new TranslationMapWindow();
            this.DataContext = new MainViewModel(this.TranslationMap.TranslationMap);
        }

        private void ShowTranslationWindow_Click(object sender, RoutedEventArgs e) {
            this.TranslationMap.Show();
        }
    }
}
