namespace _21MergeTwoSortedLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            var tests = new List<Tuple<ListNode, ListNode>>()
            {
                new  (new ListNode(1, 2, 4 ), new ListNode( 1, 3, 4 ) ),
                new  (new ListNode(), new ListNode() ),
                new  (new ListNode(), new ListNode(0) ),

            };
            foreach ( var test in tests )
            {
                Console.WriteLine($"list1: {test.Item1.ToString()}\tlist2: {test.Item2.ToString()}\t->\t{solution.MergeTwoLists(test.Item1, test.Item2).ToString()}  ");
            }
        }
    }

    public class ListNode {
        public int? val;
        public ListNode? next;
        public ListNode (params int[] val)
        {
            if(val.Length == 0)
            {
                this.val=null;
            }
            else
            {
                this.val = val.First();
                var newParams = val.ToList();
                newParams.RemoveAt(0);
                next = new ListNode(newParams.ToArray());
            }
        }

        public override string ToString()
        {
            List<int> list = new List<int>();
            if (val != null)
            {
                list.Add(val.Value);
                var n = next;
                while(n?.val != null)
                {
                    list.Add(n.val.Value);
                    n = n.next;
                }
            }
            return '['+string.Join(", ", list)+']';
        }
        public ListNode(int val, ListNode next=null) {
            this.val = val;
            this.next = next;
        }
    }

    public class Solution
    {
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            return new ListNode();
        }
    }
}