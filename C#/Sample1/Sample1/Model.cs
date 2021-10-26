using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simphony.Simulation;

namespace Sample1
{
    public class Model : IModel
    {

        DiscreteEventEngine MyEngine;

        private List<IScenario> MyScenarios = new List<IScenario>();
        public Scenario MyScenario;


        #region [- Ctor -]
        public Model(DiscreteEventEngine myEngine)
        {
            MyEngine = myEngine;
            MyScenario = new Scenario(MyEngine, 1, 1);
            MyScenarios.Add(MyScenario);
        }

        #endregion

        public IEnumerable<IScenario> Scenarios => MyScenarios;

        public void FinalizeModel()
        {
            //throw new NotImplementedException();
        }

        public void InitializeModel()
        {
            //throw new NotImplementedException();
        }
    }
}
