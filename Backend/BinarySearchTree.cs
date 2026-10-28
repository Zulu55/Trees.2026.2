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
}