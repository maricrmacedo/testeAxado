# testeAxado

Ao iniciar o projeto, será criado automaticamente o Data Connection ExerciciosContext contendo as tabelas para utilização da aplicação. Se as tabelas não forem criadas automaticamente, os scripts estão no arquivo Scripts.sql.

Os scripts podem ser executados no próprio Visual Studio.
Separei a aplicação em 2 projetos. Um contendo toda a parte de Entidades e Mapeamento das tabelas. E o outro projeto contendo a parte da Apresentação do sistema(Views, Models e etc).

Funcionamento da Aplicação:

Ao iniciar, o usuário será redirecionado para a tela de login, obrigatoriamente deve estar logado para acessar a aplicação. Após o login, a tela inicial exibirá as avaliações já realizadas pelo usuário e uma opção para cadasrtrar Avaliação. No menu estarão as opções de Transportadoras e Classificação, cada uma contendo seus respectivos CRUDs. Conforme solicitado, o usuário só pode avaliar cada Tranportadora uma única vez.

Obs: Se por algum motivo a Aplicação TesteAxado não encontrar os arquivos referentes ao BancoDados, é só adicionar a referência novamente.
