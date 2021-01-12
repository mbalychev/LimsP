using LimsP.Quiryng;
using org.mariuszgromada.math.mxparser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimsP.Units
{

    /// <summary>
    /// описание вычисляемого класса (юнита) 
    /// где результат  получается из нескольких простых юнитов
    /// формуа вычисления парсится из файла настроеек Formuls.txt
    /// </summary>

    class UnitCalc : Unit
    {
        string formulaWithCodes { get; set; }
        string formulaWithValues { get; set; }

        public UnitCalc(limsprodEntities _limsprodEntities, string parsingStr) : base (_limsprodEntities, parsingStr)
        {
            PasrsingUnitStr();
            ParsingFormula();
            ReplaceUnitsToValue();
            if (!ChkForSkip())
                CalculateFormula();
            else
                Formatted_entry = 0.0001;

            Console.WriteLine("\nCalc LimsCode_" + LimsCode);
            Console.WriteLine("str parsing - " + formulaWithCodes);
            Console.WriteLine("str values - " + formulaWithValues + " = " + Formatted_entry.ToString());

        }


        public void PasrsingUnitStr()
        {
            string[] parameters;
            parameters = ParsingStr.Split('%');
            LimsCode = ParsingLimsCode(parameters[0]);
        }

        private void ParsingFormula()
        {
            string[] parameters;
            parameters = ParsingStr.Split('%');
            formulaWithCodes  = parameters[1];
            formulaWithValues = formulaWithCodes;
        }

        //выделяет коды юнитов из формулы
        private void ReplaceUnitsToValue()
        {

            char[] charSplit = { '+', '-', '*', '/', '(', ')' };
            string[] units = formulaWithCodes.Split(charSplit).Where(x => x.Length != 0 && x.First() != 'v').ToArray();  //исключим значения с знаком v  т.к. это значение типа double, а не код лимс

            foreach (string unit in units)    
            {
                formulaWithValues = formulaWithValues.Replace(unit, GetResult(unit).ToString());
            }

            formulaWithValues = formulaWithValues.Replace("v", "");
        }

        private double GetResult(string limsCodeStr)
        {
            int limsCode;
            bool chk = int.TryParse(limsCodeStr, out limsCode);
            if (chk)
            {
                Unit unit = Program.Units.Where(u => u.LimsCode == limsCode).FirstOrDefault();
                return unit.Formatted_entry;
            }
            else
            {
                Error = "не удалось преобразовать в лимс код значение " + limsCodeStr;
                return 0.0001;  //значение прочерк для Галактики, т.е. неопределено
            }
        }

        //вычисление формулы (где вместо кодов - результаты)
        void CalculateFormula()
        {
            double result = 0;
            Expression expression = new Expression(formulaWithValues);
            try
            {
                result = expression.calculate();
            }
            catch (Exception ex)
            {
                Error += ex.Message;
            }

            Formatted_entry = Math.Round(result, 3);


        }

        bool ChkForSkip()
        {
            if (formulaWithValues.Contains("0.0001"))
                return true;
            else
                return false;
        }

    }
}
