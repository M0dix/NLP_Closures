class Program
{
    static HashSet<(int, int)> ReflexiveClosure(HashSet<(int, int)> relation, List<int> set)
    {
        foreach (var a in set)
        {
            relation.Add((a, a));
        }
        return relation;
    }

    static HashSet<(int, int)> SymmetricClosure(HashSet<(int, int)> relation)
    {
        var result = new HashSet<(int, int)>(relation);
        foreach (var (a, b) in relation)
        {
            result.Add((b, a));
        }
        return result;
    }

    static HashSet<(int, int)> TransitiveClosure(HashSet<(int, int)> relation)
    {
        var result = new HashSet<(int, int)>(relation);
        bool added;
        do
        {
            added = false;
            var temp = new HashSet<(int, int)>(result);

            foreach (var (a, b) in result)
            {
                foreach (var (c, d) in result)
                {
                    if (b == c && !result.Contains((a, d)))
                    {
                        temp.Add((a, d));
                        added = true;
                    }
                }
            }
            result = temp;
        }
        while (added);

        return result;
    }

    static void Main()
    {
        var set = new List<int> { 0, 1, 2 };
        var relation = new HashSet<(int, int)> { (0, 1), (0, 2) };

        Console.WriteLine("Исходное отношение:");
        PrintRelation(relation);

        var reflexive = ReflexiveClosure(new HashSet<(int, int)>(relation), set);
        Console.WriteLine("\nРефлексивное замыкание:");
        PrintRelation(reflexive);

        var symmetric = SymmetricClosure(new HashSet<(int, int)>(relation));
        Console.WriteLine("\nСимметричное замыкание:");
        PrintRelation(symmetric);

        var transitive = TransitiveClosure(new HashSet<(int, int)>(relation));
        Console.WriteLine("\nТранзитивное замыкание:");
        PrintRelation(transitive);
    }

    static void PrintRelation(HashSet<(int, int)> relation)
    {
        foreach (var (a, b) in relation)
        {
            Console.WriteLine($"({a}, {b})");
        }
    }
}
