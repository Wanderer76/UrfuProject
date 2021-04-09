
namespace UrfuProject
{
    public class Database
    {
        private static Database instance;

        public static Database Instance()
        {
            if (instance == null)
                instance = new Database();
            return instance;
        }

        public Quest GetQuest(int index)
        {
            return new Quest();
        }
    }
}