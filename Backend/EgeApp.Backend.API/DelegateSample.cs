namespace EgeApp.Backend.API
{
    public class DelegateSample
    {
        public delegate int Operation(int a, int b);
        public int Topla(int a, int b)
        {
            return a + b;
        }
        public int Carp(int a, int b)
        {
            return a * b;
        }
        public void Uygula()
        {
            Operation op = Topla;
            int result = op(3, 5);

            op = Carp;
            int result2 = op(3, 7);
        }
    }
}
