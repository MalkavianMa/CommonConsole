using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    abstract class Strategy
    {
        // Methods
        abstract public void AlgorithmInterface();
    }

    class ConcreteStrategyA : Strategy
    {
        // Methods
        override public void AlgorithmInterface()
        {
            Console.WriteLine("Called ConcreteStrategyA.AlgorithmInterface()");
        }
    }

    // "ConcreteStrategyB"
    class ConcreteStrategyB : Strategy
    {
        // Methods
        override public void AlgorithmInterface()
        {
            Console.WriteLine("Called ConcreteStrategyB.AlgorithmInterface()");
        }
    }


    // "ConcreteStrategyC"
    class ConcreteStrategyC : Strategy
    {
        // Methods
        override public void AlgorithmInterface()
        {
            Console.WriteLine("Called ConcreteStrategyC.AlgorithmInterface()");
        }
    }

    // "Context"
    class Context
    {
        // Fields
        Strategy strategy;

        // Constructors
        public Context(Strategy strategy)
        {
            this.strategy = strategy;
        }

        // Methods
        public void ContextInterface()
        {
            strategy.AlgorithmInterface();
        }
    }
}
