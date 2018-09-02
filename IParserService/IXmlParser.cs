using IParserService.Models;

namespace IParserService
{
    public interface IXmlParser
    {
        BaseModel<Expense> GetExpense(string emailContent);
    }
}
