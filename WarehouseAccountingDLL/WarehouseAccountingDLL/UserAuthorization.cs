using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WarehouseAccountingDLL
{
    public class Employee
    {
        public int IdEmployee { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }

    public class UserAuthorization
    {
        public static async Task<Employee> SetAuthorizationLoginPassword(string apiUrl, string login, string password, string keyWord)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var requestUrl = $"{apiUrl}?login={Uri.EscapeDataString(login)}&password={Uri.EscapeDataString(password)}&keyWord={Uri.EscapeDataString(keyWord)}";

                    Console.WriteLine($"Sending request to: {requestUrl}");

                    var response = await client.PostAsync(requestUrl, null);

                    response.EnsureSuccessStatusCode();

                    var employee = await response.Content.ReadFromJsonAsync<Employee>();
                    if (employee != null)
                    {
                        return employee;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static async Task<string> SetAuthorizationEmail(string apiUrl, string email)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var requestUrl = $"{apiUrl}?email={Uri.EscapeDataString(email)}";

                    Console.WriteLine($"Sending request to: {requestUrl}");

                    var response = await client.PostAsync(requestUrl, null);

                    response.EnsureSuccessStatusCode();

                    var result = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(result))
                    {
                        return result;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static async Task<Employee> SetAuthorizationVerifyCode(string apiUrl, string email, string verificationCode)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var requestUrl = $"{apiUrl}?email={Uri.EscapeDataString(email)}&verificationCode={Uri.EscapeDataString(verificationCode)}";

                    Console.WriteLine($"Sending request to: {requestUrl}");

                    var response = await client.PostAsync(requestUrl, null);

                    response.EnsureSuccessStatusCode();

                    var employee = await response.Content.ReadFromJsonAsync<Employee>();
                    if (employee != null)
                    {
                        return employee;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
