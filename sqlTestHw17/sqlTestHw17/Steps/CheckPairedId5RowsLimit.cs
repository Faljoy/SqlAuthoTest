using NUnit.Framework;
using System;
using System.Data;
using TechTalk.SpecFlow;

namespace sqlTestHw17
{
    [Binding]
    public class CheckPairedId5RowsLimit
    {
        private SQLConnecterHelper _sqlHelper = (SQLConnecterHelper)ScenarioContext.Current["SqlHelper"];

        [When(@"I chose paired id, limit output (.*) rows in table ""(.*)""")]
        public void WhenIChosePairedIdLimitOutputRowsInTable(int countRows, string tableName)
        {
            string query = $"SELECT TOP {countRows} * FROM {tableName} " +
              $"WHERE ID% 2 = 0";
            DataTable responseTable = _sqlHelper.MakeQuery(query);
            ScenarioContext.Current["PersonsTable"] = responseTable;
            _sqlHelper.MakeQuery(query);
        }

        [Then(@"I see paired Id and Limit (.*) rows")]
        public void ThenISeePairedIdAndLimitRows(int countRows)
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
    }
}