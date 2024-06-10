class Stack
{
    static void Main(string[] args)
    {
        string s = Console.ReadLine();
        bool flag= false;
        Stack<string> stack = new Stack<string>();
        for(int i=0; i<s.Length; i++)
        {
            if (s[i] == '(') { stack.Push("("); }
            if (s[i] == '[') { stack.Push("["); }
            if (s[i] == '{') { stack.Push("{"); }
            if (s[i] == ')')
            {
                if (Stack_Find(stack, '(') == true)
                    flag = true;
                else
                {
                    flag = false; break;
                }
                    
            }
            if (s[i] == ']')
            {
                if (Stack_Find(stack, '[') == true)
                    flag = true;
                else
                {
                    flag = false;  break;
                }
            }
            if (s[i]=='}')
            {
                if(Stack_Find(stack,'{')==true)
                    flag = true;
                else
                {
                    flag = false; break;
                }    
            }
        }
        if(flag==true)
            Console.WriteLine("Yes");
        else
            Console.WriteLine("No");
    }
    static bool Stack_Find(Stack<string>stack,char s)
    {
        if (stack.Count == 0)
            return false;
        else
        {
            if (stack.Pop() == Convert.ToString(s))
                return true;
            else return false;
        }
    }
}

