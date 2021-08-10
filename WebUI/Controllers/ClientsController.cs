using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Auth.Application.Common.Interfaces;
using Ecommerce.Auth.Infrastructutre.Identity.EfRepository;
using IdentityServer4.EntityFramework.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Auth.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ClientsRepository _clientsRepository;
        public ClientsController(ClientsRepository clientsRepository)
        {
            _clientsRepository = clientsRepository ?? throw new ArgumentNullException(nameof(clientsRepository));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
           var clients = await _clientsRepository.GetAll();
           return Ok(clients);
        }

        [HttpGet("{clientId}")]
        public async Task<IActionResult> GetClientById(int clientId)
        {
            if (clientId == 0) throw new ArgumentNullException(nameof(clientId));

            var client = await _clientsRepository.GetByIdAsync(clientId);
            if(client == null) throw new ArgumentNullException(nameof(client));
            return Ok(clientId);
        }


    }
}
