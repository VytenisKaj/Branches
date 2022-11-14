
namespace Branches
{
    public class Branch
    {
        List<Branch> branches;

        public Branch()
        {
            branches = new List<Branch>();
        }
        public void AddBranch(Branch branch)
        {
            branches.Add(branch);
        }

        public List<Branch> GetBranches()
        {
            return branches;
        }
    }
}
