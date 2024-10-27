namespace back_facturation_api.Classes
{
    public class Client
    {
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public int Age { get; set; }
        public DateOnly DateNaissance { get; set; }
    }
}