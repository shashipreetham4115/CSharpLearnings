namespace HandCricketGame.Util
{
    public class Pair<T>
    {
        public T first;
        public T second;

        public Pair(T first, T second)
        {
            this.first = first;
            this.second = second;
        }
    }

    public class Pair<A, B>
    {
        public A first;
        public B second;
        
        public Pair(A first, B second) 
        {
            this.first = first;
            this.second = second;
        }
    }
}
