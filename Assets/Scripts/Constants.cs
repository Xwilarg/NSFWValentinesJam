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
}
