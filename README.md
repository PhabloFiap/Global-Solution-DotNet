# Representantes

* RM 550687 Phablo Santos
* RM 551821 Lucas Serbato
* RM 552228 Vitor Teixeira
* RM 552364 Ronald de Oliveira
* RM 552466 Gustavo Carvalho


# Global Solution DotNet

## **Descrição do Projeto**

Este projeto foi desenvolvido como parte da **Global Solution** da FIAP, com o objetivo de aplicar os conhecimentos adquiridos durante o curso em um cenário prático. A aplicação foi construída utilizando a linguagem **C#** e a plataforma **.NET**, seguindo os princípios da arquitetura Onion para promover um design limpo e modular.

---

## **Arquitetura Onion**

A arquitetura Onion é uma abordagem que enfatiza a separação de responsabilidades e o desacoplamento entre as camadas de uma aplicação. Ela é composta por:

- **Domínio (Core):** Contém as entidades e interfaces que definem as regras de negócio.
- **Aplicação:** Implementa os casos de uso e orquestra as operações do domínio.
- **Infraestrutura:** Fornece implementações concretas para interfaces do domínio, como repositórios e serviços externos.
- **Interface de Usuário (UI):** Camada mais externa, responsável pela interação com o usuário ou outras aplicações.

Essa estrutura facilita a manutenção, testabilidade e escalabilidade do sistema.

---

## **Entidades Principais**

As principais entidades do projeto incluem:

- **MoradorEntity:** Representa um morador com propriedades como `Id`, `Nome` e `CPF`.
- **MoradorDto:** Data Transfer Object utilizado para transferir dados do morador entre as camadas da aplicação.
- **MedidorEntity:** Representa os dados relacionados ao medidor, como `Id`, `data_medida`, `valor_corrente`, `valor_tensao` e `valor_consumo`.

---

## **Endpoints da API**

### **1. Endpoints de Morador**

1. **Listar todos os moradores**
   - **Rota:** `GET /api/morador`
   - **Descrição:** Retorna uma lista de todos os moradores cadastrados.

2. **Obter um morador por ID**
   - **Rota:** `GET /api/morador/{id}`
   - **Descrição:** Retorna os detalhes de um morador específico com base no ID fornecido.

3. **Inserir um novo morador**
   - **Rota:** `POST /api/morador`
   - **Descrição:** Adiciona um novo morador ao sistema.

4. **Editar um morador existente**
   - **Rota:** `PUT /api/morador/{id}`
   - **Descrição:** Atualiza as informações de um morador existente.

5. **Deletar um morador**
   - **Rota:** `DELETE /api/morador/{id}`
   - **Descrição:** Remove um morador do sistema com base no ID fornecido.

---

### **2. Endpoints de Medidor**

1. **Listar todas as medições**
   - **Rota:** `GET /api/medidor`
   - **Descrição:** Retorna uma lista de todas as medições registradas.

2. **Obter uma medição por ID**
   - **Rota:** `GET /api/medidor/{id}`
   - **Descrição:** Retorna os detalhes de uma medição específica com base no ID fornecido.

3. **Registrar uma nova medição**
   - **Rota:** `POST /api/medidor`
   - **Descrição:** Registra uma nova medição.

4. **Editar uma medição existente**
   - **Rota:** `PUT /api/medidor/{id}`
   - **Descrição:** Atualiza as informações de uma medição existente.

5. **Deletar uma medição**
   - **Rota:** `DELETE /api/medidor/{id}`
   - **Descrição:** Remove uma medição específica com base no ID fornecido.

---

## **Integração com Machine Learning**

A funcionalidade de Machine Learning foi implementada para realizar predições baseadas nos dados dos **medidores**. O objetivo é prever o consumo elétrico (`valor_consumo`) com base nos valores de **corrente elétrica** (`valor_corrente`) e **tensão elétrica** (`valor_tensao`), permitindo análise de eficiência energética e otimização do consumo.

### **Treinamento do Modelo**

O modelo foi treinado utilizando o algoritmo **FastTree Regression**, que analisa os dados históricos e cria um modelo preditivo baseado nos seguintes atributos:

- **Entrada (Features):**
  - `valor_corrente` (float): A corrente elétrica em amperes.
  - `valor_tensao` (float): A tensão elétrica em volts.

- **Saída (Label):**
  - `valor_consumo` (float): O consumo elétrico previsto.

---

### **Endpoint de Predição**

- **Rota:** `GET /api/consumo/prever/{valor_corrente}/{valor_tensao}`
- **Descrição:** Utiliza o modelo treinado para prever o consumo elétrico com base nos valores fornecidos de corrente e tensão.

- **Exemplo de Requisição:**
  ```bash
  curl -X GET "http://localhost:5000/api/consumo/prever/12.5/230"
  ```

- **Exemplo de Resposta:**
  ```json
  {
    "valor_corrente": 12.5,
    "valor_tensao": 230,
    "consumo_previsto": 2.75
  }
  ```

---

## **Como Treinar o Modelo**

Para treinar ou atualizar o modelo, siga os passos:

1. **Atualizar o Dataset:**
   - Substitua o arquivo de treinamento `dados_consumo.csv` na pasta `Data/` pelo novo conjunto de dados.

2. **Recompilar e Executar o Projeto:**
   - O método `TreinarModelo` será executado automaticamente se o modelo existente (`ModeloConsumo.zip`) não for encontrado.

---

## **Como Executar o Projeto**

1. **Clonar o Repositório:**
   ```bash
   git clone https://github.com/PhabloFiap/Global-Solution-DotNet.git
   cd Global-Solution-DotNet
   ```

2. **Restaurar as Dependências:**
   ```bash
   dotnet restore
   ```

3. **Executar o Projeto:**
   ```bash
   dotnet run
   ```

4. **Acessar a API:**
   - Acesse o Swagger para explorar os endpoints:
     ```
     http://localhost:5000/swagger
     ```

---

## **Tecnologias Utilizadas**

- **.NET 6**
- **ML.NET**
- **FastTree Regression**
- **Entity Framework Core**
- **Swagger**

---

## **Download**

Clique [aqui para baixar este README](sandbox:/mnt/data/README.md) e adicioná-lo diretamente ao repositório no GitHub.
