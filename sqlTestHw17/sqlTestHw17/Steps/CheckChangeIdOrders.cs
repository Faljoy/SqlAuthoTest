using NUnit.Framework;
using System;
using System.Data;
using TechTalk.SpecFlow;

namespace sqlTestHw17
{
    [Binding]
    public class CheckChangeIdOrders
    {
        private SQLConnecterHelper _sqlHelper = (SQLConnecterHelper)ScenarioContext.Current["SqlHelper"];

        public static int ValueId()
        {
            Random rnd = new Random();
            int valueId = rnd.Next(1, 20);
            return valueId;
        }
        public static int idOrders = ValueId();

        [When(@"I change idOrders in table ""(.*)"" on random amount where id (.*) and sum (.*)")]
        public void WhenIChangeIdOrdersInTableOnRandomAmountWhereIdAndSum(string tableName, int Id, Decimal sumChose)
        {
            Random rnd = new Random();
            string query = $"UPDATE Orders " +
                $"SET idOrders = {idOrders}" +
                $"WHERE Id = {Id} " +
                $"AND sumOrders = {sumChose}";
            DataTable responseTable = _sqlHelper.MakeQuery(query);
            ScenarioContext.Current["OrdersTable"] = responseTable;
            _sqlHelper.MakeQuery(query);
        }

        [Then(@"I see idOrders with new value, where id (.*) and sum (.*)")]
        public void ThenISeeIdOrdersWithNewValueWhereIdAndSum(int Id, Decimal sumChose)
        {
            DataTable responseTable = (DataTable)ScenarioContext.Current["OrdersTable"];
            //int numOfRows = responseTable.Rows.Count;
            string query = $"SELECT * FROM Orders " +
                $"WHERE Id = {Id} " +
                $"AND sumOrders = {sumChose}";
            responseTable = _sqlHelper.MakeQuery(query);
            ScenarioContext.Current["OrdersTable"] = responseTable;
            Assert.AreEqual(expected: idOrders.ToString(), actual: responseTable.Rows[0]["idOrders"].ToString());
        }
    }
}