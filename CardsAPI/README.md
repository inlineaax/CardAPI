# CardsAPI
API para geração de cards

Recentemente, tenho estudado muito Front-End com JavaScript e Back-End com JAVA, então o meu primeiro desafio foi entender como poderia construir uma API em .Net utilizando linguagem c#, já que eu não possuia o conhecimento necessário. Comecei lendo os materiais de referência passados no email e também vi alguns vídeos sobre o assunto.
Felizmente, encontrei uma documentação bastante útil com tudo necessário para construir o desafio proposto. 
https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-5.0&tabs=visual-studio

A primeira parte seria estruturar a base da aplicação, pra isso utilizei uma template de API dentro da IDE visual studio.
A template me fornece os arquivos básicos para o funcionamento de uma API e até uma controller, que é onde eu posso colocar meus endpoints.

Com a API rodando, comecei alterando a controller para dar lugar aos dois endpoints que utilizaria para o teste. Optei por um POST para inserir um novo usuário,
e um GET para buscar os cartões do usuário utilizando o email como parâmetro.

Com os endpoints pensados, a primeira coisa seria criar os dois objetos: Card e Users. Coloquei esses objetos em uma pasta separada para melhor organização do projeto,
penso que em larga escala esse tipo de esquematização seja importante para uma boa API. Defini os objetos com parâmetros simples que atendessem os requisitos, com o curto prazo
não precisava me complicar.

Com os objetos e a controller construidas, precisava entender então um pouco do EntityFramework, acredito que foi a parte mais complicada,
foi o meu primeiro contato com esse tipo de ferramenta. Achei que precisaria conectar a algum banco e até quebrei a cabeça um pouco,
mas descobri que poderia optar por usar um contexto temporário/local com a bibilioteca adicional do framework chamada InMemory.
Precisei criar um contexto utilizando a classe do entity que permitiria minha aplicação conectar ao banco fictício e manipular os objetos.
Na definição eu também precisei definir minhas classes como tabelas, dessa forma poderia acessa-las utilizando o entity.

Comecei pelo POST que insere um novo cartão na base associado a um usuário. O método recebe no body o objeto inteiro onde posso utilizar pra passar somente o email.
No serviço, tento buscar um usuário pelo email, caso ele não exista vou cria-lo e inserir na base. Se caso já exista, apenas adiciona na base um novo cartão.
Acho que a maior regra aqui fica por conta da geração do número. Primeiro, tentei utilizar o objeto Random gerando um número de 16 digitos mas isso excede o tamanho da variável.
Optei então por gerar 4 blocos de 4 números e associar a uma string. Também coloquei um campo created pra servir como orientação na hora da ordenação,
na hora que eu gero o número do cartão, aproveito e insiro a timestamp de criação.

Com a inserção criada, eu poderia então implementar o GET para retornar os cartõres referente a um usuário. Recebendo o email por parâmetro,
eu realizo uma busca na base com um WHERE para o EMAIL e um ORDERBY no campo CREATED para ordenar. Quando estava retornando fazendo a busca dos cartões que percebi
que era o caso de uma chave estrangeira e o objeto Users poderia carregar uma lista de CARDS se os CARDS tivessem o USERID. Aqui tive meu maior problema com a busca
porque o serviço passou a retornar erro de dependência circular. Depois de algumas buscas o JSON Ignore resolveu o problema.

Depois de alguns ajustes, os endpoints pareciam corretos, utilizei a aplicação POSTMAN que facilitou meus testes e ajudou a acessar os serviços.

O desafio foi excelente para entender como é a construção de uma API no .Net que parece ser um framework bastante sólido. A princípio, quando vi o desafio,
eu achei que não iria conseguir por conta da nova linguagem e pela pouca experiência com API's. Mas estudei bastante, li e reli a documentação que achei, virei noites
para estudar e consegui esse resultado! Isso é muito motivador! Com certeza irei procurar novos desafios todos os dias!
Terminei um bootcamp a pouco tempo pelo IGTI onde tive ótimas aulas de Java, consegui aproveitar bastante o conteúdo, isso me ajudou muito a entender 
mais rapidamente a linguagem c#. Tive a agradável surpresa de conhecer o POSTMAN e ainda o primeiro contato com o EntityFramework que parece facilitar
bastante as interações com o banco de dados. 
Tentei implementar ainda o Swagger como sugeria na documentação que achei, mas sem sucesso. Irei ler mais sobre para poder aplicar futuramente!
