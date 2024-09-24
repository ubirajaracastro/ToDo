ToDo List tem o back end na pasta scr\Back e o FrontEnd na respectiva pasta Front.

O backend está separadas com as camadas Api, camada service, camada de domínio e camada de persistencia.
Verificações para subir o projeto:

![image](https://github.com/user-attachments/assets/7ef427a5-cd00-4a0b-ba22-1949352c36b3)


FrontEnd:
![image](https://github.com/user-attachments/assets/7f285d40-4b50-4892-b33d-cc4c035dd7e0)


Ajustar a string de conexao da base na seção do arquivo appsettings.Development.json

{
  "ConnectionStrings": {
  "DefaultConnection": "Server=DESKTOP-7GFSE0V;Database=DbTask;Trusted_Connection=True;Encrypt=False;"
},

Rodar a migração do EF Core para criar a base e tabela ToDo

dotnet ef migrations add Initial -p ToDoListPersistencia -s ToDoListApi
dotnet ef database update -s ToDoListApi

No Front ajustar se necessário a apiUrl da api no ToDoController  
  string apiUrl = "http://localhost:5072/api/ToDo";

Acessar o front end e ajustar se necessário a url gerada pelo host do .net
  https://localhost:7247

Na lista de tarefas se a tarefa nao estiver finalizada aparecerá o botão Finalizar Tarefa, caso contrário aparece o botao para 
remover a tarefa finalizada.


