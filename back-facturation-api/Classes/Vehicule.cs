namespace back_facturation_api.Classes
{
    public class Vehicule
    {
        public string? Marque { get; set; }
        public int Annee { get; set; }
        public DateOnly DateMiseEnCirculation { get; set; }
        public int Prix { get; set; }
    }
}