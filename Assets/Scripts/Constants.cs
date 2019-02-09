public static class Constants
{
    public static readonly Cloth SchoolSwimsuit = new Cloth("School Swimsuit", .4f);
    public static readonly Cloth Panty = new Cloth("School Swimsuit", .1f);
    public static readonly Cloth Socks = new Cloth("School Swimsuit", .1f);
    public static readonly Cloth Tights = new Cloth("School Swimsuit", .2f);
    public static readonly Cloth Skirt = new Cloth("School Swimsuit", .3f);
    public static readonly Cloth Throusers = new Cloth("School Swimsuit", .5f);
    public static readonly Cloth Vest = new Cloth("School Swimsuit", .5f);

    public static readonly Cloth[] clothes = new Cloth[]
    {
        SchoolSwimsuit, Panty, Socks, Tights, Skirt, Throusers, Vest
    };

    public struct Cloth
    {
        public Cloth(string name, float value)
        {
            Name = name;
            Value = value;
        }


        public string Name { private set; get; }
        public float Value { private set; get; }
    }

    public enum LanguageName
    {
        fr,
        en,
        nl
    }

    public static string GetLine(string key, LanguageName language)
    {
        Language? lang = System.Array.Find(lines, x => x.Key == key);
        if (lang == null)
            return ("Translation error: Key " + key + " not found.");
        return (lang.Value.GetLine(language));
    }

    static Language[] lines = new Language[]
    {
    };

    public struct Language
    {
        public Language(string key, string frenchText, string englishText, string dutchText)
        {
            Key = key;
            FrenchText = frenchText;
            EnglishText = englishText;
            DutchText = dutchText;
        }

        public string GetLine(LanguageName language)
        {
            if (language == LanguageName.en)
                return (EnglishText);
            if (language == LanguageName.fr)
                return (FrenchText);
            if (language == LanguageName.nl)
                return (DutchText);
            return (null);
        }

        public string Key { private set; get; }
        public string FrenchText { private set; get; }
        public string EnglishText { private set; get; }
        public string DutchText { private set; get; }
    }
}
