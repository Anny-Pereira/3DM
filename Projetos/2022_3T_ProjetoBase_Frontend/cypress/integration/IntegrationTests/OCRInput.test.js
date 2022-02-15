describe('Integração - OCR', ()=>{

    beforeEach(( ) => {
        cy.visit('http://localhost:3000');
    })

    it('Deve logar e inserir a imagem OCR retornando o valor correto da mesma', ()=> {
        cy.get('.cabecalhoPrincipal-nav-login').should('exist')
        cy.get('.cabecalhoPrincipal-nav-login').click()
        cy.get('.input__login').first().type('saulo@gmail.com')
        cy.get('.input__login').last().type('Teste12345')

        cy.get('#btn__login').click()

        cy.get('input[type=file]').first().selectFile('src/assets/testes/equipamento.jpeg')

        cy.wait(3000)
        cy.get('#codigoPatrimonio').should('have.value', '1202459')

    })

})