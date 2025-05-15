# 📦 Fluxo_Caixa - API

Projeto de uma API para controle de fluxo de caixa, com lançamentos financeiros diários e previsão dos próximos 30 dias.

---

## 🚀 Tecnologias Utilizadas

- ASP.NET Core 8
- MongoDB (via container Docker)
- Docker
- Docker Compose
- Swagger (OpenAPI) para documentação
- xUnit para testes unitários
- GitHub Actions para CI/CD ✅

---

## 📋 Pré-requisitos

- Docker instalado
- Docker Compose instalado
- Windows (ou ajuste dos scripts `.bat` para Unix, se necessário)

---

## 🚀 Como rodar o projeto

Clone o repositório:

```bash
git clone https://github.com/RGORETTI/Fluxo_Caixa.git
```

Acesse a pasta raiz do projeto:

```bash
cd Fluxo_Caixa
```

### 📂 Buildar e subir os containers

Execute o script:

```bash
start-container.bat
```

Ou manualmente via Docker Compose:

```bash
docker-compose up -d
```

A aplicação e o MongoDB serão inicializados automaticamente.

➡️ Acesse a API em: [http://localhost:5000/swagger](http://localhost:5000/swagger)

---

## 🛑 Parar os containers

Execute:

```bash
stop-container.bat
```

Ou manualmente:

```bash
docker-compose down
```

---

## ♻️ Rebuildar os containers (após alterações no código)

Execute:

```bash
rebuild-container.bat
```

Ou manualmente:

```bash
docker-compose down
docker rmi fluxo-caixa-fluxo-caixa-api
docker-compose up --build -d
```

---

## 🗃️ Banco de Dados (MongoDB)

- O MongoDB roda automaticamente via container Docker.
- Você **não precisa instalar o MongoDB manualmente**.
- Os dados são persistidos dentro do container (volume pode ser adicionado futuramente).
- Para visualizar os dados, acesse o painel do [MongoDB Atlas](https://cloud.mongodb.com) ou conecte-se usando uma ferramenta como o **MongoDB Compass**.

---

## 📑 Documentação da API

Acesse:

➡️ [http://localhost:5000/swagger](http://localhost:5000/swagger)

---

## 🧪 Testes Automatizados

O projeto possui testes unitários com **xUnit**, localizados no repositório [FluxoCaixa.Tests](https://github.com/RGORETTI/FluxoCaixa.Tests).

Para rodar localmente:

- Abra o Visual Studio
- Execute os testes pelo **Test Explorer**

---

## ⚙️ Pipeline de Integração Contínua (CI/CD)

O projeto possui pipeline automático usando **GitHub Actions**:
- Build da aplicação
- Execução dos testes automatizados
- Validação automática em cada `push` ou `pull request`

Você pode acompanhar na aba [Actions](https://github.com/RGORETTI/Fluxo-Caixa/actions).

---

## 📜 Regras de Negócio Implementadas

- Não é permitido lançamentos no passado.
- Tipo de lançamento aceito: **Recebimento (1)** ou **Pagamento (2)**.
- Saldo negativo permitido até **-20.000,00**:
  - Pagamentos são bloqueados se ultrapassar o limite.
  - Recebimentos são sempre permitidos.
- Previsão do fluxo de caixa para os próximos 30 dias.
- Cálculo de posição do dia (variação percentual em relação ao saldo anterior).

---

## ✍️ Autor

Rafael Goretti De Deus ([RGORETTI](https://github.com/RGORETTI))