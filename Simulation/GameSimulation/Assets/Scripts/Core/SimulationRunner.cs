using Assets.Scripts.Exceptions;
using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Core
{
    public class SimulationRunner
    {
        private readonly List<ISimulationService> _services =
            new List<ISimulationService>();

        public void AddService(ISimulationService service)
        {
            _services.Add(service);
        }

        public void Tick()
        {
            try
            {
                foreach (var service in _services)
                {
                    service.Update();
                }
            }
            catch (Exception ex)
            {
               
            }
        }
    }
}