using NUnit.Framework;
using System;
using System.Data;
using TechTalk.SpecFlow;

namespace sqlTestHw17
{
    [Binding]
    public class DataBaseWorkSteps
    {
        private SQLConnecterHelper _sqlHelper = (SQLConnecterHelper)ScenarioContext.Current["SqlHelper"];

        [When(@"я выбираю парные значения aйди, ограничиваю выведение (.*) строками в таблице ""(.*)""")]
        public void WhenЯВыбираюПарныеЗначенияAйдиОграничиваюВыведениеСтрокамиВТаблице(int countRows, string tableName)
        {
            string query = $"SELECT TOP {countRows} * FROM {tableName} " +
               $"WHERE ID% 2 = 0";
            DataTable responseTable = _sqlHelper.MakeQuery(query);
            ScenarioContext.Current["PersonsTable"] = responseTable;
            _sqlHelper.MakeQuery(query);
        }

        [Then(@"я вижу парные айди и только (.*) строк")]
        public void ThenЯВижуПарныеАйдиИТолькоСтрок(int countRows)
        {
            DataTable responseTable = (DataTable)ScenarioContext.Current["PersonsTable"];
            int numOfRows = responseTable.Rows.Count;
            bool checkResultat = false;
            for (int i = 0; i < 2; i++)
            {
                string id = responseTable.Rows[i]["Id"].ToString();
                int checkId = Convert.ToInt32(id);
                if (checkId % 2 == 0) checkResultat = true;
                else checkResultat = false;
            }
            Assert.AreEqual(expected: true, actual: checkResultat);
            Assert.AreEqual(expected: countRows, actual: numOfRows);
        }

        //[When(@"I crate row in table ""(.*)"" with data")]
        //public void WhenICreateRowInTableWithData(string tableName, Table table)
        //{
        //    string query = $"INSERT INTO {tableName} (AuthorName, PublishDate) " +
        //        $"VALUES ('{table.Rows[0]["AuthorName"]}', '{table.Rows[0]["PublishDate"]}')";
        //    _sqlHelper.MakeQuery(query);
        //}
        //[Then(@"Table contains data")]
        //public void ThenTableContainsData(Table table)
        //{
        //    DataTable responseTable = (DataTable)ScenarioContext.Current["AuthorsTable"];
        //    int numOfRows = responseTable.Rows.Count;
        //    string lastAuthors = responseTable.Rows[numOfRows - 1]["AuthorName"].ToString();
        //    Assert.AreEqual(lastAuthors, table.Rows[0]["AuthorName"]);
        //}
    }
}
