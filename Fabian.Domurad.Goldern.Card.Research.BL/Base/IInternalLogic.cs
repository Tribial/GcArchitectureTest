using System.Threading.Tasks;

namespace Fabian.Domurad.Golden.Card.Research.BL.Base
{
    public interface IInternalLogic<TResult>
    {
        Task<TResult> ExecuteAsync();
        TResult Execute();
    }

    public interface IInternalLogic<in TParam, TResult>
    {
        Task<TResult> ExecuteAsync(TParam param);
        TResult Execute(TParam param);
    }
}
