using ConexaoCodeFirst.Data;
using ConexaoCodeFirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConexaoCodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }



        [HttpGet("Clients")]
        public async Task<List<Client>> getClients()
        {
            var clients = await _context.Clients.ToListAsync();
            return clients;
        }


        [HttpPost("addClient")]
        public async Task<IActionResult> AddClient(Client client)
        {
            if (client.Id == 0)
            {
                await this._context.Clients.AddAsync(client);
            }
            else
            {
                var dsclient = await _context.Clients.FindAsync(client.Id);
                if (dsclient != null)
                {
                    dsclient.FullName = client.FullName;
                    dsclient.Income = client.Income;
                    dsclient.Cpf = client.Cpf;
                    dsclient.BirthDate = client.BirthDate;
                }

            }
            await this._context.SaveChangesAsync();
            return Content("Usuário Criado");
        }


        [HttpPut("editClient")]
        public async Task<IActionResult> EditClient(int id)
        {
            Client client = new Client();
            client = await _context.Clients.FirstOrDefaultAsync(x => x.Id == id) ?? new Client();
            return Content("Usuário Atualizado");
        }

        [HttpDelete("deleteClient")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            Client client = new Client();
            client = await _context.Clients.FindAsync(id) ?? new Client();
            if (client != null)
            {
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
            }
            return Content("Usuário Removido");
        }



    }
}

