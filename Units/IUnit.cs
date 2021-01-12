using LimsP.Quiryng;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimsP.Units
{
    //описание общих св-в юнитов (вычисляемы и простых)
    interface IUnit
    {
        void PasrsingUnitStr();
        void GetResult();
    }
}
