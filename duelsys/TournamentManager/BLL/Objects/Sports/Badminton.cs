using BLL.Validation;

namespace BLL.Objects.Sports
{
    public class Badminton : ISport
    {
        public string Name { get; }
        public string Scoring { get; }

        public Badminton()
        {
            Name = "Badminton";
            Scoring = "Points";
        }

        public bool ScoreIsValid(object home, object away)
        {
            //The official badminton scoring system must be followed/ enforced when registering the result:
            //• A game consists of 21 points
            //• If the game reaches 20 - 20 points, the player that gains a 2 - point lead wins the game
            //• At 29 - 29, the side scoring the 30th point wins the game

            if (Validate.AsInt(home) && Validate.AsInt(away))
            {
                int homeScore = Convert.ToInt32(home);
                int awayScore = Convert.ToInt32(away);

                if((homeScore <= 19 && awayScore >= 21) || (homeScore >= 21 && awayScore <= 19))
                {
                    return true;
                }
                if(homeScore >= 20 && awayScore >= 20 && homeScore <= 29 && awayScore <= 29)
                {
                    if(homeScore >= awayScore + 2 || awayScore >= homeScore + 2)
                    {
                        return true;
                    }
                }
                else if(homeScore == 30 ^ awayScore == 30)
                {
                    return true;
                }
                return false;
            }
            throw new FormatException();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
