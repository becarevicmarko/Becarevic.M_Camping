using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Becarevic.M_Camping.Models.db
{
    interface IReservierung
    {

        void Open();

        void Close();

        bool Insert(Reservierung reservierung);
    }
}
