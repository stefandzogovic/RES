using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class ModelFactory
    {
        public Model CreateNewModel(int id)
        {
            return new Model(id);
        }
    }
}
