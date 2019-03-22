using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExpressionsMultipleParams
{
    #region SimpleMath (with delegates)
    public class SimpleMath
    {
        public delegate void MathMessage( string msg, int result );
        private MathMessage mathMessageDelegate;

        public void SetMathHandler( MathMessage target )
        {
            mathMessageDelegate = target;
        }

        public void Add(int x, int y)
        {
            mathMessageDelegate?.Invoke("Adding has completed!", x + y);
        }

    }
    #endregion

    class LambdaExpressionsMultipleParamsProgram
    {
        static void Main( string[] args )
        {
            // Register w/ delegate as a lambda expression.
            SimpleMath m = new SimpleMath();
            m.SetMathHandler((msg, result) =>
                { Console.WriteLine("Lambda Message: {0}, Result: {1}", msg, result); });

            // This will execute the lambda expression.
            m.Add(10, 10);

            m.SetMathHandler(delegate (string msg, int result) 
                { Console.WriteLine("Anonymous Delegate Message: {0}, Result: {1}", msg, result); });
            m.Add(11, 11);

            m.SetMathHandler(ShowResult);
            m.Add(12, 12);
            Console.ReadLine();
        }

        static void ShowResult(string message, int result)
        {
            Console.WriteLine("ShowResult Message: {0}, Result: {1}", message, result);
        }

    }
}
