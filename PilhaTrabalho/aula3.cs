Stack<double> nums = new Stack<double>();
        Stack<string> ops = new Stack<string>();

        string[] tokens = "3 + 4 * 2".Split(' ');

        foreach (string t in tokens)
        {
            if (double.TryParse(t, out double n))
            {
                nums.Push(n);
            }
            else
            {
                while (ops.Count > 0 && (ops.Peek() == "*" || ops.Peek() == "/") && (t == "+" || t == "-"))
                {
                    double b = nums.Pop(), a = nums.Pop();
                    string op = ops.Pop();
                    nums.Push(op == "+" ? a+b : op == "-" ? a-b : op == "*" ? a*b : a/b);
                }
                ops.Push(t);
            }
        }

        while (ops.Count > 0)
        {
            double b = nums.Pop(), a = nums.Pop();
            string op = ops.Pop();
            nums.Push(op == "+" ? a+b : op == "-" ? a-b : op == "*" ? a*b : a/b);
        }

        Console.WriteLine("Resultado: " + nums.Pop());