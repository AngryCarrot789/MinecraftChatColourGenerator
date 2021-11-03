using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace MinecraftChatColourGenerator.Controls {
    public class ColourTextBox : RichTextBox {
        private char previousChar = '0';

        protected override void OnTextChanged(TextChangedEventArgs e) {
            base.OnTextChanged(e);
        }

        protected override void OnTextInput(TextCompositionEventArgs e) {
            base.OnTextInput(e);
        }

        public void AppendColourful(string text, Color colour) {

        }
    }
}
