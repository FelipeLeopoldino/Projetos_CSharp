// ***********************************************
// This example commands.js shows you how to
// create various custom commands and overwrite
// existing commands.
//
// For more comprehensive examples of custom
// commands please read more here:
// https://on.cypress.io/custom-commands
// ***********************************************
//
//
// -- This is a parent command --
// Cypress.Commands.add('login', (email, password) => { ... })
//
//
// -- This is a child command --
// Cypress.Commands.add('drag', { prevSubject: 'element'}, (subject, options) => { ... })
//
//
// -- This is a dual command --
// Cypress.Commands.add('dismiss', { prevSubject: 'optional'}, (subject, options) => { ... })
//
//
// -- This will overwrite an existing command --
// Cypress.Commands.overwrite('visit', (originalFn, url, options) => { ... })

// cypress/support/commands.js

Cypress.Commands.add("entrarENavegarParaCriarEmprestimo", () => {
  cy.visit("/");

  cy.get("li").contains("Empréstimos").should("be.visible").click();
});

Cypress.Commands.add("cadastrarEmprestimo", (recebedor, fornecedor, livro) => {
  cy.get("a").contains("Cadastrar novo empréstimo").click();

  cy.get("#Recebedor").type(recebedor);
  cy.get("#Fornecedor").type(fornecedor);
  cy.get("#Livro").type(livro);
  cy.get('button[type="submit"]')
    .contains("Adicionar")
    .should("be.visible")
    .click({ force: true });
});

Cypress.Commands.add(
  "editarEmprestimo",
  (recebedorEdicao, fornecedorEdicao, livroEdicao) => {
    cy.get("#Recebedor").clear();
    cy.get("#Fornecedor").clear();
    cy.get("#Livro").clear();

    cy.get("#Recebedor").type(recebedorEdicao);
    cy.get("#Fornecedor").type(fornecedorEdicao);
    cy.get("#Livro").type(livroEdicao);

    cy.get('button[type="submit"]')
      .contains("Editar")
      .should("be.visible")
      .click({ force: true });
  }
);

Cypress.Commands.add(
  "deletarEmprestimo",
  (recebedorEdicao, fornecedorEdicao, livroEdicao) => {
    cy.get("#Recebedor").should("have.value", recebedorEdicao);
    cy.get("#Fornecedor").should("have.value", fornecedorEdicao);
    cy.get("#Livro").should("have.value", livroEdicao);

    cy.get('button[type="submit"]')
      .contains("Excluir")
      .should("be.visible")
      .click({ force: true });
  }
);
