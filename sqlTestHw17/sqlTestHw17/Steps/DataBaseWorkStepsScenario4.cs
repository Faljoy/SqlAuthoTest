using NUnit.Framework;
using System;
using System.Data;
using TechTalk.SpecFlow;

namespace sqlTestHw17
{
    [Binding]
    public class DataBaseWorkSteps4
    {
        private SQLConnecterHelper _sqlHelper = (SQLConnecterHelper)ScenarioContext.Current["SqlHelper"];

        //[When(@"я выбираю в таблице ""(.*)"" все результаты, где название города начинается с ""(.*)""")]
        //public void WhenЯВыбираюВТаблицеВсеРезультатыГдеНазваниеГородаНачинаетсяС(string tableName, string nameOfCity)
        //{
        //    string query = string.Format($"SELECT * FROM {tableName}" +
        //        $"WHERE City LIKE '{nameOfCity}%' ");
        //    DataTable responseTable = _sqlHelper.MakeQuery(query);
        //    ScenarioContext.Current["PersonsTable"] = responseTable;
        //    _sqlHelper.MakeQuery(query);
        //}

        //[Then(@"я вижу города которые начинаються с ""(.*)""")]
        //public void ThenЯВижуГородаКоторыеНачинаютьсяС(string nameOfCity)
        //{
        //    DataTable responseTable = (DataTable)ScenarioContext.Current["PersonsTable"];
        //    int numOfRows = responseTable.Rows.Count;
        //    bool checkResultat = false;
        //    for (int i = 0; i < numOfRows; i++)
        //    {
        //        string city = responseTable.Rows[i]["City"].ToString();
        //        checkResultat = nameOfCity.Contains(city);
        //    }
        //    Assert.AreEqual(expected: true, actual: checkResultat);
        //}

        //[When(@"я выбираю в таблице ""(.*)"" все результаты, где возраст покупателей больше (.*)")]
        //public void WhenЯВыбираюВТаблицеВсеРезультатыГдеВозрастПокупателейБольше(string tableName, int ageFirst)
        //{
        //    int ageSecond = 50;
        //    string query = $"SELECT * FROM {tableName} " +
        //        $"WHERE Age> {ageFirst} " +
        //        $"AND Age<{ageSecond}";
        //    DataTable responseTable = _sqlHelper.MakeQuery(query);
        //    ScenarioContext.Current["PersonsTable"] = responseTable;
        //    _sqlHelper.MakeQuery(query);
        //}
        [When(@"я выбираю в таблице ""(.*)"" все результаты, где возраст покупателей меньше (.*) и больше (.*)")]
        public void WhenЯВыбираюВТаблицеВсеРезультатыГдеВозрастПокупателейМеньшеИБольше(string tableName, int ageSecond, int ageFirst)
        {
            string query = $"SELECT * FROM {tableName} " +
                $"WHERE Age> {ageFirst} " +
                $"AND Age<{ageSecond}";
            DataTable responseTable = _sqlHelper.MakeQuery(query);
            ScenarioContext.Current["PersonsTable"] = responseTable;
            _sqlHelper.MakeQuery(query);
        }


        [Then(@"я вижу покупателей с возрастом больше (.*)")]
        public void ThenЯВижуПокупателейСВозрастомБольше(int age)
        {
            DataTable responseTable = (DataTable)ScenarioContext.Current["PersonsTable"];
            int numOfRows = responseTable.Rows.Count;
            bool checkResultat = false;
            for (int i = 0; i < numOfRows; i++)
            {
                string agePersons = responseTable.Rows[i]["Age"].ToString();
                int ageResult = Convert.ToInt32(agePersons);
                checkResultat = ageResult > 30;
                checkResultat = ageResult < 50;
            }
            Assert.AreEqual(expected: true, actual: checkResultat);
        }
    }
}
