using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Fabian.Domurad.Golden.Card.Research.Data;
using Fabian.Domurad.Golden.Card.Research.Shared.Dto;
using Fabian.Domurad.Golden.Card.Research.Shared.ViewModel;
using Microsoft.Extensions.Logging;

namespace Fabian.Domurad.Golden.Card.Research.BL.Base
{
    public abstract class BaseBusinessLogic<TExecution, TResult> : BaseLogic<TExecution, TResult>
    {
        protected BaseBusinessLogic(IUnitOfWork unitOfWork, IMapper mapper, ILogger logger) : base(unitOfWork, mapper, logger)
        {
        }

        protected abstract Task<TExecution> ExecutionAsync();

        public async Task<ResultDto<TResult>> ExecuteAsync()
        {
            return await HandleExecutionAsync(async () => await ExecutionAsync());
        }
    }

    public abstract class BaseBusinessLogic<TParam, TExecution, TResult> : BaseLogic<TExecution, TResult>
    {
        protected BaseBusinessLogic(IUnitOfWork unitOfWork, IMapper mapper, ILogger logger) : base(unitOfWork, mapper, logger) { }

        protected abstract IEnumerable<IValidator<TParam>> Validators { get; }

        protected abstract Task<TExecution> ExecutionAsync(TParam parameter);

        public async Task<ResultDto<TResult>> ExecuteAsync(TParam parameter)
        {
            return await HandleExecutionAsync(async () =>
            {
                foreach (var validator in Validators)
                {
                    validator.Validate(parameter);
                }

                return await ExecutionAsync(parameter);
            });
        }
    }
}
