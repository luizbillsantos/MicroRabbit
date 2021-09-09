using MicroRabbit.Transfer.Application.Interfaces;
using MicroRabbit.Transfer.Domain.Interfaces;
using MicroRabbit.Transfer.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroRabbit.Transfer.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransferController : ControllerBase
    {

        private readonly ITransferService _transferService;
        private readonly IRedisRepository<TransferLog> _redisRepository;


        public TransferController(ITransferService transferService, IRedisRepository<TransferLog> redisRepository)
        {
            _transferService = transferService;
            _redisRepository = redisRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TransferLog>> Get()
        {
            var teste = new TransferLog
            {
                FromAccount = 1,
                ToAccount = 2,
                TransferAmount = 444.45M,
                Id = 1
            };
            _redisRepository.SetValueKey("Transfer", teste);

            return Ok(_transferService.GetTransfersLogs());
        }

        [HttpGet]
        [Route("GetCache")]
        public ActionResult<TransferLog> GetCache()
        {
            return Ok(_redisRepository.GetValueKey("Transfer"));
        }
    }
}
