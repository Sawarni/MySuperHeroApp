using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text.Json.Serialization;

namespace MySuperHeroApp.Web.Model
{
    public class SuperHero
    {

        public string? Id { get; set; } = "0";


        public string? Name { get; set; } = string.Empty;


        public PowerStats PowerStats { get; set; } = new();


        public Biography Biography { get; set; } = new();


        public Appearance Appearance { get; set; } = new();


        public Work Work { get; set; } = new();


        public Connections Connections { get; set; } = new();


        public Image Image { get; set; } = new();
    }

    public class PowerStats
    {

        public string Intelligence { get; set; } = "0";


        public string Strength { get; set; } = "0";


        public string Speed { get; set; } = "0";


        public string Durability { get; set; } = "0";


        public string Power { get; set; } = "0";


        public string Combat { get; set; } = "0";
    }


    public class Biography
    {


        public string FullName { get; set; } = string.Empty;


        public string AlterEgos { get; set; } = string.Empty;


        public List<string> Aliases { get; set; } = new();


        public string PlaceOfBirth { get; set; } = string.Empty;

        public string FirstAppearance { get; set; } = string.Empty;

        public string Publisher { get; set; } = string.Empty;

        public string Alignment { get; set; } = string.Empty;
    }

    public class Appearance
    {
        public string Gender { get; set; } = string.Empty;

        public string Race { get; set; } = string.Empty;

        public List<string> Height { get; set; } = new();

        public List<string> Weight { get; set; } = new();

        public string EyeColor { get; set; } = string.Empty;

        public string HairColor { get; set; } = string.Empty;

    }

    public class Work
    {
        public string Occupation { get; set; } = string.Empty;

        public string BaseOfOperation { get; set; } = string.Empty;
    }

    public class Connections
    {
        public string GroupAffiliation { get; set; } = string.Empty;
        public string Relatives { get; set; } = string.Empty;
    }

    public class Image
    {
        public string? Url { get; set; } = string.Empty;

    }
}
