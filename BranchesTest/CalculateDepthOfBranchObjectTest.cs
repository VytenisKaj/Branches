using Branches;
using System.Collections.Generic;
using Xunit;

namespace BranchesTest
{
    public class CalculateDepthOfBranchObject
    {
        [Fact]
        public void CalculateDepthOfBranchObject_NullIsGiven_ShouldReturnZero()
        {
            Branch? branch = null;

            int actual = Program.CalculateDepthOfBranchObject(branch);

            Assert.Equal(0, actual);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(5)]
        [InlineData(50)]
        public void CalculateDepthOfBranchObject_NotNullObjectIsGiven_ShouldReturnItsDepth(int depth)
        {
            Branch? branch = CreateNestedBranchObjectOfProvidedDepth(depth);

            int actual = Program.CalculateDepthOfBranchObject(branch);

            Assert.Equal(depth, actual);

        }

        // Not the perfect solution, but don't know the correct way to write this. I don't want this much code in test "arrange" part
        private static Branch? CreateNestedBranchObjectOfProvidedDepth(int depth)
        {
            if(depth < 1)
            {
                return null;
            }
            if(depth == 1)
            {
                return new Branch();
            }
            // Creating a list of branches
            List<Branch> branches = new List<Branch>();
            for(int i = 0; i < depth; i++)
            {
                branches.Add(new Branch());
            }
            // Puting all branches into the one before it
            for(int i = branches.Count - 2; i >= 0; i--)
            {
                branches[i].AddBranch(branches[i+1]);
            }
            return branches[0];
        }
    }
}