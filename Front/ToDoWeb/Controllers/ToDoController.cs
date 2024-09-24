using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using ToDoWeb.Models;

namespace ToDoWeb.Controllers
{
    public class ToDoController : Controller
    {
        string apiUrl = "http://localhost:5072/api/ToDo";
        
        //aqui podemos encapsular toda a chamada da api num contrato de uma serviço e injetar no controlador para nao deixar
        //essa responabilidade no controler

        public async Task<IActionResult> Index(){

            List<ToDo>? listaTarefas = new List<ToDo>();

            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync(apiUrl))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    listaTarefas = JsonConvert.DeserializeObject<List<ToDo>>(apiResponse);
                }
            }
            return View(listaTarefas);
        }


        public ActionResult NovaTarefa() {

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> NovaTarefa(ToDo tarefa)
        {
            ToDo? nova = new ToDo();

            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(tarefa),
                                                  Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync(apiUrl, content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    nova = JsonConvert.DeserializeObject<ToDo>(apiResponse);
                }
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> FinalizarTarefa(int id)
        {
            ToDo? tarefa = new ToDo();
            tarefa.Finalizada = true;
            tarefa.Id = id;


            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(tarefa),                                                 Encoding.UTF8, "application/json");
                               
                using (var response = await httpClient.PutAsync(apiUrl + "/true?id=" + id.ToString(), content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    tarefa = JsonConvert.DeserializeObject<ToDo>(apiResponse);
                }
            }

            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> DeletarTarefa(int id){
            
            using (var httpClient = new HttpClient())
            {
               //StringContent content = new StringContent(JsonConvert.SerializeObject(tarefa), Encoding.UTF8, "application/json");

                using (var response = await httpClient.DeleteAsync(apiUrl + "/" + id.ToString()))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    //tarefa = JsonConvert.DeserializeObject<ToDo>(apiResponse);
                }
            }

            return RedirectToAction("Index");
        }


        public ActionResult FinalizarTarefa(string id)
        {
            ToDo? tarefa = new ToDo();
            tarefa.Finalizada = true;
            tarefa.Id = Int32.Parse(id);


            return View(tarefa);
        }

        public ActionResult DeletarTarefa(string id)
        {
            ToDo? tarefa = new ToDo();           
            tarefa.Id = Int32.Parse(id);


            return View(tarefa);
        }

    }
}
