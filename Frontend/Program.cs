using Backend;

var root = BinaryTreeFile.Load("tree.txt", int.Parse);
var option = string.Empty;

do
{
    option = MenuOptions();
    switch (option)
    {
        case "0":
            Console.WriteLine("Bye!");
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
            Console.WriteLine("LevelOrder =>");
            BinaryTreeOps.LevelOrder(root, x => Console.Write($"{x} "));
            Console.WriteLine();
            break;
        case "5":
            Console.WriteLine("Print Sideways =>");
            BinaryTreeOps.PrintSideways(root, 0);
            Console.WriteLine();
            break;
        case "6":
            Console.Write("Enter new value to insert: ");
            if (int.TryParse(Console.ReadLine(), out int valueToInsert))
            {
                BinarySearchTree<int>.Insert(root, valueToInsert);
                Console.WriteLine("New value inserted!");
            }
            else
            {
                Console.WriteLine("Invalid number.");
            }
            break;
        case "7":
            Console.Write("Enter new value to search: ");
            if (int.TryParse(Console.ReadLine(), out int valueToSearch))
            {
                var exists = BinarySearchTree<int>.Contains(root, valueToSearch);
                Console.WriteLine(exists ? "Value exists!" : "Value not exists!");
            }
            else
            {
                Console.WriteLine("Invalid number.");
            }
            break;
        case "8":
            Console.WriteLine($"Min value => {BinarySearchTree<int>.Min(root)}");
            break;
        case "9":
            Console.WriteLine($"Max value => {BinarySearchTree<int>.Max(root)}");
            break;
        default:
            Console.WriteLine("Invalid option.");
            break;
    }

} while (option != "0");

string MenuOptions()
{
    Console.WriteLine("1. Show pre-order");
    Console.WriteLine("2. Show in-order");
    Console.WriteLine("3. Show post-order");
    Console.WriteLine("4. Show level-order");
    Console.WriteLine("5. Show sideways");
    Console.WriteLine("6. Insert new value");
    Console.WriteLine("7. Search value");
    Console.WriteLine("8. Min value");
    Console.WriteLine("9. Max value");
    Console.WriteLine("0. Exit");
    Console.Write("Your option is? ");
    return Console.ReadLine()!;
}

Console.WriteLine("Saving changes...");
BinaryTreeFile.Save(root, "tree.txt");

