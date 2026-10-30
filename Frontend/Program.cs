using Backend;
var path = "C:\\Tmp\\tree2.txt";
var root = BinaryTreeFile.Load(path, int.Parse);
var option = string.Empty;

do
{
    option = MenuTree();
    switch (option)
    {
        case "0":
            Console.WriteLine("Bye.");
            break;
        case "1":
            Console.WriteLine("Pre-Order =>");
            BinaryTreeOps.PreOrder(root, x => Console.Write($"{x} "));
            Console.WriteLine();
            break;
        case "2":
            Console.WriteLine("In-Order =>");
            BinaryTreeOps.InOrder(root, x => Console.Write($"{x} "));
            Console.WriteLine();
            break;
        case "3":
            Console.WriteLine("Post-Order =>");
            BinaryTreeOps.PostOrder(root, x => Console.Write($"{x} "));
            Console.WriteLine();
            break;
        case "4":
            Console.WriteLine("Show Level Order =>");
            BinaryTreeOps.LevelOrder(root, x => Console.Write($"{x} "));
            Console.WriteLine();
            break;
        case "5":
            Console.WriteLine("Show Sideways =>");
            BinaryTreeOps.PrintSideways(root, 0);
            Console.WriteLine();
            break;
        case "6":
            Console.Write("Enter new value to insert: ");
            if (int.TryParse(Console.ReadLine(), out int valueToInsert))
            {
                root = BinarySearchTree<int>.Insert(root!, valueToInsert);
                Console.WriteLine("New value inserted!");
            }
            else
            {
                Console.WriteLine("Invalid number.");
            }
            Console.WriteLine();
            break;
        case "7":
            Console.Write("Enter number of values to insert: ");
            if (int.TryParse(Console.ReadLine(), out int n))
            {
                var random = new Random();
                for (int i = 0; i < n; i++)
                {
                    root = BinarySearchTree<int>.Insert(root!, random.Next(-100000, 100000));
                }
                Console.WriteLine($"New {n} values inserted!");
            }
            else
            {
                Console.WriteLine("Invalid number.");
            }
            Console.WriteLine();
            break;
        case "8":
            Console.Write("Enter new value to search: ");
            if (int.TryParse(Console.ReadLine(), out int valueToSearch))
            {
                var exists = BinarySearchTree<int>.Contains(root!, valueToSearch);
                Console.WriteLine(exists ? "Value exists." : "Value not exists.");
            }
            else
            {
                Console.WriteLine("Invalid number.");
            }
            Console.WriteLine();
            break;
        default:
            Console.WriteLine("Invalid option.");
            break;
    }
} while (option != "0");

Console.WriteLine("Saving changes...");
BinaryTreeFile.Save(root!, path);

string MenuTree()
{
    Console.WriteLine(" 0. Exit");
    Console.WriteLine(" 1. Show Pre-Order");
    Console.WriteLine(" 2. Show In-Order");
    Console.WriteLine(" 3. Show Post-Order");
    Console.WriteLine(" 4. Show Level Order");
    Console.WriteLine(" 5. Show Sideways");
    Console.WriteLine(" 6. Insert new value");
    Console.WriteLine(" 7. Insert N values randomly");
    Console.WriteLine(" 8. Search a value");
    Console.Write("Your option is? ");
    return Console.ReadLine()!;
}
