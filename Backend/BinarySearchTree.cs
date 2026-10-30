using System.Reflection.Emit;
using System.Xml.Linq;

namespace Backend;

public static class BinarySearchTree<T> where T : IComparable<T>
{
    public static BinaryNode<T> Insert(BinaryNode<T> node, T value)
    {
        if (node == null)
        {
            return new BinaryNode<T>(value);
        }

        int comparison = value.CompareTo(node.Value);

        if (comparison < 0)
        {
            node.Left = Insert(node.Left!, value);
        }

        if (comparison > 0)
        {
            node.Right = Insert(node.Right!, value);
        }

        return node;
    }

    public static bool Contains(BinaryNode<T> root, T value)
    {
        var current = root;
        while(current != null)
        {
            int comparison = value.CompareTo(current.Value);
            if (comparison == 0) return true;
            if (comparison < 0)
            {
                current = current.Left;
            }
            else
            {
                current = current.Right;
            }
        }
        return false;
    }
}