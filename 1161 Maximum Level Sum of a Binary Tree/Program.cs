namespace _1161_Maximum_Level_Sum_of_a_Binary_Tree
{
    public class TreeNode
    {
        public int val;
        public TreeNode? left;
        public TreeNode? right;
        public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public class Solution
    {
        List<List<int>> _values = new List<List<int>>();
        public int MaxLevelSum(TreeNode root)
        {
            _values.Add(new List<int>());
            FillValues(root, 1);
            int maxLevel = 1;
            int maxSum = root.val;
            for(int lev =1; lev < _values.Count; lev++)
            {
                int currSum = _values[lev].Sum();
                if(currSum > maxSum)
                {
                    maxLevel = lev;
                    maxSum = currSum;
                }
            }
            return maxLevel;
        }

        public void FillValues(TreeNode root, int level)
        {
            if(_values.Count - 1 < level)
            {
                _values.Add(new List<int>());
            }
            _values[level].Add(root.val);
            if(root.left != null)
            {
                FillValues(root.left, level+1);
            }
            if(root.right != null)
            {
                FillValues(root.right, level+1);
            }
        }
    }
} 