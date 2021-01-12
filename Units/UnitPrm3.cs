using LimsP.Quiryng;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimsP.Units
{
    class UnitPrm3 : Unit, IUnit
    {
        //класс для работы со строками 
        //типа ЭЛОУ-АВТ-3--08:00--ФРАК_НК160--ЛИНИЯ-15--%;235;конец кипения бензина, °C
        //в файле Units
        public UnitPrm3(limsprodEntities _limsprodEntities, string parsingStr) : base(_limsprodEntities, parsingStr)
        {
            PasrsingUnitStr();
            GetResult();
        }

        public void PasrsingUnitStr()
        {
            string[] parameters;
            parameters = ParsingStr.Split(';');
            Text_Id = parameters[0];
            LimsCode = ParsingLimsCode(parameters[1]);
            Name = parameters[2];
        }

        public void GetResult()
        {
            Result result = new FindByTextId(this, limsprodEntities);
            this.Result = result;
        }
    }
}
