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

namespace MinecraftChatColourGenerator.Controls {
    /// <summary>
    /// Interaction logic for ColourTranslationControl.xaml
    /// </summary>
    public partial class ColourTranslationControl : UserControl {
        public DependencyProperty ColourProperty =
            DependencyProperty.Register(
                "Colour", 
                typeof(Color), 
                typeof(ColourTranslationControl), 
                new FrameworkPropertyMetadata(Colors.White, FrameworkPropertyMetadataOptions.AffectsRender, (o, e) => {

                }));

        public ColourTranslationControl() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {

        }
    }
}
