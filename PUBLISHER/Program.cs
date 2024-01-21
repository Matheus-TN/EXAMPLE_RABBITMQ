using RabbitMQ.Client;
using System.Text;

namespace PUBLISHER
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

            // Criamos um canal onde vamos definir uma fila, uma mensagem e publicar a mensagem 
            using var channel = connection.CreateModel();

            channel.QueueDeclare(
                queue: "mensagem1", // Nome da fila
                durable: false,     // Quando true, a fila permanece ativa após o servidor ser reiniciado
                exclusive: false,   // Quando true, a fila só pode ser acessada via conexão atual e são excluída ao fechar a conexão
                autoDelete: false,  // Quando true, a fila será automaticamente deletada após os consumidores usarem a fila 
                arguments: null
            );

            string message = "Exemplo de mensagem RabbitMQ !!";

            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(
                exchange: "",
                routingKey: "mensagem1",
                basicProperties: null,
                body: body
            );

            Console.WriteLine("Mensagem enviada com sucesso !!");
        }
    }
}