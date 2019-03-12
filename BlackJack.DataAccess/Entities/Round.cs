namespace BlackJack.DataAccess.Entities
{
    public class Round
    {
        /// <summary>
        /// Round index.
        /// </summary>
        public int Index { get; set; }
        
        /// <summary>
        /// The game.
        /// </summary>
        public Game Game { get; set; }
    }
}
