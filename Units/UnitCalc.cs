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

    class UnitCalc : Unit, IUnit
    {
        List<UnitSimple> UnitsSimple { get; set; }
        string strForParse { get; set; }
        string formulaWithCodes { get; set; }
        string formulaWithValues { get; set; }

        /// <param name="_stop">дата послед.результата</param>
        /// <param name="_limsprodEntities">ссылка на поделючение к БД</param>
        /// <param name="_strForParse">строка для парсинга с формулой из файла</param>
        public UnitCalc(DateTime _stop, limsprodEntities _limsprodEntities, string _strForParse)
        {
            stop = _stop;
            strForParse = _strForParse;
            limsprodEntities = _limsprodEntities;

            KeyValuePair<int, string> codeWithUnits = SeparateLimsCode(strForParse);
            LimsCode = codeWithUnits.Key;
            formulaWithCodes = codeWithUnits.Value;
            string[] unitsForCalc = SeparateUnits(codeWithUnits.Value);
            List<KeyValuePair<int, double>> unitsValues = GetUnitsValue(unitsForCalc);
            Formatted_entry = Math.Round(CalculateFormula(unitsValues), 2);
        }

        //отделяет код от формулы
        KeyValuePair<int, string> SeparateLimsCode(string strFormula)
        {
            string[] str = strFormula.Split('%');
            int limsCode = 0;

            if (!int.TryParse(str[0], out limsCode))
            {
                Error += strFormula + " ошибка лимс-кода в строке формулы";
            }
            return new KeyValuePair<int, string>(limsCode, str[1]);
        }

        //выделяет юниты из формулы
        string[] SeparateUnits(string formula)
        {
            char[] charSplit = { '+', '-', '*', '/', '(', ')' };
            string[] units = formula.Split(charSplit).Where(x => x.Length != 0 && x.First() != 'v').ToArray();

            return units;
        }

        //вычисляет результат исследования для каждого юнита
        List<KeyValuePair<int, double>> GetUnitsValue(string[] unitsCodes)
        {
            List<KeyValuePair<int, double>> keyValues = new List<KeyValuePair<int, double>>();
            this.UnitsSimple = new List<UnitSimple>();

            foreach (string unitCode in unitsCodes)
            {
                int code = 0;
                string unitStr = unitCode;
                code = Convert.ToInt32(unitStr);
                UnitSimple unit = Program.UnitsSimple.Where(x => x.LimsCode == code).FirstOrDefault();
                if (unit != null)
                {
                    Result result = new Result(unit, stop, limsprodEntities);
                    double formatted_entry = result.Formatted_entry;
                    keyValues.Add(new KeyValuePair<int, double>(code, result.Formatted_entry));
                    this.UnitsSimple.Add(unit);
                }
                else
                {
                    Error += unitCode + " результат не получен " + Environment.NewLine;
                }
            }
            return keyValues;
        }

        //вычисление формулы (где вместо кодов - результаты)
        double CalculateFormula(List<KeyValuePair<int, double>> unitsValue)
        {
            string stringForCalc = formulaWithCodes.Replace("v", null); //удалим символ v, т.к. это числовое значение формулы, а не рузультат исследования
            double result = 0;

            foreach (KeyValuePair<int, double> unitValue in unitsValue)
            {
                stringForCalc = stringForCalc.Replace(unitValue.Key.ToString(), unitValue.Value.ToString());
                stringForCalc = stringForCalc.Replace("v", null);
            }
            Expression expression = new Expression(stringForCalc);
            try
            {
                result = expression.calculate();
            }
            catch (Exception ex)
            {
                Error += ex.Message;
            }

            return result;
        }
    }
}
