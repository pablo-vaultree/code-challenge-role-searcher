### Solução
Para desenlvover a solução comecei com uma breve analise do desafio buscando os 
dominíos envolvidos e funcionalidades necessários. Realizei a seguinte analise:

- Um app que irá fazer leitura de um csv realizando parse de grupos para usuários e permissões de grupos;
- Usuário irá possuir email e a quais grupos pertence;
- O grupo será composto por um tipo e a qual condominío pertence e também com quais permissões é composto;
- Toda permissão é composta por uma chave-valor com funcionalidade e tipo de permissão;
- O programa deve poder buscar um usuário, retornar suas permissões por condominio e por priordade de tipo de permissão

Para desenvolver a solução serão utilizadas as seguintes tecnologias:

- .net core 2.2
- CsvHelper lib
- nunit
- TDD

### code-challenge-role-searcher

O aplicativo TownSq provê diversas funcionalidades ( Reservas, Entregas, etc) aos 
moradores, síndicos e funcionários de condomínios. 
Existem vários tipos de usuários, que são diferenciados pelas permissões ( Escrita, 
Leitura ou Nenhuma) que têm para realizar ações dentro do aplicativo. 
Por exemplo, moradores podem realizar reservas dos salões de festa 
(funcionalidade Reservas), mas não podem adicionar ou remover outros usuários 
(funcionalidade Usuarios)​. Usuários síndicos, entretanto, podem criar novos usuários para 
cadastrar novos moradores. Já os usuários que são porteiros, não podem realizar reservas, 
mas podem registrar entregas (funcionalidade Entregas)​e notificar moradores para a 
retirada. Essas diferentes permissões estão modeladas por Grupos. Todo usuário está em um 
ou mais Grupos.​Cada Grupo​é definido por um tipo​(Morador, Sindico,​ou Porteiro), e tem um 
conjunto de permissões em cada funcionalidade (pares Funcionalidade​x Permissao)​. 

Ex.: grupos do usuario 1 

- Grupo 1: 
tipo: Morador 
idCondominio: 1 
permissoes: [ (Reservas, Escrita), (Entregas, Nenhuma), (Usuarios, Leitura) ] 

Ex.: grupos do usuario 2 

- Grupo 1: 
tipo: Morador 
idCondominio: 1 
permissoes: [ (Reservas, Escrita), (Entregas, Nenhuma), (Usuarios, Leitura) ] 

- Grupo 2: 
tipo: Sindico 
idCondominio: 1 
permissoes: [ (Reservas, Leitura), (Entregas, Nenhuma), (Usuarios, Escrita) ] 

Como no exemplo do usuário 2 acima, um usuário pode ser síndico E morador no 
MESMO condomínio, ao mesmo tempo. Além disso, um usuário pode ser síndico em um 
condomínio, e morador em OUTRO. 

Ex.: grupos do usuario 3 

- Grupo 1: 
tipo: Morador 
idCondominio: 1 
permissoes: [ (Reservas, Escrita), (Entregas, Nenhuma), (Usuarios, Leitura) ] 

- Grupo 2: 
tipo: Sindico 
idCondominio: 1 
permissoes: [ (Reservas, Leitura), (Entregas, Nenhuma), (Usuarios, Escrita) ] 

- Grupo 3: 
tipo: Sindico 
idCondominio: 2 
permissoes: [ (Reservas, Escrita), (Entregas, Leitura), (Usuarios, Escrita) ] 

Queremos desenvolver uma nova funcionalidade, para listar quais as permissões um 
dado usuário tem em cada condomínio que ele está cadastrado. 
Nossa base de dados é um arquivo texto, onde as linhas contem dados de usuários e 
grupos. Cada campo é separado por ";". O primeiro campo de cada linha indica o tipo do 
registro (se é um Usuario ou um Grupo). 

<TipoRegistro>;... 

Caso o registro seja de usuário, o segundo campo é o email, e o terceiro uma lista de 
pares (TipoGrupo,​IdCondominio). 

Usuario;<email>;[(<TipoGrupo>,<IdCondominio>),...] 

Caso o registro seja de grupo, o segundo campo é o TipoGrupo,​o terceiro é o 
IdCondominio, e o quarto é uma lista de pares ( Funcionalidade,​Permissao)​. 

Grupo;<TipoGrupo>;<IdCondominio>;[(<Funcionalidade>,<Permissao>),...] 

Ex.: base de usuários 
Usuario;rodrigo.soares@gmail.com;[(Morador,1)] 
Usuario;maria.silva.sindica@gmail.com;[(Morador,1),(Sindico,1)] 
Usuario;joao.costa@gmail.com;[(Morador,1),(Sindico,1),(Sindico,2)] 
Grupo;Morador;1;[(Reservas,Escrita),(Entregas,Nenhuma),(Usuarios,Leitura)] 
Grupo;Sindico;1;[(Reservas,Leitura),(Entregas,Nenhuma),(Usuarios,Escrita)] 
Grupo;Sindico;2;[(Reservas,Escrita),(Entregas,Leitura),(Usuarios,Escrita)] 

A sua tarefa é escrever um função que recebe como entrada um endereço de email, 
realiza a busca na base de dados, e retorna a lista de permissões mais altas que ele tem em 
cada condomínio (considerando Escrita​> Leitura​> Nenhuma), conforme o exemplo abaixo: 
Formato de cada linha do output esperado: 

<IdCondominio>;[(<Funcionalidade>,<Permissao>),...] 

Ex. input: 
joao.costa@gmail.com 

Output esperado: 

1;[(Reservas,Escrita),(Entregas,Nenhuma),(Usuarios,Escrita)] 
2;[(Reservas,Escrita),(Entregas,Leitura),(Usuarios,Escrita)] 

Você tem a liberdade de escrever a solução em qualquer linguagem de programação, 
e usar quaisquer bibliotecas, frameworks ou ferramentas que julgar necessário. O único 
requisito é obedecer o formato dos dados de entrada e saída. 
Ao final, nos envie o código fonte da solução, com instruções de como executar. 


