using System;
using System.Collections.Generic;
using System.Text;

namespace EriteLib
{
    internal class EnergiaTarve
    {
        // lammitysenergiaan vaikuttavat
        public double Aurinko { get; set; }
        public double VaipanHavio { get; set; }
        public double LampoKuorma { get; set; }

        // private?

        // getters for lammitysenergia, laitesahko?
        // Oletus: kaikki tilat lampiaa samalla systeemilla
        internal double GetHeatingEnergyNeedAnnual()
        {
            throw new NotImplementedException();
        }


    }
}
