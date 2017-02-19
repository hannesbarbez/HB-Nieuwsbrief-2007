using System;

namespace HB_Nieuwsbrief.Logic
{
    public static class HintOfTheDay
    {
        private const string fixedPart = "Hier komt de tekst. Intussen alvast de tip van het moment: ";
        private static string[] hintOfTheDay = 
        {
            "Bij het weergeven van een nieuwsbrief met achtergrondafbeelding op webclients (zoals Hotmail) kan het zijn dat de achtergrond om veiligheidsredenen niet wordt weergegeven. Hierdoor is het aangewezen om een goed leesbare voorgrondkleur te gebruiken. Iedere kleur die ook op witte achtergrond leesbaar is, is een goede kleur. Kleur en achtergrond kunnen worden ingesteld onder het gedeelte 'Instellingen'.",
            "Voor het verzenden van een nieuwsbrief wordt de nieuwsbrief gesynchroniseerd. Zo zullen zelfs de prilste abonnees de nieuwsbrief ontvangen.",
            "Eventuele problemen met de synchronisatie van abonnees kan te wijten zijn aan foutieve nieuwsbriefinstellingen of een niet-responsieve server. Een controle van de instellingen kan dan aangewezen zijn.",
            "In de e-mailvakken 'Aan:' en 'CC:' hoeft niets te worden ingevuld. De nieuwsbrief wordt verzonden via 'BCC' zodat de e-mailadressen en dus de privacy van de abonnees gevrijwaard blijven."
        };

        public static string Generate()
        {
            int position = new Random().Next(hintOfTheDay.Length - 1);
            string generatedString = fixedPart + hintOfTheDay[position];
            return generatedString;
        }
    }
}