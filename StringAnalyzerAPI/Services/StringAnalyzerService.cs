using System.Security.Cryptography;
using System.Text;
using StringAnalyzerAPI.Models;

namespace StringAnalyzerAPI.Services
{
    public class StringAnalyzerService
    {
        private readonly List<StringRecord> _records = new();

        // 🔹 Analyze and store a new string
        public StringRecord Analyze(string value)
        {
            var id = ComputeSha256(value);
            if (_records.Any(r => r.Id == id))
                throw new InvalidOperationException("String already exists");

            var record = new StringRecord
            {
                Id = id,
                Value = value,
                Length = value.Length,
                IsPalindrome = IsPalindrome(value),
                UniqueCharacters = value.Distinct().Count(),
                WordCount = value.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length,
                CharacterFrequencyMap = value.GroupBy(c => c)
                                             .ToDictionary(g => g.Key, g => g.Count())
            };

            _records.Add(record);
            return record;
        }

        // 🔹 Get all analyzed strings
        public List<StringRecord> GetAll() => _records;

        // 🔹 Get by string value
        public StringRecord? GetByValue(string value)
        {
            var id = ComputeSha256(value);
            return _records.FirstOrDefault(r => r.Id == id);
        }

        // 🔹 Delete a string
        public bool Delete(string value)
        {
            var id = ComputeSha256(value);
            var record = _records.FirstOrDefault(r => r.Id == id);
            if (record == null) return false;
            _records.Remove(record);
            return true;
        }

        // 🔹 Helper methods
        private static string ComputeSha256(string value)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(value));
            return Convert.ToHexString(bytes);
        }

        private static bool IsPalindrome(string value)
        {
            var cleaned = new string(value.Where(char.IsLetterOrDigit)
                                          .Select(char.ToLower)
                                          .ToArray());
            return cleaned.SequenceEqual(cleaned.Reverse());
        }
    }
}
