describe('Teste de Ponta a Ponta', ()=>{


    beforeEach(( ) => {
        cy.visit('http://localhost:3000');
    })

    it('Deve logar, inserir a imagem OCR retornando o valor correto da mesma, cadastrar e excluir equipamento', ()=> {
        cy.get('.cabecalhoPrincipal-nav-login').should('exist')
        cy.get('.cabecalhoPrincipal-nav-login').click()
        cy.get('.input__login').first().type('saulo@gmail.com')
        cy.get('.input__login').last().type('Teste12345')

        cy.get('#btn__login').click()

        cy.get('input[type=file]').first().selectFile('src/assets/testes/equipamento.jpeg')

        cy.wait(3000)
        cy.get('#codigoPatrimonio').should('have.value', '1202459')

        cy.get('#nomePatrimonio').first().type('Produto Teste')

        cy.get('input[type=file]').last().selectFile('src/assets/testes/notebook.jpg')

        cy.get('.btn__cadastro').click()

        cy.wait(5000)
        cy.get('.excluir').last().click()


    })

})