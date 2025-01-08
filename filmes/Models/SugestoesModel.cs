namespace filmes.Models
{
    public class SugestoesModel
    {
        public string backdrop_path { get; set; } = string.Empty;
        public string original_language { get; set; } = string.Empty;
        public string original_title { get; set; } = string.Empty;
        public string overview { get; set; } = string.Empty;
        public decimal popularity { get; set; }
        public string poster_path { get; set; } = string.Empty;
        public DateTime release_date { get; set; }
        public string title { get; set; } = string.Empty;
        public decimal vote_average { get; set; }
        public int vote_count { get; set; }

    }
}
