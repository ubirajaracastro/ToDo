ToDo List tem o back end na pasta scr\Back e o FrontEnd na respectiva pasta Front.

Verificações para subir o projeto:

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


