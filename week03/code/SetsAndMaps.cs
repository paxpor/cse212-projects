using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
{
    // Step 1: Put all words into a HashSet for O(1) lookup
    HashSet<string> set = new HashSet<string>(words);

    // Step 2: Track words we've already used so we don't duplicate pairs
    HashSet<string> used = new HashSet<string>();

    // Step 3: Store results
    List<string> results = new List<string>();

    // Step 4: Loop through each word
    foreach (var word in words)
    {
        // Skip if already used
        if (used.Contains(word))
            continue;

        // Step 5: Reverse the word
        string reversed = new string(new char[] { word[1], word[0] });

        // Step 6: Check special case (ignore same-letter words like "aa")
        if (word[0] == word[1])
            continue;

        // Step 7: Check if reverse exists
        if (set.Contains(reversed))
        {
            results.Add($"{word} & {reversed}");
            used.Add(word);
            used.Add(reversed);
        }
    }

    return results.ToArray();
}
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            var degree = fields[3];

            if (degrees.ContainsKey(degree))
            {
                degrees[degree]++;
            }
            else
            {
                degrees[degree] = 1;
            }
                    }

                    return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
{
    word1 = word1.Replace(" ", "").ToLower();
    word2 = word2.Replace(" ", "").ToLower();

    if (word1.Length != word2.Length)
        return false;

    Dictionary<char, int> counts = new Dictionary<char, int>();

    foreach (char c in word1)
    {
        if (counts.ContainsKey(c))
            counts[c]++;
        else
            counts[c] = 1;
    }

    foreach (char c in word2)
    {
        if (!counts.ContainsKey(c))
            return false;

        counts[c]--;

        if (counts[c] < 0)
            return false;
    }

    return true;
}

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

            var results = new List<string>();

    if (featureCollection?.features != null)
    {
        foreach (var feature in featureCollection.features)
        {
            var place = feature.properties.place;
            var mag = feature.properties.mag;

            results.Add($"{place} - Mag {mag}");
        }
    }

    return results.ToArray();
    }
}