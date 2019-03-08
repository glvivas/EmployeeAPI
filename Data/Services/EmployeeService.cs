using DataAccess.Contants;
using DataAcess.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IHttpClientFactory httpClient;

        public EmployeeService(IHttpClientFactory httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            IEnumerable<Employee> employees = Array.Empty<Employee>();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, Constants.EmployeeEndpoint);
            HttpClient conection = httpClient.CreateClient();
            var response = await conection.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                employees = JsonConvert.DeserializeObject<IEnumerable<Employee>>(result);

            }

            return employees;
        }

    }
}
