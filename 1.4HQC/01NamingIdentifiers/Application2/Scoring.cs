namespace Minesweeper
{
    public class Scoring
    {
        private string name;
        private int score;

        public Scoring(string name, int score)
        {
            Name = name;
            Score = score;
        }

        public string Name { get; set; }

        public int Score { get; set; }
    }
}