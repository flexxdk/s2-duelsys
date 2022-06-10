using BLL.Objects.TournamentSystem;

namespace BLL.Objects.Assigners
{
    public class TournamentSystemAssigner
    {
        private static List<ITournamentSystem?> systems;

        static TournamentSystemAssigner()
        {
            systems = typeof(ITournamentSystem).Assembly.GetTypes()
            .Where(t => typeof(ITournamentSystem).IsAssignableFrom(t)
            && t.IsClass)
            .Select(t => Activator.CreateInstance(t) as ITournamentSystem)
            .ToList();
        }

        public ITournamentSystem? Retrieve(int index)
        {
            if (index >= 0 && index < systems.Count)
            {
                if (systems[index] != null)
                {
                    return Activator.CreateInstance(systems[index]!.GetType()) as ITournamentSystem;
                }
            }
            return null;
        }


        public ITournamentSystem? Retrieve(string name)
        {
            foreach (ITournamentSystem? system in systems)
            {
                if (system != null)
                {
                    if (system!.Name.ToLower() == name.ToLower())
                    {
                        return Activator.CreateInstance(system.GetType()) as ITournamentSystem;
                    }
                }
            }
            return null;
        }

        public List<ITournamentSystem?> GetObjects()
        {
            return systems.ToList();
        }

        public List<string> GetNames()
        {
            return systems.Select(s => s!.Name).ToList();
        }
    }
}
