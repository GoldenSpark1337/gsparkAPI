using gspark.Domain.Models;

namespace gspark.Service.Contract;

public interface IRecordLabelRepository
{
    Task<RecordLabel> GetRecordLabel(int id);
    Task<IReadOnlyList<RecordLabel>> GetAllRecordLabels();
    Task<int> AddRecordLabel(RecordLabel recordLabel);
}