using Fabian.Domurad.Golden.Card.Research.Shared.Enum;

namespace Fabian.Domurad.Golden.Card.Research.Shared.ViewModel
{
    public class ResultDto<T>
    {
        public T Data { get; set; }
        public string Error { get; set; }
        public bool ErrorOccurred => !string.IsNullOrWhiteSpace(Error);
        public ExceptionType Type { get; set; }
    }
}
