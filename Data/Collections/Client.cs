namespace ApiEscolaridade.Data.Collections
{
    public class Client
    {
        public Client(int id, int birthYear, string gender, string educLevel, int basicGradYear)
        {
            this.Id = id;
            this.BirthYear = birthYear;
            this.Gender = gender;
            this.EducLevel = educLevel;
            this.BasicGradYear = basicGradYear;
        }
        
        public int Id { get; set; }
        public int BirthYear { get; set; }
        public string Gender { get; set; }
        public string EducLevel { get; set; }
        public int BasicGradYear { get; set; }
    }
}