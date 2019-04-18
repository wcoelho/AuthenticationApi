using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using AuthenticationApi.Models;
using AuthenticationApi.Utils;

namespace AuthenticationApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly AuthenticationContext _context;

        public AuthenticationController(AuthenticationContext context)
        {
            _context = context;

            if (_context.AuthenticationItems.Count() == 0)
            {
                // Adiciona credenciais de usuários
                CommonOperations.AddAuthItems(context);
            }
        }
        // GET: api/v1/Authentication
        // Lista usuários cadastrados, ocultando o password
        [HttpGet]
        public string GetAuthenticationItems()
        {
            var list = _context.AuthenticationItems;
            var output = new List<AuthenticationItem>();
            foreach (var item in list)
            {
                item.Password="";
                output.Add(item);
            }
            return JsonConvert.SerializeObject(output);  
        }

        // POST: api/v1/Authentication
        // Efetua a validação do usuário
        [HttpPost]
        public string ExecuteAuthentication(AuthenticationItem authItem)
        {

            var authenticationItem = _context.AuthenticationItems.Find(authItem.Id);

            if(authenticationItem==null)
            {
                return JsonConvert.SerializeObject(new {result = false, message = "Usuário não encontrado"});
            }

            var name = authenticationItem.UserName;

            if(!authItem.UserName.Equals(name))
            {
                return JsonConvert.SerializeObject(new {result = false, message = "Nome do usuário não confere"});
            }

            var encPassword = authenticationItem.Password;

            if(!authItem.Password.Equals(encPassword))
            {
                return JsonConvert.SerializeObject(new {result = false, message = "Senha não confere"});
            }

            return JsonConvert.SerializeObject(new {result = true, Mensagem = "Usuário validado com sucesso"});
        }

    }  

}