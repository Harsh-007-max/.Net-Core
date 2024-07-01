namespace All_Programs.Practical_4;
using System.Collections;
public class Prog_3
{
    
    public void start()
    {
        Stack<int> st = new Stack<int>();
        st.Push(1);
        st.Push(2);
        st.Push(3);
        st.Push(4);
        st.Push(5);
        Console.WriteLine(st.Pop());
        Console.WriteLine(st.Peek());
        Console.WriteLine(st.Contains(1));
        st.Clear();
    }
}
