using AutoMapper;
using Fabian.Domurad.Golden.Card.Research.Data;
using Fabian.Domurad.Golden.Card.Research.Shared.Constant;
using Fabian.Domurad.Golden.Card.Research.Shared.CustomException;
using Fabian.Domurad.Golden.Card.Research.Shared.Enum;
using Fabian.Domurad.Golden.Card.Research.Shared.ViewModel;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Fabian.Domurad.Golden.Card.Research.BL.Base
{
    public abstract class BaseLogic<TExecution, TResult>
    {
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IMapper Mapper;
        private readonly ILogger _logger;

        protected BaseLogic(IUnitOfWork unitOfWork, IMapper mapper, ILogger logger)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
            _logger = logger;
        }

        protected async Task<ResultDto<TResult>> HandleExecutionAsync(Func<Task<TExecution>> execution)
        {
            try
            {
                var result = await execution();

                return new ResultDto<TResult>
                {
                    Data = Mapper.Map<TResult>(result),
                };
            }
            catch (BusinessLogicException ex)
            {
                _logger.LogError(ex.Message);
                return new ResultDto<TResult>
                {
                    Error = ex.Message,
                    Type = ex.Type
                };
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogError(ex.Message);

                return new ResultDto<TResult>
                {
                    Error = ErrorMessageConst.Default,
                    Type = ExceptionType.Forbidden
                };
            }
            catch (Exception ex)
            {
                do
                {
                    _logger.LogCritical(ex.Message);
                    ex = ex.InnerException;
                } while (ex != null);

                return new ResultDto<TResult>
                {
                    Error = ErrorMessageConst.Default,
                    Type = ExceptionType.InternalServerError
                };
            }
        }
    }
}
