using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace CONSUMER
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Definimos uma conexão com um nó RabbitMQ em localhost
            var factory = new ConnectionFactory()
            {
                  HostName = "localhost",
                  UserName = "guest",
                  Password = "guest"
            };

            // Abrimos uma conexão com um nó RabbitMQ
            using var connection = factory.CreateConnection();

            // Criar o canal na conexão para operar 
            using var channel = connection.CreateModel();

            channel.QueueDeclare(
                queue: "mensagem1", // Declaramos a fila a partir da qual vamos consumir as mensagens
                durable: false,     
                exclusive: false,
                autoDelete: false,
                arguments: null
            );

            // Solicita a entrega das mensagens de forma assíncrona e fornece um retorno de chamada
            var consumer = new EventingBasicConsumer(channel);

            // Recebe a mensagem da fila
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();

                var message = Encoding.UTF8.GetString(body);

                Console.WriteLine($"Mensagem recebida com sucesso !!");
                Console.WriteLine(message);
            };

            // Indicamos o consumo da mensagem
            channel.BasicConsume(
                queue: "mensagem1",
                autoAck: true,
                consumer: consumer
            );

            Console.ReadLine();
        }
    }
}