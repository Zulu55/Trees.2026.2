namespace Backend;

public static class BinarySearchTree<T> where T : IComparable<T>
{
    public static BinaryNode<T> Insert(BinaryNode<T> node, T value)
    {
        if (node == null)
        {
            return new BinaryNode<T>(value);
        }

        return null;
    }
}