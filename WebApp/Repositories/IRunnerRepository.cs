using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Repositories
{
    interface IRunnerRepository
    {
        IEnumerable<Runner> Runners { get; }

        void AddRunner(Runner runner);

        void EditRunner(Runner runner);

        void DeleteRunner(Runner runner);

        Runner GetRunnerId(int runnerId);
    }
}
