📦 Fluxo_Caixa - API
Projeto de uma API para controle de fluxo de caixa, com lançamentos financeiros diários e previsão dos próximos 30 dias.

🛠️ Tecnologias Utilizadas
ASP.NET Core 8

Docker

Docker Compose

Swagger (OpenAPI) para documentação

xUnit para testes unitários

📋 Pré-requisitos
Docker instalado

Docker Compose instalado

Windows (ou ajuste dos scripts .bat para Unix, se necessário)

🚀 Como rodar o projeto
Clone o repositório:

bash
Copiar
Editar
git clone https://github.com/RGORETTI/Fluxo_Caixa.git
Acesse a pasta raiz do projeto:

bash
Copiar
Editar
cd Fluxo_Caixa
📂 Buildar e subir os containers
Execute o script:

bash
Copiar
Editar
start-container.bat
Ou manualmente via Docker Compose:

bash
Copiar
Editar
docker-compose up -d
A aplicação ficará disponível em:
➡️ http://localhost:5000/swagger

🛑 Parar os containers
Execute:

bash
Copiar
Editar
stop-container.bat
Ou manualmente:

bash
Copiar
Editar
docker-compose down
♻️ Rebuildar os containers (após alterações no código)
Execute:

bash
Copiar
Editar
rebuild-container.bat
Ou manualmente:

bash
Copiar
Editar
docker-compose down
docker rmi fluxo-caixa-fluxo-caixa-api
docker-compose up --build -d
📑 Documentação da API
Acesse pelo navegador:

http://localhost:5000/swagger

🧪 Testes
Os testes unitários estão disponíveis no projeto FluxoCaixa.Tests.

Para rodar:

Abra o Visual Studio

Execute os testes pelo Test Explorer

📜 Regras de Negócio Implementadas
Não é permitido lançamentos no passado.

Tipo de lançamento aceito: Recebimento (1) ou Pagamento (2).

Saldo negativo permitido até -20.000,00:

Pagamentos não são permitidos se saldo ultrapassar o limite.

Recebimentos são sempre permitidos (mesmo com saldo negativo).

Previsão do fluxo de caixa para os próximos 30 dias.

Cálculo de posição do dia (aumento ou queda percentual) comparado ao dia anterior.

✍️ Autor
Rafael Goretti (RGORETTI)