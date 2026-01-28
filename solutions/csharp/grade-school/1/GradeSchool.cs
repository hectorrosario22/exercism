public class GradeSchool
{
    private readonly Dictionary<string, int> roster = new Dictionary<string, int>();
    
    public bool Add(string student, int grade)
    {
        if (!roster.ContainsKey(student))
        {
            roster.Add(student, grade);
            return true;
        }
        
        return false;
    }

    public IEnumerable<string> Roster()
    {
        return roster.OrderBy(d => d.Value).ThenBy(d => d.Key).Select(d => d.Key);
    }

    public IEnumerable<string> Grade(int grade)
    {
        return roster.Where(d => d.Value == grade).OrderBy(d => d.Key).Select(d => d.Key);
    }
}