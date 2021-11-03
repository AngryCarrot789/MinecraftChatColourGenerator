using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using REghZyFramework.Utilities;

namespace MinecraftChatColourGenerator {
    public class TranslationMapViewModel : BaseViewModel {
        public ObservableCollection<ColourTranslationModel> Translations { get; }

        private Dictionary<char, Color> charToColourMap;

        public TranslationMapViewModel() {
            this.Translations = new ObservableCollection<ColourTranslationModel>();
            this.charToColourMap = new Dictionary<char, Color>(32);
            AddColour("Black", '0', Colors.Black, false);
            AddColour("Blue", '1', Colors.DarkBlue, false);
            AddColour("Dark Green", '2', Colors.DarkGreen, false);
            AddColour("Dark Cyan", '3', Colors.DarkCyan, false);
            AddColour("Dark Red", '4', Colors.DarkRed, false);
            AddColour("Dark Purple", '5', Colors.MediumPurple, false);
            AddColour("Gold", '6', Colors.Gold, false);
            AddColour("Light Grey", '7', Colors.Gray, false);
            AddColour("Dark Grey", '8', Colors.DarkGray, false);
            AddColour("Light Blue", '9', Colors.Blue, false);
            AddColour("Lime", 'a', Colors.LimeGreen, false);
            AddColour("Cyan", 'b', Colors.Cyan, false);
            AddColour("Red", 'c', Colors.Red, false);
            AddColour("Purple", 'd', Colors.Purple, false);
            AddColour("Yellow", 'e', Colors.Yellow, false);
            AddColour("White", 'f', Colors.WhiteSmoke, false);
            RCSConfig config = IoC.Config;
            if (config.TryGetList("extra-colours", out List<string> values)) {
                foreach (string line in values) {
                    string[] blocks = line.Split(';');
                    if (blocks.Length != 3) {
                        continue;
                    }

                    string[] parts = blocks[2].Split(',');
                    if (parts.Length != 4) {
                        continue;
                    }

                    if (byte.TryParse(parts[0], out byte a)) {
                        if (byte.TryParse(parts[0], out byte r)) {
                            if (byte.TryParse(parts[0], out byte g)) {
                                if (byte.TryParse(parts[0], out byte b)) {
                                    AddColour(blocks[0], blocks[1] == string.Empty ? '?' : blocks[1][0], Color.FromArgb(a, r, g, b), true);
                                }
                            }
                        }
                    }
                }
            }
        }

        public void AddColour(string name, char c, Color colour, bool isEnabled = true) {
            AddColourModel(new ColourTranslationModel(name, c, colour, isEnabled));
        }

        public void AddColourModel(ColourTranslationModel model) {
            this.Translations.Add(model);
            this.charToColourMap[model.Character] = model.Colour;
        }

        public void SerialiseAllToList(List<string> list) {
            foreach (ColourTranslationModel translation in this.Translations) {
                if (translation.IsEditable) {
                    list.Add($"{translation.ColourName};{translation.Character};{translation.Colour.A},{translation.Colour.R},{translation.Colour.G},{translation.Colour.B}");
                }
            }
        }

        private static string JSubstring(string value, int startIndex, int endIndex) {
            return value.Substring(startIndex, endIndex - startIndex);
        }

        public bool TryGetColourFromChar(char c, out Color colour) {
            return this.charToColourMap.TryGetValue(c, out colour);
        }
    }
}
