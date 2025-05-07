using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text.Json.Serialization;

namespace MySuperHeroApp.Web.Model
{
    public class SuperHero
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; } = "0";

        [JsonPropertyName("name")]
        public string? Name { get; set; } = string.Empty;

        [JsonPropertyName("powerstats")]
        public PowerStats PowerStats { get; set; } = new();

        [JsonPropertyName("biography")]
        public Biography Biography { get; set; } = new();

        [JsonPropertyName("appearance")]
        public Appearance Appearance { get; set; } = new();

        [JsonPropertyName("work")]
        public Work Work { get; set; } = new();

        [JsonPropertyName("connections")]
        public Connections Connections { get; set; } = new();

        [JsonPropertyName("image")]
        public Image Image { get; set; } = new();
    }

    public class PowerStats
    {
        [JsonPropertyName("intelligence")]
        public string Intelligence { get; set; } = "0";

        [JsonPropertyName("strength")]
        public string Strength { get; set; } = "0";

        [JsonPropertyName("speed")]
        public string Speed { get; set; } = "0";

        [JsonPropertyName("durability")]
        public string Durability { get; set; } = "0";

        [JsonPropertyName("power")]
        public string Power { get; set; } = "0";

        [JsonPropertyName("combat")]
        public string Combat { get; set; } = "0";
    }

    public class Alias
    {
        public int Id { get; set; } // Primary key for EF Core
        public string Value { get; set; } = string.Empty;
    }

    public class Height
    {
        public int Id { get; set; } // Primary key for EF Core
        public string Value { get; set; } = string.Empty;
    }

    public class Weight
    {
        public int Id { get; set; } // Primary key for EF Core
        public string Value { get; set; } = string.Empty;
    }


    public class Biography
    {

        [JsonPropertyName("full-name")]
        public string FullName { get; set; } = string.Empty;

        [JsonPropertyName("alter-egos")]
        public string AlterEgos { get; set; } = string.Empty;

        [JsonPropertyName("aliases")]
        public List<string> Aliases { get; set; } = new();

        [JsonPropertyName("place-of-birth")]
        public string PlaceOfBirth { get; set; } = string.Empty;

        [JsonPropertyName("first-appearance")]
        public string FirstAppearance { get; set; } = string.Empty;

        [JsonPropertyName("publisher")]
        public string Publisher { get; set; } = string.Empty;

        [JsonPropertyName("alignment")]
        public string Alignment { get; set; } = string.Empty;
    }

    public class Appearance
    {
        [JsonPropertyName("gender")]
        public string Gender { get; set; } = string.Empty;

        [JsonPropertyName("race")]
        public string Race { get; set; } = string.Empty;

        [JsonPropertyName("height")]
        public List<string> Height { get; set; } = new();

        [JsonPropertyName("weight")]
        public List<string> Weight { get; set; } = new();

        [JsonPropertyName("eye-color")]
        public string EyeColor { get; set; } = string.Empty;

        [JsonPropertyName("hair-color")]
        public string HairColor { get; set; } = string.Empty;

    }

    public class Work
    {
        [JsonPropertyName("occupation")]
        public string Occupation { get; set; } = string.Empty;

        [JsonPropertyName("base")]
        public string BaseOfOperation { get; set; } = string.Empty;
    }

    public class Connections
    {
        [JsonPropertyName("group-affiliation")]
        public string GroupAffiliation { get; set; } = string.Empty;

        [JsonPropertyName("relatives")]
        public string Relatives { get; set; } = string.Empty;
    }

    public class Image
    {
        [JsonPropertyName("url")]
        public string? Url { get; set; } = string.Empty;

    }
}
