using System.Windows.Media;
using REghZyFramework.Utilities;

namespace MinecraftChatColourGenerator {
    public class MainViewModel : BaseViewModel, IColourProvider {
        private readonly TranslationMapViewModel translationMap;
        public TranslationMapViewModel TranslationMap {
            get => this.translationMap;
        }

        private char translatorChar;
        public char TranslatorChar {
            get => this.translatorChar;
            set => RaisePropertyChanged(ref this.translatorChar, value);
        }

        public MainViewModel(TranslationMapViewModel translationMap) {
            this.translationMap = translationMap;
            this.TranslatorChar = '&';
        }

        public bool IsTranslatorChar(char c) {
            return c == this.translatorChar;
        }

        public Color? GetColor(char c) {
            if (this.translationMap.TryGetColourFromChar(c, out Color colour)) {
                return colour;
            }

            return null;
        }
    }
}
