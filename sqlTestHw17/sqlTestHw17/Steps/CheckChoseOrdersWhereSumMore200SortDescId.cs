using NUnit.Framework;
using System;
using System.Data;
using TechTalk.SpecFlow;

namespace sqlTestHw17
{
    [Binding]
    public class CheckChoseOrdersWhereSumMore200SortDescId
    {
        private SQLConnecterHelper _sqlHelper = (SQLConnecterHelper)ScenarioContext.Current["SqlHelper"];

        [When(@"I chose summ more than (.*) sort by DESC id in tables ""(.*)""")]
        public void WhenIChoseSummMoreThanSortByDESCIdInTables(int sumChose, string tableName)
        {
            string query = $"SELECT * FROM {tableName} " +
                           $"WHERE sumOrders> {sumChose} " +
                           $"Order by id DESC";
            DataTable responseTable = _sqlHelper.MakeQuery(query);
            ScenarioContext.Current["PersonsTable"] = responseTable;
            _sqlHelper.MakeQuery(query);
        }

        [Then(@"I see first Id more than last and sum more than (.*)")]
        public void ThenISeeFirstIdMoreThanLastAndSumMoreThan(int sumChose)
        {
            DataTable responseTable = (DataTable)ScenarioContext.Current["PersonsTable"];
            int numOfRows = responseTable.Rows.Count;
            bool checkResultatId = false;
            bool checkResultatSum = true;
            for (int i = 0; i < 2; i++)
            {
                string idFirst = responseTable.Rows[i]["Id"].ToString();
                int checkIdFirst = Convert.ToInt32(idFirst);
                string idLast = responseTable.Rows[numOfRows - 1]["Id"].ToString();
                int checkIdLast = Convert.ToInt32(idLast);
                if (checkIdFirst > checkIdLast) checkResultatId = true;
                else checkResultatId = false;

                string sumCheck = responseTable.Rows[i]["sumOrders"].ToString();
                double checkSum = Convert.ToDouble(sumCheck);
                Console.WriteLine(checkSum);
                if (checkSum > sumChose) checkResultatSum = true;
                else checkResultatSum = false;
            }

            Assert.AreEqual(expected: true, actual: checkResultatId);
            Assert.AreEqual(expected: true, actual: checkResultatSum);
        }
    }
}