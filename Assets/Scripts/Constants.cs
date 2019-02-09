﻿public static class Constants
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
        new Language("guy", "", "Guy",    "Guy"),
        new Language("invocation1", "", "It's opening, it's opening!",    "Het opent, het opent!"),
        new Language("invocation2", "", "Something is coming out",        "Er komt iets uit"),
        new Language("invocation3", "", "Be ready to get her!",           "Wees klaar om haar te pakken!"),
        new Language("invocation4", "", "What was that ?",                "Wat was dat?"),
        new Language("invocation5", "", "Where is she ?",                 "Waar is ze?"),
        new Language("invocation6", "", "Search the school!",             "Doorzoek de school!"),
        new Language("invocation7", "", "(Wasn't it my sister ?)",        "(Was dat niet mijn zus?)"),
        new Language("Introducation", "", "My beloved sister... I can feel she is near... But where ?",
            "Mijn geliefde zus... Ik kan voelen dat ze in de buurt is... Maar waar?"),
        new Language("Teacher1", "", "What is it ?",                        "Wat is het?"),
        new Language("Teacher2", "", "Show yourself!",                      "Laat jezelf zien!"),
        new Language("1stYearStudent1", "", "Aaaah! A ghost! I'll go get my senpai!",
            "Aaaah! Een geest! Ik ga mijn senpai halen!"),
        new Language("1stYearStudent2", "", "She's there! She's there! Senpai, help!",
            "Ze is daar! Ze is daar! Senpai, help!"),
        new Language("2ndYearStudent1", "", "I'm gonna get you!",           "Ik ga je pakken!"),
        new Language("2ndYearStudent2", "", "You're mine now!",             "Jij bent nu van mij!"),
        new Language("3rdYearStudent1", "", "I'm gonna ban you from this world!",
            "Ik ga je van deze wereld verbannen!"),
        new Language("3rdYearStudent2", "", "Go back from where you came!", "Ga terug van waar je vandaan komt!"),
        new Language("Spirit1", "", "Let me disapear...",                   "Laat mij verdwijnen..."),
        new Language("Spirit2", "", "Why did you leave me ...?",            "Waarom heb je mij verlaten ...?"),
        new Language("DeathByTeacher", "", "My body... I feel so cold...",  "Mijn lichaam... Ik heb het zo koud..."),
        new Language("DeathByStudent", "", "I don't want to go...",         "Ik wil niet gaan..."),
        new Language("DeathBySpirit", "", "I'm full...\nI can't take it anymore...",
            "Ik ben vol...\nIk kan het niet langer volhouden..."),
        new Language("ending1", "", "Rei, is that you ?",                   "Rei, ben jij dat?"),
        new Language("ending2", "", "Sister, I miss you so much",           "Zus, Ik mis je zo erg"),
        new Language("ending3", "", "My body feels so cold, would you warm it up for me ?",
            "Mijn lichaam voelt zo koud, zou je het voor mij op willen warmen?"),
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
