namespace DataStructures
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is User && obj != null)
            {
                User comparer = (User)obj;

                if (this.Id.Equals(comparer.Id))
                    return true;

                return false;
            }

            else return false;
        }

    }
}
