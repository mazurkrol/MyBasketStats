namespace MyBasketStats.API.Models
{
    public class PlayerForCreationDto
    {

        public string Name { get; set; }

        public string Surname { get; set; }

        public int HeightInCm { get; set; }

        public int HeightInInches        
        {
            get
            {
                return (int)Math.Floor(HeightInCm/2.54);
            }
        }

        public string Position { get; set; }

    }
}
