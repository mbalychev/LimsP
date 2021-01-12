using LimsP.Quiryng;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimsP.Units
{
    class UnitPrm5 : Unit, IUnit
    {
        public UnitPrm5(limsprodEntities _limsprodEntities, string parsingStr) : base(_limsprodEntities, parsingStr)
        {
            PasrsingUnitStr();
            GetResult();
        }

        public void PasrsingUnitStr()
        {
            string[] parameters;
            parameters = ParsingStr.Split(';');
            X_Process_Unit = parameters[0];
            LimsCode = ParsingLimsCode(parameters[3]);
            Product = parameters[1];
            Sampling_Point = parameters[2];
            Name = parameters[4];
        }

        public void GetResult()
        {
            Result result = new FindLast(this, limsprodEntities);
            this.Result = result;
        }
    }
}
