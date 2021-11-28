using NUnit.Framework;
using System.Data;
using TechTalk.SpecFlow;

namespace sqlTestHw17
{
    [Binding]
    public class CheckCityWhereNameCityStartSan
    {
        private SQLConnecterHelper _sqlHelper = (SQLConnecterHelper)ScenarioContext.Current["SqlHelper"];

        [When(@"i chose in table ""(.*)"" all results, where name of city like ""(.*)""")]
        public void WhenIChoseInTableAllResultsWhereNameOfCityLike(string tableName, string cityName)
        {
            string query = $"SELECT * FROM {tableName} " +
               $"WHERE City LIKE '{cityName}%'";
            DataTable responseTable = _sqlHelper.MakeQuery(query);
            ScenarioContext.Current["PersonsTable"] = responseTable;
            _sqlHelper.MakeQuery(query);
        }

        [Then(@"i see city which start with ""(.*)""")]
        public void ThenISeeCityWhichStartWith(string cityName)
        {

            DataTable responseTable = (DataTable)ScenarioContext.Current["PersonsTable"];
            int numOfRows = responseTable.Rows.Count;
            bool checkResultat = false;
            for (int i = 0; i < numOfRows; i++)
            {
                string city = responseTable.Rows[i]["City"].ToString();
                checkResultat = city.Contains(cityName);
            }
            Assert.AreEqual(expected: true, actual: checkResultat);
        }
    }
}