using ModelsLibrary;
using ModelsLibrary.Messages;
using Newtonsoft.Json;
using System.Reflection.Emit;
using System.Text;
using System.Windows;


namespace Service
{
    public class Service
    {
        public List<ModelsLibrary.Messages.MessageResponse> Messages
        { get; private set; }

        public Uri Uri { get; set; }

        public Service()
        {
            Messages = new();
            Uri = new("http://localhost:0/swagger/index.html");
        }


        public Service(Uri uri) : this()
        {
            this.Uri = Uri;
        }
        public Service(string IP, int port) : this()
        {
            SetNewAddress(IP, port);
        }




        public void SetNewAddress(string IP, int port)
        {
            this.Uri = new Uri($"http://{IP}:{port}/api/messages");
        }
        public void SetNewAddress(string IP, string port)
        {
            this.Uri = new Uri($"http://{IP}:{port}/api/messages");
        }
        public void SetNewAddress(Uri uri)
        {
            this.Uri = uri;
        }




        public void Post(ModelsLibrary.Messages.MessageRequest message, Uri uri)
        {
            HttpClient client = new HttpClient();
            StringContent content = new StringContent
            (
                JsonConvert.SerializeObject(message),
                Encoding.UTF8,
                "application/json"
            );


            try
            {
                HttpResponseMessage response = client.PostAsync(uri, content).Result;
                response.EnsureSuccessStatusCode();
                string responseBody = response.Content.ReadAsStringAsync().Result;

                Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
                throw e;
            }
        }
        public async Task PostAsync(ModelsLibrary.Messages.MessageRequest message, Uri uri)
        {
            HttpClient client = new HttpClient();
            StringContent content = new StringContent
            (
                JsonConvert.SerializeObject(message),
                Encoding.UTF8,
                "application/json"
            );


            try
            {
                HttpResponseMessage response = await client.PostAsync(uri, content);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
                throw;
            }
        }
        public async Task<int> PostAsyncDesktop(ModelsLibrary.Messages.MessageRequest message, Uri uri)
        {
            HttpClient client = new HttpClient();
            StringContent content = new StringContent
            (
                JsonConvert.SerializeObject(message),
                Encoding.UTF8,
                "application/json"
            );


            HttpResponseMessage response;
            try
            {
                response = await client.PostAsync(uri, content);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Ошибка сервера\nПопробуйте обратиться к администратору", "Плохой запрос на сервер", MessageBoxButton.OK, MessageBoxImage.Error);
                return 1;
            }

            return 0;
        }









        public void Get(Uri uri)
        {
            HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response = client.GetAsync(uri).Result;
                response.EnsureSuccessStatusCode();
                string responseBody = response.Content.ReadAsStringAsync().Result;
                    
                try
                {
                    Messages = JsonConvert.DeserializeObject<List<MessageResponse>>(responseBody);
                    if(Messages is null || Messages.Count==0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Не удалось создать список сообщений");
                        Console.ResetColor();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                    
                Console.WriteLine(responseBody);
                foreach(var i in  Messages)
                {
                    Console.WriteLine($"{i.Content}\n");
                }
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Ошибка сервера\nПопробуйте обратиться к администратору", "Плохой запрос на сервер", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public async Task GetAsync(Uri uri)
        {
            await Task.Run(async () =>
            {
                HttpClient client = new HttpClient();
                try
                {
                    HttpResponseMessage response = await client.GetAsync(uri);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();

                    try
                    {
                        Messages = JsonConvert.DeserializeObject<List<MessageResponse>>(responseBody);
                        if (Messages is null || Messages.Count == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Не удалось создать список сообщений");
                            Console.ResetColor();
                            return;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(e.Message);
                        Console.ResetColor();
                    }

                    Console.WriteLine(responseBody);
                    foreach (var i in Messages)
                    {
                        Console.WriteLine($"{i.Content}\n");
                    }
                }
                catch (HttpRequestException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.ResetColor();
                    throw;
                }
            });
        }

        public async Task<int> GetAsyncDesktop(Uri uri)
        {
            return await Task<int>.Run(async () =>
            {
                HttpClient client = new HttpClient();
                try
                {
                    for(byte i=0;i!=6;++i)
                    {
                        using (HttpResponseMessage response = await client.GetAsync(uri))
                        {
                            response.EnsureSuccessStatusCode();
                            string responseBody = await response.Content.ReadAsStringAsync();

                            try
                            {
                                Messages = JsonConvert.DeserializeObject<List<MessageResponse>>(responseBody);
                                if (Messages is null || Messages.Count == 0)
                                {
                                    if(i==5)
                                    {
                                        MessageBox.Show("Не удалось содать список сообщений", "Ошибка расшифровки", MessageBoxButton.OK, MessageBoxImage.Error);
                                        return 1;
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(e.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        Thread.Sleep(1000);
                    }
                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show("Ошибка сервера\nПопробуйте обратиться к администратору", "Плохой запрос на сервер", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                return 0;
            });
        }








        public void Post(ModelsLibrary.Messages.MessageRequest message)
        {
            this.Post(message, this.Uri);
        }
        public async void PostAsync(ModelsLibrary.Messages.MessageRequest message)
        {
            await PostAsync(message, this.Uri);
        }
        public async Task<int> PostAsyncDesktop(ModelsLibrary.Messages.MessageRequest message)
        {
            return 
            await PostAsyncDesktop(message, this.Uri);
        }



        public void Get()
        {
            this.Get(this.Uri);
        }
        public async void GetAsync()
        {
             await this.GetAsync(this.Uri);
        }
        public async void GetAsyncDesktop()
        {
            await GetAsyncDesktop(this.Uri);
        }
    }
}