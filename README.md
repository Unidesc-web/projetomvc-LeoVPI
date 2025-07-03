Trabalho - Princípios SOLID (ISP e DIP)

cd AluguelCarros
http://localhost:5147/


1) Princípio da Segregação de Interfaces (ISP)
O Princípio da Segregação de Interfaces (ISP) estabelece que uma classe não deve ser forçada a depender de métodos que não utiliza. Esse princípio ajuda a evitar o 'code smell' conhecido como 'Interface Inflada', que ocorre quando uma interface possui métodos demais, obrigando classes a implementarem funcionalidades desnecessárias.

Por exemplo, em vez de uma interface grande com vários métodos, podemos dividi-la em interfaces menores e mais específicas, fazendo com que as classes implementem apenas os métodos que realmente utilizam.

Exemplo:

abstract class Salario {
    void calcularSalario();
}

abstract class Comissao {
    void calcularComissao();
}

abstract class Presenca {
    void marcarPresenca();
}

class Vendedor implements Salario, Comissao, Presenca { ... }
class Gerente implements Salario, Presenca { ... }
2) Princípio da Inversão de Dependências (DIP)
O Princípio da Inversão de Dependências (DIP) afirma que módulos de alto nível não devem depender de módulos de baixo nível. Ambos devem depender de abstrações. Isso significa que devemos programar voltados para interfaces e não diretamente para implementações concretas.

Esse princípio contribui para um sistema mais flexível e fácil de testar, pois permite substituir facilmente implementações e utilizar mocks em testes.

Exemplo:

abstract class ServicoNotificacao {
    void enviar(String mensagem);
}

class EmailService implements ServicoNotificacao {
    void enviar(String mensagem) {
        print("Enviando email: $mensagem");
    }
}

class Notificador {
    final ServicoNotificacao servico;

    Notificador(this.servico);

    void notificar(String mensagem) {
        servico.enviar(mensagem);
    }
}
3) Refatoração - ISP (Funcionario)
O código original força todas as classes a implementarem o método calcularComissao, mesmo que nem todas usem esse método.

Refatoração:

abstract class Funcionario {
    void calcularSalario();
    void marcarPresenca();
}

abstract class Comissionado {
    void calcularComissao();
}

class Vendedor implements Funcionario, Comissionado { ... }
class Gerente implements Funcionario { ... }
4) Refatoração - DIP (Notificador)
O código original viola o DIP pois a classe Notificador depende diretamente da classe concreta EmailService.

Refatoração:

abstract class ServicoNotificacao {
    void enviar(String mensagem);
}

class EmailService implements ServicoNotificacao {
    void enviar(String mensagem) {
        print("Enviando email: $mensagem");
    }
}

class Notificador {
    final ServicoNotificacao servico;

    Notificador(this.servico);

    void notificar(String mensagem) {
        servico.enviar(mensagem);
    }
}
5) Refatoração - ISP e DIP (Dispositivo)
O código original viola o ISP porque obriga a classe Computador a implementar o método enviarMensagem, que ela não usa. Também viola o DIP pois o controlador depende diretamente de uma implementação concreta.

Refatoração:

abstract class DispositivoBasico {
    void ligar();
    void desligar();
}

abstract class Conectavel {
    void conectarWiFi();
}

abstract class Comunicavel {
    void enviarMensagem(String mensagem);
}

class Computador implements DispositivoBasico, Conectavel { ... }

class ControladorDeDispositivos {
    final DispositivoBasico dispositivo;

    ControladorDeDispositivos(this.dispositivo);

    void iniciarDispositivo() {
        dispositivo.ligar();
    }
}
