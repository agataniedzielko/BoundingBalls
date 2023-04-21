using System;
using System.Collections.Generic;
using System.Text;

namespace BBDemo
{
    public class SimulationBox
    {
        private IAlgo algoritm;
        private BBox bbox;

        
        public SimulationBox(BBox bb, IAlgo algo)
        {
            bbox = bb;
            algoritm = algo;
        }

        public void NextStep()
        {
            algoritm.NextStep(bbox);
        }
    }
}
