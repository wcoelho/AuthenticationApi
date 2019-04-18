# Authentication API  
API para autenticar usuário e senha.  

## End Points  
* GET /api/v1/Authentication = Recupera todos os usuários cadastrados, ocultando a senha.  
* POST /api/v1/Authentication = Efetua a validação do usuário.  
  
Requisição:  
{  
	"Id": number,  
	"UserName": "string",  
	"Password": "string"  
}   
  
Respostas:  
* Validação bem sucedida  
  
{"result":true,"message":"Usuário validado com sucesso"}  
  
* Usuário inválido  
  
{"result":false,"message":"Nome do usuário não confere"}  
  
* Senha inválida  
  
{"result":false,"message":"Senha não confere"}  
  
## Testes Unitários
Utilzar a Postman Collection em Postman/postman_collection.json.  
  
**Testes**  
* Recupera lista de usuários sem apresentar a senha.  
* Efetua a validação de usuário e senha corretamente.  
* Efetua a tentativa de validação de usuário incorreto.  
* Efetua a tentativa de validação de senha incorreta.  
  
**Registros para Testes**  
{  
	"Id": N,  
	"UserName": userN,  
	"Password": userpwdN  
}  
  
Onde N varia de 1 a 10.  
  
Exemplo:  
{  
	"Id": 1,  
	"UserName": user1,  
	"Password": userpwd1    
}  
  
## Documentação  
Estando a aplicação em execução, acesse a URL:  
https://localhost:5001/swagger/v1/swagger.json
