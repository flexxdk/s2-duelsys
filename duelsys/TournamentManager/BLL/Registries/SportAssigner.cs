using BLL.Objects.Sports;

namespace BLL.Registries
{
    public class SportAssigner
    {
        private static List<ISport?> sports;

        static SportAssigner()
        {
            sports = typeof(ISport).Assembly.GetTypes()
            .Where(t => typeof(ISport).IsAssignableFrom(t)
            && t.IsClass)
            .Select(t => Activator.CreateInstance(t) as ISport)
            .ToList();
        }

        public ISport? RetrieveSport(int index)
        {
            if(index < 0 || index >= sports.Count)
            {
                return null;
            }
            return sports[index];
        }


        public ISport? RetrieveSport(string name)
        {
            foreach(var sport in sports)
            {
                if(sport!.Name.ToLower() == name.ToLower())
                {
                    return sport;
                }
            }
            return null;
        }

        public List<ISport?> GetSports()
        {
            return sports;
        }

        public List<string> GetNames()
        {
            return sports.Select(s => s!.Name).ToList();
        }
    }
}
