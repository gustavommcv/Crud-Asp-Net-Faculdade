# Fundamentos de Sistema de Informação

## Nome:
- Enzo Monnerat Martins Bravo Marquet
- Bernardo Castro Barros
- Juan Fagundes Knupp

## Projeto: Sistema Imobiliário

### O que?
O projeto desenvolvido foi um **sistema imobiliário** composto por três classes principais:
- `Client` (Cliente)
- `Property` (Propriedade)
- `Contract` (Contrato)

### Como?
O sistema foi desenvolvido utilizando a linguagem de programação **C#** com o framework **ASP.NET** (versão .NET 8). A interface foi criada com **Razor Pages**, permitindo a interação entre o front-end e o back-end de maneira simplificada.

#### Armazenamento de Dados
Em vez de utilizar um banco de dados tradicional, criamos uma classe `FakeDbContext`, localizada na pasta **Data**, que contém três listas para armazenar os dados das três classes principais (`Client`, `Property` e `Contract`).

#### ViewModels
Para integrar o front-end com o back-end, usamos **ViewModels** para transportar os dados do `FakeDbContext` para as páginas correspondentes. Esses ViewModels conectam a interface com os dados processados no back-end.

#### Arquitetura
Adotamos a arquitetura **MVC (Model-View-Controller)**:
- **Model**: Responsável pelas classes principais.
- **View**: Interface do usuário.
- **Controller**: Gerencia a interação entre o back-end e o front-end.

---

## Fluxo de Dados de Cada Tela

### Home
1. **Index**  
   - Entrada: Nenhuma
   - Saída:  
     - `Client`: Id, FullName, Email  
     - `Property`: Id, Address, Price  
     - `Contract`: Id, ClientId, PropertyId, ContractDate  

### Client
1. **Create**  
   - Entrada: FirstName, LastName, Email  
   - Saída: Visualização com o novo cliente na lista  

2. **Delete**  
   - Entrada: ID do cliente  
   - Saída: Visualizacao sem o cliente na lista (retirada de um cliente da lista e o fechamento daquele contrato relacinado, caso tenha um.)

3. **Edit**  
   - Entrada: ID do cliente  
   - Saída: Visualizacao dos detalhes do cliente atualizados

4. **Details**  
   - Entrada: ID do cliente  
   - Saída: Visualização completa dos dados do cliente, propriedades e contratos  

5. **LinkProperty**  
   - Entrada: ID do cliente, Lista das Propriedades  
   - Saída: Visualizacao dos detalhes do cliente com nova propriedade vinculada (e criacao de um contrato)

### Property
1. **Create**  
   - Entrada: Address, Price  
   - Saída:Visualização com o nova propriedade na lista

2. **Delete**  
   - Entrada: ID da propriedade  
   - Saída: Visualizacao sem a propriedade na lista (fechamento de seu contrato relacinado, caso tenha um.)

3. **Edit**  
   - Entrada: ID da propriedade  
   - Saída: Visualizacao dos detalhes da propriedade atualizados

4. **Details**  
   - Entrada: ID da propriedade  
   - Saída: Visualização completa dos dados da propriedade e contratos relacionados  

### Contract
1. **Create**  
   - Um contrato pode ser criado a partir dos detalhes do cliente usando o Link Property (Vincular propriedade)

2. **Delete**  
   - Entrada: ID do contrato  
   - Saída: Visualizacao sem o contrato na lista (Desvincularização da propriedade e o cliente de mesmo contrato)

3. **Edit**  
   - Entrada: ID do contrato  
   - Saída: Visualizacao dos detalhes do contrato atualizados

4. **Details**  
   - Entrada: --  
   - Saída: Visualização completa dos dados do contrato  

---

## Testes

### Testes de Unidade
Os testes foram realizados utilizando o framework **xUnit** para garantir o funcionamento correto das classes e funcionalidades isoladas.

#### Testes da Classe `Client`:
- **Criação de Cliente**: Verificação da adição correta do cliente à lista.
- **Edição de Cliente**: Atualização de informações de clientes e validação dos dados atualizados.
- **Exclusão de Cliente**: Remoção de clientes e encerramento de contratos relacionados.
- **Vinculação de Cliente a uma Propriedade**: Teste da criação de contratos entre cliente e propriedade.

#### Testes da Classe `Property`:
- **Criação de Propriedade**: Adição de novas propriedades à lista.
- **Exclusão de Propriedade**: Remoção da propriedade e contratos relacionados.
- **Edição de Propriedade**: Atualização dos dados da propriedade.

#### Testes da Classe `Contract`:
- **Criação de Contrato**: Validação da criação de contratos entre clientes e propriedades.
- **Exclusão de Contrato**: Remoção de contratos e desvinculação entre cliente e propriedade.
- **Edição de Contrato**: Atualização do estado do contrato (aberto/fechado).

### Testes de Integração
Os testes de integração garantiram o correto funcionamento entre as diferentes camadas do sistema, validando o fluxo de dados entre o back-end e o front-end.

### Testes Funcionais
Os testes funcionais simularam o comportamento do usuário no sistema, verificando operações como:
- Criação de clientes
- Atualização de propriedades
- Exibição correta dos dados nas telas de detalhes

---

