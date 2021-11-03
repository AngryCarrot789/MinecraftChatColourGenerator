using System.Windows.Media;
using REghZyFramework.Utilities;

namespace MinecraftChatColourGenerator {
    public class ColourTranslationModel : BaseViewModel {
        private string colourName;
        private char character;
        private Color colour;
        private bool isEditable;

        public string ColourName {
            get => this.colourName;
            set => RaisePropertyChanged(ref this.colourName, value);
        }

        public char Character {
            get => this.character;
            set => RaisePropertyChanged(ref this.character, value);
        }

        public Color Colour {
            get => this.colour;
            set => RaisePropertyChanged(ref this.colour, value);
        }

        public bool IsEditable {
            get => this.isEditable;
            set => RaisePropertyChanged(ref this.isEditable, value);
        }

        public ColourTranslationModel() {
            this.ColourName = "Colour Name";
            this.Character = '?';
            this.Colour = Colors.White;
        }

        public ColourTranslationModel(string name, char character, Color colour, bool isEditable = true) {
            this.ColourName = name;
            this.Character = character;
            this.Colour = colour;
            this.IsEditable = isEditable;
        }
    }
}
