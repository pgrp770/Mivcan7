using Microsoft.Extensions.Hosting;
using Mivcan7.Models;

namespace Mivcan7
{
    public class JsonSevice
    {
        private readonly HttpClient _httpClient;

        public JsonSevice(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ToDo>> GetPostsAsync()
        {
            var response = await _httpClient.GetAsync("https://dummyjson.com/todos");
            response.EnsureSuccessStatusCode();
            var posts = await response.Content.ReadFromJsonAsync<List<ToDo>>();
            return posts;
        }

        public async Task<ToDo> GetPostAsync(int id)
        {
            var response = await _httpClient.GetAsync($"https://jsonplaceholder.typicode.com/posts/{id}");
            response.EnsureSuccessStatusCode();
            var post = await response.Content.ReadFromJsonAsync<ToDo>();
            return post;
        }

        public async Task<ToDo> CreatePostAsync(ToDo newPost)
        {
            var response = await _httpClient.PostAsJsonAsync("https://jsonplaceholder.typicode.com/posts", newPost);
            response.EnsureSuccessStatusCode();
            var createdPost = await response.Content.ReadFromJsonAsync<ToDo>();
            return createdPost;
        }

        public async Task UpdatePostAsync(int id, ToDo updatedPost)
        {
            var response = await _httpClient.PutAsJsonAsync($"https://jsonplaceholder.typicode.com/posts/{id}", updatedPost);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeletePostAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"https://jsonplaceholder.typicode.com/posts/{id}");
            response.EnsureSuccessStatusCode();
        }
    }

}
