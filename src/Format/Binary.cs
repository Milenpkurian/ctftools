using System.Text;

namespace ctftools.Format;
public class Binary
{
    public static string ToText(string inputBytes)
    {
        if (inputBytes is null)
            throw new ArgumentNullException(nameof(inputBytes));

        if (string.IsNullOrWhiteSpace(inputBytes))
            return string.Empty;

        var bits = new string(inputBytes.Where(c => !char.IsWhiteSpace(c)).ToArray());

        if(bits.Length == 0)
            return string.Empty;

        if(bits.Any(c => c!='0' && c!='1'))
            throw new ArgumentException("Input string is not a valid binary string.");

        if (bits.Length % 8 != 0)
            throw new ArgumentException("Input length must be a multiple of 8 after removing whitespace.", nameof(inputBytes));

        var result = new StringBuilder(bits.Length / 8);
        for (int i = 0; i < bits.Length; i += 8)
        {
            var byteString = bits.Substring(i, 8);
            int value = Convert.ToInt32(byteString, 2);
            result.Append(Convert.ToChar(value));
        }

        return result.ToString();
    }
}
