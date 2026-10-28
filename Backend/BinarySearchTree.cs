// Backend/BinarySearchTree.cs  (6.2, 6.3 and 6.4 are one class)
namespace Backend;

/// <summary>Binary search tree: left &lt; node &lt; right for every node. Duplicates are ignored.</summary>
public class BinarySearchTree<T> where T : IComparable<T>
{
    public static BinaryNode<T>? Root { get; private set; }
    public static int Count { get; private set; }

    public static void Insert(T value)
    {
        Root = Insert(Root, value);
    }

    public static BinaryNode<T> Insert(BinaryNode<T>? node, T value)
    {
        // Base case: we found the empty spot where the value belongs.
        if (node == null)
        {
            Count++;
            return new BinaryNode<T>(value);
        }

        int comparison = value.CompareTo(node.Value);

        if (comparison < 0)
        {
            node.Left = Insert(node.Left, value);   // Smaller values go left.
        }
        else if (comparison > 0)
        {
            node.Right = Insert(node.Right, value); // Larger values go right.
        }
        // comparison == 0: duplicate, nothing to do.

        return node;
    }

    public static bool Contains(BinaryNode<T> root, T value)
    {
        Root = root;
        return Contains(value);
    }

    /// <summary>Iterative search: at each node we discard half of the remaining tree.</summary>
    public static bool Contains(T value)
    {
        var current = Root;

        while (current != null)
        {
            int comparison = value.CompareTo(current.Value);
            if (comparison == 0) return true;
            current = comparison < 0 ? current.Left : current.Right;
        }

        return false;
    }

    public static T Min(BinaryNode<T> root)
    {
        Root = root;
        return Min();
    }

    public static T Min()
    {
        if (Root == null) throw new InvalidOperationException("The tree is empty.");
        return MinNode(Root).Value!;
    }

    public static T Max(BinaryNode<T> root)
    {
        Root = root;
        return Max();
    }

    public static T Max()
    {
        if (Root == null) throw new InvalidOperationException("The tree is empty.");
        var current = Root;
        while (current.Right != null) current = current.Right; // Keep going right.
        return current.Value!;
    }

    private static BinaryNode<T> MinNode(BinaryNode<T> node)
    {
        while (node.Left != null) node = node.Left; // Keep going left.
        return node;
    }

}