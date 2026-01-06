using System.Text;
using System.Text.RegularExpressions;
namespace Core.Utilities.Slug
{
    public static class SlugHelper
    {
        public static string ToSlug(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;

            text = text.ToLowerInvariant();

            // Türkçe karakter dönüşümü
            var replacements = new Dictionary<string, string>
        {
            { "ğ", "g" }, { "ü", "u" }, { "ş", "s" },
            { "ı", "i" }, { "ö", "o" }, { "ç", "c" }
        };

            foreach (var kv in replacements)
                text = text.Replace(kv.Key, kv.Value);

            // Unicode normalize (aksan vs. temizle)
            text = text.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();

            foreach (var c in text)
            {
                if (Char.GetUnicodeCategory(c) != System.Globalization.UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            }

            text = sb.ToString().Normalize(NormalizationForm.FormC);

            // Harf & rakam dışındakileri sil
            text = Regex.Replace(text, @"[^a-z0-9]+", "-");

            // Baş / son tire temizle
            return text.Trim('-');
        }
    }

}
