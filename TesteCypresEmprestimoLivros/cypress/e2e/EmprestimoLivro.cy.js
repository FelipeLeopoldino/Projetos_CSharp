let recebedor = "TesteCypress";
let fornecedor = "Cypress";
let livro = "Teste automatizados com o Cypress";

let recebedorEdicao = "Teste Cypress Edição";
let fornecedorEdicao = "Cypress edição";
let livroEdicao = "Teste automatizados com o Cypress edição";

describe("Entrar no site e cadastrar um empréstimo", () => {
  it("Cadastrar um emprestimo", () => {
    cy.entrarENavegarParaCriarEmprestimo();
    cy.cadastrarEmprestimo(recebedor, fornecedor, livro);
    cy.get("div").contains("Cadastro realizado com sucesso!");
    cy.screenshot("Cadastra efetuado com sucesso");
  });
});

describe("Editar um empréstimo", () => {
  it("Editar um emprestimo", () => {
    cy.entrarENavegarParaCriarEmprestimo();

    cy.get("th")
      .last()
      .contains(recebedor)
      .parent()
      .find("a:contains('Editar')")
      .should("be.visible")
      .click();

    cy.editarEmprestimo(recebedorEdicao, fornecedorEdicao, livroEdicao);
    cy.get("div").contains("Edição realizada com sucesso!");
    cy.screenshot("Edição efetuada com sucesso");
  });
});

describe("Excluir um empréstimo", () => {
  it("Excluir um emprestimo", () => {
    cy.entrarENavegarParaCriarEmprestimo();

    cy.get("th")
      .contains(recebedorEdicao)
      .parent()
      .find("a:contains('Excluir')")
      .should("be.visible")
      .click();

    cy.deletarEmprestimo(recebedorEdicao, fornecedorEdicao, livroEdicao);
    cy.get("div").contains("Remoção realizado com sucesso!");
    cy.screenshot("Exclusão efetuada com sucesso");
  });
});
