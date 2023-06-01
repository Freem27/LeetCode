internal class Program
{
    private static void Main(string[] args)
    {
        List<Tuple<List<int>, List<int>>> tests = new List<Tuple<List<int>, List<int>>>
        {
            new Tuple<List<int>, List<int>>(new List<int>{2,4,3}, new List<int>{5,6,4}),
            new Tuple<List<int>, List<int>>(new List<int>{0}, new List<int>{0}),
            new Tuple<List<int>, List<int>>(new List<int>{9,9,9,9,9,9,9}, new List<int>{9,9,9,9}),
        };
        Solution solution = new Solution();
        tests.ForEach(test =>
        {
            Console.WriteLine($"l1 = [{string.Join(",", test.Item1)}], l2 = [{string.Join(",", test.Item2)}] ");
            Console.WriteLine($"Output: [{string.Join(",", solution.AddTwoNumbers(ListNode.FromList(test.Item1), ListNode.FromList(test.Item2)).ToList())}]");
        });

    }

    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }

        public static ListNode FromList(List<int> list)
        {
            ListNode result = null;
            ListNode currNode = null;
            list.ForEach(item =>
            {
                var newNode = new ListNode(item);
                if (result == null)
                {
                    result = newNode;
                }
                else
                {
                    currNode.next = newNode;
                }
                currNode = newNode;
            });
            return result;
        }

        public List<int> ToList()
        {
            List<int> result = new List<int>();
            result.Add(val);
            var currNode = this;
            while (currNode.next != null)
            {
                result.Add(currNode.next.val);
                currNode = currNode.next;
            }
            return result;
        }
    }

    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode result = null;
            ListNode lastNode = null;
            var currNode1 = l1;
            var currNode2 = l2;
            while (currNode1 != null || currNode2 != null)
            {
                int forAdd = (currNode1?.val ?? 0) + (currNode2?.val ?? 0) + (lastNode?.next?.val ?? 0);
                if (forAdd >= 10)
                {
                    var newNode = new ListNode(forAdd % 10, new ListNode(forAdd / 10));
                    if (result == null)
                    {
                        result = newNode;
                    }
                    else
                    {
                        lastNode.next = newNode;
                    }
                    lastNode = newNode;
                }
                else
                {
                    var newNode = new ListNode(forAdd == 10 ? 0 : forAdd);
                    if (result == null)
                    {
                        result = newNode;
                    }
                    else
                    {
                        lastNode.next = newNode;
                    }
                    lastNode = newNode;
                }
                currNode1 = currNode1?.next;
                currNode2 = currNode2?.next;
            }
            return result;
        }
    }
}