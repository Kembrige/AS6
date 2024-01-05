class Node
{
    public double value;
    public Node left;
    public Node right;
}

class BinarySearchTree
{
    public Node root;

    public void Insert(double value)
    {
        Node newNode = new Node();
        newNode.value = value;

        if (root == null)
        {
            root = newNode;
        }
        else
        {
            Node current = root;
            while (true)
            {
                if (value < current.value)
                {
                    if (current.left == null)
                    {
                        current.left = newNode;
                        break;
                    }
                    else
                    {
                        current = current.left;
                    }
                }
                else
                {
                    if (current.right == null)
                    {
                        current.right = newNode;
                        break;
                    }
                    else
                    {
                        current = current.right;
                    }
                }
            }
        }
    }

    public void Delete(double value)
    {
        root = DeleteHelper(root, value);
    }

    private Node DeleteHelper(Node node, double value)
    {
        if (node == null)
        {
            return null;
        }

        if (value < node.value)
        {
            node.left = DeleteHelper(node.left, value);
        }
        else if (value > node.value)
        {
            node.right = DeleteHelper(node.right, value);
        }
        else
        {
            if (node.left == null)
            {
                return node.right;
            }
            else if (node.right == null)
            {
                return node.left;
            }

            Node minRight = node.right;
            while (minRight.left != null)
            {
                minRight = minRight.left;
            }

            node.value = minRight.value;
            node.right = DeleteHelper(node.right, minRight.value);
        }

        return node;
    }

    public void Print()
    {
        PrintHelper(root);
    }

    private void PrintHelper(Node node)
    {
        if (node != null)
        {
            PrintHelper(node.left);
            Console.Write(node.value + " ");
            PrintHelper(node.right);
        }
    }

    public int[] CountNodesPerLevel()
    {
        List<int> counts = new List<int>();
        CountNodesPerLevelHelper(root, 0, counts);
        return counts.ToArray();
    }

    private void CountNodesPerLevelHelper(Node node, int level, List<int> counts)
    {
        if (node != null)
        {
            if (level >= counts.Count)
            {
                counts.Add(1);
            }
            else
            {
                counts[level]++;
            }
            CountNodesPerLevelHelper(node.left, level + 1, counts);
            CountNodesPerLevelHelper(node.right, level + 1, counts);
        }
    }
    static void Main()
    {
        BinarySearchTree tree = new BinarySearchTree();
        tree.Insert(5.6);
        tree.Insert(2.3);
        tree.Insert(7.8);
        tree.Insert(1.2);
        tree.Insert(4.5);
        tree.Insert(6.7);
        tree.Insert(8.9);

        Console.WriteLine("До удаления:");
        tree.Print();

        tree.Delete(2.3);
        tree.Delete(6.7);

        Console.WriteLine("После удаления:");
        tree.Print();

        int[] counts = tree.CountNodesPerLevel();
        for (int i = 0; i < counts.Length; i++)
        {
            Console.WriteLine("Level " + i + ": " + counts[i] + " nodes");
        }
    }
}
