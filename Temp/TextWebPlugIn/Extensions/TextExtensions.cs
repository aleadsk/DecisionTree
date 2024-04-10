namespace TextWebPlugIn.Extensions;

public static class TextExtensions {
    public static bool ValidateMaxLength(string text, int maxLength, out string errorMessage)   {
        if (text.Length > maxLength) {
            errorMessage = $"The text exceeds the maximum allowed length of {maxLength} characters.";
            return false;
        }

        errorMessage = string.Empty;
        return true;
    }
}