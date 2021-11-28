using NUnit.Framework;
using System;
using System.Data;
using TechTalk.SpecFlow;

namespace sqlTestHw17
{
    [Binding]
    public class CheckAgeMoreThan30AndLessThan50
    {
        private SQLConnecterHelper _sqlHelper = (SQLConnecterHelper)ScenarioContext.Current["SqlHelper"];

        [When(@"I chose in table ""(.*)"" all resultat, where age less than (.*) and more than (.*)")]
        public void WhenIChoseInTableAllResultatWhereAgeLessThanAndMoreThan(string tableName, int ageSecond, int ageFirst)
        {
            string query = $"SELECT * FROM {tableName} " +
                $"WHERE Age> {ageFirst} " +
                $"AND Age<{ageSecond}";
            DataTable responseTable = _sqlHelper.MakeQuery(query);
            ScenarioContext.Current["PersonsTable"] = responseTable;
            _sqlHelper.MakeQuery(query);
        }

        [Then(@"I see customers whose age more than (.*) and less than (.*)")]
        public void ThenISeeCustomersWhoseAgeMoreThanAndLessThan(int ageMore, int ageLess)
        {
            DataTable responseTable = (DataTable)ScenarioContext.Current["PersonsTable"];
            int numOfRows = responseTable.Rows.Count;
            bool checkResultat = false;
            for (int i = 0; i < numOfRows; i++)
            {
                string agePersons = responseTable.Rows[i]["Age"].ToString();
                int ageResult = Convert.ToInt32(agePersons);
                checkResultat = ageResult > ageMore;
                checkResultat = ageResult < ageLess;
            }
            Assert.AreEqual(expected: true, actual: checkResultat);
        }
    }
}