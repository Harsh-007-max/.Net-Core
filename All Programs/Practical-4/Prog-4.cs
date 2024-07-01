namespace All_Programs.Practical_4;
using System.Collections;
public class Prog_4
{
    
    public void start()
    {
        Queue<int> q = new Queue<int>();
        q.Enqueue(1);
        q.Enqueue(2);
        q.Enqueue(3);
        q.Enqueue(4);
        q.Enqueue(5);
        Console.WriteLine(q.Dequeue());
        Console.WriteLine(q.Dequeue());
        Console.WriteLine(q.Peek());
        Console.WriteLine(q.Contains(3));
        q.Clear();
    }
}