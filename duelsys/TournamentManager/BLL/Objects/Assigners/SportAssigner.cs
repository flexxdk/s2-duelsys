using BLL.Objects.Sports;

namespace BLL.Objects.Assigners
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

        public ISport? Retrieve(int index)
        {
            if (index >= 0 && index < sports.Count)
            {
                if (sports[index] != null)
                {
                    return Activator.CreateInstance(sports[index]!.GetType()) as ISport;
                }
            }
            return null;
        }


        public ISport? Retrieve(string name)
        {
            foreach (ISport? sport in sports)
            {
                if (sport != null)
                {
                    if (sport!.Name.ToLower() == name.ToLower())
                    {
                        return Activator.CreateInstance(sport.GetType()) as ISport;
                    }
                }
            }
            return null;
        }

        public List<ISport?> GetObjects()
        {
            return sports;
        }

        public List<string> GetNames()
        {
            return sports.Select(s => s!.Name).ToList();
        }
    }
}
