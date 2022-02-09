namespace TechTalkDemo.UnitTests.Repositories
{
    public interface ITaxRepository
    {
        void SaveQuery(double grossSalary, double tax);
    }
}