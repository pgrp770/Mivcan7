using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mivcan7.Data;
using Mivcan7.Models;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Mivcan7.Controllers
{
    public class ToDoesController : Controller
    {
        private readonly Mivcan7Context _context;
        public JsonSevice js;
        HttpClient _httpClient;
        static readonly HttpClient client = new HttpClient();
        public ToDoesController(Mivcan7Context context)
        {
            _httpClient = new HttpClient();
            _context = context;
            js = new JsonSevice(_httpClient);
        }

        // GET: ToDoes
        public async Task<string> Index()
        {
            {
                var data = new
                {
                    Name = "John Doe",
                    Age = 30,
                    Email = "john.doe@example.com"
                };


                string json = JsonConvert.SerializeObject(data);


                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");



                using HttpResponseMessage response = await client.GetAsync("https://dummyjson.com/todos");
                var a = response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);
                return responseBody;

            }
            }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<string>  Create([Bind("task,Completed,UserId")] ToDo toDo)
        {
            var data = new ToDo()
            {
                task = toDo.task,
                Completed = toDo.Completed,
                UserId = toDo.UserId,
            };


            string json = JsonConvert.SerializeObject(data);


            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using HttpResponseMessage response = await client.PostAsync("https://dummyjson.com/todos", content);
  
       
            // Above three lines can be replaced with new helper method below
            // string responseBody = await client.GetStringAsync(uri);


        
            return json;
        }
    }
}
