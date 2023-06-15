using System;

namespace _1146_Snapshot_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SnapshotArray snapshotArr = new SnapshotArray(3); // set the length to be 3
            snapshotArr.Set(0, 5);  // Set array[0] = 5
            var snapId = snapshotArr.Snap();  // Take a snapshot, return snap_id = 0
            snapshotArr.Set(0, 6);
            var res = snapshotArr.Get(0, 0);  // Get the value of array[0] with snap_id = 0, return 5
        }
    }

    public class SnapshotArray
    {
        public int[] _array;
        public List<Dictionary<int, int>> _snapshots;

        public SnapshotArray(int length)
        {
            _array = new int[length];
            _snapshots = new List<Dictionary<int, int>>();
        }

        public void Set(int index, int val)
        {
            var curSnapshot = _snapshots.LastOrDefault();
            if(curSnapshot == null)
            {
                _array[index] = val;
                return;
            }

            if (curSnapshot.ContainsKey(index))
            {
                curSnapshot[index] = val;
            }
            else { 
                curSnapshot.Add(index, val);
            }
        }

        public int Snap()
        {
            _snapshots.Add(new Dictionary<int, int>());
            return _snapshots.Count - 1;
        }

        public int Get(int index, int snap_id)
        {
            snap_id--;
            while (snap_id >= 0)
            {
                if (_snapshots[snap_id].ContainsKey(index))
                {
                    return _snapshots[snap_id][index];
                }
                snap_id--;
            }

            return _array[index];
        }
    }
}