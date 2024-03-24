<img src="/logo.png" alt="Logo" width="200" style="display: block; margin: 0 auto;"/>

___
1. [Descrição](#descricao)
2. [Requisitos](#requisitos)
3. [Tecnologias utilizadas](#tecnologias)
4. [Time](#time)
5. [Tutorial para Instalação](#tutorial)

## <a id="descricao"></a>1. Descrição

Projeto Hackadev realizado no Bootcamp Sharp Coders da Imã Tech em parceria com a MXM. Consiste em uma aplicação web de um Banco Digital, com cadastro de clientes, contas, e realização de transações.

## <a id="requisitos"></a>2. Requisitos

### Requisitos Funcionais:
- [x] Cadastro de Contas
- [x] Operação de Depósito
- [x] Operação de Saque
- [x] Operação de Transferência
- [x] Consulta de Saldo

### Requisitos Não Funcionais:
- [x] Maximizar o desempenho das requisições
- [x] Documentar o projeto e tornar a API Restful
- [x] Ter suporte a auditoria dos registros na aplicação
- [x] Ser escalável caso necessário


## <a id="tecnologias"></a>3. Tecnologias Utilizadas

### Front-end
- HTML
- CSS
- Bootstrap
- Angular
### Back-end
- C# (Asp.Net)
- Entity Framework
- JWT
- AutoMapper
### Banco de Dados
- SQLite
- MySQL

## <a id="time"></a>4. Time 👩‍💻👨‍💻👩‍💻👨‍💻


<div align="center" style="display:flex;flex-wrap:wrap;justify-content:center;gap:.875rem;">
<div>
<img src="https://avatars.githubusercontent.com/u/96749239?v=4" height="100" style="display:block; margin-top:.5rem" /><br>
<a href="https://github.com/AlanEduardoCruz">Alan Eduardo</a>
</div>
<div>
<img src="https://avatars.githubusercontent.com/u/137793024?v=4" height="100" style="display:block; margin-top:.5rem" /><br>
<a href="https://github.com/AlxdPaiva">Alexandre Paiva</a>
</div>
<div>
<img src="https://avatars.githubusercontent.com/u/101590857?v=4/" height="100" style="display:block; margin-top:.5rem"/><br>
<a href="https://github.com/CamilaSBVieira">Camila Vieira</a>
</div>
<div>
<img src="https://avatars.githubusercontent.com/u/110201520?v=4" height="100" style="display:block; margin-top:.5rem"/><br>
<a href="https://github.com/daytrevisan">Dayane Trevisan</a>
</div>
<div>
<img src="https://avatars.githubusercontent.com/u/104864916?v=4" height="100" style="display:block; margin-top:.5rem"/><br>
<a href="https://github.com/E-A-D-S">Eduardo Santos</a>
</div>
<div>
<img src="https://avatars.githubusercontent.com/u/104444836?v=4" height="100" style="display:block; margin-top:.5rem"/><br>
<a href="https://github.com/gustavoscarl">Gustavo Lucianelli</a>
</div>
<div>
<img src="https://avatars.githubusercontent.com/u/86315467?v=4" height="100" style="display:block; margin-top:.5rem"/><br>
<a href="https://github.com/Psbrandes">Pedro Brandes</a>
</div>
</div>

## <a id="tutorial"></a>5. Tutorial para Instalação 

Para rodar a aplicação na sua máquina:

1. Abrir a solução **PayWiseBackEnd** no Visual Studio
2. Clicar com o botão direito do mouse na pasta do projeto (dentro do Visual Studio) e clicar em **Gerenciar Segredos do Usuário**
3. Copiar o json a seguir para o arquivo aberto (secrets.json)
```
{
    "Jwt:issuer": "http://localhost:5062",
    "Jwt:audience": "http://localhost:4200",
    "Jwt:key": "sldjflsdrojlkj987jlkjljljl465498815dsfdseur92"
}
```
5. Digitar o comando:
```
dotnet ef database update -c PaywiseDbContextSqlite
```
3. Após o DB ter sido atualizado, digitar o comando:
```js
dotnet watch run
// ou
dotnet run
```
4. Abrir a pasta **frontend** no VS Code
5. Digitar o comando:
```js
ng serve
// ou
npm run start 
```
6. Opcionalmente abrir uma ferramenta de administração de Banco de Dados, como **DBeaver** para visualizar os dados salvos.
