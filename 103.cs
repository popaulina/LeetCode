/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
 
public class Solution {
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
        if (root == null) return new List<IList<int>>();
        
        List<Tuple<TreeNode, int>> queue = new List<Tuple<TreeNode, int>>();
        IList<IList<int>> values = new List<IList<int>>();
        queue.Add(Tuple.Create(root, 0));
        int level;
        TreeNode node;
        while (queue.Any()) {
            node = queue[0].Item1;
            level = queue[0].Item2;
            if (values.Count() <= level) values.Add(new List<int>());
            if (level % 2 == 0) {
                values[level].Add(node.val);
            } else {
                values[level].Insert(0, node.val);
            }
            
            if (node.left != null) {
                queue.Add(Tuple.Create(node.left, level + 1));
            }
            if (node.right != null) {
                queue.Add(Tuple.Create(node.right, level + 1));
            }
            
            queue.RemoveAt(0);
        }
        return (IList<IList<int>>)(values);
    }
}