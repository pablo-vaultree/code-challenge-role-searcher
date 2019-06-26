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

### Como rodar

1. Instale .net core 2.2
2. Clone o repositório com `git clone --depth=1 https://github.com/pablofeijo/code-challenge-role-searcher`
3. `cd code-challenge-role-searcher`
4. Configure o path para o arquivo que deseja processar e o de destino, por default envia para a pata bin
4. `dotnet run`
5. Informe o email que deseja realizar o processamento
6. Veja o arquivo