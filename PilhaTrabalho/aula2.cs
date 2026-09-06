
        Stack<int> original = new Stack<int>();
        Stack<int> auxiliar = new Stack<int>();

        original.Push(5);
        original.Push(1);
        original.Push(9);
        original.Push(3);

        while (original.Count > 0)
        {
            int elemento = original.Pop();
            while (auxiliar.Count > 0 && auxiliar.Peek() < elemento)
                original.Push(auxiliar.Pop());
            auxiliar.Push(elemento);
        }

        foreach (int n in auxiliar)
            Console.Write(n + " ");
