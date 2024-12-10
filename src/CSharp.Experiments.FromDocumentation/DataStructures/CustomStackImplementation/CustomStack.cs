namespace CSharp.Experiments.FromDocumentation.DataStructures.CustomStackImplementation;

// A stack is a linear data structure that operates on a Last In First Out (LIFO) principle,
// where the most recently added element is the first to be removed.
public sealed class CustomStack<T>
{
    private T[] items;
    private int currentIndex = -1;

    public CustomStack(int capacity = 100)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(capacity);
        this.items = new T[capacity];
    }

    public bool IsEmpty => this.currentIndex < 0;

    public void Push(T item)
    {
        if (this.currentIndex == this.items.Length - 1)
        {
            Array.Resize(ref this.items, this.items.Length * 2);
        }

        this.items[++this.currentIndex] = item;
    }

    public T Pop()
    {
        if (this.currentIndex < 0)
        {
            throw new InvalidOperationException("Stack is empty.");
        }

        return this.items[this.currentIndex--];
    }

    public T Peek()
    {
        if (this.currentIndex < 0)
        {
            throw new InvalidOperationException("Stack is empty.");
        }

        return this.items[this.currentIndex];
    }
}
