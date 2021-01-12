using LimsP.Quiryng;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimsP.Units
{

    /// <summary>
    /// абстрактный класс всех юнитов (описание общих св-в классов)
    /// </summary>
    abstract class Unit
    {
        public string X_Process_Unit { get; set; }  //поле в БД
        public int LimsCode { get; set; }   //код лимс для передачи в ексель
        public string Product { get; set; } //поле в БД
        public string Sampling_Point { get; set; }  //поле в БД
        public string Name { get; set; }    //поле в БД
        public string Error { get; set; }   //описание ошибки
        public int? Sample_Number { get; set; } //поле в БД
        public System.DateTime? Entered_on { get; set; }    //поле в БД
        public double Formatted_entry { get; set; }    //поле в БД, результат в double
        public string Formatted_entryStr { get; set; }  //результат в стр значении
        public DateTime? Sampled_Date { get; set; } //поле в БД
        protected limsprodEntities limsprodEntities { get; set; }   //ссылка на соеденение
        public DateTime Stop { get; set; }   //дата нач поиска в БД
        public bool ContinueSearch { get; set; } //поиск с продолжением (если не найден образец за вчера - ищем за предидущие дни)
        public string Text_Id { get; set; }    //поле в БД
        public string ParsingStr { get; set; }  //строка в файле units

        protected Result result;
        public Result Result 
        {
            get => result;
            set
            {
                result = value;
                Formatted_entry = result.Formatted_entry;
            }
        }


        public Unit(limsprodEntities _limsprodEntities, string parsingStr)
        {
            limsprodEntities = _limsprodEntities;
            ParsingStr = parsingStr;
            Stop = Program.DateSearch;
            ChkContinueSearch();
        }
        protected int ParsingLimsCode(string codeStr)
        {
            int code = 0;
            try
            {
                code = Convert.ToInt32(codeStr);
            }
            catch (Exception)
            {
                Error += "ошибка инициализации (код лимс - не число) " + codeStr;
            }
            return code;
        }
        private void ChkContinueSearch()
        {
            //проверка на поиск с продолжением
            if (ParsingStr.Contains("@"))
            {
                ContinueSearch = true;
                ParsingStr = ParsingStr.Replace("@", null);
            }
        }


    }
}
