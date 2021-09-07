using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadQueue
{
    public interface IJobExecutor
    {
        int Ammount { get; }

        void Start(int maxConcurrent);

        void Add(Action action);

        void Clear();

    }
}
