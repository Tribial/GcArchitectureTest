using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Fabian.Domurad.Golden.Card.Research.Shared.ViewModel;

namespace Fabian.Domurad.Golden.Card.Research.BL.Base
{
    public interface IBusinessLogic<in TParam, TResult>
    {
        Task<ResultDto<TResult>> ExecuteAsync(TParam parameter);
    }

    public interface IBusinessLogic<TResult>
    {
        Task<ResultDto<TResult>> ExecuteAsync();
    }
}
