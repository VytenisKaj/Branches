
namespace Branches
{
    public class Program
    {
        public static int CalculateDepthOfBranchObject(Branch? branch)
        {
            if(branch == null)
            {
                return 0;
            }
            if(branch.GetBranches().Count == 0)
            {
                return 1;
            }
            List<int> depths = new List<int>();
            foreach(Branch b in branch.GetBranches())
            {
                depths.Add(CalculateDepthOfBranchObject(b));
            }
            return depths.OrderByDescending(x => x).ToList()[0] + 1;
        }
        public static void Main()
        {
            // Creating structure like in the example
            Branch layer5 = new();

            Branch layer4a = new();
            Branch layer4b = new();
            Branch layer4c = new();
            layer4b.AddBranch(layer5);

            Branch layer3a = new();
            Branch layer3b = new();
            Branch layer3c = new();
            Branch layer3d = new();
            layer3b.AddBranch(layer4a);
            layer3c.AddBranch(layer4b);
            layer3c.AddBranch(layer4c);

            Branch layer2a = new();
            Branch layer2b = new();
            layer2a.AddBranch(layer3a);
            layer2b.AddBranch(layer3b);
            layer2b.AddBranch(layer3c);
            layer2b.AddBranch(layer3d);

            Branch layer1 = new();
            layer1.AddBranch(layer2a);
            layer1.AddBranch(layer2b);



            Console.WriteLine($"Depth of object is {CalculateDepthOfBranchObject(layer1)}");
        }
    }
}
