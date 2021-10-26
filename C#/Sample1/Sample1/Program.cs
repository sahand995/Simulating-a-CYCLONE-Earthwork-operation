using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simphony.Simulation;

namespace Sample1
{
    class Program
    {
        static void Main(string[] args)
        {

            DiscreteEventEngine MyEngine = new DiscreteEventEngine();

            Model MyModel = new Model(MyEngine);

            //Initializations
            MyEngine.InitializeEngine();
            MyEngine.Simulate(MyModel);


            //Print Details
            Console.WriteLine("Large Trucks: ");
            for (int i = 0; i < MyModel.MyScenario.ObservationForLargeTrucks.Count; i++)
            {
                Console.WriteLine("{0} = {1} min", i + 1, MyModel.MyScenario.ObservationForLargeTrucks[i]);
            }

            Console.WriteLine("\nSmall Trucks: ");
            for (int i = 0; i < MyModel.MyScenario.ObservationForSmallTrucks.Count; i++)
            {
                Console.WriteLine("{0} = {1} min", i + 1, MyModel.MyScenario.ObservationForSmallTrucks[i]);
            }

            Console.WriteLine("\nMean = {0} ", MyModel.MyScenario.Mean);
            Console.ReadKey();
        }


    }



}
