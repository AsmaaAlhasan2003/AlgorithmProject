using System.Xml.Linq;

public class AVLTreeNode
{
    public int Value { get; set; }
    public AVLTreeNode Left { get; set; }
    public AVLTreeNode Right { get; set; }
    public int Height { get; set; }
}

public class AVLTree
{
    public AVLTreeNode Root { get; set; }
     public int InsertAttempts { get; private set; }
    public int SearchAttempts { get; private set; }

    // «·Õ’Ê· ⁄·Ï «— ›«⁄ «·‘Ã—…
    private int Height(AVLTreeNode node)
    {
        if (node == null) return 0;
        return node.Height;
    }

    //  ÕœÌÀ «— ›«⁄ «·⁄ﬁœ…
    private void UpdateHeight(AVLTreeNode node)
    {
        node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;
    }

    // Õ”«» «·⁄«„· «· Ê«“‰ (Balance Factor)
    private int GetBalanceFactor(AVLTreeNode node)
    {
        if (node == null) return 0;
        return Height(node.Left) - Height(node.Right);
    }

    // «· œÊÌ— ≈·Ï «·Ì”«—
    private AVLTreeNode RotateLeft(AVLTreeNode root)
    {
        AVLTreeNode newRoot = root.Right;
        root.Right = newRoot.Left;
        newRoot.Left = root;

        UpdateHeight(root);
        UpdateHeight(newRoot);
        return newRoot;
    }

    // «· œÊÌ— ≈·Ï «·Ì„Ì‰
    private AVLTreeNode RotateRight(AVLTreeNode root)
    {
        AVLTreeNode newRoot = root.Left;
        root.Left = newRoot.Right;
        newRoot.Right = root;

        UpdateHeight(root);
        UpdateHeight(newRoot);
        return newRoot;
    }

    // ≈œŒ«· ⁄‰’— ›Ì «·‘Ã—…
    public AVLTreeNode Insert(AVLTreeNode node, int value)
    {
        if (node == null) return new AVLTreeNode { Value = value, Height = 1 };

        if (value < node.Value)
            node.Left = Insert(node.Left, value);
        else
            node.Right = Insert(node.Right, value);

        UpdateHeight(node);

        // «· Ê«“‰ Ê«· Õﬁﬁ „‰ «· œÊÌ—
        int balance = GetBalanceFactor(node);

        //  œÊÌ— Ì”«—
        if (balance > 1 && value < node.Left.Value)
            return RotateRight(node);

        //  œÊÌ— Ì„Ì‰
        if (balance < -1 && value > node.Right.Value)
            return RotateLeft(node);

        //  œÊÌ— „“œÊÃ Ì”«—-Ì„Ì‰
        if (balance > 1 && value > node.Left.Value)
        {
            node.Left = RotateLeft(node.Left);
            return RotateRight(node);
        }

        //  œÊÌ— „“œÊÃ Ì„Ì‰-Ì”«—
        if (balance < -1 && value < node.Right.Value)
        {
            node.Right = RotateRight(node.Right);
            return RotateLeft(node);
        }

        return node;
    }

    public void Insert(int value)
    {
        InsertAttempts = 0;
        Root = Insert(Root, value);
    }


    public void InOrderTraversal(AVLTreeNode node, List<int> treeValues)
    {
        if (node != null)
        {
            InOrderTraversal(node.Left, treeValues);
            treeValues.Add(node.Value);
            InOrderTraversal(node.Right, treeValues);
        }
    }
    public (bool found, int attempts) Search(AVLTreeNode node, int value, int attempts = 0)
    {
        if (node == null) return (false, attempts);
        attempts++;
        if (node.Value == value) return (true, attempts);
        return value < node.Value ? Search(node.Left, value, attempts) : Search(node.Right, value, attempts);
    }
    // Õ–› ⁄‰’— „‰ «·‘Ã—…
    // Õ–› ⁄‰’— „‰ «·‘Ã—… „⁄ ≈⁄«œ… «· Ê«“‰
    public AVLTreeNode Delete(AVLTreeNode node, int value)
    {
        if (node == null) return null;

        if (value < node.Value)
            node.Left = Delete(node.Left, value);
        else if (value > node.Value)
            node.Right = Delete(node.Right, value);
        else
        {
            // ≈–« ﬂ«‰  «·⁄ﬁœ…  Õ ÊÌ ⁄·Ï Ê·œ Ê«Õœ √Ê ·«  Õ ÊÌ ⁄·Ï √Ì Ê·œ
            if (node.Left == null) return node.Right;
            if (node.Right == null) return node.Left;

            // «·Õ’Ê· ⁄·Ï «·Õœ «·√œ‰Ï „‰ «·ÃÂ… «·Ì„‰Ï
            AVLTreeNode temp = GetMinValueNode(node.Right);
            node.Value = temp.Value;
            node.Right = Delete(node.Right, temp.Value);
        }

        if (node == null) return node;

        UpdateHeight(node);

        // ≈⁄«œ… «· Ê«“‰
        int balance = GetBalanceFactor(node);

        //  œÊÌ— Ì„Ì‰
        if (balance > 1 && GetBalanceFactor(node.Left) >= 0)
            return RotateRight(node);

        //  œÊÌ— Ì”«—
        if (balance < -1 && GetBalanceFactor(node.Right) <= 0)
            return RotateLeft(node);

        //  œÊÌ— „“œÊÃ Ì”«—-Ì„Ì‰
        if (balance > 1 && GetBalanceFactor(node.Left) < 0)
        {
            node.Left = RotateLeft(node.Left);
            return RotateRight(node);
        }

        //  œÊÌ— „“œÊÃ Ì„Ì‰-Ì”«—
        if (balance < -1 && GetBalanceFactor(node.Right) > 0)
        {
            node.Right = RotateRight(node.Right);
            return RotateLeft(node);
        }

        return node;
    }

    private AVLTreeNode GetMinValueNode(AVLTreeNode node)
    {
        while (node.Left != null) node = node.Left;
        return node;
    }

    public void Delete(int value)
    {
        Root = Delete(Root, value);
    }

    public (bool found, int attempts) Search(int value)
    {
        return Search(Root, value);
    }
}
