using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using REghZyFramework.Utilities;
using Application = System.Windows.Application;

namespace MinecraftChatColourGenerator {
    // my effortless attempt at IoC
    public static class IoC {
        public static ColourTranslationModel OpenDialogCreateTranslation() {
            AddColourTranslationWindow window = new AddColourTranslationWindow {
                ColourModel = new ColourTranslationModel("Colour Name...", '?', Colors.Red)
            };

            if (window.ShowDialog() == true) {
                return window.ColourModel;
            }

            return null;
        }

        public static Color? GetColourFromDialog() {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK) {
                System.Drawing.Color newColour = dialog.Color;
                return Color.FromArgb(newColour.A, newColour.R, newColour.G, newColour.B);
            }

            return null;
        }

        public static RCSConfig Config {
            get => ((MainWindow) Application.Current.MainWindow).Config;
        }

        public static IColourProvider ColourProvider {
            get => ((MainWindow) Application.Current.MainWindow).DataContext as MainViewModel;
        }
    }
}
