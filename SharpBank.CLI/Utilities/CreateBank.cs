using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpBank.CLI.Controllers;

namespace SharpBank.CLI.Utilities
{
    public static class CreateBank
    {
        //BanksController
        public static void CustomBanks(BanksController banksController)
        {
            banksController.CreateBank("Axis");
            banksController.CreateBank("CANARA");
            banksController.CreateBank("HDFC");
        }

    }
}
