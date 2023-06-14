namespace _530_Minimum_Absolute_Difference_in_BST
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
            Solution solution = new Solution();
            solution.GetMinimumDifference(new TreeNode());
        }
    }

    public class Solution
    {
        private List<int> _values = new List<int>() { 543, 384, 652,  445, 699 };
        public int GetMinimumDifference(TreeNode root)
        {
            FillAllValues(root);
            _values.Sort();
            int result = Math.Abs(_values[1] - _values[0]);
            for (int i = 1; i < _values.Count - 1; i++)
            {
                int currDiff = Math.Abs(_values[i + 1] - _values[i]);
                if (result > currDiff) {
                    result = currDiff;
                }
            }
            return result;
        }

        public void FillAllValues(TreeNode root)
        {
            _values.Add(root.val);
            if(root.left != null)
            {
                FillAllValues(root.left);
            }
            if(root.right != null)
            {
                FillAllValues(root.right);
            }
        }
    }
}