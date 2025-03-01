public class BinaryTree
{
    public TreeNode Root { get; set; }

    // œ«·… ·≈œŒ«· ﬁÌ„… ÃœÌœ…
    public void Insert(int value)
    {
        Root = InsertNode(Root, value);
    }

    private TreeNode InsertNode(TreeNode node, int value)
    {
        if (node == null)
            return new TreeNode(value);

        if (value < node.Value)
            node.Left = InsertNode(node.Left, value);
        else
            node.Right = InsertNode(node.Right, value);

        return node;
    }

    // œ«·… ·Õ–› ﬁÌ„…
    public bool Delete(int value)
    {
        Root = DeleteNode(Root, value);
        return Root != null;
    }

    private TreeNode DeleteNode(TreeNode node, int value)
    {
        if (node == null) return null;

        if (value < node.Value)
            node.Left = DeleteNode(node.Left, value);
        else if (value > node.Value)
            node.Right = DeleteNode(node.Right, value);
        else
        {
            if (node.Left == null)
                return node.Right;
            else if (node.Right == null)
                return node.Left;

            node.Value = MinValueNode(node.Right).Value;
            node.Right = DeleteNode(node.Right, node.Value);
        }

        return node;
    }

    private TreeNode MinValueNode(TreeNode node)
    {
        TreeNode current = node;
        while (current.Left != null)
            current = current.Left;
        return current;
    }

    // œ«·… · ⁄œÌ· ﬁÌ„…
    public bool Update(int oldValue, int newValue)
    {
        var node = FindNode(Root, oldValue);
        if (node != null)
        {
            node.Value = newValue;
            return true;
        }
        return false;
    }

    private TreeNode FindNode(TreeNode node, int value)
    {
        if (node == null) return null;
        if (value == node.Value) return node;
        return value < node.Value ? FindNode(node.Left, value) : FindNode(node.Right, value);
    }

    // œ«·… ··Õ’Ê· ⁄·Ï «·ﬁÌ„ » — Ì» Inorder
    public List<int> InOrderTraversal(TreeNode node, List<int> result = null)
    {
        if (result == null)
            result = new List<int>();

        if (node != null)
        {
            InOrderTraversal(node.Left, result);
            result.Add(node.Value);
            InOrderTraversal(node.Right, result);
        }

        return result;
    }

    // œ«·… ··Õ’Ê· ⁄·Ï «·ﬁÌ„ » — Ì» Preorder
    public List<int> PreOrderTraversal(TreeNode node, List<int> result = null)
    {
        if (result == null)
            result = new List<int>();

        if (node != null)
        {
            result.Add(node.Value);
            PreOrderTraversal(node.Left, result);
            PreOrderTraversal(node.Right, result);
        }

        return result;
    }

    // œ«·… ··Õ’Ê· ⁄·Ï «·ﬁÌ„ » — Ì» Postorder
    public List<int> PostOrderTraversal(TreeNode node, List<int> result = null)
    {
        if (result == null)
            result = new List<int>();

        if (node != null)
        {
            PostOrderTraversal(node.Left, result);
            PostOrderTraversal(node.Right, result);
            result.Add(node.Value);
        }

        return result;
    }
}

// «·⁄ﬁœ… ›Ì «·‘Ã—… «·À‰«∆Ì…
public class TreeNode
{
    public int Value { get; set; }
    public TreeNode Left { get; set; }
    public TreeNode Right { get; set; }

    public TreeNode(int value)
    {
        Value = value;
        Left = Right = null;
    }
}
