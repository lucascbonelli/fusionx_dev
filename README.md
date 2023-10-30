<div align='center'>
  
<p><a href="https://git.io/typing-svg"><img src="https://readme-typing-svg.demolab.com?font=Exo+2&size=25&pause=1000&color=30F3AD&center=true&vCenter=true&random=false&width=400&lines=Sintonize+o+Engajamento+e+..." alt="Typing SVG"/></a></p>

<p><a href="https://git.io/typing-svg"><img src="https://readme-typing-svg.demolab.com?font=Exo+2&size=25&pause=1000&color=30F3AD&center=true&vCenter=true&random=false&width=400&lines=Inove+os+Eventos+!" alt="Typing SVG"/></a></p>

  <p>Projetada para resolver o problema do engajamento em eventos de tecnologia, nossa missão para esta solução é medir o interesse e o engajamento dos participantes e fornecer         métricas e feedback direto, capacitando as empresas a otimizar suas estratégias de engajamento. Também trabalhamos com o foco no engajamento do organizador com os             
    participantes, utilizando a personalização de processos.</p>

<div style='display: inline_block' align='center'>
  
  <p align="center"><a href="https://git.io/typing-svg"><img src="https://readme-typing-svg.demolab.com?font=Exo+2&size=25&pause=1000&color=30F3AD&center=true&vCenter=true&random=false&width=435&lines=Tecnologias+utilizadas%3A" alt="Typing SVG"/></a></p>
  
  <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white">
  <img src="https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white"> 
  <img src="https://img.shields.io/badge/entity-512BD4?style=for-the-badge&logo=dotnet&logoColor=white">
  <img src="https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white">
  
</div>

 <hr>
 
<div align='center'>
<p><a href="https://git.io/typing-svg"><img src="https://readme-typing-svg.demolab.com?font=Exo+2&size=25&pause=1000&color=30F3AD&center=true&vCenter=true&random=false&width=435&lines=Como+rodar+o+projeto%3A" alt="Typing SVG"/></a></p>
  
Aqui estão duas maneiras de executar o projeto, usando o Visual Studio e a linha de comando.

### Usando o `Visual Studio:`

`1.` **Clone o Repositório**: Você precisará obter o código-fonte do projeto. Você pode clonar o repositório do GitHub usando as opções do Visual Studio ou executando o seguinte comando em seu terminal:

``` git clone https://github.com/seu-usuario/fusionx_dev.git ```

Substitua `seu-usuario` pelo seu nome de usuário do GitHub ou use o URL correto do repositório. <br>


`2.` **Abra o Projeto**: Abra o Visual Studio e escolha "Arquivo" -> "Abrir" -> "Projeto/Solução" e selecione o arquivo `.csproj` no diretório do projeto. 


`3.` **Configure o Ambiente de Desenvolvimento**: Certifique-se de ter o .NET Core 7.0 instalado em seu sistema. <br>


`4.` **Execute o Projeto**: Você pode pressionar F5 ou clicar em "Iniciar" no Visual Studio para executar o projeto. 

`5.` **Acesse o Aplicativo**: O aplicativo estará acessível localmente. Você pode usar um navegador da web e acessar `http://localhost:7129` para interagir com o back-end do projeto. 

<hr>



### Usando a `Linha de Comando`

`1.` **Navegue para a Pasta do Projeto**: Use o comando `cd` para entrar na pasta do projeto: cd `fusionx_dev`


`2.` **Rode o Projeto**: Você pode iniciar o projeto executando o seguinte comando: `dotnet run`. Isso iniciará o servidor e seu aplicativo estará acessível localmente.


`3.` **Acesse o Aplicativo**: Abra um navegador da web e acesse `http://localhost:7129` para interagir com o back-end da solução.

</div>
<hr>

<div align='center'>
<p><a href="https://git.io/typing-svg"><img src="https://readme-typing-svg.demolab.com?font=Exo+2&size=25&pause=1000&color=30F3AD&center=true&vCenter=true&random=false&width=435&lines=Documenta%C3%A7%C3%A3o%3A" alt="Typing SVG" /></a></p>
<h4>UML (Feita com Draw.io)</h4> 
<img src="https://media.discordapp.net/attachments/1165041947233239118/1167232600843239424/FusionX.png?ex=654d6112&is=653aec12&hm=ed32f163415f296ba8f2fe96235007294b99c9fc9233898148524f5d232d78a1&=&width=567&height=473"> 
</div>

<hr>

<br>

<div align='center'>
<p ><a href="https://git.io/typing-svg"><img src="https://readme-typing-svg.demolab.com?font=Exo+2&size=25&pause=1000&color=30F3AD&center=true&vCenter=true&random=false&width=435&lines=Endpoints+%F0%9F%93%8D%3A" alt="Typing SVG" /></a></p>
  
### Eventos

`GET /Events`: Retorna todos os eventos.

`GET /Events/{id}`: Retorna um evento específico pelo ID.

`GET /Events/{id}/overview`: Retorna uma visão geral de um evento específico.

`POST /Events`: Cria um novo evento.

`PUT /Events/{id}`: Atualiza um evento existente.

`DELETE /Events/{id}`: Exclui um evento existente.

<hr>

### Gerenciadores

`GET /EventManagers`: Retorna todos os gerentes de eventos.

`GET /EventManagers/{id}`: Retorna um gerente de evento específico pelo ID.

`POST /EventManagers`: Cria um novo gerente de evento.

`DELETE /EventManagers/{id}`: Exclui um gerente de evento existente.

<hr>

### Tags do Evento

`GET /EventTag/{tagId}/{eventId}`: Retorna uma tag de evento específica.

`POST /EventTag`: Cria uma nova tag de evento.

`DELETE /EventTag/{tagId}/{eventId}`: Exclui uma tag de evento existente.

`GET /EventTag/byEvent/{eventId}`: Retorna todas as tags de evento associadas a um evento específico.

`GET /EventTag/byTag/{tagId}`: Retorna todos os eventos associados a uma tag específica.

<hr>

### Usuários

`GET /Users/{id}`: Retorna um usuário específico pelo ID.

`POST /Users`: Cria um novo usuário.

`DELETE /Users/{id}`: Exclui um usuário existente.

`PUT /Users/{id}`: Atualiza um usuário existente.

<hr>

### Tags do Usuário

`GET /UserTags/tag/{tagId}/user/{userId}`: Retorna uma relação entre tag e usuário específica.

`POST /UserTags`: Cria uma nova relação entre tag e usuário.

`DELETE /UserTags/tag/{tagId}/user/{userId}`: Remove uma relação entre tag e usuário existente.

`GET /UserTags/user/{userId}`: Retorna todas as relações entre tag e usuário de um usuário específico.

`GET /UserTags/tag/{tagId}`: Retorna todas as relações entre tag e usuário de uma tag específica.

<hr>

### Autenticação

`POST /Auth/login`: Realiza o login de um usuário.

<hr>

### Usuários

 `GET /User/{id}`: Retorna um usuário por Id.
 
 `GET User/role/{role}`: Retorna usuários por seu cargo (role).
 
 `GET /User/{id}/redefine`: Retorna uma nova senha gerada.
 
 `POST /User`: Cria um usuário.
 
 `DELETE /User/{id}`: Deleta um usuário.
 
 `PUT /User/{id}`: Atualiza um usuário.
 
<hr>

### Emails

`POST /Email/send/{email}`: Envia um email de confirmação.


`GET /Email/token/{token}`: Encontra um token.

`PUT /Email/token/{token}/confirm`: Confirma o email de um usuário.

<hr>

### Tags

`GET /Tags`: Retorna todas as tags disponíveis.

`GET /Tags/{id}`: Retorna uma tag específica pelo ID.

`POST /Tags`: Cria uma nova tag (restrito a usuários com função "Company").

`PUT /Tags/{id}`: Atualiza uma tag existente (restrito a usuários com função "Company").

`DELETE /Tags/{id}`: Exclui uma tag existente (restrito a usuários com função "Company" ou "Admin").

<hr> 

### Sessões 

`GET /api/sessions/{id}`: Retorna uma sessão específica pelo ID.

`POST /api/sessions`: Cria uma nova sessão.

`PUT /api/sessions/{id}`: Atualiza uma sessão existente.

`DELETE /api/sessions/{id}`: Exclui uma sessão existente.

`GET /api/sessions/byEvent/{eventId}`: Retorna todas as sessões por ID de evento.

`GET /api/sessions/{id}/availableCapacity`: Retorna a capacidade disponível de uma sessão.

<hr>

### Notificações

`GET /Notifications/{id}`: Retorna uma notificação específica pelo ID.

`POST /Notifications`: Cria uma nova notificação (restrito a usuários com função "Company").

`PUT /Notifications/{id}`: Atualiza uma notificação existente (restrito a usuários com função "Company").

`DELETE /Notifications/{id}`: Exclui uma notificação existente (restrito a usuários com função "Company").

`GET /Notifications/event/{idEvent}`: Retorna todas as notificações por ID de evento.

`GET /Notifications/user/{idUser}`: Retorna notificações de um usuário específico (restrito ao usuário autenticado).

`GET /Notifications/user/{idUser}/new`: Retorna notificações não lidas de um usuário específico (restrito ao usuário autenticado).

`GET /Notifications/types`: Retorna todos os tipos de notificações.

`GET /Notifications/recipients`: Retorna todos os destinatários de notificações.

<hr>

### Localizações

`GET /Locations/{id}`: Retorna uma localização específica pelo ID.

`POST /Locations`: Cria uma nova localização (restrito a usuários com função "Company").

`PUT /Locations/{id}`: Atualiza uma localização existente (restrito a usuários com função "Company").

`DELETE /Locations/{id}`: Exclui uma localização existente (restrito a usuários com função "Company").

`GET /Locations/ZipCode/{ZipCode}`: Retorna uma localização específica por CEP.

<hr>

### Palestras

`GET /api/lectures/{id}`: Retorna uma palestra específica pelo ID.

`POST /api/lectures`: Cria uma nova palestra.

`PUT /api/lectures/{id}`: Atualiza uma palestra existente.

`DELETE /api/lectures/{id}`: Exclui uma palestra existente.

`GET /api/lectures/bySession/{sessionId}`: Retorna todas as palestras por ID de sessão.

`GET /api/lectures/byEvent/{eventId}`: Retorna todas as palestras por ID de evento.

<hr>

### Feedbacks 

`GET /Feedbacks/{id}`: Retorna um feedback específico pelo ID.

`POST /Feedbacks`: Cria um novo feedback.

`PUT /Feedbacks/{id}`: Atualiza um feedback existente.

`DELETE /Feedbacks/{id}`: Exclui um feedback existente.

`GET /Feedbacks/user/{userId}`: Retorna feedbacks por ID de usuário.

`GET /Feedbacks/notification/{notificationId}`: Retorna feedbacks por ID de notificação.

<hr>

### Participações 

`GET /Attendances/{id}`: Retorna uma inscrição específica pelo ID.

`POST /Attendances`: Cria uma nova inscrição.

`PUT /Attendances/{id}`: Atualiza o status de uma inscrição existente.

`DELETE /Attendances/{id}`: Exclui uma inscrição existente.

`GET /Attendances/user/{userId}`: Retorna inscrições por ID de usuário.

`GET /Attendances/eventday/{eventDayId}`: Retorna inscrições por ID de dia de evento.

`GET /Attendances/totalconfirmed/{eventId}`: Retorna o total de inscrições confirmadas por ID de evento.

</div>

</div>
