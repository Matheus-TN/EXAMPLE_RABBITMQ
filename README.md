# EXAMPLE_RABBITMQ

Esta instância de implementação tem como objetivo apresentar de maneira sucinta e eficiente a aplicação ágil dos serviços oferecidos pelo RabbitMQ, proporcionando simultaneamente exemplos esclarecedores de variadas categorias de tarefas.

- Site Oficial Chocolatey: https://chocolatey.org
- Site Oficial RabbitMQ: https://rabbitmq.com

Libs Utiizadas:

- RabbitMQ.Client

-----

----- Para começarmos a utilizar os serviços do RabbitMQ, são necessários seguir alguns procedimentos obrigatórios -----

Há diversas alternativas para se instalar o RabbitMQ, a que eu utilizei foi instalar o RabbitMQ via CLI do chocolatey

- Abrir o power shell com permissão de adm
- Execute o seguinte comando Get-ExecutionPolicy, caso o resultado seja "Restricted", execute algum dos comandos a seguir:
  - Set-ExecutionPolicy AllSigned
  - Set-ExecutionPolicy Bypass -Scope Process
- Instalar o chocolatey utilzando o seguinte comando:
  - Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://community.chocolatey.org/install.ps1'))
- Para validar se a instalação foi concluída com sucesso, basta utilizar os comandos *choco* ou *choco -?*

Com o CLI do chocolatey já instalado, basta inserir o seguinte comando para instalar o RabbitM: 
- choco install rabbitmq ( note que primeiramente será instalado ).

-----

----- bônus -----

Para habilitar o plug-in de gerenciamento de gerenciamento do RabbitMQ - Dashboard, basta acessar o diretório onde o rabbitMQ server foi instalado e digitar o seguinte comando "rabbitmq-plugins enable rabbitmq_management"

Exemplo: 

cd C:\\Program Files\RabbitMQ Server\rabbitmq_server-[version]\sbin 
rabbitmq-plugins enable rabbitmq_management
