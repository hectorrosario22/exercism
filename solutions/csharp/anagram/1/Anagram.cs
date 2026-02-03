public class Anagram
{
    private readonly string _baseWord;
    private readonly Dictionary<char, short> _chars = new Dictionary<char, short>();
    
    public Anagram(string baseWord)
    {
        _baseWord = baseWord.ToLower();
        foreach (var character in _baseWord)
        {
            if (_chars.ContainsKey(character))
            {
                _chars[character]++;
                continue;
            }

            _chars.Add(character, 1);
        }
    }

    public string[] FindAnagrams(string[] potentialMatches)
    {
        List<string> anagrams = new List<string>();

        foreach (var potentialMatch in potentialMatches)
        {
            var loweredPotentialMatch = potentialMatch.ToLower();
            if (loweredPotentialMatch == _baseWord || loweredPotentialMatch.Length != _baseWord.Length) continue;

            var isAnagram = true;
            foreach (var item in _chars)
            {
                var count = loweredPotentialMatch.Split(item.Key).Length - 1;
                if (item.Value != count)
                {
                    isAnagram = false;
                    break;
                }
            }

            if (isAnagram)
            {
                anagrams.Add(potentialMatch);
            }
        }
        
        return anagrams.ToArray();
    }
}