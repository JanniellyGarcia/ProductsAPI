
# Products API

### Descrição

Projeto desenvolvido como um teste técnico para a posição de Desenvolvedor de Software na Ploomes. O repositório consiste no código da API com um CRUD para produtos. Com ele, é possível pesquisar, excluir, editar ou criar novos produtos.

### Serviços

- GET: Retorna todos os produtos existentes no banco de dados
- GET/id: Retorna um produto do banco de dados a partir de seu identificador(ID)
- PUT: Atualiza uma ou mais propriedades de um determinado produto
- DELETE: Deleta um produto existente no banco de dados a partir de seu identificador(ID)
- POST: Cria um novo produto no banco de dados

### Tecnologias e Pacotes Usados:


- C#
- .NET v6
- Entity Framework
- Sql Server
- Swagger
- Microsoft Azure
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- Swashbuckle.AspNetCore

### Informações Necessárias:
A API está atualmente hospedada em um Azure App Service em execução no windows e pode ser encontrada em:
https://productsapibr.azurewebsites.net/swagger/index.html

Ao acessar o link você encontrará a seguinte interface gerada usando a ferramenta swagger. Nessa tela estão listados os serviços e você pode testar cada um seguindo as instruções de uso e informações de Response descritas em cada endpoint.

![image](https://user-images.githubusercontent.com/49817192/223926439-bcc59927-c695-4a4f-a960-7987387af5a8.png)



### Passo a Passo para Teste:

- Clique na seta que fica à direita de cada endpoint listado para testá-lo:



- GET: Clique em "try it out" que fica no canto direito, conforme mostrado na imagem abaixo, e logo após clique em "Execute"

![image](https://user-images.githubusercontent.com/49817192/223926318-3c6df733-c446-4030-8a94-5cfadc5d4571.png)


- POST: Clique em "try it out" que fica no canto direito, preencha o Request body conforme a descrição e logo após clique em "Execute"

![image](https://user-images.githubusercontent.com/49817192/223926387-8c862c7e-906e-4793-ac26-89cd669fd0c5.png)


- PUT: Clique em "try it out" que fica no canto direito, preencha o Parâmetro e Request body conforme a descrição e logo após clique em "Execute"

![image](https://user-images.githubusercontent.com/49817192/223923479-456e8d69-a1ec-4fdc-b264-ca51bf518b85.png)


- GET/ID: Clique em "try it out" que fica no canto direito, preencha o Parâmetro conforme a descrição e logo após clique em "Execute"

![image](https://user-images.githubusercontent.com/49817192/223923842-53c4cb0d-a907-455e-8015-c20e6dcfc720.png)


- DELETE: Clique em "try it out" que fica no canto direito, preencha o Parâmetro conforme a descrição e logo após clique em "Execute"

![image](https://user-images.githubusercontent.com/49817192/223924104-003e2eee-cfe5-4382-a1f6-cde85cd95e53.png)


É importante verificar:
- Se os Id's utilizados para teste existem no banco de dados, para isso você pode executar o GET(1) e obter um Id válido.
- Se a regra de restrição de preço está sendo obedecida.
