using System.Windows.Media;

namespace MinecraftChatColourGenerator {
    public interface IColourProvider {
        char TranslatorChar { get; }

        /// <summary>
        /// Returns true if the given char is the translator character
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        bool IsTranslatorChar(char c);

        /// <summary>
        /// Gets the colour associated with the given char, or <see langword="null"/> if there isn't a colour for that char
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        Color? GetColor(char c);
    }
}
