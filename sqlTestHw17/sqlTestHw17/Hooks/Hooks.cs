using TechTalk.SpecFlow;

namespace sqlTestHw17
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _scenarioContext;

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            SQLConnecterHelper _sqlHelper = new SQLConnecterHelper();
            _sqlHelper.ConnectDataBase();
            _scenarioContext.Add("SqlHelper", _sqlHelper);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            SQLConnecterHelper _sqlHelper = _scenarioContext.Get<SQLConnecterHelper>("SqlHelper");
            _sqlHelper.CloseConnection();
        }
    }
}
