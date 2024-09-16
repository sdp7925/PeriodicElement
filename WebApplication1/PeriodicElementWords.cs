using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1
{
    public static class PeriodicElementWords
    {
        public static readonly Dictionary<string, string> Elements = new Dictionary<string, string>
    {
        {"H", "Hydrogen"}, {"He", "Helium"}, {"Li", "Lithium"}, {"Be", "Beryllium"}, {"B", "Boron"},
        {"C", "Carbon"}, {"N", "Nitrogen"}, {"O", "Oxygen"}, {"F", "Fluorine"}, {"Ne", "Neon"},
        {"Na", "Sodium"}, {"Mg", "Magnesium"}, {"Al", "Aluminum"}, {"Si", "Silicon"}, {"P", "Phosphorus"},
        {"S", "Sulfur"}, {"Cl", "Chlorine"}, {"K", "Potassium"}, {"Ca", "Calcium"}, {"Sc", "Scandium"},
        {"Ti", "Titanium"}, {"V", "Vanadium"}, {"Cr", "Chromium"}, {"Mn", "Manganese"}, {"Fe", "Iron"},
        {"Co", "Cobalt"}, {"Ni", "Nickel"}, {"Cu", "Copper"}, {"Zn", "Zinc"}, {"Ga", "Gallium"},
        {"Ge", "Germanium"}, {"As", "Arsenic"}, {"Se", "Selenium"}, {"Br", "Bromine"}, {"Kr", "Krypton"},
        {"Rb", "Rubidium"}, {"Sr", "Strontium"}, {"Y", "Yttrium"}, {"Zr", "Zirconium"}, {"Nb", "Niobium"},
        {"Mo", "Molybdenum"}, {"Tc", "Technetium"}, {"Ru", "Ruthenium"}, {"Rh", "Rhodium"}, {"Pd", "Palladium"},
        {"Ag", "Silver"}, {"Cd", "Cadmium"}, {"In", "Indium"}, {"Sn", "Tin"}, {"Sb", "Antimony"},
        {"Te", "Tellurium"}, {"I", "Iodine"}, {"Xe", "Xenon"}, {"Cs", "Cesium"}, {"Ba", "Barium"},
        {"La", "Lanthanum"}, {"Ce", "Cerium"}, {"Pr", "Praseodymium"}, {"Nd", "Neodymium"}, {"Pm", "Promethium"},
        {"Sm", "Samarium"}, {"Eu", "Europium"}, {"Gd", "Gadolinium"}, {"Tb", "Terbium"}, {"Dy", "Dysprosium"},
        {"Ho", "Holmium"}, {"Er", "Erbium"}, {"Tm", "Thulium"}, {"Yb", "Ytterbium"}, {"Lu", "Lutetium"},
        {"Hf", "Hafnium"}, {"Ta", "Tantalum"}, {"W", "Tungsten"}, {"Re", "Rhenium"}, {"Os", "Osmium"},
        {"Ir", "Iridium"}, {"Pt", "Platinum"}, {"Au", "Gold"}, {"Hg", "Mercury"}, {"Tl", "Thallium"},
        {"Pb", "Lead"}, {"Bi", "Bismuth"}, {"Po", "Polonium"}, {"At", "Astatine"}, {"Rn", "Radon"},
        {"Fr", "Francium"}, {"Ra", "Radium"}, {"Ac", "Actinium"}, {"Th", "Thorium"}, {"Pa", "Protactinium"},
        {"U", "Uranium"}, {"Np", "Neptunium"}, {"Pu", "Plutonium"}, {"Am", "Americium"}, {"Cm", "Curium"},
        {"Bk", "Berkelium"}, {"Cf", "Californium"}, {"Es", "Einsteinium"}, {"Fm", "Fermium"}, {"Md", "Mendelevium"},
        {"No", "Nobelium"}, {"Lr", "Lawrencium"}, {"Rf", "Rutherfordium"}, {"Db", "Dubnium"}, {"Sg", "Seaborgium"},
        {"Bh", "Bohrium"}, {"Hs", "Hassium"}, {"Mt", "Meitnerium"}, {"Ds", "Darmstadtium"}, {"Rg", "Roentgenium"},
        {"Cn", "Copernicium"}, {"Nh", "Nihonium"}, {"Fl", "Flerovium"}, {"Mc", "Moscovium"}, {"Lv", "Livermorium"},
        {"Ts", "Tennessine"}, {"Og", "Oganesson"}
    };

        public static List<List<string>> Form(string word)
        {
            if (string.IsNullOrEmpty(word)) return new List<List<string>>(); 

            List<List<string>> forms = new List<List<string>>();
            FindForms(word.ToLower(), new List<string>(), forms);
            return forms;
        }

        private static void FindForms(string word, List<string> currentForm, List<List<string>> forms)
        {
            if (word == "")
            {
                forms.Add(new List<string>(currentForm));
                return;
            }

            for (int i = 1; i <= 3 && i <= word.Length; i++)
            {
                string symbol = word.Substring(0, i);
                string format = symbol.First().ToString().ToUpper() + symbol.Substring(1);

                if (Elements.ContainsKey(format))
                {
                    currentForm.Add($"{Elements[format]} ({format})");

                    FindForms(word.Substring(i), currentForm, forms);

                    // Backtrack
                    currentForm.RemoveAt(currentForm.Count - 1);
                }
            }
        }
    }

}
