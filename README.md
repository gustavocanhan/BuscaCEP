# 📦 Projeto: BuscaCEP

Este projeto marca meu **primeiro uso de requisições HTTP (request)** em C# utilizando `HttpClient`.  
O objetivo é consultar a **API ViaCEP** e exibir informações de endereço a partir de um CEP informado pelo usuário.

---

## 🧠 Objetivo do Projeto

Aprender como:
- Fazer **requisições HTTP** com `HttpClient`
- Tratar respostas da API
- Converter (desserializar) JSON em um **objeto C#**
- Trabalhar com **async / await**
- Lidar com erros de rede, respostas inválidas e exceções

---

## 🧩 Estrutura do Projeto

```
BuscaCEP/
│
├── Program.cs        → Ponto de entrada, faz a leitura do CEP e exibe o resultado.
├── ApiCep.cs         → Contém o método que envia a requisição HTTP e trata respostas/erros.
└── Cep.cs            → Modelo (classe) que representa os dados retornados pela API.
```

---

## ⚙️ Funcionamento

1. O usuário digita um CEP sem traço.
2. O programa chama `ApiCep.BuscarCEP(cep)` que:
   - Envia uma requisição GET para `https://viacep.com.br/ws/{cep}/json/`
   - Retorna o conteúdo da resposta em formato JSON.
   - Caso ocorra erro, retorna um JSON de erro padronizado.
3. A resposta é desserializada em um objeto `Cep` e os campos principais são exibidos no console.

---

## 🧾 Exemplo de Execução

```
Digite um CEP sem traço: 01001000

=== Resultado ===
CEP: 01001-000
Logradouro: Praça da Sé
Bairro: Sé
Cidade: São Paulo
UF: SP
```

### 🧱 Exemplo de Erro (CEP inexistente)
```
Digite um CEP sem traço: 99999999
Erro: CEP inválido ou não encontrado.
```

### ⚠️ Exemplo de Erro de Requisição
```
Digite um CEP sem traço: %%%%%%%%
Erro: Erro na requisição: BadRequest
```

### 💥 Exemplo de Exceção de Rede
```
Digite um CEP sem traço: 05271250
Erro: Ocorreu um erro ao enviar a solicitação.
```

---

## 🧰 Tecnologias Utilizadas

- **C# (.NET 8.0)**
- **HttpClient**
- **System.Text.Json** (para desserialização de JSON)
- **Programação Assíncrona (async/await)**

---

## 🏁 Aprendizado

Este foi meu primeiro projeto consumindo uma API no C#, entendendo como:
- Funciona uma requisição GET
- Tratar respostas HTTP
- Estruturar o código em múltiplas classes
- Trabalhar com erros de rede e respostas JSON inválidas

---

## ✍️ Autor

Desenvolvido por **Gustavo Canhan** como exercício de aprendizado em C#.
